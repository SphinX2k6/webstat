using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x02002AC0 RID: 10944
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsActivityData : ActivityBaseData
{
	// Token: 0x06015E4E RID: 89678 RVA: 0x006149D4 File Offset: 0x00612BD4
	protected override void OnInit(ActivityData data)
	{
		SurvivorsActivityConfig? survivorsActivityConfigByActivityId = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(base.Id);
		if (survivorsActivityConfigByActivityId == null)
		{
			return;
		}
		this.ActId = survivorsActivityConfigByActivityId.Value.Id;
		this.InitRewardTaskData();
		this.InitMilestoneReward();
		this.InitRole();
		this.InitWeapon();
		this.InitItem();
		this.InitTalentTree();
	}

	// Token: 0x06015E4F RID: 89679 RVA: 0x00614A38 File Offset: 0x00612C38
	protected override void PhraseEx(ActivityData data)
	{
		if (this.CheckIfInShowTime())
		{
			ModelBase<SurvivorsRogueModel>.Instance.SetCurrentActivityId(base.Id);
		}
		Aki.Protocol.SurvivorsActivityData survivorsActivityData = data.SurvivorsActivityData;
		if (survivorsActivityData == null)
		{
			return;
		}
		foreach (SurvivorsChallengeInfo survivorsChallengeInfo in survivorsActivityData.SurvivorsChallengeInfos)
		{
			this.LevelMap[survivorsChallengeInfo.LevelId] = survivorsChallengeInfo;
		}
		if (survivorsActivityData.NormalTaskData != null)
		{
			foreach (ActivityTask task in survivorsActivityData.NormalTaskData.ActivityTasks)
			{
				this.RefreshRewardTaskData(task);
			}
		}
		foreach (int milestoneRewardId in survivorsActivityData.ScoreTaskDatas)
		{
			this.RefreshGotMilestoneReward(milestoneRewardId);
		}
		foreach (int key in survivorsActivityData.UnlockRoleHandBooks)
		{
			this.RoleMap[key] = true;
		}
		foreach (int key2 in survivorsActivityData.UnlockWeaponHandBooks)
		{
			this.WeaponMap[key2] = true;
		}
		foreach (int key3 in survivorsActivityData.UnlockItemHandBooks)
		{
			this.ItemMap[key3] = true;
		}
		foreach (KeyValuePair<int, int> keyValuePair in survivorsActivityData.TalentSkillDict)
		{
			this.RefreshTalentTreeNode(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06015E50 RID: 89680 RVA: 0x00614C6C File Offset: 0x00612E6C
	public override bool GetExDataRedPointShowState()
	{
		return this.GetActivityRedDotState();
	}

	// Token: 0x06015E51 RID: 89681 RVA: 0x00614C74 File Offset: 0x00612E74
	public bool GetActivityRedDotState()
	{
		return this.GetActivityUnlockRedDotState() || this.GetRewardRedDotState() || this.GetLevelUnlockRedDotState();
	}

	// Token: 0x06015E52 RID: 89682 RVA: 0x00614C90 File Offset: 0x00612E90
	public bool GetActivityUnlockRedDotState()
	{
		foreach (SurvivorsChallengeInfo survivorsChallengeInfo in this.LevelMap.Values)
		{
			ModeInfo normalModeInfos = survivorsChallengeInfo.NormalModeInfos;
			if (normalModeInfos != null && normalModeInfos.IsFinish)
			{
				return false;
			}
		}
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 0, 0, 0) == 0;
	}

	// Token: 0x06015E53 RID: 89683 RVA: 0x00614D10 File Offset: 0x00612F10
	public bool SaveCacheState(ESurvivorsActivitySaveFlags saveFlag, int key1, int key2 = 0, int saveValue = 1)
	{
		if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)saveFlag, key1, key2) == saveValue)
		{
			return true;
		}
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, (int)saveFlag, key1, key2, saveValue);
		return false;
	}

	// Token: 0x06015E54 RID: 89684 RVA: 0x00614D44 File Offset: 0x00612F44
	public void RefreshActivityRedDot()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06015E55 RID: 89685 RVA: 0x00614D5C File Offset: 0x00612F5C
	public void OnQuestStateChange(int questId, QuestState state)
	{
		int[] preShowGuideQuestArray = this.LocalConfig.Value.GetPreShowGuideQuestArray();
		bool flag = false;
		for (int i = 0; i < preShowGuideQuestArray.Length; i++)
		{
			if (preShowGuideQuestArray[i] == questId)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		if (state < QuestState.Finish)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x17001C6D RID: 7277
	// (get) Token: 0x06015E56 RID: 89686 RVA: 0x00614DB6 File Offset: 0x00612FB6
	// (set) Token: 0x06015E57 RID: 89687 RVA: 0x00614DD0 File Offset: 0x00612FD0
	public bool NotTipsEnterInst
	{
		get
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 6, 0, 0) == 1;
		}
		set
		{
			int saveValue = (value > false) ? 1 : 0;
			this.SaveCacheState(ESurvivorsActivitySaveFlags.NotTipsEnterInst, 0, 0, saveValue);
		}
	}

	// Token: 0x06015E58 RID: 89688 RVA: 0x00614DF0 File Offset: 0x00612FF0
	private void InitRewardTaskData()
	{
		foreach (SurvivorsTask survivorsTask in ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTaskByActId(this.ActId))
		{
			this.CreateRewardTaskData(survivorsTask.Id);
		}
	}

	// Token: 0x06015E59 RID: 89689 RVA: 0x00614E50 File Offset: 0x00613050
	public void RefreshRewardTaskData(ActivityTask task)
	{
		global::ActivityTaskData activityTaskData;
		this.RewardTaskMap.TryGetValue(task.Id, out activityTaskData);
		global::ActivityTaskData activityTaskData2;
		if (activityTaskData == null)
		{
			activityTaskData2 = this.CreateRewardTaskData(task.Id);
		}
		else
		{
			activityTaskData2 = activityTaskData;
		}
		activityTaskData2.Refresh(task, null);
	}

	// Token: 0x06015E5A RID: 89690 RVA: 0x00614E90 File Offset: 0x00613090
	private global::ActivityTaskData CreateRewardTaskData(int taskId)
	{
		global::ActivityTaskData activityTaskData = new global::ActivityTaskData();
		SurvivorsTask? survivorsTask = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTask(taskId);
		int num = (survivorsTask != null) ? survivorsTask.GetValueOrDefault().PageType : 0;
		activityTaskData.TypeId = num;
		activityTaskData.Id = taskId;
		this.RewardTaskMap[taskId] = activityTaskData;
		List<int> list;
		if (!this.RewardType2TaskIdList.TryGetValue(num, out list))
		{
			list = new List<int>();
			this.RewardType2TaskIdList[num] = list;
		}
		list.Add(taskId);
		return activityTaskData;
	}

	// Token: 0x06015E5B RID: 89691 RVA: 0x00614F12 File Offset: 0x00613112
	public void SetRewardTaskDataDone(int taskId)
	{
		this.RewardTaskMap[taskId].Status = EActivityTaskState.FinishedAndClaimed;
	}

	// Token: 0x06015E5C RID: 89692 RVA: 0x00614F28 File Offset: 0x00613128
	public int GetFinishedRewardTaskCount()
	{
		int num = 0;
		using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.RewardTaskMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EActivityTaskState.FinishedAndClaimed)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06015E5D RID: 89693 RVA: 0x00614F88 File Offset: 0x00613188
	public List<global::ActivityTaskData> GetRewardTaskDataListByTypeId(int typeId)
	{
		List<global::ActivityTaskData> list = new List<global::ActivityTaskData>();
		List<int> list2;
		if (!this.RewardType2TaskIdList.TryGetValue(typeId, out list2))
		{
			return list;
		}
		foreach (int key in list2)
		{
			global::ActivityTaskData item = this.RewardTaskMap[key];
			list.Add(item);
		}
		List<global::ActivityTaskData> list3 = list;
		Comparison<global::ActivityTaskData> comparison;
		if ((comparison = global::SurvivorsActivityData.<>O.<0>__SortTaskData) == null)
		{
			comparison = (global::SurvivorsActivityData.<>O.<0>__SortTaskData = new Comparison<global::ActivityTaskData>(global::SurvivorsActivityData.SortTaskData));
		}
		list3.Sort(comparison);
		return list;
	}

	// Token: 0x06015E5E RID: 89694 RVA: 0x00615020 File Offset: 0x00613220
	public bool GetTypeRedDotState(int typeId)
	{
		List<int> list;
		if (!this.RewardType2TaskIdList.TryGetValue(typeId, out list))
		{
			return false;
		}
		foreach (int key in list)
		{
			if (this.RewardTaskMap[key].Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015E5F RID: 89695 RVA: 0x00615094 File Offset: 0x00613294
	public bool GetRewardRedDotState()
	{
		if (this.GetAllAvailableGetMilestoneRewardIds().Count > 0)
		{
			return true;
		}
		using (Dictionary<int, global::ActivityTaskData>.ValueCollection.Enumerator enumerator = this.RewardTaskMap.Values.GetEnumerator())
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

	// Token: 0x06015E60 RID: 89696 RVA: 0x00615104 File Offset: 0x00613304
	private static int SortTaskData(global::ActivityTaskData a, global::ActivityTaskData b)
	{
		if (a.Status != b.Status)
		{
			return a.Status - b.Status;
		}
		SurvivorsTask? survivorsTask = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTask(a.Id);
		SurvivorsTask? survivorsTask2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsTask(b.Id);
		if (survivorsTask.Value.SortId == survivorsTask2.Value.SortId)
		{
			return a.Id - b.Id;
		}
		return survivorsTask.Value.SortId - survivorsTask2.Value.SortId;
	}

	// Token: 0x06015E61 RID: 89697 RVA: 0x0061519C File Offset: 0x0061339C
	public List<int> GetAvailableGetTaskRewardIdsByType(int typeId)
	{
		List<int> list = new List<int>();
		List<int> list2;
		if (!this.RewardType2TaskIdList.TryGetValue(typeId, out list2))
		{
			return list;
		}
		foreach (int num in list2)
		{
			if (this.RewardTaskMap[num].Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				list.Add(num);
			}
		}
		return list;
	}

	// Token: 0x06015E62 RID: 89698 RVA: 0x00615218 File Offset: 0x00613418
	private void InitMilestoneReward()
	{
		this.MilestoneItemId = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(base.Id).Value.ScoreItemId;
		this.MilestoneRewardMap.Clear();
		int num = -1;
		foreach (SurvivorsScoreReward survivorsScoreReward in ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsScoreRewardByActId(this.ActId))
		{
			SurvivorsMilestoneData value = new SurvivorsMilestoneData(survivorsScoreReward.Id, survivorsScoreReward.Index, survivorsScoreReward.Score, survivorsScoreReward.DropId, false);
			this.MilestoneRewardMap[survivorsScoreReward.Id] = value;
			if (survivorsScoreReward.Score > num)
			{
				num = survivorsScoreReward.Score;
			}
		}
		this.MilestoneRewardMaxCount = num;
	}

	// Token: 0x06015E63 RID: 89699 RVA: 0x006152F0 File Offset: 0x006134F0
	public void RefreshGotMilestoneReward(int milestoneRewardId)
	{
		SurvivorsMilestoneData survivorsMilestoneData;
		if (!this.MilestoneRewardMap.TryGetValue(milestoneRewardId, out survivorsMilestoneData))
		{
			return;
		}
		survivorsMilestoneData.IsGot = true;
	}

	// Token: 0x06015E64 RID: 89700 RVA: 0x00615315 File Offset: 0x00613515
	public int GetMilestoneItemCount()
	{
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.MilestoneItemId, 0);
	}

	// Token: 0x06015E65 RID: 89701 RVA: 0x00615328 File Offset: 0x00613528
	public List<SurvivorsMilestoneData> GetAllMilestoneReward()
	{
		List<SurvivorsMilestoneData> list = new List<SurvivorsMilestoneData>(this.MilestoneRewardMap.Values);
		list.Sort((SurvivorsMilestoneData a, SurvivorsMilestoneData b) => a.SortId - b.SortId);
		return list;
	}

	// Token: 0x06015E66 RID: 89702 RVA: 0x00615360 File Offset: 0x00613560
	public List<int> GetAllAvailableGetMilestoneRewardIds()
	{
		List<int> list = new List<int>();
		int milestoneItemCount = this.GetMilestoneItemCount();
		foreach (KeyValuePair<int, SurvivorsMilestoneData> keyValuePair in this.MilestoneRewardMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value.IsReceivable(milestoneItemCount))
			{
				list.Add(key);
			}
		}
		return list;
	}

	// Token: 0x06015E67 RID: 89703 RVA: 0x006153DC File Offset: 0x006135DC
	public List<int> GetAllLevelId()
	{
		List<int> list = new List<int>(this.LevelMap.Keys);
		list.Sort((int a, int b) => a - b);
		return list;
	}

	// Token: 0x06015E68 RID: 89704 RVA: 0x00615414 File Offset: 0x00613614
	[NullableContext(2)]
	public ISurvivorsLevelInfo GetCurrentLevelInfoByLevelId(int levelId)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		if (!this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo))
		{
			return null;
		}
		bool flag = this.IsEndlessMode(levelId);
		if (flag && survivorsChallengeInfo.InfiniteModeInfos == null)
		{
			return null;
		}
		return new SurvivorsLevelInfo
		{
			LevelId = survivorsChallengeInfo.LevelId,
			OpenTime = survivorsChallengeInfo.OpenTime,
			IsEndlessMode = flag,
			Info = (flag ? survivorsChallengeInfo.InfiniteModeInfos : survivorsChallengeInfo.NormalModeInfos)
		};
	}

	// Token: 0x06015E69 RID: 89705 RVA: 0x00615483 File Offset: 0x00613683
	public bool IsEndlessMode(int levelId)
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 3, levelId, 0) == 1;
	}

	// Token: 0x06015E6A RID: 89706 RVA: 0x0061549C File Offset: 0x0061369C
	public bool GetLevelUnlockRedDotState()
	{
		if (!base.GetPreGuideQuestFinishState())
		{
			return false;
		}
		foreach (SurvivorsChallengeInfo levelInfo in this.LevelMap.Values)
		{
			if (this.GetLevelNewUnlock(levelInfo))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06015E6B RID: 89707 RVA: 0x00615508 File Offset: 0x00613708
	private bool GetLevelNewUnlock(SurvivorsChallengeInfo levelInfo)
	{
		ModeInfo normalModeInfos = levelInfo.NormalModeInfos;
		if (normalModeInfos != null && this.GetLevelUnlockState(levelInfo.LevelId, false) && !normalModeInfos.IsFinish && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, levelInfo.LevelId, 0) == 0)
		{
			return true;
		}
		ModeInfo infiniteModeInfos = levelInfo.InfiniteModeInfos;
		return infiniteModeInfos != null && this.GetLevelUnlockState(levelInfo.LevelId, true) && infiniteModeInfos.KillMonsterCount == 0 && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, levelInfo.LevelId, 1) == 0;
	}

	// Token: 0x06015E6C RID: 89708 RVA: 0x00615594 File Offset: 0x00613794
	public bool TryRemoveLevelNewUnlock(int levelId, bool isEndless)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		if (!this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo))
		{
			return false;
		}
		if (isEndless)
		{
			if (this.GetLevelUnlockState(levelId, true))
			{
				return !this.SaveCacheState(ESurvivorsActivitySaveFlags.NewLevel, levelId, 1, 1);
			}
		}
		else if (this.GetLevelUnlockState(levelId, false))
		{
			return !this.SaveCacheState(ESurvivorsActivitySaveFlags.NewLevel, levelId, 0, 1);
		}
		return false;
	}

	// Token: 0x06015E6D RID: 89709 RVA: 0x006155E8 File Offset: 0x006137E8
	public bool TryRemoveLevelNewFinished(int levelId)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		if (!this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo))
		{
			return false;
		}
		ModeInfo normalModeInfos = survivorsChallengeInfo.NormalModeInfos;
		return normalModeInfos != null && normalModeInfos.IsFinish && !this.SaveCacheState(ESurvivorsActivitySaveFlags.LevelFinishedCheck, levelId, 0, 1);
	}

	// Token: 0x06015E6E RID: 89710 RVA: 0x0061562C File Offset: 0x0061382C
	public bool IsEndlessFirstOpenCheck()
	{
		bool flag = false;
		foreach (SurvivorsChallengeInfo survivorsChallengeInfo in this.LevelMap.Values)
		{
			if (this.GetLevelUnlockState(survivorsChallengeInfo.LevelId, true))
			{
				flag = true;
				break;
			}
		}
		return flag && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 4, 0, 0) == 0;
	}

	// Token: 0x06015E6F RID: 89711 RVA: 0x006156B0 File Offset: 0x006138B0
	[NullableContext(2)]
	public string GetLevelUnlockRemainTime(int levelId)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		if (!this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo))
		{
			return null;
		}
		long openTime = survivorsChallengeInfo.OpenTime;
		if ((double)openTime <= Singleton<TimeUtil>.Instance.GetServerTime())
		{
			return null;
		}
		return Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)openTime - Singleton<TimeUtil>.Instance.GetServerTime()).CountDownText;
	}

	// Token: 0x06015E70 RID: 89712 RVA: 0x00615704 File Offset: 0x00613904
	public bool GetLevelTimeUnlockState(int levelId)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		return this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo) && (double)survivorsChallengeInfo.OpenTime <= Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x06015E71 RID: 89713 RVA: 0x0061573C File Offset: 0x0061393C
	public bool GetLevelUnlockState(int levelId, bool isInfinite)
	{
		SurvivorsChallengeInfo survivorsChallengeInfo;
		if (!this.LevelMap.TryGetValue(levelId, out survivorsChallengeInfo))
		{
			return false;
		}
		bool isUnlock;
		if (isInfinite && survivorsChallengeInfo.InfiniteModeInfos != null)
		{
			isUnlock = survivorsChallengeInfo.InfiniteModeInfos.IsUnlock;
		}
		else
		{
			isUnlock = survivorsChallengeInfo.NormalModeInfos.IsUnlock;
		}
		return isUnlock && (double)survivorsChallengeInfo.OpenTime <= Singleton<TimeUtil>.Instance.GetServerTime();
	}

	// Token: 0x06015E72 RID: 89714 RVA: 0x006157A0 File Offset: 0x006139A0
	public int GetFocusLevelId()
	{
		List<int> allLevelId = this.GetAllLevelId();
		int result = allLevelId[0];
		foreach (int num in allLevelId)
		{
			SurvivorsChallengeInfo survivorsChallengeInfo = this.LevelMap[num];
			if (this.GetLevelNewUnlock(survivorsChallengeInfo))
			{
				result = num;
				break;
			}
			ISurvivorsLevelInfo currentLevelInfoByLevelId = this.GetCurrentLevelInfoByLevelId(num);
			if (this.GetLevelUnlockState(survivorsChallengeInfo.LevelId, currentLevelInfoByLevelId.IsEndlessMode))
			{
				result = num;
				if (currentLevelInfoByLevelId.Info.WaveId == 0)
				{
					result = num;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06015E73 RID: 89715 RVA: 0x00615844 File Offset: 0x00613A44
	public ESurvivorsLevelDiff GetCurrentUnlockDiffId()
	{
		int[] areaBoundLevelIdArray = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsActivityConfigByActivityId(base.Id).Value.GetAreaBoundLevelIdArray();
		ESurvivorsLevelDiff esurvivorsLevelDiff = ESurvivorsLevelDiff.Easy;
		for (int i = 1; i < areaBoundLevelIdArray.Length; i++)
		{
			int key = areaBoundLevelIdArray[i];
			SurvivorsChallengeInfo survivorsChallengeInfo = this.LevelMap[key];
			if (!this.GetLevelUnlockState(survivorsChallengeInfo.LevelId, false) || this.GetLevelNewUnlock(survivorsChallengeInfo))
			{
				break;
			}
			esurvivorsLevelDiff++;
		}
		return esurvivorsLevelDiff;
	}

	// Token: 0x17001C6E RID: 7278
	// (get) Token: 0x06015E74 RID: 89716 RVA: 0x006158BC File Offset: 0x00613ABC
	public List<SurvivorsTalentAreaData> AreaDataList
	{
		get
		{
			List<SurvivorsTalentAreaData> list = new List<SurvivorsTalentAreaData>();
			foreach (KeyValuePair<int, SurvivorsTalentAreaData> keyValuePair in this.TalentAreaMap)
			{
				bool key = keyValuePair.Key != 0;
				SurvivorsTalentAreaData value = keyValuePair.Value;
				if (key)
				{
					list.Add(value);
				}
			}
			return list;
		}
	}

	// Token: 0x06015E75 RID: 89717 RVA: 0x00615928 File Offset: 0x00613B28
	public bool GetTalentTreeRed()
	{
		bool result = false;
		foreach (int key in this.TalentNodeMap.Keys)
		{
			SurvivorsTalentNode survivorsTalentNode;
			if (this.TalentNodeMap.TryGetValue(key, out survivorsTalentNode))
			{
				bool flag = this.IsEnoughUpgradeNode(survivorsTalentNode);
				if (survivorsTalentNode.Status == ESurvivorsTalentNodeStatus.CanUpgrade && flag)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06015E76 RID: 89718 RVA: 0x006159A8 File Offset: 0x00613BA8
	[NullableContext(2)]
	public SurvivorsTalentNode GetTalentNodeById(int nodeId)
	{
		SurvivorsTalentNode result;
		this.TalentNodeMap.TryGetValue(nodeId, out result);
		return result;
	}

	// Token: 0x06015E77 RID: 89719 RVA: 0x006159C8 File Offset: 0x00613BC8
	[NullableContext(2)]
	public SurvivorsTalentNode GetFirstTalentNode()
	{
		SurvivorsTalentNode result = null;
		foreach (SurvivorsTalentNode survivorsTalentNode in this.TalentNodeMap.Values)
		{
			if (survivorsTalentNode.AreaId == 0)
			{
				result = survivorsTalentNode;
				break;
			}
		}
		return result;
	}

	// Token: 0x06015E78 RID: 89720 RVA: 0x00615A28 File Offset: 0x00613C28
	public void RefreshTalentTreeNode(int nodeId, int status)
	{
		SurvivorsTalentNode talentNodeById = this.GetTalentNodeById(nodeId);
		if (talentNodeById != null)
		{
			talentNodeById.Status = (ESurvivorsTalentNodeStatus)status;
		}
	}

	// Token: 0x06015E79 RID: 89721 RVA: 0x00615A48 File Offset: 0x00613C48
	public bool IsPreNodeUpgraded(SurvivorsTalentNode node)
	{
		bool flag = false;
		if (node.PreNodeIds == null || node.PreNodeIds.Length == 0)
		{
			flag = true;
		}
		if (!flag && node.PreNodeIds != null)
		{
			for (int i = 0; i < node.PreNodeIds.Length; i++)
			{
				int num = node.PreNodeIds[i];
				if (num == 0)
				{
					flag = true;
					break;
				}
				SurvivorsTalentNode talentNodeById = this.GetTalentNodeById(num);
				if (talentNodeById != null && talentNodeById.Status == ESurvivorsTalentNodeStatus.Upgraded)
				{
					flag = true;
					break;
				}
			}
		}
		return flag;
	}

	// Token: 0x06015E7A RID: 89722 RVA: 0x00615AB4 File Offset: 0x00613CB4
	public bool IsEnoughUpgradeNode(SurvivorsTalentNode node)
	{
		SurvivorsTalentEffect? talentTreeEffect = ConfigBase<SurvivorsRogueConfig>.Instance.GetTalentTreeEffect(node.EffectId);
		if (talentTreeEffect == null)
		{
			return false;
		}
		if (talentTreeEffect.Value.ConsumeLength <= 0)
		{
			return true;
		}
		bool result = true;
		for (int i = 0; i < talentTreeEffect.Value.ConsumeLength; i++)
		{
			int key = talentTreeEffect.Value.Consume(i).Value.Key;
			int value = talentTreeEffect.Value.Consume(i).Value.Value;
			if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(key, 0) < value)
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x06015E7B RID: 89723 RVA: 0x00615B6C File Offset: 0x00613D6C
	public void CheckCurrentTalentTreeNode()
	{
		SurvivorsTalentNode survivorsTalentNode = null;
		SurvivorsTalentNode survivorsTalentNode2 = null;
		List<SurvivorsTalentNode> list = new List<SurvivorsTalentNode>();
		List<SurvivorsTalentNode> list2 = new List<SurvivorsTalentNode>(this.TalentNodeMap.Values);
		list2.Sort((SurvivorsTalentNode a, SurvivorsTalentNode b) => a.IndexSortId - b.IndexSortId);
		foreach (SurvivorsTalentNode survivorsTalentNode3 in list2)
		{
			bool flag = survivorsTalentNode3.Status == ESurvivorsTalentNodeStatus.Lock;
			bool flag2 = survivorsTalentNode3.Status == ESurvivorsTalentNodeStatus.CanUpgrade;
			bool flag3 = this.IsEnoughUpgradeNode(survivorsTalentNode3);
			if (flag2)
			{
				if (flag3)
				{
					survivorsTalentNode = survivorsTalentNode3;
					break;
				}
				list.Add(survivorsTalentNode3);
			}
			else if (flag && survivorsTalentNode2 == null)
			{
				survivorsTalentNode2 = survivorsTalentNode3;
			}
		}
		this.CurrentSelectNode = (survivorsTalentNode2 ?? this.GetFirstTalentNode());
		if (survivorsTalentNode != null)
		{
			this.CurrentSelectNode = survivorsTalentNode;
			return;
		}
		if (list.Count > 0)
		{
			this.CurrentSelectNode = list[0];
		}
	}

	// Token: 0x06015E7C RID: 89724 RVA: 0x00615C64 File Offset: 0x00613E64
	private void InitTalentTree()
	{
		this.TalentNodeMap.Clear();
		this.TalentAreaMap.Clear();
		foreach (SurvivorsTalentTree survivorsTalentTree in ConfigBase<SurvivorsRogueConfig>.Instance.GetAllTalentTreeNodeByActId(this.ActId))
		{
			SurvivorsTalentAreaData survivorsTalentAreaData;
			if (!this.TalentAreaMap.TryGetValue(survivorsTalentTree.Area, out survivorsTalentAreaData))
			{
				survivorsTalentAreaData = new SurvivorsTalentAreaData();
				survivorsTalentAreaData.AreaId = survivorsTalentTree.Area;
				survivorsTalentAreaData.NodeIds = new List<int>();
				this.TalentAreaMap[survivorsTalentTree.Area] = survivorsTalentAreaData;
			}
			survivorsTalentAreaData.NodeIds.Add(survivorsTalentTree.Id);
			SurvivorsTalentNode survivorsTalentNode;
			if (!this.TalentNodeMap.TryGetValue(survivorsTalentTree.Id, out survivorsTalentNode))
			{
				survivorsTalentNode = new SurvivorsTalentNode(survivorsTalentTree.Id, survivorsTalentTree.Area, survivorsTalentTree.GetPreNodeArray(), survivorsTalentTree.Effect, survivorsTalentTree.IndexId, survivorsTalentTree.IndexSortId);
				survivorsTalentNode.Status = ESurvivorsTalentNodeStatus.Lock;
				this.TalentNodeMap[survivorsTalentTree.Id] = survivorsTalentNode;
			}
		}
	}

	// Token: 0x06015E7D RID: 89725 RVA: 0x00615D8C File Offset: 0x00613F8C
	private void InitRole()
	{
		this.RoleMap.Clear();
		foreach (Aki.Config.SurvivorsRole survivorsRole in ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsRoleByActId(this.ActId))
		{
			this.RoleMap[survivorsRole.Id] = false;
		}
	}

	// Token: 0x06015E7E RID: 89726 RVA: 0x00615DFC File Offset: 0x00613FFC
	private void InitWeapon()
	{
		this.WeaponMap.Clear();
		foreach (Aki.Config.SurvivorsWeapon survivorsWeapon in ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsWeaponByActId(this.ActId))
		{
			this.WeaponMap[survivorsWeapon.Id] = false;
		}
	}

	// Token: 0x06015E7F RID: 89727 RVA: 0x00615E6C File Offset: 0x0061406C
	private void InitItem()
	{
		this.ItemMap.Clear();
		foreach (SurvivorsItem survivorsItem in ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsItemByActId(this.ActId))
		{
			this.ItemMap[survivorsItem.Id] = false;
		}
	}

	// Token: 0x06015E80 RID: 89728 RVA: 0x00615EDC File Offset: 0x006140DC
	public List<int> GetShowRoleList()
	{
		List<int> list = new List<int>();
		foreach (int num in this.RoleMap.Keys)
		{
			if (this.IsRoleIdCanShow(num))
			{
				list.Add(num);
			}
		}
		list.Sort(delegate(int a, int b)
		{
			Aki.Config.SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(a);
			Aki.Config.SurvivorsRole? survivorsRole2 = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(b);
			bool flag = this.RoleMap[a];
			bool flag2 = this.RoleMap[b];
			if (flag != flag2)
			{
				if (!flag)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (survivorsRole.Value.SortId == survivorsRole2.Value.SortId)
				{
					return a - b;
				}
				return survivorsRole.Value.SortId - survivorsRole2.Value.SortId;
			}
		});
		return list;
	}

	// Token: 0x06015E81 RID: 89729 RVA: 0x00615F58 File Offset: 0x00614158
	public bool IsRoleIdCanShow(int survivorsRoleId)
	{
		Aki.Config.SurvivorsRole? survivorsRole = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(survivorsRoleId);
		if (survivorsRole == null)
		{
			return false;
		}
		int trialRoleId = survivorsRole.Value.TrialRoleId;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleId, true);
		if (roleDataById == null)
		{
			return false;
		}
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		int roleId = roleDataById.GetRoleId();
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId);
		int roleId2 = (roleConfig.Value.ParentId != 0) ? roleConfig.Value.ParentId : roleId;
		return !ModelBase<RoleModel>.Instance.IsMainRole(roleId2) || ConfigBase<RoleConfig>.Instance.GetTrialRoleConfig(trialRoleId).Value.Gender == (int)playerGender;
	}

	// Token: 0x06015E82 RID: 89730 RVA: 0x0061601C File Offset: 0x0061421C
	public List<int> GetAllNeedPopupWeaponId()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, bool> keyValuePair in this.WeaponMap)
		{
			int key = keyValuePair.Key;
			if (keyValuePair.Value && !this.SaveCacheState(ESurvivorsActivitySaveFlags.WeaponNewUnlockCheck, key, 0, 1))
			{
				list.Add(key);
			}
		}
		return list;
	}

	// Token: 0x06015E83 RID: 89731 RVA: 0x00616094 File Offset: 0x00614294
	public int GetAllItemUnlockCount()
	{
		int num = 0;
		foreach (int key in this.GetShowRoleList())
		{
			if (this.RoleMap[key])
			{
				num++;
			}
		}
		using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator2 = this.WeaponMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current)
				{
					num++;
				}
			}
		}
		using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator2 = this.ItemMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x06015E84 RID: 89732 RVA: 0x00616180 File Offset: 0x00614380
	public int GetAllItemCount()
	{
		return 0 + this.GetShowRoleList().Count + this.WeaponMap.Count + this.ItemMap.Count;
	}

	// Token: 0x0400A82B RID: 43051
	public int ActId;

	// Token: 0x0400A82C RID: 43052
	public Dictionary<int, global::ActivityTaskData> RewardTaskMap = new Dictionary<int, global::ActivityTaskData>();

	// Token: 0x0400A82D RID: 43053
	public Dictionary<int, List<int>> RewardType2TaskIdList = new Dictionary<int, List<int>>();

	// Token: 0x0400A82E RID: 43054
	private readonly Dictionary<int, SurvivorsMilestoneData> MilestoneRewardMap = new Dictionary<int, SurvivorsMilestoneData>();

	// Token: 0x0400A82F RID: 43055
	public int MilestoneRewardMaxCount;

	// Token: 0x0400A830 RID: 43056
	public int MilestoneItemId;

	// Token: 0x0400A831 RID: 43057
	public readonly Dictionary<int, SurvivorsChallengeInfo> LevelMap = new Dictionary<int, SurvivorsChallengeInfo>();

	// Token: 0x0400A832 RID: 43058
	public Dictionary<int, SurvivorsTalentNode> TalentNodeMap = new Dictionary<int, SurvivorsTalentNode>();

	// Token: 0x0400A833 RID: 43059
	public Dictionary<int, SurvivorsTalentAreaData> TalentAreaMap = new Dictionary<int, SurvivorsTalentAreaData>();

	// Token: 0x0400A834 RID: 43060
	[Nullable(2)]
	public SurvivorsTalentNode CurrentSelectNode;

	// Token: 0x0400A835 RID: 43061
	public Dictionary<int, bool> RoleMap = new Dictionary<int, bool>();

	// Token: 0x0400A836 RID: 43062
	public Dictionary<int, bool> WeaponMap = new Dictionary<int, bool>();

	// Token: 0x0400A837 RID: 43063
	public Dictionary<int, bool> ItemMap = new Dictionary<int, bool>();

	// Token: 0x02008E31 RID: 36401
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402FD45 RID: 195909
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<global::ActivityTaskData> <0>__SortTaskData;
	}
}
