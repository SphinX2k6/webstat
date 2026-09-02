using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Activity.ActivityContent.Spring25;

// Token: 0x020015BD RID: 5565
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class Spring25Model : ModelBase<Spring25Model>
{
	// Token: 0x06009CE4 RID: 40164 RVA: 0x002914A5 File Offset: 0x0028F6A5
	protected override bool OnInit()
	{
		this.ConfigContext = new Spring25ConfigContext(this);
		this.ProtocolContext = new Spring25ProtocolContext(this);
		this.UiContext = new Spring25UiContext(this);
		return true;
	}

	// Token: 0x06009CE5 RID: 40165 RVA: 0x002914CC File Offset: 0x0028F6CC
	protected override bool OnClear()
	{
		this.ConfigContext.Dispose();
		this.ProtocolContext.Dispose();
		this.UiContext.Dispose();
		return true;
	}

	// Token: 0x17000D40 RID: 3392
	// (get) Token: 0x06009CE6 RID: 40166 RVA: 0x002914F0 File Offset: 0x0028F6F0
	public ActivityBaseData ActivityData
	{
		get
		{
			return this.ProtocolContext;
		}
	}

	// Token: 0x17000D41 RID: 3393
	// (get) Token: 0x06009CE7 RID: 40167 RVA: 0x002914F8 File Offset: 0x0028F6F8
	public int CurrentActivityId
	{
		get
		{
			return this.ProtocolContext.Id;
		}
	}

	// Token: 0x17000D42 RID: 3394
	// (get) Token: 0x06009CE8 RID: 40168 RVA: 0x00291505 File Offset: 0x0028F705
	public bool IsLetterListViewAvailable
	{
		get
		{
			return this.ProtocolContext.InvitedCount > 0;
		}
	}

	// Token: 0x17000D43 RID: 3395
	// (get) Token: 0x06009CE9 RID: 40169 RVA: 0x00291515 File Offset: 0x0028F715
	public bool IsInviteAvailableExternal
	{
		get
		{
			return this.ProtocolContext.IsInviteAvailable;
		}
	}

	// Token: 0x17000D44 RID: 3396
	// (get) Token: 0x06009CEA RID: 40170 RVA: 0x00291522 File Offset: 0x0028F722
	public bool IsAllInvited
	{
		get
		{
			return this.ConfigContext.SignCount == this.ProtocolContext.InvitedCount;
		}
	}

	// Token: 0x17000D45 RID: 3397
	// (get) Token: 0x06009CEB RID: 40171 RVA: 0x0029153C File Offset: 0x0028F73C
	public int HelpId
	{
		get
		{
			return this.ProtocolContext.GetHelpId();
		}
	}

	// Token: 0x17000D46 RID: 3398
	// (get) Token: 0x06009CEC RID: 40172 RVA: 0x00291549 File Offset: 0x0028F749
	public bool IsSkinRewarded
	{
		get
		{
			return this.ProtocolContext.IsSkinRewarded;
		}
	}

	// Token: 0x17000D47 RID: 3399
	// (get) Token: 0x06009CED RID: 40173 RVA: 0x00291558 File Offset: 0x0028F758
	public bool NeedOpenEnvelopeView
	{
		get
		{
			return this.UiContext.CurrentSignId != null;
		}
	}

	// Token: 0x17000D48 RID: 3400
	// (get) Token: 0x06009CEE RID: 40174 RVA: 0x00291578 File Offset: 0x0028F778
	public bool HasNewLetter
	{
		get
		{
			Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.Spring25FirstLetterClick, null);
			if (player == null)
			{
				return false;
			}
			foreach (KeyValuePair<int, bool> keyValuePair in player)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				if (!flag)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x17000D49 RID: 3401
	// (get) Token: 0x06009CEF RID: 40175 RVA: 0x002915E8 File Offset: 0x0028F7E8
	public bool HasAnyRewardExternal
	{
		get
		{
			return this.ProtocolContext.HasAnyReward;
		}
	}

	// Token: 0x17000D4A RID: 3402
	// (get) Token: 0x06009CF0 RID: 40176 RVA: 0x002915F5 File Offset: 0x0028F7F5
	public bool HasRedDot
	{
		get
		{
			return this.HasAnyRewardExternal || this.IsInviteAvailableExternal;
		}
	}

	// Token: 0x17000D4B RID: 3403
	// (get) Token: 0x06009CF1 RID: 40177 RVA: 0x00291607 File Offset: 0x0028F807
	public ESpring25InfoBottomState BottomStateInInfoView
	{
		get
		{
			if (this.IsSkinRewarded)
			{
				return ESpring25InfoBottomState.SkinRewarded;
			}
			if (this.ConfigContext.TaskCount != this.ProtocolContext.FinishTaskCount)
			{
				return ESpring25InfoBottomState.QuestNotAllDone;
			}
			if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.Spring25FirstTimeTaskAllDone, false))
			{
				return ESpring25InfoBottomState.QuestAllDoneFirstTime;
			}
			return ESpring25InfoBottomState.QuestAllDoneButNotFirst;
		}
	}

	// Token: 0x17000D4C RID: 3404
	// (get) Token: 0x06009CF2 RID: 40178 RVA: 0x0029163C File Offset: 0x0028F83C
	public string SharePhotoPath
	{
		get
		{
			SettleReward? config = ConfigSettleRewardByActivityId.GetConfig(this.CurrentActivityId, true);
			return ((ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male) ? ((config != null) ? config.GetValueOrDefault().MalePhotoPath : null) : ((config != null) ? config.GetValueOrDefault().FemalePhotoPath : null)) ?? string.Empty;
		}
	}

	// Token: 0x17000D4D RID: 3405
	// (get) Token: 0x06009CF3 RID: 40179 RVA: 0x002916A4 File Offset: 0x0028F8A4
	public bool NeedStartDialog
	{
		get
		{
			return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.Spring25FirstEnter, true) && this.ProtocolContext.InvitedCount == 0;
		}
	}

	// Token: 0x06009CF4 RID: 40180 RVA: 0x002916C0 File Offset: 0x0028F8C0
	public bool IsLetterNewBySignId(int id)
	{
		Dictionary<int, bool> player = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.Spring25FirstLetterClick, null);
		bool flag;
		return player != null && player.TryGetValue(id, out flag) && !flag;
	}

	// Token: 0x06009CF5 RID: 40181 RVA: 0x002916EC File Offset: 0x0028F8EC
	public void SetLetterClickedBySignId(int id, bool value)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.Spring25FirstLetterClick, null) ?? new Dictionary<int, bool>();
		dictionary[id] = value;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.Spring25FirstLetterClick, dictionary);
	}

	// Token: 0x06009CF6 RID: 40182 RVA: 0x0029171C File Offset: 0x0028F91C
	public void SyncSpringSignDrawRoleResponse(SpringSignDrawRoleResponse response)
	{
		int drawId = response.DrawId;
		this.UiContext.CurrentSignId = new int?(drawId);
		this.ProtocolContext.InvitedRoleSet.Add(drawId);
		this.ProtocolContext.CanInvite = false;
		foreach (KeyValuePair<int, ActivityTask> keyValuePair in this.ProtocolContext.TaskCache)
		{
			int num;
			ActivityTask activityTask;
			keyValuePair.Deconstruct(out num, out activityTask);
			int id = num;
			ActivityTask activityTask2 = activityTask;
			int taskThresholdByTaskId = this.ConfigContext.GetTaskThresholdByTaskId(id);
			if (activityTask2.Status == ActivityTaskState.ActivityTaskRunning && this.ProtocolContext.InvitedCount >= taskThresholdByTaskId)
			{
				activityTask2.Status = ActivityTaskState.ActivityTaskFinish;
			}
		}
		this.SetLetterClickedBySignId(drawId, false);
	}

	// Token: 0x06009CF7 RID: 40183 RVA: 0x002917EC File Offset: 0x0028F9EC
	public void SyncSpringSignDrawRewardResponse(int id)
	{
		this.ProtocolContext.SyncTaskStateByTaskId(id);
	}

	// Token: 0x06009CF8 RID: 40184 RVA: 0x002917FA File Offset: 0x0028F9FA
	public void SyncSpringSignSkinRewardResponse()
	{
		this.ProtocolContext.SyncSkinReward();
	}

	// Token: 0x06009CF9 RID: 40185 RVA: 0x00291808 File Offset: 0x0028FA08
	public void ResetCurrentSignId()
	{
		this.UiContext.CurrentSignId = null;
	}

	// Token: 0x06009CFA RID: 40186 RVA: 0x0029182C File Offset: 0x0028FA2C
	public void TrySetCurrentLetterSignId(int id)
	{
		int? currentLetterSignId = this.UiContext.CurrentLetterSignId;
		if (id == currentLetterSignId.GetValueOrDefault() & currentLetterSignId != null)
		{
			return;
		}
		this.UiContext.CurrentLetterSignId = new int?(id);
	}

	// Token: 0x06009CFB RID: 40187 RVA: 0x0029186C File Offset: 0x0028FA6C
	public void InitLetterSignIdForLetterListView()
	{
		int? num = null;
		foreach (int num2 in this.ProtocolContext.InvitedRoleSet)
		{
			if (num != null)
			{
				int? num3 = num;
				int num4 = num2;
				if (!(num3.GetValueOrDefault() > num4 & num3 != null))
				{
					continue;
				}
			}
			num = new int?(num2);
		}
		this.UiContext.CurrentLetterSignId = num;
	}

	// Token: 0x06009CFC RID: 40188 RVA: 0x002918FC File Offset: 0x0028FAFC
	public Spring25ActivitySubViewData BuildActivitySubViewData()
	{
		return new Spring25ActivitySubViewData
		{
			ProgressTextId = "Springsystem_1",
			RewardTextId = "Springsystem_2",
			ButtonTextId = "Springsystem_3",
			Current = this.ProtocolContext.InvitedCount.ToString(),
			TotalTextId = "Springsystem_5",
			TotalTextArg = this.ConfigContext.TaskCount.ToString(),
			IsMale = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Male),
			NeedStartDialog = this.NeedStartDialog
		};
	}

	// Token: 0x06009CFD RID: 40189 RVA: 0x0029198C File Offset: 0x0028FB8C
	public Spring25MainViewData BuildMainViewData(bool isOnlyRefresh = false)
	{
		Dictionary<ESpring25RoleType, bool> dictionary = new Dictionary<ESpring25RoleType, bool>();
		ESpring25RoleType value = (ESpring25RoleType)0;
		int num;
		foreach (KeyValuePair<int, SpringSign> keyValuePair in this.ConfigContext.SignCfgMap)
		{
			SpringSign springSign;
			keyValuePair.Deconstruct(out num, out springSign);
			int num2 = num;
			ESpring25RoleType? resourceTypeBySignId = this.ConfigContext.GetResourceTypeBySignId(num2);
			if (resourceTypeBySignId != null)
			{
				dictionary[resourceTypeBySignId.Value] = this.ProtocolContext.IsRoleInvitedById(num2);
				int? currentSignId = this.UiContext.CurrentSignId;
				num = num2;
				if ((currentSignId.GetValueOrDefault() == num & currentSignId != null) && !isOnlyRefresh)
				{
					value = resourceTypeBySignId.Value;
				}
			}
		}
		Spring25MainViewData spring25MainViewData = new Spring25MainViewData();
		Spring25ProtocolContext protocolContext = this.ProtocolContext;
		spring25MainViewData.TitleTextId = (((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().Title : null) ?? string.Empty);
		num = this.ProtocolContext.SignCountRemain;
		spring25MainViewData.InviteRemainCount = num.ToString();
		spring25MainViewData.CharacterInvitedMap = dictionary;
		spring25MainViewData.NewRoleType = new ESpring25RoleType?(value);
		return spring25MainViewData;
	}

	// Token: 0x06009CFE RID: 40190 RVA: 0x00291ABC File Offset: 0x0028FCBC
	public Spring25DialogueViewData BuildDialogueViewData()
	{
		int? currentSignId = this.UiContext.CurrentSignId;
		if (currentSignId == null)
		{
			return null;
		}
		Spring25DialogueSpineData[] array = this.BuildSpineDataBySignId(currentSignId.Value);
		List<Spring25DialogueChatData> chatDataList = this.BuildChatDataListInDialogViewBySignId(currentSignId.Value);
		return new Spring25DialogueViewData
		{
			IsOpening = false,
			LeftSpineData = array[0],
			RightSpineData = array[1],
			ChatDataList = chatDataList
		};
	}

	// Token: 0x06009CFF RID: 40191 RVA: 0x00291B24 File Offset: 0x0028FD24
	public Spring25DialogueViewData BuildStartDialogueViewData()
	{
		Spring25DialogueSpineData[] array = this.BuildStartSpineData();
		List<Spring25DialogueChatData> chatDataList = this.BuildStartChatDataListInDialogView();
		return new Spring25DialogueViewData
		{
			IsOpening = true,
			LeftSpineData = array[0],
			RightSpineData = array[1],
			ChatDataList = chatDataList
		};
	}

	// Token: 0x06009D00 RID: 40192 RVA: 0x00291B64 File Offset: 0x0028FD64
	public Spring25InfoViewData BuildInfoViewData()
	{
		int invitedCount = this.ProtocolContext.InvitedCount;
		int taskCount = this.ConfigContext.TaskCount;
		Spring25InfoViewData spring25InfoViewData = new Spring25InfoViewData();
		Spring25ProtocolContext protocolContext = this.ProtocolContext;
		spring25InfoViewData.TitleTextId = (((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().Title : null) ?? string.Empty);
		spring25InfoViewData.CurrentNum = invitedCount.ToString();
		spring25InfoViewData.TotalNumTextId = "Springsystem_5";
		spring25InfoViewData.TotalNumTextArg = taskCount.ToString();
		spring25InfoViewData.BottomState = this.BottomStateInInfoView;
		spring25InfoViewData.ContentList = this.BuildContentListInInfoView();
		spring25InfoViewData.ProgressList = this.BuildProgressListInInfoView();
		return spring25InfoViewData;
	}

	// Token: 0x06009D01 RID: 40193 RVA: 0x00291C0C File Offset: 0x0028FE0C
	public Spring25LetterListViewData BuildLetterListViewData()
	{
		string infoTextId = null;
		string titleTextId = null;
		int? currentLetterSignId = this.UiContext.CurrentLetterSignId;
		if (currentLetterSignId != null)
		{
			infoTextId = this.ConfigContext.GetLetterContentTextIdBySignId(currentLetterSignId.Value);
			titleTextId = this.ConfigContext.GetLetterTitleTextIdBySignId(currentLetterSignId.Value);
		}
		return new Spring25LetterListViewData
		{
			TabDataList = this.BuildTabDataListInLetterListView(),
			InfoTextId = infoTextId,
			TitleTextId = titleTextId
		};
	}

	// Token: 0x06009D02 RID: 40194 RVA: 0x00291C78 File Offset: 0x0028FE78
	public Spring25EnvelopeViewData BuildEnvelopeViewData()
	{
		int? currentSignId = this.UiContext.CurrentSignId;
		string titleTextId = (currentSignId != null) ? this.ConfigContext.GetLetterTitleTextIdBySignId(currentSignId.Value) : null;
		string infoTextId = (currentSignId != null) ? this.ConfigContext.GetLetterContentTextIdBySignId(currentSignId.Value) : null;
		return new Spring25EnvelopeViewData
		{
			TitleTextId = titleTextId,
			InfoTextId = infoTextId
		};
	}

	// Token: 0x06009D03 RID: 40195 RVA: 0x00291CE4 File Offset: 0x0028FEE4
	private unsafe List<Spring25InfoContentData> BuildContentListInInfoView()
	{
		List<Spring25InfoContentData> list = new List<Spring25InfoContentData>();
		foreach (KeyValuePair<int, SpringReward> keyValuePair in this.ConfigContext.TaskCfgMap)
		{
			int num;
			SpringReward springReward;
			keyValuePair.Deconstruct(out num, out springReward);
			SpringReward springReward2 = springReward;
			int id = springReward2.Id;
			ActivityTaskState taskStateByTaskId = this.ProtocolContext.GetTaskStateByTaskId(id);
			Spring25InfoContentData spring25InfoContentData = new Spring25InfoContentData();
			spring25InfoContentData.TaskId = id;
			spring25InfoContentData.State = taskStateByTaskId;
			spring25InfoContentData.ItemList = this.ProtocolContext.GetTaskRewardPreviewByTaskId(id);
			spring25InfoContentData.NameTextId = (this.ConfigContext.GetTaskNameTextIdByTaskId(id) ?? string.Empty);
			spring25InfoContentData.SubtitleTextId = "Text_ItemRecycleChosen_text";
			num = 2;
			List<string> list2 = new List<string>(num);
			CollectionsMarshal.SetCount<string>(list2, num);
			Span<string> span = CollectionsMarshal.AsSpan<string>(list2);
			int num2 = 0;
			*span[num2] = ((taskStateByTaskId < ActivityTaskState.ActivityTaskFinish) ? "0" : "1");
			num2++;
			*span[num2] = "1";
			spring25InfoContentData.SubtitleTextArgs = list2;
			spring25InfoContentData.IsDone = (taskStateByTaskId == ActivityTaskState.ActivityTaskTaken);
			spring25InfoContentData.CanReward = (taskStateByTaskId == ActivityTaskState.ActivityTaskFinish);
			spring25InfoContentData.RightTextId = ((taskStateByTaskId == ActivityTaskState.ActivityTaskRunning) ? "Text_NotFinished_Text" : null);
			Spring25InfoContentData item = spring25InfoContentData;
			list.Add(item);
		}
		list.Sort(delegate(Spring25InfoContentData a, Spring25InfoContentData b)
		{
			if (a.State == b.State)
			{
				return a.TaskId.CompareTo(b.TaskId);
			}
			if (a.State == ActivityTaskState.ActivityTaskFinish)
			{
				return -1;
			}
			if (b.State == ActivityTaskState.ActivityTaskFinish)
			{
				return 1;
			}
			if (a.State == ActivityTaskState.ActivityTaskRunning)
			{
				return -1;
			}
			return 1;
		});
		return list;
	}

	// Token: 0x06009D04 RID: 40196 RVA: 0x00291E70 File Offset: 0x00290070
	private List<Spring25InfoProgressData> BuildProgressListInInfoView()
	{
		List<Spring25InfoProgressData> list = new List<Spring25InfoProgressData>();
		int num = -1;
		for (int i = 0; i < this.ConfigContext.TaskCount; i++)
		{
			bool flag = i < this.ProtocolContext.InvitedCount;
			if (flag)
			{
				num = i;
			}
			list.Add(new Spring25InfoProgressData
			{
				IsLight = flag,
				IsBlink = false
			});
		}
		if (num != -1 && LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.Spring25FirstDoneTaskIndex, -1) < num)
		{
			Spring25InfoProgressData spring25InfoProgressData = list[num];
			spring25InfoProgressData.IsBlink = true;
			list[num] = spring25InfoProgressData;
		}
		return list;
	}

	// Token: 0x06009D05 RID: 40197 RVA: 0x00291EF4 File Offset: 0x002900F4
	private List<Spring25LetterListTabData> BuildTabDataListInLetterListView()
	{
		List<int> list = (from id in this.ProtocolContext.InvitedRoleSet
		orderby id
		select id).ToList<int>();
		List<Spring25LetterListTabData> list2 = new List<Spring25LetterListTabData>();
		foreach (int num in list)
		{
			List<Spring25LetterListTabData> list3 = list2;
			Spring25LetterListTabData spring25LetterListTabData = new Spring25LetterListTabData();
			spring25LetterListTabData.SignId = num;
			int num2 = num;
			int? currentLetterSignId = this.UiContext.CurrentLetterSignId;
			spring25LetterListTabData.IsChosen = (num2 == currentLetterSignId.GetValueOrDefault() & currentLetterSignId != null);
			spring25LetterListTabData.IsNew = this.IsLetterNewBySignId(num);
			spring25LetterListTabData.TexturePath = this.ConfigContext.GetLetterIconBySignId(num);
			spring25LetterListTabData.DescriptionTextId = this.ConfigContext.GetLetterTabTextIdBySignId(num);
			list3.Add(spring25LetterListTabData);
		}
		return list2;
	}

	// Token: 0x06009D06 RID: 40198 RVA: 0x00291FDC File Offset: 0x002901DC
	private List<Spring25DialogueChatData> BuildChatDataListInDialogViewByChatCfg(SpringChat? chatCfg)
	{
		List<Spring25DialogueChatData> list = new List<Spring25DialogueChatData>();
		if (chatCfg == null)
		{
			return list;
		}
		for (int i = 0; i < chatCfg.Value.ContentListLength; i++)
		{
			list.Add(new Spring25DialogueChatData
			{
				ContentTextId = chatCfg.Value.ContentList(i),
				Position = (ESpring25DialogType)chatCfg.Value.PosList(i),
				SpineAnimName = chatCfg.Value.AnimNameList(i)
			});
		}
		return list;
	}

	// Token: 0x06009D07 RID: 40199 RVA: 0x00292064 File Offset: 0x00290264
	private Spring25DialogueSpineData[] BuildSpineDataByChatCfg(SpringChat? chatCfg)
	{
		return new Spring25DialogueSpineData[]
		{
			new Spring25DialogueSpineData
			{
				AtlasPath = ((chatCfg != null) ? chatCfg.GetValueOrDefault().LeftSpineAtlas : null),
				SkeletonDataPath = ((chatCfg != null) ? chatCfg.GetValueOrDefault().LeftSpineSkeletonData : null)
			},
			new Spring25DialogueSpineData
			{
				AtlasPath = ((chatCfg != null) ? chatCfg.GetValueOrDefault().RightSpineAtlas : null),
				SkeletonDataPath = ((chatCfg != null) ? chatCfg.GetValueOrDefault().RightSpineSkeletonData : null)
			}
		};
	}

	// Token: 0x06009D08 RID: 40200 RVA: 0x0029210C File Offset: 0x0029030C
	private List<Spring25DialogueChatData> BuildChatDataListInDialogViewBySignId(int id)
	{
		SpringChat? chatConfigBySignId = this.ConfigContext.GetChatConfigBySignId(id, ModelBase<PlayerInfoModel>.Instance.GetPlayerGender());
		return this.BuildChatDataListInDialogViewByChatCfg(chatConfigBySignId);
	}

	// Token: 0x06009D09 RID: 40201 RVA: 0x00292138 File Offset: 0x00290338
	private List<Spring25DialogueChatData> BuildStartChatDataListInDialogView()
	{
		SpringChat? chatCfg = this.ConfigContext.StartChatCfgByGender(ModelBase<PlayerInfoModel>.Instance.GetPlayerGender());
		return this.BuildChatDataListInDialogViewByChatCfg(chatCfg);
	}

	// Token: 0x06009D0A RID: 40202 RVA: 0x00292164 File Offset: 0x00290364
	private Spring25DialogueSpineData[] BuildSpineDataBySignId(int id)
	{
		SpringChat? chatConfigBySignId = this.ConfigContext.GetChatConfigBySignId(id, ModelBase<PlayerInfoModel>.Instance.GetPlayerGender());
		return this.BuildSpineDataByChatCfg(chatConfigBySignId);
	}

	// Token: 0x06009D0B RID: 40203 RVA: 0x00292190 File Offset: 0x00290390
	private Spring25DialogueSpineData[] BuildStartSpineData()
	{
		SpringChat? chatCfg = this.ConfigContext.StartChatCfgByGender(ModelBase<PlayerInfoModel>.Instance.GetPlayerGender());
		return this.BuildSpineDataByChatCfg(chatCfg);
	}

	// Token: 0x0400480E RID: 18446
	private Spring25ConfigContext ConfigContext;

	// Token: 0x0400480F RID: 18447
	private Spring25ProtocolContext ProtocolContext;

	// Token: 0x04004810 RID: 18448
	private Spring25UiContext UiContext;
}
