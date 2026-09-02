using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x020012D6 RID: 4822
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssActivityData : ActivityBaseData
{
	// Token: 0x060081D3 RID: 33235 RVA: 0x00224F8C File Offset: 0x0022318C
	protected override void PhraseEx(ActivityData data)
	{
		this.InitAllRoleData();
		AbyssInfo abyssInfo = data.AbyssInfo;
		foreach (Aki.Protocol.AbyssPluginItemInfo data2 in abyssInfo.PluginItems)
		{
			this.UpdatePluginInfo(data2);
		}
		foreach (AbyssRoleInfo data3 in abyssInfo.RoleList)
		{
			this.UpdateRoleInfo(data3, false);
		}
		this.CurrentLikeCount = abyssInfo.LikeCount;
		this.PhraseChallengeData(abyssInfo.ChallengeInfos.ToArray<AbyssChallenge>());
		this.PhraseRewardInfo(abyssInfo.RewardInfo.ToArray<Aki.Protocol.AbyssRewardInfo>());
		this.LimitStartTime = Singleton<MathUtils>.Instance.LongToBigInt(abyssInfo.LimitBeginTime) / 1000L;
		this.LimitEndTime = Singleton<MathUtils>.Instance.LongToBigInt(abyssInfo.LimitEndTime) / 1000L;
	}

	// Token: 0x17000AEF RID: 2799
	// (get) Token: 0x060081D4 RID: 33236 RVA: 0x00225090 File Offset: 0x00223290
	public override bool RedPointShowState
	{
		get
		{
			return this.CheckIfInShowTime() && ((base.IsUnLock() && ModelBase<DangoAbyssModel>.Instance.GetAbyssDangoEnterNew()) || base.RedPointShowState);
		}
	}

	// Token: 0x060081D5 RID: 33237 RVA: 0x002250B8 File Offset: 0x002232B8
	protected override bool GetExDataFinishShowState()
	{
		foreach (int tab in this.GetRewardTypeTabList(2))
		{
			global::AbyssRewardInfo[] rewardInfoByRewardTypeAndTab = this.GetRewardInfoByRewardTypeAndTab(2, tab);
			for (int j = 0; j < rewardInfoByRewardTypeAndTab.Length; j++)
			{
				if (!rewardInfoByRewardTypeAndTab[j].GetHasGetReward())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060081D6 RID: 33238 RVA: 0x00225108 File Offset: 0x00223308
	public override bool GetExDataRedPointShowState()
	{
		bool rewardTypeIfHaveCanTakeReward = this.GetRewardTypeIfHaveCanTakeReward(EAbyssShopType.Common);
		bool rewardTypeIfHaveCanTakeReward2 = this.GetRewardTypeIfHaveCanTakeReward(EAbyssShopType.Limit);
		bool dangoNewRedDot = ModelBase<DangoAbyssModel>.Instance.GetDangoNewRedDot();
		return base.GetPreGuideQuestFinishState() && (rewardTypeIfHaveCanTakeReward || rewardTypeIfHaveCanTakeReward2 || dangoNewRedDot);
	}

	// Token: 0x060081D7 RID: 33239 RVA: 0x00225140 File Offset: 0x00223340
	public bool CheckInLimitTime()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		return serverTime >= (double)this.LimitStartTime && serverTime <= (double)this.LimitEndTime;
	}

	// Token: 0x060081D8 RID: 33240 RVA: 0x00225174 File Offset: 0x00223374
	public string GetRemainTimeText()
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double remainTime = Math.Max((double)this.LimitEndTime - serverTime, 1.0);
		return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(remainTime).CountDownText ?? "";
	}

	// Token: 0x060081D9 RID: 33241 RVA: 0x002251BD File Offset: 0x002233BD
	public bool EntranceRedDot()
	{
		return this.GetExDataRedPointShowState();
	}

	// Token: 0x060081DA RID: 33242 RVA: 0x002251C8 File Offset: 0x002233C8
	private void PhraseChallengeData(AbyssChallenge[] data)
	{
		foreach (AbyssChallenge abyssChallenge in data)
		{
			AbyssChallengeData abyssChallengeData;
			if (this.ChallengeDataMap.TryGetValue(abyssChallenge.ChallengeId, out abyssChallengeData))
			{
				abyssChallengeData.Phrase(abyssChallenge);
			}
			else
			{
				AbyssChallengeData abyssChallengeData2 = new AbyssChallengeData();
				abyssChallengeData2.Phrase(abyssChallenge);
				this.ChallengeDataMap[abyssChallengeData2.GetChallengeId()] = abyssChallengeData2;
			}
		}
	}

	// Token: 0x060081DB RID: 33243 RVA: 0x0022522C File Offset: 0x0022342C
	private void PhraseRewardInfo(Aki.Protocol.AbyssRewardInfo[] data)
	{
		foreach (Aki.Protocol.AbyssRewardInfo abyssRewardInfo in data)
		{
			global::AbyssRewardInfo abyssRewardInfo2;
			if (!this.RewardMap.TryGetValue(abyssRewardInfo.Id, out abyssRewardInfo2))
			{
				abyssRewardInfo2 = new global::AbyssRewardInfo();
				abyssRewardInfo2.Pharse(abyssRewardInfo);
				this.RewardMap[abyssRewardInfo.Id] = abyssRewardInfo2;
			}
			else
			{
				abyssRewardInfo2.Pharse(abyssRewardInfo);
			}
			this.RefreshRewardCategoryMap(abyssRewardInfo2);
		}
	}

	// Token: 0x060081DC RID: 33244 RVA: 0x00225294 File Offset: 0x00223494
	[NullableContext(2)]
	public global::AbyssRewardInfo GetRewardInfoById(int id)
	{
		global::AbyssRewardInfo result;
		if (this.RewardMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060081DD RID: 33245 RVA: 0x002252B4 File Offset: 0x002234B4
	public void OnRoleInfoUpdate(AbyssRoleInfoUpdateNotify notify)
	{
		foreach (AbyssRoleInfo data in notify.RoleList)
		{
			this.UpdateRoleInfo(data, false);
		}
	}

	// Token: 0x060081DE RID: 33246 RVA: 0x00225304 File Offset: 0x00223504
	public void OnAddRoleInfo(AbyssRoleAddNotify notify)
	{
		foreach (AbyssRoleInfo data in notify.RoleList)
		{
			this.UpdateRoleInfo(data, true);
		}
	}

	// Token: 0x060081DF RID: 33247 RVA: 0x00225354 File Offset: 0x00223554
	public void OnPluginInfoUpdate(AbyssPluginItemInfoUpdateNotify notify)
	{
		foreach (Aki.Protocol.AbyssPluginItemInfo data in notify.PluginItems)
		{
			this.UpdatePluginInfo(data);
		}
	}

	// Token: 0x060081E0 RID: 33248 RVA: 0x002253A4 File Offset: 0x002235A4
	public void OnPluginAdd(AbyssPluginItemAddNotify notify)
	{
		foreach (Aki.Protocol.AbyssPluginItemInfo data in notify.PluginItems)
		{
			this.UpdatePluginInfo(data);
		}
	}

	// Token: 0x060081E1 RID: 33249 RVA: 0x002253F4 File Offset: 0x002235F4
	public void OnPluginEquip(AbyssRoleInfo data)
	{
		this.UpdateRoleInfo(data, false);
	}

	// Token: 0x060081E2 RID: 33250 RVA: 0x00225400 File Offset: 0x00223600
	public void OnPluginRemove(AbyssPluginItemRemoveNotify notify)
	{
		foreach (int key in notify.IncrIds)
		{
			this.PluginItemMap.Remove(key);
		}
	}

	// Token: 0x060081E3 RID: 33251 RVA: 0x00225454 File Offset: 0x00223654
	public void OnUpdateRewardIdList(AbyssRewardsUpdateNotify notify)
	{
		foreach (Aki.Protocol.AbyssRewardInfo abyssRewardInfo in notify.RewardInfos)
		{
			global::AbyssRewardInfo abyssRewardInfo2;
			if (!this.RewardMap.TryGetValue(abyssRewardInfo.Id, out abyssRewardInfo2))
			{
				abyssRewardInfo2 = new global::AbyssRewardInfo();
				abyssRewardInfo2.Pharse(abyssRewardInfo);
				this.RewardMap[abyssRewardInfo.Id] = abyssRewardInfo2;
			}
			else
			{
				abyssRewardInfo2.Pharse(abyssRewardInfo);
			}
			this.RefreshRewardCategoryMap(abyssRewardInfo2);
		}
	}

	// Token: 0x060081E4 RID: 33252 RVA: 0x002254E0 File Offset: 0x002236E0
	public string GetRewardFinishProgressText()
	{
		int[] rewardTypeTabList = this.GetRewardTypeTabList(2);
		int num = 0;
		int num2 = 0;
		foreach (int tab in rewardTypeTabList)
		{
			foreach (global::AbyssRewardInfo abyssRewardInfo in this.GetRewardInfoByRewardTypeAndTab(2, tab))
			{
				num2++;
				if (abyssRewardInfo.GetHasGetReward() || abyssRewardInfo.GetCanGetReward())
				{
					num++;
				}
			}
		}
		return StringUtils.Format("{0}/{1}", new string[]
		{
			num.ToString(),
			num2.ToString()
		});
	}

	// Token: 0x060081E5 RID: 33253 RVA: 0x00225570 File Offset: 0x00223770
	public bool GetRewardTypeIfHaveCanTakeReward(EAbyssShopType rewardType)
	{
		if (rewardType == EAbyssShopType.Limit && !this.CheckInLimitTime())
		{
			return false;
		}
		foreach (int tab in this.GetRewardTypeTabList((int)rewardType))
		{
			foreach (global::AbyssRewardInfo abyssRewardInfo in this.GetRewardInfoByRewardTypeAndTab((int)rewardType, tab))
			{
				if (!abyssRewardInfo.GetHasGetReward() && abyssRewardInfo.GetCanGetReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060081E6 RID: 33254 RVA: 0x002255DC File Offset: 0x002237DC
	public int[] GetRewardTypeTabList(int rewardType)
	{
		List<int> list = new List<int>();
		Dictionary<int, List<global::AbyssRewardInfo>> dictionary;
		if (!this.RewardCategoryMap.TryGetValue(rewardType, out dictionary))
		{
			return list.ToArray();
		}
		foreach (KeyValuePair<int, List<global::AbyssRewardInfo>> keyValuePair in dictionary)
		{
			list.Add(keyValuePair.Key);
		}
		return list.ToArray();
	}

	// Token: 0x060081E7 RID: 33255 RVA: 0x00225654 File Offset: 0x00223854
	public global::AbyssRewardInfo[] GetRewardInfoByRewardTypeAndTab(int rewardType, int tab)
	{
		Dictionary<int, List<global::AbyssRewardInfo>> dictionary;
		if (!this.RewardCategoryMap.TryGetValue(rewardType, out dictionary))
		{
			return Array.Empty<global::AbyssRewardInfo>();
		}
		List<global::AbyssRewardInfo> list;
		if (!dictionary.TryGetValue(tab, out list))
		{
			return Array.Empty<global::AbyssRewardInfo>();
		}
		return list.ToArray();
	}

	// Token: 0x060081E8 RID: 33256 RVA: 0x00225690 File Offset: 0x00223890
	public IActivityRewardData[] GetTaskActivityRewardDataList(int rewardType, int tab)
	{
		global::AbyssRewardInfo[] rewardInfoByRewardTypeAndTab = this.GetRewardInfoByRewardTypeAndTab(rewardType, tab);
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		global::AbyssRewardInfo[] array = rewardInfoByRewardTypeAndTab;
		for (int i = 0; i < array.Length; i++)
		{
			IActivityRewardData activityRewardData = array[i].GetActivityRewardData();
			list.Add(activityRewardData);
		}
		list.Sort(new Comparison<IActivityRewardData>(this.SortReward));
		return list.ToArray();
	}

	// Token: 0x060081E9 RID: 33257 RVA: 0x002256E4 File Offset: 0x002238E4
	private int SortReward(IActivityRewardData a, IActivityRewardData b)
	{
		int rewardSort = this.GetRewardSort(b);
		int rewardSort2 = this.GetRewardSort(a);
		if (rewardSort == rewardSort2)
		{
			return a.Id.Value - b.Id.Value;
		}
		return rewardSort - rewardSort2;
	}

	// Token: 0x060081EA RID: 33258 RVA: 0x00225728 File Offset: 0x00223928
	private int GetRewardSort(IActivityRewardData data)
	{
		int result;
		switch (data.RewardState)
		{
		case EActivityRewardState.Disabled:
			result = 2;
			break;
		case EActivityRewardState.Enable:
			result = 3;
			break;
		case EActivityRewardState.Claimed:
			result = 1;
			break;
		default:
			result = 4;
			break;
		}
		return result;
	}

	// Token: 0x060081EB RID: 33259 RVA: 0x00225764 File Offset: 0x00223964
	private void RefreshRewardCategoryMap(global::AbyssRewardInfo data)
	{
		Dictionary<int, List<global::AbyssRewardInfo>> dictionary;
		if (!this.RewardCategoryMap.TryGetValue(data.GetRewardType(), out dictionary))
		{
			dictionary = new Dictionary<int, List<global::AbyssRewardInfo>>();
			this.RewardCategoryMap[data.GetRewardType()] = dictionary;
		}
		int tabId = data.GetTabId();
		List<global::AbyssRewardInfo> list;
		if (!dictionary.TryGetValue(tabId, out list))
		{
			list = new List<global::AbyssRewardInfo>();
			dictionary[tabId] = list;
		}
		bool flag = false;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].GetId() == data.GetId())
			{
				list[i] = data;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			list.Add(data);
		}
	}

	// Token: 0x060081EC RID: 33260 RVA: 0x00225801 File Offset: 0x00223A01
	public void OnUpdateUnlockChallengeIdList(AbyssChallengeUpdateNotify notify)
	{
		this.PhraseChallengeData(notify.ChallengeInfos.ToArray<AbyssChallenge>());
	}

	// Token: 0x060081ED RID: 33261 RVA: 0x00225814 File Offset: 0x00223A14
	public int[] GetUnLockChallengeIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			if (keyValuePair.Value.GetIfUnlock())
			{
				list.Add(keyValuePair.Value.GetChallengeId());
			}
		}
		return list.ToArray();
	}

	// Token: 0x060081EE RID: 33262 RVA: 0x0022588C File Offset: 0x00223A8C
	public int[] GetCanChallengeIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			if (keyValuePair.Value.GetCanChallenge())
			{
				list.Add(keyValuePair.Value.GetChallengeId());
			}
		}
		return list.ToArray();
	}

	// Token: 0x060081EF RID: 33263 RVA: 0x00225904 File Offset: 0x00223B04
	public int GetLikeCount()
	{
		return this.CurrentLikeCount;
	}

	// Token: 0x060081F0 RID: 33264 RVA: 0x0022590C File Offset: 0x00223B0C
	private void InitAllRoleData()
	{
		if (this.InitDangoState)
		{
			return;
		}
		this.InitDangoState = true;
		foreach (int id in ConfigBase<DangoAbyssConfig>.Instance.GetAbyssActivityData(base.Id).Value.DangoList())
		{
			AbyssDangoRoleData abyssDangoRoleData = new AbyssDangoRoleData();
			AbyssLittleRole value = ConfigBase<DangoAbyssConfig>.Instance.GetDangoRoleById(id).Value;
			abyssDangoRoleData.Init(value);
			this.RoleMap[value.Id] = abyssDangoRoleData;
		}
	}

	// Token: 0x060081F1 RID: 33265 RVA: 0x00225998 File Offset: 0x00223B98
	private void UpdateRoleInfo(AbyssRoleInfo data, bool isAdd = false)
	{
		this.UpdatePluginRoleInfo(data);
		AbyssDangoRoleData abyssDangoRoleData;
		if (!this.RoleMap.TryGetValue(data.Id, out abyssDangoRoleData))
		{
			abyssDangoRoleData = new AbyssDangoRoleData();
			this.RoleMap[data.Id] = abyssDangoRoleData;
		}
		if (isAdd)
		{
			ModelBase<DangoAbyssModel>.Instance.SetDangoIfNew(data.Id, true);
			ModelBase<DangoAbyssModel>.Instance.SetDangoFormationIfNew(data.Id, true);
		}
		RepeatedField<int> equipItems = data.EquipItems;
		List<int> list = new List<int>();
		foreach (int num in equipItems)
		{
			global::AbyssPluginItemInfo abyssPluginItemInfo;
			if (!this.PluginItemMap.TryGetValue(num, out abyssPluginItemInfo) && num > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "团子中含有未初始化的插件";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dangoId", data.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			list.Add((abyssPluginItemInfo != null) ? abyssPluginItemInfo.GetConfigId() : 0);
		}
		abyssDangoRoleData.Phrase(data, list.ToArray());
	}

	// Token: 0x060081F2 RID: 33266 RVA: 0x00225AA8 File Offset: 0x00223CA8
	private void UpdatePluginRoleInfo(AbyssRoleInfo data)
	{
		AbyssDangoRoleData abyssDangoRoleData;
		if (!this.RoleMap.TryGetValue(data.Id, out abyssDangoRoleData))
		{
			return;
		}
		RepeatedField<int> equipItems = data.EquipItems;
		int[] equipItems2 = abyssDangoRoleData.GetEquipItems();
		int count = equipItems.Count;
		for (int i = 0; i < count; i++)
		{
			int num = (i < equipItems2.Length) ? equipItems2[i] : 0;
			int num2 = equipItems[i];
			if (num != num2)
			{
				global::AbyssPluginItemInfo abyssPluginItemInfo;
				if (num2 > 0 && this.PluginItemMap.TryGetValue(num2, out abyssPluginItemInfo))
				{
					abyssPluginItemInfo.SetRoleId(data.Id);
				}
				bool flag = false;
				using (IEnumerator<int> enumerator = equipItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current == num)
						{
							flag = true;
							break;
						}
					}
				}
				global::AbyssPluginItemInfo abyssPluginItemInfo2;
				if (num > 0 && !flag && this.PluginItemMap.TryGetValue(num, out abyssPluginItemInfo2))
				{
					abyssPluginItemInfo2.SetRoleId(0);
				}
			}
		}
	}

	// Token: 0x060081F3 RID: 33267 RVA: 0x00225BA0 File Offset: 0x00223DA0
	[NullableContext(2)]
	public AbyssDangoRoleData GetRoleDataById(int id)
	{
		AbyssDangoRoleData result;
		if (this.RoleMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060081F4 RID: 33268 RVA: 0x00225BC0 File Offset: 0x00223DC0
	public AbyssDangoRoleData[] GetAllDangoList()
	{
		List<AbyssDangoRoleData> list = new List<AbyssDangoRoleData>();
		foreach (KeyValuePair<int, AbyssDangoRoleData> keyValuePair in this.RoleMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list.ToArray();
	}

	// Token: 0x060081F5 RID: 33269 RVA: 0x00225C28 File Offset: 0x00223E28
	public string GetAbyssWorldProgressText()
	{
		int num = 0;
		foreach (KeyValuePair<int, AbyssDangoRoleData> keyValuePair in this.RoleMap)
		{
			if (!keyValuePair.Value.GetIfLock())
			{
				num++;
			}
		}
		return StringUtils.Format("{0}/{1}", new string[]
		{
			num.ToString(),
			this.RoleMap.Count.ToString()
		});
	}

	// Token: 0x060081F6 RID: 33270 RVA: 0x00225CB8 File Offset: 0x00223EB8
	public float GetAbyssWorldProgressPercentage()
	{
		int num = 0;
		foreach (KeyValuePair<int, AbyssDangoRoleData> keyValuePair in this.RoleMap)
		{
			if (!keyValuePair.Value.GetIfLock())
			{
				num++;
			}
		}
		return (float)num / (float)this.RoleMap.Count;
	}

	// Token: 0x060081F7 RID: 33271 RVA: 0x00225D28 File Offset: 0x00223F28
	public string GetAbyssProgressText()
	{
		int num = this.GetCanChallengeIdList().Length;
		int count = this.ChallengeDataMap.Count;
		return StringUtils.Format("{0}/{1}", new string[]
		{
			num.ToString(),
			count.ToString()
		});
	}

	// Token: 0x060081F8 RID: 33272 RVA: 0x00225D70 File Offset: 0x00223F70
	public bool GetPreChallengeFinishState(int challengeId)
	{
		List<AbyssChallengeData> list = new List<AbyssChallengeData>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i].GetChallengeId() == challengeId)
			{
				return i == 0 || list[i - 1].GetIfPass();
			}
		}
		return false;
	}

	// Token: 0x060081F9 RID: 33273 RVA: 0x00225E10 File Offset: 0x00224010
	public int GetCurrentLastFinishChallengeId()
	{
		int num = 0;
		List<AbyssChallengeData> list = new List<AbyssChallengeData>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (i == 0)
			{
				num = list[i].GetChallengeId();
			}
			else if (list[i - 1].GetIfPass())
			{
				num = list[i].GetChallengeId();
			}
		}
		if (num == 0)
		{
			num = this.GetFirstUnlockChallengeId();
		}
		return num;
	}

	// Token: 0x060081FA RID: 33274 RVA: 0x00225EC8 File Offset: 0x002240C8
	public int GetCurrentCanSelectChallengeId()
	{
		int num = 0;
		List<AbyssChallengeData> list = new List<AbyssChallengeData>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (i == 0)
			{
				num = list[i].GetChallengeId();
			}
			else
			{
				AbyssChallengeData abyssChallengeData = list[i - 1];
				AbyssChallengeData challengeData = list[i];
				if (abyssChallengeData.GetIfPass() && this.GetChallengeIfCanEnterState(challengeData))
				{
					num = list[i].GetChallengeId();
				}
			}
		}
		if (num == 0)
		{
			num = this.GetFirstUnlockChallengeId();
		}
		return num;
	}

	// Token: 0x060081FB RID: 33275 RVA: 0x00225F98 File Offset: 0x00224198
	private bool GetChallengeIfCanEnterState(AbyssChallengeData challengeData)
	{
		bool canChallenge = challengeData.GetCanChallenge();
		bool preChallengeFinishState = this.GetPreChallengeFinishState(challengeData.GetChallengeId());
		bool conditionFinishState = challengeData.GetConditionFinishState();
		bool overUnlockTime = challengeData.GetOverUnlockTime();
		return canChallenge && preChallengeFinishState && conditionFinishState && overUnlockTime;
	}

	// Token: 0x060081FC RID: 33276 RVA: 0x00225FCC File Offset: 0x002241CC
	public int GetFirstUnlockChallengeId()
	{
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			if (keyValuePair.Value.GetIfUnlock())
			{
				return keyValuePair.Value.GetChallengeId();
			}
		}
		return 0;
	}

	// Token: 0x060081FD RID: 33277 RVA: 0x00226038 File Offset: 0x00224238
	private void UpdatePluginInfo(Aki.Protocol.AbyssPluginItemInfo data)
	{
		global::AbyssPluginItemInfo value;
		if (!this.PluginItemMap.TryGetValue(data.IncrId, out value))
		{
			value = new global::AbyssPluginItemInfo(data);
			this.PluginItemMap[data.IncrId] = value;
		}
	}

	// Token: 0x060081FE RID: 33278 RVA: 0x00226074 File Offset: 0x00224274
	[NullableContext(2)]
	public global::AbyssPluginItemInfo GetPluginItemInfoById(int incId)
	{
		global::AbyssPluginItemInfo result;
		if (this.PluginItemMap.TryGetValue(incId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060081FF RID: 33279 RVA: 0x00226094 File Offset: 0x00224294
	public global::AbyssPluginItemInfo[] GetPluginItemInfoAll()
	{
		List<global::AbyssPluginItemInfo> list = new List<global::AbyssPluginItemInfo>();
		foreach (KeyValuePair<int, global::AbyssPluginItemInfo> keyValuePair in this.PluginItemMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list.ToArray();
	}

	// Token: 0x06008200 RID: 33280 RVA: 0x002260FC File Offset: 0x002242FC
	public AbyssChallengeData[] GetAbyssChallengeDataList()
	{
		List<AbyssChallengeData> list = new List<AbyssChallengeData>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list.ToArray();
	}

	// Token: 0x06008201 RID: 33281 RVA: 0x00226164 File Offset: 0x00224364
	public AbyssChallengeData[] GetAbyssChallengeRankList()
	{
		List<AbyssChallengeData> list = new List<AbyssChallengeData>();
		foreach (KeyValuePair<int, AbyssChallengeData> keyValuePair in this.ChallengeDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		List<AbyssChallengeData> list2 = new List<AbyssChallengeData>();
		foreach (AbyssChallengeData abyssChallengeData in list)
		{
			int challengeId = abyssChallengeData.GetChallengeId();
			AbyssInst? dangoAbyssInstById = ConfigBase<DangoAbyssConfig>.Instance.GetDangoAbyssInstById(challengeId);
			if (dangoAbyssInstById != null && dangoAbyssInstById.Value.RankOpen)
			{
				list2.Add(abyssChallengeData);
			}
		}
		return list2.ToArray();
	}

	// Token: 0x06008202 RID: 33282 RVA: 0x00226244 File Offset: 0x00224444
	[NullableContext(2)]
	public AbyssChallengeData GetAbyssChallengeDataById(int id)
	{
		AbyssChallengeData result;
		if (this.ChallengeDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x04003DD8 RID: 15832
	private bool InitDangoState;

	// Token: 0x04003DD9 RID: 15833
	private readonly Dictionary<int, global::AbyssRewardInfo> RewardMap = new Dictionary<int, global::AbyssRewardInfo>();

	// Token: 0x04003DDA RID: 15834
	private readonly Dictionary<int, Dictionary<int, List<global::AbyssRewardInfo>>> RewardCategoryMap = new Dictionary<int, Dictionary<int, List<global::AbyssRewardInfo>>>();

	// Token: 0x04003DDB RID: 15835
	private readonly Dictionary<int, AbyssDangoRoleData> RoleMap = new Dictionary<int, AbyssDangoRoleData>();

	// Token: 0x04003DDC RID: 15836
	private readonly Dictionary<int, global::AbyssPluginItemInfo> PluginItemMap = new Dictionary<int, global::AbyssPluginItemInfo>();

	// Token: 0x04003DDD RID: 15837
	private readonly Dictionary<int, AbyssChallengeData> ChallengeDataMap = new Dictionary<int, AbyssChallengeData>();

	// Token: 0x04003DDE RID: 15838
	private int CurrentLikeCount;

	// Token: 0x04003DDF RID: 15839
	private long LimitStartTime;

	// Token: 0x04003DE0 RID: 15840
	private long LimitEndTime;
}
