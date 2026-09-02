using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Plot.Flow;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;

// Token: 0x02002557 RID: 9559
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PhoneMsgModel : ModelBase<PhoneMsgModel>
{
	// Token: 0x1700178C RID: 6028
	// (get) Token: 0x06012986 RID: 76166 RVA: 0x0051F27A File Offset: 0x0051D47A
	public bool IsUsingDefaultChatBg
	{
		get
		{
			return this.IsDefaultChatBg(this.CurrentUsingChatBgId);
		}
	}

	// Token: 0x1700178D RID: 6029
	// (get) Token: 0x06012987 RID: 76167 RVA: 0x0051F288 File Offset: 0x0051D488
	public HashSet<int> SelectedFilterIdSet
	{
		get
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (HashSet<int> hashSet2 in this.SelectedFilterSetDict.Values)
			{
				foreach (int item in hashSet2)
				{
					hashSet.Add(item);
				}
			}
			return hashSet;
		}
	}

	// Token: 0x06012988 RID: 76168 RVA: 0x0051F31C File Offset: 0x0051D51C
	public void InitFilterSets()
	{
		this.AllFilterTypeSetDict.Clear();
		this.SelectedFilterSetDict.Clear();
		IEnumerable<ChatFilterType> allChatFilterTypeConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatFilterTypeConfigList();
		IEnumerable<ChatPartnerFilter> allChatPartnerFilterConfigList = ConfigBase<PhoneMsgConfig>.Instance.GetAllChatPartnerFilterConfigList();
		if (allChatFilterTypeConfigList == null || allChatPartnerFilterConfigList == null)
		{
			return;
		}
		foreach (ChatFilterType chatFilterType in allChatFilterTypeConfigList)
		{
			this.AllFilterTypeSetDict[chatFilterType.Id] = new HashSet<int>();
			this.SelectedFilterSetDict[chatFilterType.Id] = new HashSet<int>();
		}
		foreach (ChatPartnerFilter chatPartnerFilter in allChatPartnerFilterConfigList)
		{
			foreach (int num in this.AllFilterTypeSetDict.Keys)
			{
				if (chatPartnerFilter.Type == num)
				{
					this.AllFilterTypeSetDict[num].Add(chatPartnerFilter.Id);
					break;
				}
			}
		}
	}

	// Token: 0x06012989 RID: 76169 RVA: 0x0051F460 File Offset: 0x0051D660
	public void SetSelectedFilterIdSet(HashSet<int> filterIds)
	{
		foreach (HashSet<int> hashSet in this.SelectedFilterSetDict.Values)
		{
			hashSet.Clear();
		}
		foreach (int item in filterIds)
		{
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.AllFilterTypeSetDict)
			{
				if (keyValuePair.Value.Contains(item))
				{
					this.SelectedFilterSetDict[keyValuePair.Key].Add(item);
					break;
				}
			}
		}
		this.SelectedFilterIdSet_Internal.Clear();
		foreach (int item2 in filterIds)
		{
			this.SelectedFilterIdSet_Internal.Add(item2);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhoneMsgFilterChanged);
	}

	// Token: 0x0601298A RID: 76170 RVA: 0x0051F5B4 File Offset: 0x0051D7B4
	public void ClearSelectedFilterIdSet()
	{
		foreach (HashSet<int> hashSet in this.SelectedFilterSetDict.Values)
		{
			hashSet.Clear();
		}
		this.SelectedFilterIdSet_Internal.Clear();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnPhoneMsgFilterChanged);
	}

	// Token: 0x0601298B RID: 76171 RVA: 0x0051F624 File Offset: 0x0051D824
	private int GetContentFilterId(EChatMsgType chatMsgType)
	{
		if (chatMsgType == EChatMsgType.Task)
		{
			return 3001;
		}
		if (chatMsgType != EChatMsgType.Reward)
		{
			return 3003;
		}
		return 3002;
	}

	// Token: 0x0601298C RID: 76172 RVA: 0x0051F644 File Offset: 0x0051D844
	private bool IsIdPassFilter(int id)
	{
		int num = -1;
		if (this.AllFilterTypeSetDict.Count == 0 || this.SelectedFilterSetDict.Count == 0)
		{
			this.InitFilterSets();
		}
		foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.AllFilterTypeSetDict)
		{
			if (keyValuePair.Value.Contains(id))
			{
				num = keyValuePair.Key;
				break;
			}
		}
		HashSet<int> hashSet;
		return num != -1 && (!this.SelectedFilterSetDict.TryGetValue(num, out hashSet) || hashSet.Count == 0 || hashSet.Contains(id));
	}

	// Token: 0x0601298D RID: 76173 RVA: 0x0051F6F4 File Offset: 0x0051D8F4
	public bool IsThisMessageCanShow(int shortMsgId)
	{
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(shortMsgId);
		if (phoneMsgConfig == null)
		{
			return false;
		}
		int contentFilterId = this.GetContentFilterId((EChatMsgType)phoneMsgConfig.Value.FinallPopType);
		return this.IsIdPassFilter(contentFilterId);
	}

	// Token: 0x0601298E RID: 76174 RVA: 0x0051F738 File Offset: 0x0051D938
	public bool IsThisChatPartnerCanShow(int chatPartnerId)
	{
		ChatPartner? chatPartnerConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatPartnerConfig(chatPartnerId);
		if (chatPartnerConfig == null)
		{
			return false;
		}
		List<PhoneMsgShortMsgData> allPhoneMsgShortMsgDataByChatPartnerId = this.GetAllPhoneMsgShortMsgDataByChatPartnerId(chatPartnerId);
		if (allPhoneMsgShortMsgDataByChatPartnerId == null)
		{
			return false;
		}
		bool flag = false;
		int count = allPhoneMsgShortMsgDataByChatPartnerId.Count;
		for (int i = 0; i < count; i++)
		{
			PhoneMsgShortMsgData phoneMsgShortMsgData = allPhoneMsgShortMsgDataByChatPartnerId[i];
			if (this.IsThisMessageCanShow(phoneMsgShortMsgData.ShortMsgId))
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		int id = chatPartnerConfig.Value.IsGroupChat ? 1003 : chatPartnerConfig.Value.TypeFilter;
		bool flag2 = this.IsIdPassFilter(id);
		bool flag3 = false;
		if (chatPartnerConfig.Value.RegionFilterListLength > 0)
		{
			for (int j = 0; j < chatPartnerConfig.Value.RegionFilterListLength; j++)
			{
				if (this.IsIdPassFilter(chatPartnerConfig.Value.RegionFilterList(j)))
				{
					flag3 = true;
					break;
				}
			}
		}
		return flag2 && flag3;
	}

	// Token: 0x0601298F RID: 76175 RVA: 0x0051F834 File Offset: 0x0051DA34
	protected override bool OnInit()
	{
		IReadOnlyList<PhoneTipShowList> configList = ConfigPhoneTipShowListAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (PhoneTipShowList phoneTipShowList in configList)
			{
				this.NormalDungeonSet.Add((EDungeonSubType)phoneTipShowList.DungeonSubType);
			}
		}
		IReadOnlyList<PhoneInputTime> configList2 = ConfigPhoneInputTimeAll.GetConfigList(true);
		if (configList2 != null)
		{
			foreach (PhoneInputTime config in configList2)
			{
				PhoneMsgInputTimeData item = new PhoneMsgInputTimeData(config);
				this.MsgInputTimeList.Add(item);
			}
		}
		this.InitFilterSets();
		return true;
	}

	// Token: 0x06012990 RID: 76176 RVA: 0x0051F8EC File Offset: 0x0051DAEC
	public void InitChatShow(int dialogId, int bgId, List<int> unLockDialogIds, List<int> unLockBgIds)
	{
		this.CurrentUsingChatDialogId = dialogId;
		this.CurrentUsingChatBgId = bgId;
		this.SetUnLockChatDialogIds(unLockDialogIds);
		this.SetUnLockChatBgIds(unLockBgIds);
		this.IsPhoneChatShowInitDone = true;
		this.InitServerRedDotSetAndLocalRedDotCache();
	}

	// Token: 0x06012991 RID: 76177 RVA: 0x0051F918 File Offset: 0x0051DB18
	public void InitServerRedDotSetAndLocalRedDotCache()
	{
		this.ServerRedDotSet = (ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.PhoneMsgChatShowRedDot) as ServerStorageSet);
		this.LocalRedDotCache = new Dictionary<EPhoneMsgServerRedDotType, HashSet<int>>();
		foreach (int num in this.ServerRedDotSet.GetContainer())
		{
			int num2 = num % 10;
			int num3 = num / 10;
			EPhoneMsgServerRedDotType ephoneMsgServerRedDotType = (EPhoneMsgServerRedDotType)num2;
			if (!this.LocalRedDotCache.ContainsKey(ephoneMsgServerRedDotType))
			{
				this.LocalRedDotCache[ephoneMsgServerRedDotType] = new HashSet<int>();
			}
			this.LocalRedDotCache[ephoneMsgServerRedDotType].Add(num3);
			if (ephoneMsgServerRedDotType == EPhoneMsgServerRedDotType.Preview)
			{
				this.LastOpenBigPanelTime = num3;
			}
		}
		this.CleanInvalidChatShowRedDot();
	}

	// Token: 0x06012992 RID: 76178 RVA: 0x0051F9D8 File Offset: 0x0051DBD8
	private void CleanInvalidChatShowRedDot()
	{
		HashSet<int> hashSet;
		if (this.LocalRedDotCache == null || !this.LocalRedDotCache.TryGetValue(EPhoneMsgServerRedDotType.Decoration, out hashSet))
		{
			return;
		}
		List<int> list = new List<int>();
		foreach (int item in hashSet)
		{
			if (!this.UnlockedDialogIds.Contains(item) && !this.UnlockedBgIds.Contains(item))
			{
				list.Add(item);
			}
		}
		foreach (int id in list)
		{
			this.RemovePhoneMsgRedDot(EPhoneMsgServerRedDotType.Decoration, id);
		}
	}

	// Token: 0x06012993 RID: 76179 RVA: 0x0051FAA8 File Offset: 0x0051DCA8
	private int EncodePhoneMsgRedDot(EPhoneMsgServerRedDotType type, int id)
	{
		return (int)(id * 10 + type);
	}

	// Token: 0x06012994 RID: 76180 RVA: 0x0051FAB0 File Offset: 0x0051DCB0
	private void AddPhoneMsgRedDot(EPhoneMsgServerRedDotType type, int id)
	{
		if (this.LocalRedDotCache == null)
		{
			this.LocalRedDotCache = new Dictionary<EPhoneMsgServerRedDotType, HashSet<int>>();
		}
		if (!this.LocalRedDotCache.ContainsKey(type))
		{
			this.LocalRedDotCache[type] = new HashSet<int>();
		}
		this.LocalRedDotCache[type].Add(id);
		int value = this.EncodePhoneMsgRedDot(type, id);
		ServerStorageSet serverRedDotSet = this.ServerRedDotSet;
		if (serverRedDotSet == null)
		{
			return;
		}
		serverRedDotSet.Add(value);
	}

	// Token: 0x06012995 RID: 76181 RVA: 0x0051FB1C File Offset: 0x0051DD1C
	private void RemovePhoneMsgRedDot(EPhoneMsgServerRedDotType type, int id)
	{
		if (this.LocalRedDotCache == null)
		{
			return;
		}
		HashSet<int> hashSet;
		if (this.LocalRedDotCache.TryGetValue(type, out hashSet))
		{
			hashSet.Remove(id);
		}
		int value = this.EncodePhoneMsgRedDot(type, id);
		ServerStorageSet serverRedDotSet = this.ServerRedDotSet;
		if (serverRedDotSet == null)
		{
			return;
		}
		serverRedDotSet.Remove(value);
	}

	// Token: 0x06012996 RID: 76182 RVA: 0x0051FB64 File Offset: 0x0051DD64
	public void AddVoiceRedDot(int id)
	{
		this.AddPhoneMsgRedDot(EPhoneMsgServerRedDotType.VoiceOnce, id);
	}

	// Token: 0x06012997 RID: 76183 RVA: 0x0051FB70 File Offset: 0x0051DD70
	public bool TryGetVoiceRedDot(int id)
	{
		HashSet<int> hashSet;
		return this.LocalRedDotCache != null && this.LocalRedDotCache.TryGetValue(EPhoneMsgServerRedDotType.VoiceOnce, out hashSet) && hashSet.Contains(id);
	}

	// Token: 0x06012998 RID: 76184 RVA: 0x0051FBA0 File Offset: 0x0051DDA0
	public bool CheckIsInWhiteList()
	{
		if (ControllerBase<BattleUiControl>.Instance.GetMainViewName() != EUiViewName.BattleView)
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			if (config == null || !this.NormalDungeonSet.Contains((EDungeonSubType)config.Value.InstSubType))
			{
				return false;
			}
			if (config.Value.InstSubType == 12)
			{
				PhoneTipShowList? config2 = ConfigPhoneTipShowListByDungeonSubType.GetConfig(12, true);
				if (config2 == null)
				{
					return false;
				}
				bool flag = false;
				int[] array = config2.Value.WorldDungeonSubTypeList();
				int num = array.Length;
				for (int i = 0; i < num; i++)
				{
					if (array[i] == config.Value.WorldDungeonSubType)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06012999 RID: 76185 RVA: 0x0051FC7C File Offset: 0x0051DE7C
	public void SetUnLockChatDialogIds(List<int> unLockIds)
	{
		foreach (int item in unLockIds)
		{
			this.UnlockedDialogIds.Add(item);
		}
	}

	// Token: 0x0601299A RID: 76186 RVA: 0x0051FCD0 File Offset: 0x0051DED0
	public void SetUnLockChatBgIds(List<int> unLockIds)
	{
		foreach (int item in unLockIds)
		{
			this.UnlockedBgIds.Add(item);
		}
	}

	// Token: 0x0601299B RID: 76187 RVA: 0x0051FD24 File Offset: 0x0051DF24
	public void OnPhoneMsgDialogAndBgAddNotify(ShortMessageItemUpdateNotify message)
	{
		RepeatedField<int> bubbleIds = message.BubbleIds;
		if (bubbleIds != null && bubbleIds.Count > 0)
		{
			this.SetUnLockChatDialogIds(bubbleIds.ToList<int>());
			foreach (int id in bubbleIds)
			{
				this.AddPhoneMsgRedDot(EPhoneMsgServerRedDotType.Decoration, id);
			}
		}
		RepeatedField<int> chatBgIds = message.ChatBgIds;
		if (chatBgIds != null && chatBgIds.Count > 0)
		{
			this.SetUnLockChatBgIds(chatBgIds.ToList<int>());
			foreach (int id2 in chatBgIds)
			{
				this.AddPhoneMsgRedDot(EPhoneMsgServerRedDotType.Decoration, id2);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.PhoneMsgDialogAndBgUpdate);
		Singleton<EventSystem>.Instance.Emit(EEventName.PhoneMsgDialogAndBgRedDotUpdate);
	}

	// Token: 0x0601299C RID: 76188 RVA: 0x0051FE08 File Offset: 0x0051E008
	public bool IsChatDialogUnlocked(int dialogId)
	{
		return this.UnlockedDialogIds.Contains(dialogId);
	}

	// Token: 0x0601299D RID: 76189 RVA: 0x0051FE16 File Offset: 0x0051E016
	public bool IsChatBgUnlocked(int bgId)
	{
		return this.UnlockedBgIds.Contains(bgId);
	}

	// Token: 0x0601299E RID: 76190 RVA: 0x0051FE24 File Offset: 0x0051E024
	public bool IsDefaultChatBg(int id)
	{
		return id == 80820001;
	}

	// Token: 0x0601299F RID: 76191 RVA: 0x0051FE30 File Offset: 0x0051E030
	public void OnPhoneMsgUpdateNotify(ShortMessageUpdateNotify message)
	{
		ChangeReason reason = message.Reason;
		this.AddMessages(message.Adds.ToList<ShortMessageInfo>(), new ChangeReason?(reason), true, true);
		RepeatedField<int> removes = message.Removes;
		int count = removes.Count;
		for (int i = 0; i < count; i++)
		{
			int num = removes[i];
			if (this.Id2ShortMessagesDict.ContainsKey(num))
			{
				this.Id2ShortMessagesDict.Remove(num);
			}
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(num);
			if (phoneMsgConfig != null && this.ChatPartnerId2ShortMessagesIdsDict.ContainsKey(phoneMsgConfig.Value.WhichChat))
			{
				int whichChat = phoneMsgConfig.Value.WhichChat;
				List<int> list = this.ChatPartnerId2ShortMessagesIdsDict[whichChat];
				int num2 = list.IndexOf(num);
				if (num2 != -1)
				{
					list.RemoveAt(num2);
				}
				if (list.Count == 0)
				{
					this.ChatPartnerId2ShortMessagesIdsDict.Remove(whichChat);
					int num3 = this.ChatPartnerIdList.IndexOf(whichChat);
					if (num3 != -1)
					{
						this.ChatPartnerIdList.RemoveAt(num3);
					}
				}
			}
		}
		if (count > 0)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnPhoneHaveMsgToRemove);
		}
	}

	// Token: 0x060129A0 RID: 76192 RVA: 0x0051FF60 File Offset: 0x0051E160
	public void AddMessages(List<ShortMessageInfo> dataList, ChangeReason? reason = null, bool isNeedShowTips = true, bool isNeedSetLatestShortMsgTime = true)
	{
		bool flag = isNeedShowTips;
		long num = 0L;
		int count = dataList.Count;
		for (int i = 0; i < count; i++)
		{
			ShortMessageInfo shortMessageInfo = dataList[i];
			int configId = shortMessageInfo.ConfigId;
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(configId);
			if (phoneMsgConfig != null)
			{
				PhoneMsgShortMsgData phoneMsgShortMsgData = new PhoneMsgShortMsgData(configId);
				this.Id2ShortMessagesDict[configId] = phoneMsgShortMsgData;
				phoneMsgShortMsgData.IsRead = shortMessageInfo.IsRead;
				phoneMsgShortMsgData.IsReceived = shortMessageInfo.IsReceived;
				phoneMsgShortMsgData.LatestProgress = shortMessageInfo.LastConfigId;
				phoneMsgShortMsgData.UnLockTime = shortMessageInfo.UnlockTime;
				MapField<int, int> options = shortMessageInfo.Options;
				int count2 = options.Count;
				foreach (KeyValuePair<int, int> keyValuePair in options)
				{
					phoneMsgShortMsgData.SelectedOptionsDict[keyValuePair.Key] = keyValuePair.Value;
				}
				ShortMessage? phoneMsgConfig2 = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(configId);
				long unLockTime = phoneMsgShortMsgData.UnLockTime;
				if (!phoneMsgShortMsgData.IsRead && phoneMsgConfig2 != null && phoneMsgConfig2.Value.TipType == 1 && unLockTime > num)
				{
					num = unLockTime;
				}
				int whichChat = phoneMsgConfig.Value.WhichChat;
				if (!this.ChatPartnerIdList.Contains(whichChat))
				{
					this.ChatPartnerIdList.Add(whichChat);
				}
				if (this.ChatPartnerId2ShortMessagesIdsDict.ContainsKey(whichChat))
				{
					List<int> list = this.ChatPartnerId2ShortMessagesIdsDict[whichChat];
					if (!list.Contains(configId))
					{
						list.Add(configId);
					}
				}
				else
				{
					this.ChatPartnerId2ShortMessagesIdsDict[whichChat] = new List<int>
					{
						configId
					};
				}
				if (reason != null)
				{
					switch (reason.Value)
					{
					case ChangeReason.None:
						Singleton<global::Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "短信通知原因为Proto_None, 请联系后端", default(ReadOnlySpan<ValueTuple<string, object>>));
						flag = false;
						break;
					case ChangeReason.QuestFix:
						flag = false;
						break;
					case ChangeReason.ActionRevert:
						flag = false;
						break;
					}
				}
				if (flag && phoneMsgConfig.Value.TipType != 0)
				{
					if (phoneMsgConfig.Value.TipType == 1)
					{
						this.CurrentToBeNotifiedMsgInSmallHeadQueue.Add(configId);
					}
					else
					{
						this.CurrentToBeNotifiedMsgArray.Add(configId);
					}
					Singleton<EventSystem>.Instance.Emit(EEventName.OnNewPhoneMsgNeedShowTips);
				}
			}
		}
		if (isNeedSetLatestShortMsgTime)
		{
			this.SetLatestShortMsgTime(num);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPhoneMsgAdd, 0);
		this.SortChatPartnerAndMessages();
	}

	// Token: 0x060129A1 RID: 76193 RVA: 0x005201F8 File Offset: 0x0051E3F8
	public void SortChatPartnerAndMessages()
	{
		this.SortAllMessages();
		this.SortChatPartnerList();
	}

	// Token: 0x060129A2 RID: 76194 RVA: 0x00520208 File Offset: 0x0051E408
	public void SortAllMessages()
	{
		if (this.ChatPartnerId2ShortMessagesIdsDict.Count <= 1)
		{
			return;
		}
		foreach (KeyValuePair<int, List<int>> keyValuePair in this.ChatPartnerId2ShortMessagesIdsDict)
		{
			List<int> value = keyValuePair.Value;
			if (value.Count > 1)
			{
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				Dictionary<int, int> otherMsgIdIndexMap = new Dictionary<int, int>();
				for (int i = 0; i < value.Count; i++)
				{
					int num = value[i];
					PhoneMsgShortMsgData phoneMsgShortMsgData;
					if (!this.Id2ShortMessagesDict.TryGetValue(num, out phoneMsgShortMsgData))
					{
						otherMsgIdIndexMap[num] = list2.Count;
						list2.Add(num);
					}
					else
					{
						ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(num);
						if (phoneMsgShortMsgData != null && phoneMsgConfig != null && phoneMsgConfig.Value.FinallPopType == 6 && !phoneMsgShortMsgData.IsReceived)
						{
							list.Add(num);
						}
						else
						{
							otherMsgIdIndexMap[num] = list2.Count;
							list2.Add(num);
						}
					}
				}
				list2.Sort(delegate(int a, int b)
				{
					PhoneMsgShortMsgData phoneMsgShortMsgData2 = this.Id2ShortMessagesDict[a];
					PhoneMsgShortMsgData phoneMsgShortMsgData3 = this.Id2ShortMessagesDict[b];
					if (!phoneMsgShortMsgData2.IsRead && phoneMsgShortMsgData3.IsRead)
					{
						return -1;
					}
					if (phoneMsgShortMsgData2.IsRead && !phoneMsgShortMsgData3.IsRead)
					{
						return 1;
					}
					long unLockTime = phoneMsgShortMsgData2.UnLockTime;
					long unLockTime2 = phoneMsgShortMsgData3.UnLockTime;
					if (unLockTime == unLockTime2)
					{
						int num2;
						otherMsgIdIndexMap.TryGetValue(a, out num2);
						int num3;
						otherMsgIdIndexMap.TryGetValue(b, out num3);
						if (num2 == num3)
						{
							return 0;
						}
						if (num2 >= num3)
						{
							return 1;
						}
						return -1;
					}
					else
					{
						if (unLockTime >= unLockTime2)
						{
							return -1;
						}
						return 1;
					}
				});
				value.Clear();
				for (int j = 0; j < list.Count; j++)
				{
					value.Add(list[j]);
				}
				for (int k = 0; k < list2.Count; k++)
				{
					value.Add(list2[k]);
				}
			}
		}
	}

	// Token: 0x060129A3 RID: 76195 RVA: 0x005203C8 File Offset: 0x0051E5C8
	public void SortChatPartnerList()
	{
		this.UnreceivedPartnerList = new List<int>();
		this.ReceivedUnreadPartnerList = new List<int>();
		this.ReceivedReadPartnerList = new List<int>();
		for (int i = 0; i < this.ChatPartnerIdList.Count; i++)
		{
			int num = this.ChatPartnerIdList[i];
			if (this.IsSomeOneHasUnReceivedMsg(num))
			{
				this.UnreceivedPartnerList.Add(num);
			}
			else if (this.IsPartnerHasUnreadMsg(num))
			{
				this.ReceivedUnreadPartnerList.Add(num);
			}
			else
			{
				this.ReceivedReadPartnerList.Add(num);
			}
		}
		this.SortReceivedPartnerList();
		this.ChatPartnerIdList = new List<int>();
		for (int j = 0; j < this.UnreceivedPartnerList.Count; j++)
		{
			this.ChatPartnerIdList.Add(this.UnreceivedPartnerList[j]);
		}
		for (int k = 0; k < this.ReceivedUnreadPartnerList.Count; k++)
		{
			this.ChatPartnerIdList.Add(this.ReceivedUnreadPartnerList[k]);
		}
		for (int l = 0; l < this.ReceivedReadPartnerList.Count; l++)
		{
			this.ChatPartnerIdList.Add(this.ReceivedReadPartnerList[l]);
		}
	}

	// Token: 0x060129A4 RID: 76196 RVA: 0x005204F0 File Offset: 0x0051E6F0
	private bool IsPartnerHasUnreadMsg(int chatPartnerId)
	{
		List<PhoneMsgShortMsgData> allPhoneMsgShortMsgDataByChatPartnerId = this.GetAllPhoneMsgShortMsgDataByChatPartnerId(chatPartnerId);
		if (allPhoneMsgShortMsgDataByChatPartnerId == null)
		{
			return false;
		}
		for (int i = 0; i < allPhoneMsgShortMsgDataByChatPartnerId.Count; i++)
		{
			if (!allPhoneMsgShortMsgDataByChatPartnerId[i].IsRead)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060129A5 RID: 76197 RVA: 0x0052052C File Offset: 0x0051E72C
	public void SortReceivedPartnerList()
	{
		if (this.ReceivedUnreadPartnerList != null && this.ReceivedUnreadPartnerList.Count > 0)
		{
			this.ReceivedUnreadPartnerList.Sort((int a, int b) => this.ComparePartnerByUnlockTime(a, b));
		}
		if (this.ReceivedReadPartnerList != null && this.ReceivedReadPartnerList.Count > 0)
		{
			this.ReceivedReadPartnerList.Sort((int a, int b) => this.ComparePartnerByUnlockTime(a, b));
		}
	}

	// Token: 0x060129A6 RID: 76198 RVA: 0x00520594 File Offset: 0x0051E794
	private int ComparePartnerByUnlockTime(int a, int b)
	{
		List<int> list = this.ChatPartnerId2ShortMessagesIdsDict[a];
		List<int> list2 = this.ChatPartnerId2ShortMessagesIdsDict[b];
		PhoneMsgShortMsgData phoneMsgShortMsgData = this.Id2ShortMessagesDict[list[0]];
		PhoneMsgShortMsgData phoneMsgShortMsgData2 = this.Id2ShortMessagesDict[list2[0]];
		long unLockTime = phoneMsgShortMsgData.UnLockTime;
		long unLockTime2 = phoneMsgShortMsgData2.UnLockTime;
		if (unLockTime == unLockTime2)
		{
			if (list[0] >= list2[0])
			{
				return -1;
			}
			return 1;
		}
		else
		{
			if (unLockTime >= unLockTime2)
			{
				return -1;
			}
			return 1;
		}
	}

	// Token: 0x060129A7 RID: 76199 RVA: 0x0052060F File Offset: 0x0051E80F
	public List<int> GetAllChatPartnerIds()
	{
		return this.ChatPartnerIdList;
	}

	// Token: 0x060129A8 RID: 76200 RVA: 0x00520618 File Offset: 0x0051E818
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PhoneMsgShortMsgData> GetAllPhoneMsgShortMsgDataByChatPartnerId(int chatPartnerId)
	{
		if (!this.ChatPartnerIdList.Contains(chatPartnerId))
		{
			return null;
		}
		List<int> list;
		if (!this.ChatPartnerId2ShortMessagesIdsDict.TryGetValue(chatPartnerId, out list))
		{
			return null;
		}
		List<PhoneMsgShortMsgData> list2 = new List<PhoneMsgShortMsgData>();
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			int key = list[i];
			PhoneMsgShortMsgData phoneMsgShortMsgData;
			if (this.Id2ShortMessagesDict.TryGetValue(key, out phoneMsgShortMsgData) && phoneMsgShortMsgData != null)
			{
				list2.Add(phoneMsgShortMsgData);
			}
		}
		return list2;
	}

	// Token: 0x060129A9 RID: 76201 RVA: 0x00520688 File Offset: 0x0051E888
	[NullableContext(2)]
	public PhoneMsgShortMsgData GetPhoneMsgShortMsgDataByShortMsgId(int shortMsgId)
	{
		PhoneMsgShortMsgData result;
		if (this.Id2ShortMessagesDict.TryGetValue(shortMsgId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060129AA RID: 76202 RVA: 0x005206A8 File Offset: 0x0051E8A8
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	public ValueTuple<string, string, string>? GetFirstMsgDataByShortMsgId(int shortMsgId)
	{
		if (this.GetPhoneMsgShortMsgDataByShortMsgId(shortMsgId) == null)
		{
			return null;
		}
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(shortMsgId);
		if (phoneMsgConfig == null)
		{
			return null;
		}
		string[] array = phoneMsgConfig.Value.FlowParam();
		List<ActionInfo> flowStateActions = ConfigBase<FlowConfig>.Instance.GetFlowStateActions(array[0], int.Parse(array[1]), int.Parse(array[2]));
		if (flowStateActions == null)
		{
			return null;
		}
		if (flowStateActions[0] == null)
		{
			return null;
		}
		int count = flowStateActions.Count;
		for (int i = 0; i < count; i++)
		{
			ActionInfo actionInfo = flowStateActions[i];
			if (actionInfo.Name == EAction.ShowTalk)
			{
				List<ITalkItem> talkItems = ((ShowTalk)actionInfo.Params).TalkItems;
				int count2 = talkItems.Count;
				int j = 0;
				while (j < count2)
				{
					ITalkItem talkItem = talkItems[j];
					if (!this.IsSystemTipMessage(talkItem))
					{
						int? whoId = talkItem.WhoId;
						Speaker? speaker = null;
						if (whoId != null)
						{
							speaker = ConfigSpeakerById.GetConfig(whoId.Value, true);
						}
						if (speaker == null)
						{
							return null;
						}
						string item = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(speaker.Value.Id)) ?? "";
						string headIconAsset = ConfigSpeakerById.GetConfig(talkItem.WhoId.Value, true).Value.HeadIconAsset;
						string item2 = "";
						ETalkItemType value = talkItem.Type.Value;
						if (value != ETalkItemType.Talk)
						{
							if (value == ETalkItemType.PhoneMessage)
							{
								ITalkItemPhoneMessage talkItemPhoneMessage = (ITalkItemPhoneMessage)talkItem;
								EPhoneMessageType type = talkItemPhoneMessage.MessageType.Type;
								if (type != EPhoneMessageType.Emoji)
								{
									if (type == EPhoneMessageType.Attachment)
									{
										item2 = (ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Attachment", Array.Empty<string>()) ?? "");
									}
								}
								else
								{
									int emojiId = ((ITalkItemPhoneMessageEmoji)talkItemPhoneMessage.MessageType).EmojiId;
									ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(emojiId);
									if (expressionConfig != null)
									{
										string name = expressionConfig.Value.Name;
										string text = ConfigBase<TextConfig>.Instance.GetMultiText(name, Array.Empty<string>()) ?? "";
										item2 = ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Expression", new string[]
										{
											text
										});
									}
								}
							}
						}
						else
						{
							item2 = (Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkItem.TidTalk) ?? "");
						}
						return new ValueTuple<string, string, string>?(new ValueTuple<string, string, string>(item, headIconAsset, item2));
					}
					else
					{
						j++;
					}
				}
			}
		}
		return null;
	}

	// Token: 0x060129AB RID: 76203 RVA: 0x0052096C File Offset: 0x0051EB6C
	public bool IsShortMsgRead(int shortMsgId)
	{
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = this.GetPhoneMsgShortMsgDataByShortMsgId(shortMsgId);
		return phoneMsgShortMsgDataByShortMsgId != null && phoneMsgShortMsgDataByShortMsgId.IsRead;
	}

	// Token: 0x060129AC RID: 76204 RVA: 0x0052098C File Offset: 0x0051EB8C
	public bool IsSomeOneHasUnReadMsg(int chatPartnerId)
	{
		List<PhoneMsgShortMsgData> allPhoneMsgShortMsgDataByChatPartnerId = this.GetAllPhoneMsgShortMsgDataByChatPartnerId(chatPartnerId);
		if (allPhoneMsgShortMsgDataByChatPartnerId == null)
		{
			return false;
		}
		int count = allPhoneMsgShortMsgDataByChatPartnerId.Count;
		for (int i = 0; i < count; i++)
		{
			if (!allPhoneMsgShortMsgDataByChatPartnerId[i].IsRead)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060129AD RID: 76205 RVA: 0x005209CC File Offset: 0x0051EBCC
	public bool IsSomeOneHasUnReceivedMsg(int chatPartnerId)
	{
		List<PhoneMsgShortMsgData> allPhoneMsgShortMsgDataByChatPartnerId = this.GetAllPhoneMsgShortMsgDataByChatPartnerId(chatPartnerId);
		if (allPhoneMsgShortMsgDataByChatPartnerId == null)
		{
			return false;
		}
		int count = allPhoneMsgShortMsgDataByChatPartnerId.Count;
		for (int i = 0; i < count; i++)
		{
			PhoneMsgShortMsgData phoneMsgShortMsgData = allPhoneMsgShortMsgDataByChatPartnerId[i];
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(phoneMsgShortMsgData.ShortMsgId);
			if (phoneMsgConfig != null && phoneMsgConfig.Value.FinallPopType == 6 && !phoneMsgShortMsgData.IsReceived)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060129AE RID: 76206 RVA: 0x00520A3C File Offset: 0x0051EC3C
	public bool IsAllPhoneMsgRead()
	{
		foreach (KeyValuePair<int, PhoneMsgShortMsgData> keyValuePair in this.Id2ShortMessagesDict)
		{
			if (!keyValuePair.Value.IsRead)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060129AF RID: 76207 RVA: 0x00520AA0 File Offset: 0x0051ECA0
	public bool IsHasUnReceivedMsg()
	{
		foreach (KeyValuePair<int, PhoneMsgShortMsgData> keyValuePair in this.Id2ShortMessagesDict)
		{
			PhoneMsgShortMsgData value = keyValuePair.Value;
			ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(value.ShortMsgId);
			if (phoneMsgConfig != null && phoneMsgConfig.Value.FinallPopType == 6 && !value.IsReceived)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060129B0 RID: 76208 RVA: 0x00520B34 File Offset: 0x0051ED34
	public bool IsPhoneMsgUnlock(int shortMsgId)
	{
		return this.Id2ShortMessagesDict.ContainsKey(shortMsgId);
	}

	// Token: 0x060129B1 RID: 76209 RVA: 0x00520B44 File Offset: 0x0051ED44
	public void SetShortMsgOptionData(int shortMsgId, int chatIndex, int optIndex)
	{
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = this.GetPhoneMsgShortMsgDataByShortMsgId(shortMsgId);
		if (phoneMsgShortMsgDataByShortMsgId != null)
		{
			phoneMsgShortMsgDataByShortMsgId.SelectedOptionsDict[chatIndex] = optIndex;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnUpdateShortMsgOptionData, shortMsgId);
		}
	}

	// Token: 0x060129B2 RID: 76210 RVA: 0x00520B7C File Offset: 0x0051ED7C
	public bool GetShortMsgHasAnySelectedOption(int shortMsgId)
	{
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = this.GetPhoneMsgShortMsgDataByShortMsgId(shortMsgId);
		return phoneMsgShortMsgDataByShortMsgId != null && phoneMsgShortMsgDataByShortMsgId.SelectedOptionsDict.Count > 0;
	}

	// Token: 0x060129B3 RID: 76211 RVA: 0x00520BA4 File Offset: 0x0051EDA4
	public void SetShortMsgRewardData(int shortMsgId, bool isReceived)
	{
		PhoneMsgShortMsgData phoneMsgShortMsgDataByShortMsgId = this.GetPhoneMsgShortMsgDataByShortMsgId(shortMsgId);
		if (phoneMsgShortMsgDataByShortMsgId != null)
		{
			phoneMsgShortMsgDataByShortMsgId.IsReceived = isReceived;
		}
	}

	// Token: 0x060129B4 RID: 76212 RVA: 0x00520BC4 File Offset: 0x0051EDC4
	[return: Nullable(new byte[]
	{
		0,
		2
	})]
	public UniTask<ShortMessageDisplayData> CreateShortMessageDisplayDataByShortMsgId(int shortMsgId)
	{
		PhoneMsgModel.<CreateShortMessageDisplayDataByShortMsgId>d__72 <CreateShortMessageDisplayDataByShortMsgId>d__;
		<CreateShortMessageDisplayDataByShortMsgId>d__.<>t__builder = AsyncUniTaskMethodBuilder<ShortMessageDisplayData>.Create();
		<CreateShortMessageDisplayDataByShortMsgId>d__.<>4__this = this;
		<CreateShortMessageDisplayDataByShortMsgId>d__.shortMsgId = shortMsgId;
		<CreateShortMessageDisplayDataByShortMsgId>d__.<>1__state = -1;
		<CreateShortMessageDisplayDataByShortMsgId>d__.<>t__builder.Start<PhoneMsgModel.<CreateShortMessageDisplayDataByShortMsgId>d__72>(ref <CreateShortMessageDisplayDataByShortMsgId>d__);
		return <CreateShortMessageDisplayDataByShortMsgId>d__.<>t__builder.Task;
	}

	// Token: 0x060129B5 RID: 76213 RVA: 0x00520C10 File Offset: 0x0051EE10
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<ShortMessageDisplayData> CreateShortMessageDisplayData(PhoneMsgShortMsgData shortMsgData)
	{
		PhoneMsgModel.<CreateShortMessageDisplayData>d__73 <CreateShortMessageDisplayData>d__;
		<CreateShortMessageDisplayData>d__.<>t__builder = AsyncUniTaskMethodBuilder<ShortMessageDisplayData>.Create();
		<CreateShortMessageDisplayData>d__.<>4__this = this;
		<CreateShortMessageDisplayData>d__.shortMsgData = shortMsgData;
		<CreateShortMessageDisplayData>d__.<>1__state = -1;
		<CreateShortMessageDisplayData>d__.<>t__builder.Start<PhoneMsgModel.<CreateShortMessageDisplayData>d__73>(ref <CreateShortMessageDisplayData>d__);
		return <CreateShortMessageDisplayData>d__.<>t__builder.Task;
	}

	// Token: 0x060129B6 RID: 76214 RVA: 0x00520C5C File Offset: 0x0051EE5C
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<string> GetLastChatTextByShortMsgId(int shortMsgId, EGetLastChatTextType type = EGetLastChatTextType.FromReadIndex)
	{
		PhoneMsgModel.<GetLastChatTextByShortMsgId>d__74 <GetLastChatTextByShortMsgId>d__;
		<GetLastChatTextByShortMsgId>d__.<>t__builder = AsyncUniTaskMethodBuilder<string>.Create();
		<GetLastChatTextByShortMsgId>d__.<>4__this = this;
		<GetLastChatTextByShortMsgId>d__.shortMsgId = shortMsgId;
		<GetLastChatTextByShortMsgId>d__.type = type;
		<GetLastChatTextByShortMsgId>d__.<>1__state = -1;
		<GetLastChatTextByShortMsgId>d__.<>t__builder.Start<PhoneMsgModel.<GetLastChatTextByShortMsgId>d__74>(ref <GetLastChatTextByShortMsgId>d__);
		return <GetLastChatTextByShortMsgId>d__.<>t__builder.Task;
	}

	// Token: 0x060129B7 RID: 76215 RVA: 0x00520CB0 File Offset: 0x0051EEB0
	public string GetLastChatTextByDisplayData(ShortMessageDisplayData displayData, EGetLastChatTextType type = EGetLastChatTextType.FromReadIndex)
	{
		List<PhoneMsgChatData> chatDataList = displayData.ChatDataList;
		if (chatDataList.Count == 0)
		{
			return "";
		}
		string text = "";
		int num = 0;
		if (type != EGetLastChatTextType.FromReadIndex)
		{
			if (type == EGetLastChatTextType.FromLastCanReadIndex)
			{
				num = chatDataList.Count - 1;
			}
		}
		else
		{
			num = displayData.ReadIndex;
		}
		for (int i = num; i >= 0; i--)
		{
			PhoneMsgChatData phoneMsgChatData = chatDataList[i];
			if (phoneMsgChatData != null && phoneMsgChatData.ChatContentType != EPhoneMsgContentType.Tips)
			{
				PhoneMsgChatData lastChatData = phoneMsgChatData;
				text = this.GetTalkText(lastChatData, displayData);
				if (!(text == ""))
				{
					break;
				}
			}
		}
		if (text == "")
		{
			if (displayData.ReadIndex < 0)
			{
				int count = chatDataList.Count;
				for (int j = 0; j < count; j++)
				{
					PhoneMsgChatData phoneMsgChatData2 = chatDataList[j];
					if (phoneMsgChatData2 != null && phoneMsgChatData2.ChatContentType != EPhoneMsgContentType.Tips)
					{
						PhoneMsgChatData lastChatData = phoneMsgChatData2;
						text = this.GetTalkText(lastChatData, displayData);
						if (!(text == ""))
						{
							break;
						}
					}
				}
			}
			else
			{
				text = (ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Input", Array.Empty<string>()) ?? "");
			}
		}
		return text;
	}

	// Token: 0x060129B8 RID: 76216 RVA: 0x00520DBC File Offset: 0x0051EFBC
	private string GetTalkText(PhoneMsgChatData lastChatData, ShortMessageDisplayData displayData)
	{
		string result = "";
		if (lastChatData != null)
		{
			EChatMsgType contentType = lastChatData.ContentType;
			switch (contentType)
			{
			case EChatMsgType.Text:
				result = lastChatData.ContentStr;
				break;
			case EChatMsgType.Emoji:
			{
				int contentNum = lastChatData.ContentNum;
				ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(contentNum);
				if (expressionConfig != null)
				{
					string name = expressionConfig.Value.Name;
					string text = ConfigBase<TextConfig>.Instance.GetMultiText(name, Array.Empty<string>()) ?? "";
					result = ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Expression", new string[]
					{
						text
					});
				}
				break;
			}
			case EChatMsgType.Attachment:
			{
				PhoneMessageAttachment? config = ConfigPhoneMessageAttachmentById.GetConfig(lastChatData.ContentNum, true);
				result = ((((config != null) ? config.GetValueOrDefault().Type : null) == "InformationView") ? (ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Information", Array.Empty<string>()) ?? "") : (ConfigBase<TextConfig>.Instance.GetMultiText("ChatBubble_Content_Attachment", Array.Empty<string>()) ?? ""));
				break;
			}
			default:
				if (contentType == EChatMsgType.Voice)
				{
					string value = ConfigBase<TextConfig>.Instance.GetMultiText("MessagePreview_Voice", Array.Empty<string>()) ?? "";
					double num = Math.Round((double)(lastChatData.VoiceDuration / 1000f), MidpointRounding.AwayFromZero);
					num = Math.Max(num, 1.0);
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted(value);
					defaultInterpolatedStringHandler.AppendFormatted<double>(num);
					defaultInterpolatedStringHandler.AppendLiteral("″");
					result = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				break;
			}
			return result;
		}
		ValueTuple<string, string, string>? firstMsgDataByShortMsgId = ModelBase<PhoneMsgModel>.Instance.GetFirstMsgDataByShortMsgId(displayData.ShortMsgId);
		if (firstMsgDataByShortMsgId == null)
		{
			return "";
		}
		return firstMsgDataByShortMsgId.Value.Item3;
	}

	// Token: 0x060129B9 RID: 76217 RVA: 0x00520F8C File Offset: 0x0051F18C
	private UniTask LoadDurationForShowTalkAsync(ShowTalk showTalkAction)
	{
		PhoneMsgModel.<LoadDurationForShowTalkAsync>d__77 <LoadDurationForShowTalkAsync>d__;
		<LoadDurationForShowTalkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDurationForShowTalkAsync>d__.<>4__this = this;
		<LoadDurationForShowTalkAsync>d__.showTalkAction = showTalkAction;
		<LoadDurationForShowTalkAsync>d__.<>1__state = -1;
		<LoadDurationForShowTalkAsync>d__.<>t__builder.Start<PhoneMsgModel.<LoadDurationForShowTalkAsync>d__77>(ref <LoadDurationForShowTalkAsync>d__);
		return <LoadDurationForShowTalkAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060129BA RID: 76218 RVA: 0x00520FD8 File Offset: 0x0051F1D8
	private UniTask LoadDurationForTalkItemAsync(ITalkItem talkItem)
	{
		PhoneMsgModel.<LoadDurationForTalkItemAsync>d__78 <LoadDurationForTalkItemAsync>d__;
		<LoadDurationForTalkItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadDurationForTalkItemAsync>d__.<>4__this = this;
		<LoadDurationForTalkItemAsync>d__.talkItem = talkItem;
		<LoadDurationForTalkItemAsync>d__.<>1__state = -1;
		<LoadDurationForTalkItemAsync>d__.<>t__builder.Start<PhoneMsgModel.<LoadDurationForTalkItemAsync>d__78>(ref <LoadDurationForTalkItemAsync>d__);
		return <LoadDurationForTalkItemAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060129BB RID: 76219 RVA: 0x00521024 File Offset: 0x0051F224
	private void ProcessSetPlotMode(SetPlotMode setPlotModeAction, ShortMessageDisplayData displayData)
	{
		IPhoneMessageConfig phoneMessageConfig = setPlotModeAction.PhoneMessageConfig;
		displayData.IsJumpToFirstOption = (phoneMessageConfig != null && phoneMessageConfig.IsJumpToFirstOption.GetValueOrDefault());
	}

	// Token: 0x060129BC RID: 76220 RVA: 0x00521054 File Offset: 0x0051F254
	private void ProcessShowTalk(ShowTalk showTalkAction, ShortMessage msgConfig, ShortMessageDisplayData displayData, int startTalkItemIndex = 0)
	{
		List<ITalkItem> talkItems = showTalkAction.TalkItems;
		int num = startTalkItemIndex;
		int count = talkItems.Count;
		while (num >= 0 && num < count)
		{
			num = this.ProcessTalkItem(showTalkAction, msgConfig, displayData, num);
		}
		if (!displayData.IsLastOption())
		{
			this.ProcessFinalSystemTips(msgConfig, displayData);
		}
	}

	// Token: 0x060129BD RID: 76221 RVA: 0x00521098 File Offset: 0x0051F298
	private int ProcessTalkItem(ShowTalk showTalkAction, ShortMessage msgConfig, ShortMessageDisplayData displayData, int startTalkItemIndex = 0)
	{
		List<ITalkItem> talkItems = showTalkAction.TalkItems;
		ITalkItem talkItem = talkItems[startTalkItemIndex];
		PhoneMsgChatData phoneMsgChatData = null;
		int num = -1;
		bool flag = false;
		if (this.IsSystemTipMessage(talkItem))
		{
			phoneMsgChatData = this.CreateSystemTipChatData((ITalkItemPhoneMessage)talkItem);
		}
		else if (this.IsOption(talkItem))
		{
			if (displayData.OptionSelectedMap.ContainsKey(startTalkItemIndex))
			{
				num = this.ProcessTalkItemOptions(talkItems, startTalkItemIndex, displayData);
			}
			else
			{
				phoneMsgChatData = this.CreateSelfPhoneMsgChatData(talkItem, true);
				flag = true;
			}
		}
		else if (talkItem.WhoId.GetValueOrDefault() == 750088 || talkItem.WhoId.GetValueOrDefault() == 701052)
		{
			phoneMsgChatData = this.CreateSelfPhoneMsgChatData(talkItem, false);
		}
		else
		{
			phoneMsgChatData = this.CreateOtherPhoneMsgChatData(talkItem);
		}
		if (phoneMsgChatData != null)
		{
			displayData.ChatDataList.Add(phoneMsgChatData);
			if (phoneMsgChatData.ContentType == EChatMsgType.Voice)
			{
				phoneMsgChatData.VoiceEventHash = msgConfig.Id * 1000 + startTalkItemIndex;
				if (phoneMsgChatData.ChatContentType == EPhoneMsgContentType.Self)
				{
					this.AddPhoneMsgRedDot(EPhoneMsgServerRedDotType.VoiceOnce, phoneMsgChatData.VoiceEventHash);
				}
			}
		}
		if (num >= 0)
		{
			return num;
		}
		if (flag)
		{
			return -1;
		}
		List<ActionInfo> actions = talkItem.Actions;
		if (actions != null && actions.Count > 0)
		{
			ActionInfo actionInfo = actions[0];
			EAction name = actionInfo.Name;
			if (name == EAction.FinishTalk)
			{
				return -1;
			}
			if (name == EAction.JumpTalk)
			{
				return this.ProcessJumpTalkAction(actionInfo, displayData);
			}
		}
		List<ITalkOption> options = talkItem.Options;
		if (options != null && options.Count > 0)
		{
			if (displayData.OptionSelectedMap.ContainsKey(startTalkItemIndex))
			{
				return this.ProcessTalkItemOptions(talkItems, startTalkItemIndex, displayData);
			}
			PhoneMsgChatData phoneMsgChatData2 = this.CreateSelfPhoneMsgChatData(talkItem, true);
			if (phoneMsgChatData2 != null)
			{
				displayData.ChatDataList.Add(phoneMsgChatData2);
				return -1;
			}
		}
		return startTalkItemIndex + 1;
	}

	// Token: 0x060129BE RID: 76222 RVA: 0x0052122C File Offset: 0x0051F42C
	private unsafe int ProcessTalkItemOptions(List<ITalkItem> talkItems, int inTalkItemIndex, ShortMessageDisplayData displayData)
	{
		List<ITalkOption> options = talkItems[inTalkItemIndex].Options;
		if (options == null)
		{
			return inTalkItemIndex;
		}
		int num;
		if (!displayData.OptionSelectedMap.TryGetValue(inTalkItemIndex, out num))
		{
			num = -1;
		}
		if (num < 0 || num >= options.Count)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhoneSystem;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[短信剧本配置ERROR] 选项选择索引错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("短信ID", displayData.ShortMsgId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		List<ActionInfo> actions = options[num].Actions;
		if (actions == null || actions.Count == 0)
		{
			return inTalkItemIndex + 1;
		}
		ActionInfo actionInfo = actions.Find((ActionInfo action) => action.Name == EAction.JumpTalk);
		if (actionInfo != null)
		{
			return this.ProcessJumpTalkAction(actionInfo, displayData);
		}
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(displayData.ShortMsgId);
		if (phoneMsgConfig != null)
		{
			global::Log instance2 = Singleton<global::Log>.Instance;
			ELogModule module2 = ELogModule.PhoneSystem;
			ELogAuthor author2 = ELogAuthor.LZK;
			string message2 = "[短信剧本配置ERROR] 选项配置中找不到JumpTalk类型，注意！JumpTalk必须指向玩家选项所对应的完整发言，而非下一句NPC发言，否则将不显示玩家发言";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("短信ID", displayData.ShortMsgId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("剧本ID", phoneMsgConfig.Value.FlowParam()[0]);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		return -1;
	}

	// Token: 0x060129BF RID: 76223 RVA: 0x00521380 File Offset: 0x0051F580
	private void ProcessFinalSystemTips(ShortMessage msgConfig, ShortMessageDisplayData displayData)
	{
		PhoneMsgChatData phoneMsgChatData = this.CreateFinalSystemTips(msgConfig, displayData);
		if (phoneMsgChatData != null)
		{
			displayData.ChatDataList.Add(phoneMsgChatData);
		}
	}

	// Token: 0x060129C0 RID: 76224 RVA: 0x005213A8 File Offset: 0x0051F5A8
	private int ProcessJumpTalkAction(ActionInfo action, ShortMessageDisplayData displayData)
	{
		JumpTalk jumpTalk = (JumpTalk)action.Params;
		int result;
		if (!displayData.IdToIndexMap.TryGetValue(jumpTalk.TalkId, out result))
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.PhoneSystem;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[短信剧本配置ERROR] JumpTalk指向的选项Index不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("短信ID", displayData.ShortMsgId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return -1;
		}
		return result;
	}

	// Token: 0x060129C1 RID: 76225 RVA: 0x00521410 File Offset: 0x0051F610
	public void ProcessAfterAnswer(ShortMessageDisplayData displayData, int talkItemIndex)
	{
		if (talkItemIndex < 0)
		{
			return;
		}
		ShowTalk showTalkConfig = displayData.ShowTalkConfig;
		if (showTalkConfig == null)
		{
			return;
		}
		int count = displayData.ChatDataList.Count;
		if (count > 0)
		{
			displayData.ChatDataList.RemoveAt(count - 1);
		}
		int num = this.ProcessTalkItemOptions(showTalkConfig.TalkItems, talkItemIndex, displayData);
		if (num < 0)
		{
			return;
		}
		ShortMessage? phoneMsgConfig = ConfigBase<PhoneMsgConfig>.Instance.GetPhoneMsgConfig(displayData.ShortMsgId);
		if (phoneMsgConfig != null)
		{
			this.ProcessShowTalk(showTalkConfig, phoneMsgConfig.Value, displayData, num);
		}
	}

	// Token: 0x060129C2 RID: 76226 RVA: 0x0052148C File Offset: 0x0051F68C
	private bool IsSystemTipMessage(ITalkItem talkItem)
	{
		return talkItem.Type.GetValueOrDefault() == ETalkItemType.PhoneMessage && ((ITalkItemPhoneMessage)talkItem).MessageType.Type == EPhoneMessageType.SystemTip;
	}

	// Token: 0x060129C3 RID: 76227 RVA: 0x005214C0 File Offset: 0x0051F6C0
	private bool IsOption(ITalkItem talkItem)
	{
		return talkItem.Type.GetValueOrDefault() == ETalkItemType.Option || talkItem.Type.GetValueOrDefault() == ETalkItemType.SystemOption;
	}

	// Token: 0x060129C4 RID: 76228 RVA: 0x005214F4 File Offset: 0x0051F6F4
	[return: Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private ValueTuple<string, string> GetSpeakerNameAndHead(int? whoId)
	{
		if (whoId == null)
		{
			return new ValueTuple<string, string>("", "");
		}
		Speaker? config = ConfigSpeakerById.GetConfig(whoId.Value, true);
		if (config == null)
		{
			return new ValueTuple<string, string>("", "");
		}
		string item = Singleton<PublicUtil>.Instance.GetConfigTextByTable(ETableText.SpeakerName, new int?(config.Value.Id)) ?? "";
		string headIconAsset = config.Value.HeadIconAsset;
		return new ValueTuple<string, string>(item, headIconAsset);
	}

	// Token: 0x060129C5 RID: 76229 RVA: 0x00521580 File Offset: 0x0051F780
	private void FillChatDataContent(PhoneMsgChatData chatData, ITalkItem talkItem, bool bOption = false)
	{
		if (bOption)
		{
			this.FillOptionChatData(chatData, talkItem);
			return;
		}
		ETalkItemType value = talkItem.Type.Value;
		if (value == ETalkItemType.Talk)
		{
			this.FillTalkChatData(chatData, talkItem);
			ITalkItemDialog talkItemDialog = (ITalkItemDialog)talkItem;
			chatData.SetScrollWaitTime((int)talkItemDialog.OtherIsTypingDuration.GetValueOrDefault());
			return;
		}
		if (value != ETalkItemType.PhoneMessage)
		{
			return;
		}
		this.FillPhoneMessageChatData(chatData, talkItem);
		ITalkItemPhoneMessage talkItemPhoneMessage = (ITalkItemPhoneMessage)talkItem;
		chatData.SetScrollWaitTime((int)talkItemPhoneMessage.OtherIsTypingDuration.GetValueOrDefault());
	}

	// Token: 0x060129C6 RID: 76230 RVA: 0x005215FC File Offset: 0x0051F7FC
	private void FillOptionChatData(PhoneMsgChatData chatData, ITalkItem talkItem)
	{
		List<ITalkOption> options = talkItem.Options;
		if (options == null || options.Count == 0)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "[短信剧本配置ERROR] 选项配置中找不到选项", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ITalkOption talkOption = options[0];
		EChatMsgType? echatMsgType = null;
		if (talkOption.TypeParams == null)
		{
			echatMsgType = new EChatMsgType?(EChatMsgType.TextOption);
		}
		else
		{
			if (talkOption.TypeParams.Type != ETalkOptionParamType.PhoneMessageEmoji)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "[短信剧本配置ERROR] 选项配置中找不到选项类型", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			echatMsgType = new EChatMsgType?(EChatMsgType.EmojiOption);
		}
		chatData.ContentType = echatMsgType.Value;
	}

	// Token: 0x060129C7 RID: 76231 RVA: 0x005216A4 File Offset: 0x0051F8A4
	private void FillTalkChatData(PhoneMsgChatData chatData, ITalkItem talkItem)
	{
		ITalkItemDialog talkItemDialog = (ITalkItemDialog)talkItem;
		chatData.IsSendError = (talkItemDialog.Style != null && talkItemDialog.Style.Type == ETalkItemStyle.PhoneSendError);
		chatData.ContentStr = (Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkItemDialog.TidTalk) ?? "");
		this.SetDialogChatData(chatData, talkItemDialog);
	}

	// Token: 0x060129C8 RID: 76232 RVA: 0x00521700 File Offset: 0x0051F900
	private void FillPhoneMessageChatData(PhoneMsgChatData chatData, ITalkItem talkItem)
	{
		ITalkItemPhoneMessage talkItemPhoneMessage = (ITalkItemPhoneMessage)talkItem;
		chatData.IsSendError = (talkItemPhoneMessage.Style != null && talkItemPhoneMessage.Style.Type == ETalkItemStyle.PhoneSendError);
		switch (talkItemPhoneMessage.MessageType.Type)
		{
		case EPhoneMessageType.Voice:
			this.SetVoiceChatData(chatData, talkItemPhoneMessage);
			return;
		case EPhoneMessageType.Emoji:
			this.SetEmojiChatData(chatData, talkItemPhoneMessage);
			return;
		case EPhoneMessageType.Attachment:
			this.SetAttachmentChatData(chatData, talkItemPhoneMessage);
			return;
		default:
			return;
		}
	}

	// Token: 0x060129C9 RID: 76233 RVA: 0x0052176C File Offset: 0x0051F96C
	public PhoneMsgChatData CreateOtherPhoneMsgChatData(ITalkItem talkItem)
	{
		PhoneMsgChatData phoneMsgChatData = new PhoneMsgChatData(EPhoneMsgContentType.Other);
		phoneMsgChatData.TalkItem = talkItem;
		ValueTuple<string, string> speakerNameAndHead = this.GetSpeakerNameAndHead(talkItem.WhoId);
		phoneMsgChatData.SpeakerName = speakerNameAndHead.Item1;
		phoneMsgChatData.SpeakerHeadIconPath = speakerNameAndHead.Item2;
		this.FillChatDataContent(phoneMsgChatData, talkItem, false);
		return phoneMsgChatData;
	}

	// Token: 0x060129CA RID: 76234 RVA: 0x005217B8 File Offset: 0x0051F9B8
	[return: Nullable(2)]
	public PhoneMsgChatData CreateSelfPhoneMsgChatData(ITalkItem talkItem, bool bOption = false)
	{
		PhoneMsgChatData phoneMsgChatData = new PhoneMsgChatData(EPhoneMsgContentType.Self);
		phoneMsgChatData.TalkItem = talkItem;
		int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
		if (curSelectMainRoleId == null)
		{
			return null;
		}
		int roleSkinIdByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinIdByRoleId(curSelectMainRoleId.Value);
		RoleSkin? roleSkinConfig = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinIdByRoleId);
		if (roleSkinConfig != null)
		{
			phoneMsgChatData.SpeakerHeadIconPath = roleSkinConfig.Value.RoleHeadIconCircle;
		}
		phoneMsgChatData.SpeakerName = (ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "");
		this.FillChatDataContent(phoneMsgChatData, talkItem, bOption);
		return phoneMsgChatData;
	}

	// Token: 0x060129CB RID: 76235 RVA: 0x0052184C File Offset: 0x0051FA4C
	[return: Nullable(2)]
	public PhoneMsgChatData CreateSystemTipChatData(ITalkItemPhoneMessage talkMsgItem)
	{
		if (talkMsgItem.MessageType.Type != EPhoneMessageType.SystemTip)
		{
			return null;
		}
		PhoneMsgChatData phoneMsgChatData = new PhoneMsgChatData(EPhoneMsgContentType.Tips);
		phoneMsgChatData.TalkItem = talkMsgItem;
		phoneMsgChatData.ContentType = EChatMsgType.Tips;
		if (talkMsgItem.TidTalk != null)
		{
			phoneMsgChatData.ContentStr = (Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkMsgItem.TidTalk) ?? "");
		}
		return phoneMsgChatData;
	}

	// Token: 0x060129CC RID: 76236 RVA: 0x005218A6 File Offset: 0x0051FAA6
	public void SetDialogChatData(PhoneMsgChatData targetChatData, ITalkItemDialog talkItem)
	{
		targetChatData.ContentType = EChatMsgType.Text;
		if (talkItem.TidTalk != null)
		{
			targetChatData.ContentStr = (Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkItem.TidTalk) ?? "");
		}
	}

	// Token: 0x060129CD RID: 76237 RVA: 0x005218D8 File Offset: 0x0051FAD8
	public void SetEmojiChatData(PhoneMsgChatData targetChatData, ITalkItemPhoneMessage talkMsgItem)
	{
		if (talkMsgItem.MessageType.Type != EPhoneMessageType.Emoji)
		{
			return;
		}
		ITalkItemPhoneMessageEmoji talkItemPhoneMessageEmoji = (ITalkItemPhoneMessageEmoji)talkMsgItem.MessageType;
		targetChatData.ContentType = EChatMsgType.Emoji;
		targetChatData.ContentNum = talkItemPhoneMessageEmoji.EmojiId;
	}

	// Token: 0x060129CE RID: 76238 RVA: 0x00521914 File Offset: 0x0051FB14
	public void SetAttachmentChatData(PhoneMsgChatData targetChatData, ITalkItemPhoneMessage talkMsgItem)
	{
		if (talkMsgItem.MessageType.Type != EPhoneMessageType.Attachment)
		{
			return;
		}
		ITalkItemPhoneMessageAttachment talkItemPhoneMessageAttachment = (ITalkItemPhoneMessageAttachment)talkMsgItem.MessageType;
		targetChatData.ContentType = EChatMsgType.Attachment;
		targetChatData.ContentNum = talkItemPhoneMessageAttachment.AttachmentId;
	}

	// Token: 0x060129CF RID: 76239 RVA: 0x00521950 File Offset: 0x0051FB50
	public void SetVoiceChatData(PhoneMsgChatData targetChatData, ITalkItemPhoneMessage talkMsgItem)
	{
		if (talkMsgItem.MessageType.Type != EPhoneMessageType.Voice)
		{
			return;
		}
		ITalkItemPhoneMessageVoice talkItemPhoneMessageVoice = (ITalkItemPhoneMessageVoice)talkMsgItem.MessageType;
		targetChatData.ContentType = EChatMsgType.Voice;
		targetChatData.TalkItem = talkMsgItem;
		float voiceDuration;
		if (this.AudioDurationMap.TryGetValue(talkMsgItem.Id, out voiceDuration))
		{
			targetChatData.VoiceDuration = voiceDuration;
		}
		targetChatData.ContentStr = (Singleton<PublicUtil>.Instance.GetFlowConfigLocalText(talkMsgItem.TidTalk) ?? "");
		targetChatData.PushCondition = talkItemPhoneMessageVoice.PushCondition;
		targetChatData.IsAutoPlay = talkItemPhoneMessageVoice.AutoPlay.GetValueOrDefault();
	}

	// Token: 0x060129D0 RID: 76240 RVA: 0x005219E4 File Offset: 0x0051FBE4
	[return: Nullable(2)]
	private PhoneMsgChatData CreateFinalSystemTips(ShortMessage msgConfig, ShortMessageDisplayData displayData)
	{
		if (msgConfig.FinallPopType == 0)
		{
			return null;
		}
		PhoneMsgChatData phoneMsgChatData = new PhoneMsgChatData(EPhoneMsgContentType.Tips);
		switch (msgConfig.FinallPopType)
		{
		case 4:
			phoneMsgChatData.ContentType = EChatMsgType.Task;
			phoneMsgChatData.QuestId = msgConfig.QuestId;
			break;
		case 5:
		{
			phoneMsgChatData.ContentType = EChatMsgType.Birthday;
			BirthDay? config = ConfigBirthDayByMsgId.GetConfig(msgConfig.Id, true);
			phoneMsgChatData.BirthdayCardItemId = ((config != null) ? config.Value.BirthDayCardItemId : 0);
			break;
		}
		case 6:
			phoneMsgChatData.ContentType = EChatMsgType.Reward;
			phoneMsgChatData.DropId = msgConfig.DropId;
			phoneMsgChatData.IsFinish = displayData.IsReceivedReward;
			break;
		}
		int whichChat = msgConfig.WhichChat;
		ChatPartner? chatPartnerConfigNew = this.GetChatPartnerConfigNew(whichChat);
		phoneMsgChatData.IsGroupChat = (chatPartnerConfigNew != null && chatPartnerConfigNew.Value.IsGroupChat);
		phoneMsgChatData.ShortMessageId = msgConfig.Id;
		phoneMsgChatData.ChatPartnerId = msgConfig.WhichChat;
		PhoneMsgShortMsgData phoneMsgShortMsgData;
		if (this.Id2ShortMessagesDict.TryGetValue(msgConfig.Id, out phoneMsgShortMsgData) && phoneMsgShortMsgData != null)
		{
			phoneMsgChatData.UnLockTime = phoneMsgShortMsgData.UnLockTime;
		}
		else
		{
			phoneMsgChatData.UnLockTime = 0L;
		}
		return phoneMsgChatData;
	}

	// Token: 0x060129D1 RID: 76241 RVA: 0x00521B0F File Offset: 0x0051FD0F
	public int CoverServerProgressToReadIndex(int progress)
	{
		return progress - 1;
	}

	// Token: 0x060129D2 RID: 76242 RVA: 0x00521B14 File Offset: 0x0051FD14
	public int CoverReadIndexToServerProgress(int readIndex)
	{
		return readIndex + 1;
	}

	// Token: 0x060129D3 RID: 76243 RVA: 0x00521B1C File Offset: 0x0051FD1C
	public string GetEmojiTexturePathByEmojiId(int emojiId)
	{
		ChatExpression? expressionConfig = ConfigBase<ChatConfig>.Instance.GetExpressionConfig(emojiId);
		if (expressionConfig == null)
		{
			Singleton<global::Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "[短信表情包配置ERROR] 表情包配置中不存在对应Id" + emojiId.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return "";
		}
		bool flag = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male;
		if (!string.IsNullOrEmpty(expressionConfig.Value.MaleVariant) && flag)
		{
			return expressionConfig.Value.MaleVariant;
		}
		return expressionConfig.Value.ExpressionTexturePath ?? "";
	}

	// Token: 0x060129D4 RID: 76244 RVA: 0x00521BC0 File Offset: 0x0051FDC0
	public bool IsChatShowHasRedDotById(int id)
	{
		HashSet<int> hashSet;
		return this.LocalRedDotCache != null && this.LocalRedDotCache.TryGetValue(EPhoneMsgServerRedDotType.Decoration, out hashSet) && hashSet.Contains(id);
	}

	// Token: 0x060129D5 RID: 76245 RVA: 0x00521BEE File Offset: 0x0051FDEE
	public bool IsChatShowHasRedDot()
	{
		return this.HasRedDotByType(EPhoneMsgServerRedDotType.Decoration);
	}

	// Token: 0x060129D6 RID: 76246 RVA: 0x00521BF8 File Offset: 0x0051FDF8
	private bool HasRedDotByType(EPhoneMsgServerRedDotType type)
	{
		HashSet<int> hashSet;
		return this.LocalRedDotCache != null && this.LocalRedDotCache.TryGetValue(type, out hashSet) && hashSet.Count > 0;
	}

	// Token: 0x060129D7 RID: 76247 RVA: 0x00521C28 File Offset: 0x0051FE28
	public void RemoveChatShowRedDotById(int id)
	{
		this.RemovePhoneMsgRedDot(EPhoneMsgServerRedDotType.Decoration, id);
		Singleton<EventSystem>.Instance.Emit(EEventName.PhoneMsgDialogAndBgRedDotUpdate);
	}

	// Token: 0x060129D8 RID: 76248 RVA: 0x00521C44 File Offset: 0x0051FE44
	public void SetLastOpenBigPanelTime(double time)
	{
		int num = (int)(time / 1000.0);
		if (num > this.LastOpenBigPanelTime)
		{
			this.RemovePhoneMsgRedDot(EPhoneMsgServerRedDotType.Preview, this.LastOpenBigPanelTime);
			this.LastOpenBigPanelTime = num;
			this.AddPhoneMsgRedDot(EPhoneMsgServerRedDotType.Preview, num);
		}
	}

	// Token: 0x060129D9 RID: 76249 RVA: 0x00521C83 File Offset: 0x0051FE83
	public void SetLatestShortMsgTime(long time)
	{
		if (time > this.LatestShortMsgTime)
		{
			this.LatestShortMsgTime = time;
		}
	}

	// Token: 0x060129DA RID: 76250 RVA: 0x00521C95 File Offset: 0x0051FE95
	public bool IsHasPhoneMsgUnReview()
	{
		return this.LatestShortMsgTime > (long)this.LastOpenBigPanelTime;
	}

	// Token: 0x060129DB RID: 76251 RVA: 0x00521CA6 File Offset: 0x0051FEA6
	public ChatPartner? GetChatPartnerConfigNew(int partnerId)
	{
		return ConfigBase<PhoneMsgConfig>.Instance.GetChatPartnerConfig(partnerId);
	}

	// Token: 0x040090FE RID: 37118
	public HashSet<EDungeonSubType> NormalDungeonSet = new HashSet<EDungeonSubType>();

	// Token: 0x040090FF RID: 37119
	public bool IsPhoneChatShowInitDone;

	// Token: 0x04009100 RID: 37120
	public int CurrentUsingChatDialogId;

	// Token: 0x04009101 RID: 37121
	public int CurrentUsingChatBgId;

	// Token: 0x04009102 RID: 37122
	private readonly HashSet<int> UnlockedDialogIds = new HashSet<int>();

	// Token: 0x04009103 RID: 37123
	private readonly HashSet<int> UnlockedBgIds = new HashSet<int>();

	// Token: 0x04009104 RID: 37124
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<EPhoneMsgServerRedDotType, HashSet<int>> LocalRedDotCache;

	// Token: 0x04009105 RID: 37125
	[Nullable(2)]
	private ServerStorageSet ServerRedDotSet;

	// Token: 0x04009106 RID: 37126
	public List<int> CurrentToBeNotifiedMsgArray = new List<int>();

	// Token: 0x04009107 RID: 37127
	public List<int> CurrentToBeNotifiedMsgInSmallHeadQueue = new List<int>();

	// Token: 0x04009108 RID: 37128
	public int CurrentShowingMsgIdInSmallHead;

	// Token: 0x04009109 RID: 37129
	public List<PhoneMsgInputTimeData> MsgInputTimeList = new List<PhoneMsgInputTimeData>();

	// Token: 0x0400910A RID: 37130
	private readonly Dictionary<int, float> AudioDurationMap = new Dictionary<int, float>();

	// Token: 0x0400910B RID: 37131
	private Dictionary<int, HashSet<int>> AllFilterTypeSetDict = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400910C RID: 37132
	private Dictionary<int, HashSet<int>> SelectedFilterSetDict = new Dictionary<int, HashSet<int>>();

	// Token: 0x0400910D RID: 37133
	private HashSet<int> SelectedFilterIdSet_Internal = new HashSet<int>();

	// Token: 0x0400910E RID: 37134
	public List<int> ChatPartnerIdList = new List<int>();

	// Token: 0x0400910F RID: 37135
	public Dictionary<int, List<int>> ChatPartnerId2ShortMessagesIdsDict = new Dictionary<int, List<int>>();

	// Token: 0x04009110 RID: 37136
	public Dictionary<int, PhoneMsgShortMsgData> Id2ShortMessagesDict = new Dictionary<int, PhoneMsgShortMsgData>();

	// Token: 0x04009111 RID: 37137
	[Nullable(2)]
	private List<int> UnreceivedPartnerList;

	// Token: 0x04009112 RID: 37138
	[Nullable(2)]
	private List<int> ReceivedUnreadPartnerList;

	// Token: 0x04009113 RID: 37139
	[Nullable(2)]
	private List<int> ReceivedReadPartnerList;

	// Token: 0x04009114 RID: 37140
	private int LastOpenBigPanelTime;

	// Token: 0x04009115 RID: 37141
	private long LatestShortMsgTime;
}
