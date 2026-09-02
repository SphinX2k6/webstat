using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;

// Token: 0x02001276 RID: 4726
[NullableContext(1)]
[Nullable(0)]
public class BossRushData : ActivityBaseData
{
	// Token: 0x06007E4F RID: 32335 RVA: 0x002160F4 File Offset: 0x002142F4
	protected override void PhraseEx(ActivityData data)
	{
		this.CurrentBuffs = data.BossRushActivityData.UnlockedBuffIndices.ToArray<int>();
		this.PhraseLevelInfo(this.CurrentBuffs, data.BossRushActivityData.BossRushLevelInfo.ToArray<BossRushLevelData>());
		this.CheckIfNewBossRushOpen();
		this.PhraseRewardInfo(data.BossRushActivityData.BossRushScoreScoreRewardInfo.ToArray<BossRushScoreRewardData>());
		this.RefreshTaskData(data.BossRushActivityData.ActivityTasks.ToArray<ActivityTask>());
		this.CurrentData = data;
		Singleton<EventSystem>.Instance.Emit(EEventName.BossRushDataUpdate);
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
		{
			Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, this.GetRewardViewData());
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.BossRefreshBossRushRewardRedDot, base.Id);
	}

	// Token: 0x06007E50 RID: 32336 RVA: 0x002161BC File Offset: 0x002143BC
	public void RefreshSingleTaskData(ActivityTask task)
	{
		global::ActivityTaskData activityTaskData;
		if (!this.TaskData.TryGetValue(task.Id, out activityTaskData))
		{
			activityTaskData = new global::ActivityTaskData();
			int tabId = ConfigBase<BossRushConfig>.Instance.GetBossRushTaskConfig(task.Id).TabId;
			List<global::ActivityTaskData> list;
			if (!this.TabTaskData.TryGetValue(tabId, out list))
			{
				list = new List<global::ActivityTaskData>();
			}
			list.Add(activityTaskData);
			this.TabTaskData[tabId] = list;
		}
		activityTaskData.Refresh(task, null);
		this.TaskData[task.Id] = activityTaskData;
	}

	// Token: 0x06007E51 RID: 32337 RVA: 0x00216244 File Offset: 0x00214444
	public void RefreshTaskData(ActivityTask[] tasks)
	{
		foreach (ActivityTask task in tasks)
		{
			this.RefreshSingleTaskData(task);
		}
	}

	// Token: 0x06007E52 RID: 32338 RVA: 0x0021626C File Offset: 0x0021446C
	public int GetFinishTaskCount()
	{
		int num = 0;
		foreach (global::ActivityTaskData activityTaskData in this.TaskData.Values)
		{
			if (activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed || activityTaskData.Status == EActivityTaskState.FinishedAndClaimed)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06007E53 RID: 32339 RVA: 0x002162D8 File Offset: 0x002144D8
	public int GetAllTaskCount()
	{
		return this.TaskData.Count;
	}

	// Token: 0x06007E54 RID: 32340 RVA: 0x002162E8 File Offset: 0x002144E8
	public List<BossRushTaskTab> GetBossRushAllTabData()
	{
		IEnumerable<BossRushTaskTab> bossRushTabListByActivityId = ConfigBase<BossRushConfig>.Instance.GetBossRushTabListByActivityId(base.Id);
		List<BossRushTaskTab> list = new List<BossRushTaskTab>();
		foreach (BossRushTaskTab item in bossRushTabListByActivityId)
		{
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06007E55 RID: 32341 RVA: 0x00216348 File Offset: 0x00214548
	public bool GetTabRedDotState(int tabId)
	{
		List<global::ActivityTaskData> list;
		if (!this.TabTaskData.TryGetValue(tabId, out list))
		{
			return false;
		}
		using (List<global::ActivityTaskData>.Enumerator enumerator = list.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007E56 RID: 32342 RVA: 0x002163B0 File Offset: 0x002145B0
	public void RebuildData()
	{
		if (this.CurrentData != null)
		{
			this.PhraseEx(this.CurrentData);
		}
	}

	// Token: 0x06007E57 RID: 32343 RVA: 0x002163C6 File Offset: 0x002145C6
	public void SetInsSelectedBuffIdMap(int levelId, int[] buffIds)
	{
		this.InsSelectedBuffIdMap[levelId] = buffIds;
	}

	// Token: 0x06007E58 RID: 32344 RVA: 0x002163D8 File Offset: 0x002145D8
	public int[] GetInsSelectedBuffId(int levelId)
	{
		int[] result;
		if (!this.InsSelectedBuffIdMap.TryGetValue(levelId, out result))
		{
			return new int[0];
		}
		return result;
	}

	// Token: 0x06007E59 RID: 32345 RVA: 0x00216400 File Offset: 0x00214600
	public void PhraseRewardInfo(BossRushScoreRewardData[] rewardData)
	{
		this.CurrentScoreRewardInfo = new List<IActivityRewardData>();
		foreach (BossRushScoreRewardData reward in rewardData)
		{
			IActivityRewardData item = this.CreateScoreReward(reward);
			this.CurrentScoreRewardInfo.Add(item);
		}
		if (this.CurrentData != null && this.CurrentData.BossRushActivityData != null)
		{
			this.CurrentData.BossRushActivityData.BossRushScoreScoreRewardInfo.Clear();
			this.CurrentData.BossRushActivityData.BossRushScoreScoreRewardInfo.AddRange(rewardData);
		}
	}

	// Token: 0x06007E5A RID: 32346 RVA: 0x00216480 File Offset: 0x00214680
	public void PhraseLevelInfo(int[] unlockBuffs, BossRushLevelData[] data)
	{
		this.CurrentLevelInfo = new List<BossRushLevelDetailInfo>();
		this.CurrentLevelRewardInfo = new List<IActivityRewardData>();
		this.CurrentLevelRewardInfoMap.Clear();
		foreach (BossRushLevelData bossRushLevelData in data)
		{
			BossRushLevelDetailInfo bossRushLevelDetailInfo = new BossRushLevelDetailInfo();
			bossRushLevelDetailInfo.Phrase(base.Id, bossRushLevelData, unlockBuffs);
			this.CurrentLevelInfo.Add(bossRushLevelDetailInfo);
			List<IActivityRewardData> list = this.CreateLevelReward(bossRushLevelDetailInfo, bossRushLevelData);
			this.CurrentLevelRewardInfo.AddRange(list);
			this.CurrentLevelRewardInfoMap[bossRushLevelDetailInfo.GetId()] = list;
		}
		this.CurrentLevelRewardInfo.Reverse();
		if (this.CurrentData != null && this.CurrentData.BossRushActivityData != null)
		{
			this.CurrentData.BossRushActivityData.BossRushLevelInfo.Clear();
			this.CurrentData.BossRushActivityData.BossRushLevelInfo.AddRange(data);
			this.CurrentData.BossRushActivityData.UnlockedBuffIndices.Clear();
			this.CurrentData.BossRushActivityData.UnlockedBuffIndices.AddRange(unlockBuffs);
		}
	}

	// Token: 0x06007E5B RID: 32347 RVA: 0x00216584 File Offset: 0x00214784
	[NullableContext(2)]
	public BossRushLevelDetailInfo GetBossRushLevelDetailInfoById(int instanceId)
	{
		foreach (BossRushLevelDetailInfo bossRushLevelDetailInfo in this.CurrentLevelInfo)
		{
			if (bossRushLevelDetailInfo.GetId() == instanceId)
			{
				return bossRushLevelDetailInfo;
			}
		}
		return null;
	}

	// Token: 0x06007E5C RID: 32348 RVA: 0x002165E0 File Offset: 0x002147E0
	public List<BossRushLevelDetailInfo> GetBossRushLevelDetailInfo()
	{
		return this.CurrentLevelInfo;
	}

	// Token: 0x06007E5D RID: 32349 RVA: 0x002165E8 File Offset: 0x002147E8
	public override bool GetExDataRedPointShowState()
	{
		return base.GetPreGuideQuestFinishState() && (this.NewOpenBossRushState || this.GetIfCanTakeReward());
	}

	// Token: 0x06007E5E RID: 32350 RVA: 0x00216604 File Offset: 0x00214804
	public bool GetNewUnlockState()
	{
		return this.NeedShowNewUnlock;
	}

	// Token: 0x06007E5F RID: 32351 RVA: 0x0021660C File Offset: 0x0021480C
	public bool GetNewBuffState()
	{
		return this.NeedShowNewBuff;
	}

	// Token: 0x06007E60 RID: 32352 RVA: 0x00216614 File Offset: 0x00214814
	private bool GetIfCanTakeReward()
	{
		using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.TaskData.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007E61 RID: 32353 RVA: 0x00216674 File Offset: 0x00214874
	private bool GetIfCanTakeRewardByLevelId(int levelId)
	{
		foreach (IActivityRewardData activityRewardData in this.CurrentLevelRewardInfo)
		{
			int? id = activityRewardData.Id;
			if ((id.GetValueOrDefault() == levelId & id != null) && activityRewardData.RewardState == EActivityRewardState.Enable)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06007E62 RID: 32354 RVA: 0x002166F0 File Offset: 0x002148F0
	public int[] GetUnlockedBuffIndices()
	{
		return this.CurrentBuffs;
	}

	// Token: 0x06007E63 RID: 32355 RVA: 0x002166F8 File Offset: 0x002148F8
	public void CheckIfNewBossRushOpen()
	{
		int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.Id, 0, 0);
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		this.NewOpenBossRushState = (currentOpenBossNum > activityCacheData);
		int activityCacheData2 = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.Id, 100, 0);
		this.NeedShowNewUnlock = (currentOpenBossNum > activityCacheData2);
		this.CheckIfNewBuffOpen();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007E64 RID: 32356 RVA: 0x00216774 File Offset: 0x00214974
	private void CheckIfNewBuffOpen()
	{
		this.NeedShowNewBuff = false;
		int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.Id, 200, 0);
		int currentCheckBuffIndex = this.GetCurrentCheckBuffIndex();
		if (currentCheckBuffIndex > activityCacheData && currentCheckBuffIndex > 0)
		{
			BossRushLevelDetailInfo bossRushLevelDetailInfo = this.GetBossRushLevelDetailInfo()[currentCheckBuffIndex - 1];
			if (bossRushLevelDetailInfo != null && bossRushLevelDetailInfo.GetConfig() != null)
			{
				int[] array = bossRushLevelDetailInfo.GetConfig().Value.UnlockBuff();
				this.NeedShowNewBuff = (array != null && array.Length != 0);
			}
		}
	}

	// Token: 0x06007E65 RID: 32357 RVA: 0x00216804 File Offset: 0x00214A04
	private int GetCurrentCheckBuffIndex()
	{
		int result = 0;
		List<BossRushLevelDetailInfo> bossRushLevelDetailInfo = this.GetBossRushLevelDetailInfo();
		int count = bossRushLevelDetailInfo.Count;
		for (int i = 0; i < count; i++)
		{
			if (bossRushLevelDetailInfo[i].GetUnLockState())
			{
				result = i;
			}
		}
		return result;
	}

	// Token: 0x06007E66 RID: 32358 RVA: 0x00216840 File Offset: 0x00214A40
	private int GetCurrentOpenBossNum()
	{
		int num = 0;
		using (List<BossRushLevelDetailInfo>.Enumerator enumerator = this.GetBossRushLevelDetailInfo().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetUnLockState())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06007E67 RID: 32359 RVA: 0x0021689C File Offset: 0x00214A9C
	public void CacheNewBuffUnlock()
	{
		this.NeedShowNewBuff = false;
		int currentCheckBuffIndex = this.GetCurrentCheckBuffIndex();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, base.Id, 200, 0, currentCheckBuffIndex);
		this.CheckIfNewBuffOpen();
	}

	// Token: 0x06007E68 RID: 32360 RVA: 0x002168DC File Offset: 0x00214ADC
	public void CacheNewUnlock()
	{
		this.NeedShowNewUnlock = false;
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, base.Id, 100, 0, currentOpenBossNum);
		this.CheckIfNewBossRushOpen();
	}

	// Token: 0x06007E69 RID: 32361 RVA: 0x00216918 File Offset: 0x00214B18
	public void CacheCurrentOpenBossNum()
	{
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, base.Id, 0, 0, currentOpenBossNum);
		this.CheckIfNewBossRushOpen();
	}

	// Token: 0x06007E6A RID: 32362 RVA: 0x0021694B File Offset: 0x00214B4B
	public bool EntranceRedDot()
	{
		return this.GetExDataRedPointShowState();
	}

	// Token: 0x06007E6B RID: 32363 RVA: 0x00216953 File Offset: 0x00214B53
	public bool HaveRewardCanTake()
	{
		return this.GetIfCanTakeReward();
	}

	// Token: 0x06007E6C RID: 32364 RVA: 0x0021695B File Offset: 0x00214B5B
	public bool HaveLevelRewardCanTake(int levelId)
	{
		return this.GetIfCanTakeRewardByLevelId(levelId);
	}

	// Token: 0x06007E6D RID: 32365 RVA: 0x00216964 File Offset: 0x00214B64
	public IActivityRewardViewData GetRewardPopUpViewData()
	{
		this.RebuildData();
		return this.GetRewardViewData();
	}

	// Token: 0x06007E6E RID: 32366 RVA: 0x00216974 File Offset: 0x00214B74
	public IActivityRewardViewData GetRewardViewData()
	{
		string tabTips = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("BossRushFullPoint", null) ?? "", new string[]
		{
			this.GetFullScore().ToString()
		});
		List<IActivityRewardData> dataList = (from a in this.CurrentLevelRewardInfo
		orderby this.GetRewardSort(a) descending, a.Id.GetValueOrDefault()
		select a).ToList<IActivityRewardData>();
		ActivityRewardDataPage item = new ActivityRewardDataPage
		{
			DataList = dataList,
			TabName = ConfigMultiTextLang.GetLocalTextNew("BossRushLevelRewardText", null),
			TabTips = " "
		};
		ActivityRewardDataPage activityRewardDataPage = new ActivityRewardDataPage();
		activityRewardDataPage.DataList = (from a in this.CurrentScoreRewardInfo
		orderby this.GetRewardSort(a), a.Id.GetValueOrDefault()
		select a).ToList<IActivityRewardData>();
		activityRewardDataPage.TabName = ConfigMultiTextLang.GetLocalTextNew("BossRushScoreRewardText", null);
		activityRewardDataPage.TabTips = tabTips;
		ActivityRewardDataPage item2 = activityRewardDataPage;
		return new ActivityRewardViewData
		{
			DataPageList = new List<IActivityRewardDataPage>
			{
				item,
				item2
			},
			Source = EActivityRewardSource.BossRush
		};
	}

	// Token: 0x06007E6F RID: 32367 RVA: 0x00216AAC File Offset: 0x00214CAC
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

	// Token: 0x06007E70 RID: 32368 RVA: 0x00216AE8 File Offset: 0x00214CE8
	public int GetFullScore()
	{
		int num = 0;
		foreach (BossRushLevelDetailInfo bossRushLevelDetailInfo in this.CurrentLevelInfo)
		{
			num += bossRushLevelDetailInfo.GetScore();
		}
		return num;
	}

	// Token: 0x06007E71 RID: 32369 RVA: 0x00216B40 File Offset: 0x00214D40
	private IActivityRewardData CreateScoreReward(BossRushScoreRewardData reward)
	{
		BossRushScore? bossRushScoreConfigById = ConfigBase<BossRushConfig>.Instance.GetBossRushScoreConfigById(reward.RewardId);
		if (bossRushScoreConfigById == null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 1);
			defaultInterpolatedStringHandler.AppendLiteral("BossRushScoreConfig not found for id: ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(reward.RewardId);
			throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		string nameText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("BossRushFullScoreTips", null) ?? "", new string[]
		{
			bossRushScoreConfigById.Value.Score.ToString()
		});
		return new ActivityRewardData
		{
			Id = new int?(reward.RewardId),
			NameText = nameText,
			RewardState = (EActivityRewardState)reward.RewardClaimStatus,
			ClickFunction = delegate
			{
				ControllerBase<BossRushController>.Instance.RequestGetBossRushReward(this.Id, reward.RewardId, BossRushRewardType.Score);
			},
			RewardList = this.GetRewardItems(bossRushScoreConfigById.Value.RewardId),
			RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)reward.RewardClaimStatus), null)
		};
	}

	// Token: 0x06007E72 RID: 32370 RVA: 0x00216C70 File Offset: 0x00214E70
	private string GetButtonText(int state)
	{
		string result = "";
		switch (state)
		{
		case 0:
			result = "PrefabTextItem_1443074454_Text";
			break;
		case 1:
			result = "CollectActivity_state_CanRecive";
			break;
		case 2:
			result = "CollectActivity_state_recived";
			break;
		}
		return result;
	}

	// Token: 0x06007E73 RID: 32371 RVA: 0x00216CB0 File Offset: 0x00214EB0
	private TItem[] GetRewardItems(int dropId)
	{
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(dropId);
		if (dropPackagePreview != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			}
		}
		return list.ToArray();
	}

	// Token: 0x06007E74 RID: 32372 RVA: 0x00216D34 File Offset: 0x00214F34
	private List<IActivityRewardData> CreateLevelReward(BossRushLevelDetailInfo levelInfo, BossRushLevelData levelData)
	{
		BossRushActivity? config = ConfigBase<BossRushConfig>.Instance.GetBossRushByActivityIdAndInstanceId(base.Id, levelData.InstId);
		if (config == null)
		{
			return new List<IActivityRewardData>();
		}
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		int index = 0;
		Action <>9__0;
		foreach (BossRushRewardClaimStatus bossRushRewardClaimStatus in levelData.LevelScoreRewardStatus)
		{
			IntPair intPair = config.Value.LevelScoreRewardList()[index];
			ActivityRewardData activityRewardData = new ActivityRewardData();
			activityRewardData.Id = new int?(levelInfo.GetId());
			activityRewardData.NameText = (ConfigMultiTextLang.GetLocalTextNew(config.Value.LevelRewardDesc, null) ?? "");
			activityRewardData.NameTextArgs = new string[]
			{
				intPair.Item1.ToString() ?? "",
				levelData.Score.ToString() ?? ""
			};
			activityRewardData.RewardState = (EActivityRewardState)bossRushRewardClaimStatus;
			ActivityRewardData activityRewardData2 = activityRewardData;
			Action clickFunction;
			if ((clickFunction = <>9__0) == null)
			{
				clickFunction = (<>9__0 = delegate()
				{
					int index2 = index;
					ControllerBase<BossRushController>.Instance.RequestGetBossRushLevelReward(this.Id, config.Value.Id, config.Value.InstId, index2);
				});
			}
			activityRewardData2.ClickFunction = clickFunction;
			activityRewardData.RewardList = this.GetRewardItems(intPair.Item2);
			activityRewardData.RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)bossRushRewardClaimStatus), null);
			ActivityRewardData item = activityRewardData;
			list.Add(item);
			int index3 = index;
			index = index3 + 1;
		}
		return list;
	}

	// Token: 0x06007E75 RID: 32373 RVA: 0x00216EF4 File Offset: 0x002150F4
	private IActivityRewardData CreateTaskReward(global::ActivityTaskData task)
	{
		EActivityTaskState status = task.Status;
		int current = task.Current;
		int target = task.Target;
		BossRushTaskConfig config = ConfigBase<BossRushConfig>.Instance.GetBossRushTaskConfig(task.Id);
		return new ActivityRewardData
		{
			Id = new int?(task.Id),
			NameText = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew(config.Title, null) ?? "", new string[]
			{
				target.ToString()
			}),
			NameTextArgs = new string[]
			{
				current.ToString() ?? "",
				target.ToString() ?? ""
			},
			RewardState = TaskStateToRewardStateResolver.Value[status],
			ClickFunction = delegate
			{
				ControllerBase<BossRushController>.Instance.RequestBossRushTaskReward(config.ActivityId);
			},
			RewardList = this.GetRewardItems(config.DropId),
			RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)TaskStateToRewardStateResolver.Value[status]), null)
		};
	}

	// Token: 0x06007E76 RID: 32374 RVA: 0x00217014 File Offset: 0x00215214
	public List<IActivityRewardData> GetTabRewardData(int tabId)
	{
		if (tabId == 0)
		{
			return new List<IActivityRewardData>();
		}
		List<global::ActivityTaskData> list;
		if (!this.TabTaskData.TryGetValue(tabId, out list))
		{
			return new List<IActivityRewardData>();
		}
		List<IActivityRewardData> list2 = new List<IActivityRewardData>();
		foreach (global::ActivityTaskData task in list)
		{
			IActivityRewardData item = this.CreateTaskReward(task);
			list2.Add(item);
		}
		return (from a in list2
		orderby this.GetRewardSort(a), a.Id.GetValueOrDefault()
		select a).ToList<IActivityRewardData>();
	}

	// Token: 0x06007E77 RID: 32375 RVA: 0x002170CC File Offset: 0x002152CC
	public List<IActivityRewardData> GetRewardByLevelId(int? levelId = null)
	{
		int valueOrDefault = levelId.GetValueOrDefault();
		List<IActivityRewardData> result;
		if (!this.CurrentLevelRewardInfoMap.TryGetValue(valueOrDefault, out result))
		{
			return new List<IActivityRewardData>();
		}
		return result;
	}

	// Token: 0x06007E78 RID: 32376 RVA: 0x002170F8 File Offset: 0x002152F8
	public void SetRewardStateClaimed(int levelId, int index)
	{
		List<IActivityRewardData> list;
		if (!this.CurrentLevelRewardInfoMap.TryGetValue(levelId, out list))
		{
			return;
		}
		if (index >= list.Count)
		{
			return;
		}
		IActivityRewardData activityRewardData = list[index];
		if (activityRewardData == null)
		{
			return;
		}
		activityRewardData.RewardState = EActivityRewardState.Claimed;
	}

	// Token: 0x06007E79 RID: 32377 RVA: 0x00217134 File Offset: 0x00215334
	protected override bool GetExDataFinishShowState()
	{
		using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.TaskData.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06007E7A RID: 32378 RVA: 0x00217194 File Offset: 0x00215394
	public int[] GetFinishAndUnclaimedTaskList()
	{
		List<int> list = new List<int>();
		foreach (global::ActivityTaskData activityTaskData in this.TaskData.Values)
		{
			if (activityTaskData.Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				list.Add(activityTaskData.Id);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04003C92 RID: 15506
	private const int UNLOCKLOCALKEY = 100;

	// Token: 0x04003C93 RID: 15507
	private const int UNLOCKBUFFKEY = 200;

	// Token: 0x04003C94 RID: 15508
	private List<IActivityRewardData> CurrentLevelRewardInfo = new List<IActivityRewardData>();

	// Token: 0x04003C95 RID: 15509
	private readonly Dictionary<int, List<IActivityRewardData>> CurrentLevelRewardInfoMap = new Dictionary<int, List<IActivityRewardData>>();

	// Token: 0x04003C96 RID: 15510
	private readonly Dictionary<int, global::ActivityTaskData> TaskData = new Dictionary<int, global::ActivityTaskData>();

	// Token: 0x04003C97 RID: 15511
	private readonly Dictionary<int, List<global::ActivityTaskData>> TabTaskData = new Dictionary<int, List<global::ActivityTaskData>>();

	// Token: 0x04003C98 RID: 15512
	private List<IActivityRewardData> CurrentScoreRewardInfo = new List<IActivityRewardData>();

	// Token: 0x04003C99 RID: 15513
	private bool NewOpenBossRushState;

	// Token: 0x04003C9A RID: 15514
	private bool NeedShowNewUnlock;

	// Token: 0x04003C9B RID: 15515
	private bool NeedShowNewBuff;

	// Token: 0x04003C9C RID: 15516
	private List<BossRushLevelDetailInfo> CurrentLevelInfo = new List<BossRushLevelDetailInfo>();

	// Token: 0x04003C9D RID: 15517
	private int[] CurrentBuffs = new int[0];

	// Token: 0x04003C9E RID: 15518
	[Nullable(2)]
	private ActivityData CurrentData;

	// Token: 0x04003C9F RID: 15519
	private readonly Dictionary<int, int[]> InsSelectedBuffIdMap = new Dictionary<int, int[]>();
}
