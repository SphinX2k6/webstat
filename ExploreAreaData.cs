using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001B66 RID: 7014
[NullableContext(1)]
[Nullable(0)]
public class ExploreAreaData
{
	// Token: 0x17001045 RID: 4165
	// (get) Token: 0x0600CB41 RID: 52033 RVA: 0x00363751 File Offset: 0x00361951
	public bool IsReachMaxProgress
	{
		get
		{
			return this.ExploreProgress >= this.MaxExploreProgress;
		}
	}

	// Token: 0x0600CB42 RID: 52034 RVA: 0x00363764 File Offset: 0x00361964
	private void UpdateExploreProgress(int progress)
	{
		if (this.ExploreProgress == progress)
		{
			return;
		}
		this.ExploreProgress = progress;
		this.NextStageNeedProgress = this.MaxExploreProgress;
		bool flag = false;
		foreach (DailyActivityDefine.IActivityGoalData activityGoalData in this.StageRewardDataList)
		{
			if (activityGoalData.Goal > progress)
			{
				this.NextStageNeedProgress = activityGoalData.Goal;
				break;
			}
			if (!activityGoalData.Achieved)
			{
				activityGoalData.State = EDailyActiveState.FinishedAndNotTaken;
				flag = true;
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnAreaExploreProgressUpdate, this.AreaId);
		if (flag)
		{
			ModelBase<ExploreProgressModel>.Instance.SureHasAreaRewardBox();
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotUpdateMapAreaBoxReward);
		}
	}

	// Token: 0x0600CB43 RID: 52035 RVA: 0x0036382C File Offset: 0x00361A2C
	public void Initialize(Area config)
	{
		this.AreaId = config.AreaId;
		this.TitleId = config.Title;
		this.AreaSortIndex = config.SortIndex;
		this.CountryId = config.CountryId;
		this.StateId = config.StateId;
		this.MapId = config.MapConfigId;
		this.InitStageReward();
		AreaReport? storyConfigByAreaIdAndStage = ConfigBase<AreaConfig>.Instance.GetStoryConfigByAreaIdAndStage(this.AreaId, 1);
		if (storyConfigByAreaIdAndStage != null)
		{
			this.PreviewImage = storyConfigByAreaIdAndStage.Value.PicResource;
		}
	}

	// Token: 0x0600CB44 RID: 52036 RVA: 0x003638C0 File Offset: 0x00361AC0
	private void InitStageReward()
	{
		IReadOnlyList<ExploreProgressReward> areaStageAwardConfigByAreaId = ConfigBase<ExploreProgressConfig>.Instance.GetAreaStageAwardConfigByAreaId(this.AreaId);
		if (areaStageAwardConfigByAreaId != null)
		{
			foreach (ExploreProgressReward exploreProgressReward in areaStageAwardConfigByAreaId)
			{
				DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(exploreProgressReward.DropReward);
				List<TItem> list = new List<TItem>();
				if (dropPackage != null)
				{
					foreach (KeyValuePair<int, int> keyValuePair in dropPackage.Value.DropPreview())
					{
						list.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
					}
				}
				bool flag = ModelBase<ExploreProgressModel>.Instance.IsAreaStageRewardIdAchieved(exploreProgressReward.Id);
				ActivityGoalData activityGoalData = new ActivityGoalData
				{
					Id = exploreProgressReward.Id,
					Goal = exploreProgressReward.NeedExploreProgress,
					Rewards = list,
					Achieved = flag,
					State = (flag ? EDailyActiveState.FinishedAndTaken : EDailyActiveState.Unfinished)
				};
				this.StageRewardDataList.Add(activityGoalData);
				this.StageRewardDataMap[exploreProgressReward.Id] = activityGoalData;
			}
		}
		this.NextStageNeedProgress = ((this.StageRewardDataList.Count > 0) ? this.StageRewardDataList[0].Goal : this.MaxExploreProgress);
	}

	// Token: 0x0600CB45 RID: 52037 RVA: 0x00363A60 File Offset: 0x00361C60
	public void Clear()
	{
		this.AreaId = 0;
		this.ExploreProgress = 0;
		this.NextStageNeedProgress = 1;
		this.ExploreAreaItemDataMap.Clear();
	}

	// Token: 0x0600CB46 RID: 52038 RVA: 0x00363A84 File Offset: 0x00361C84
	public void AddExploreAreaItemData(ExploreProgress exploreItemConfig)
	{
		EExploreType exploreType = (EExploreType)exploreItemConfig.ExploreType;
		if (this.ExploreAreaItemDataMap.ContainsKey(exploreType))
		{
			return;
		}
		ExploreAreaItemData exploreAreaItemData = new ExploreAreaItemData();
		exploreAreaItemData.Initialize(exploreItemConfig);
		this.ExploreAreaItemDataMap[exploreType] = exploreAreaItemData;
		this.ExploreAreaItemDataList.Add(exploreAreaItemData);
	}

	// Token: 0x0600CB47 RID: 52039 RVA: 0x00363ACE File Offset: 0x00361CCE
	public void AddExploreAreaItemDataFinish()
	{
		this.SortExploreAreaItemDataList(this.ExploreAreaItemDataList);
		this.UpdateExploreAreaItemSubType();
	}

	// Token: 0x0600CB48 RID: 52040 RVA: 0x00363AE2 File Offset: 0x00361CE2
	public void SortExploreAreaItemDataList(List<ExploreAreaItemData> list)
	{
		list.Sort(delegate(ExploreAreaItemData aAreaItemData, ExploreAreaItemData bAreaItemData)
		{
			if (aAreaItemData.SortIndex != bAreaItemData.SortIndex)
			{
				return aAreaItemData.SortIndex - bAreaItemData.SortIndex;
			}
			int configId = aAreaItemData.ConfigId;
			int configId2 = bAreaItemData.ConfigId;
			return configId - configId2;
		});
	}

	// Token: 0x0600CB49 RID: 52041 RVA: 0x00363B0C File Offset: 0x00361D0C
	private void UpdateExploreAreaItemSubType()
	{
		this.ExploreAreaItemSubTypeMap.Clear();
		foreach (ExploreAreaItemData exploreAreaItemData in this.ExploreAreaItemDataList)
		{
			foreach (int key in exploreAreaItemData.SubTypes)
			{
				this.ExploreAreaItemSubTypeMap[key] = (int)exploreAreaItemData.ExploreType;
			}
		}
	}

	// Token: 0x0600CB4A RID: 52042 RVA: 0x00363B90 File Offset: 0x00361D90
	public void Refresh(AreaExploreInfo areaExploreInfo)
	{
		this.UpdateExploreProgress(areaExploreInfo.ExplorePercent);
		ExploreProgressConfig instance = ConfigBase<ExploreProgressConfig>.Instance;
		foreach (OneExploreItem oneExploreItem in areaExploreInfo.ExploreProgress)
		{
			ExploreProgress? exploreProgressConfigById = instance.GetExploreProgressConfigById(oneExploreItem.ExploreProgressId);
			EExploreType key = (EExploreType)((exploreProgressConfigById != null) ? exploreProgressConfigById.Value.ExploreType : 0);
			ExploreAreaItemData exploreAreaItemData;
			if (this.ExploreAreaItemDataMap.TryGetValue(key, out exploreAreaItemData))
			{
				exploreAreaItemData.Refresh(oneExploreItem);
			}
		}
	}

	// Token: 0x0600CB4B RID: 52043 RVA: 0x00363C2C File Offset: 0x00361E2C
	[NullableContext(2)]
	public ExploreAreaItemData GetExploreAreaItemData(EExploreType exploreType)
	{
		ExploreAreaItemData result;
		this.ExploreAreaItemDataMap.TryGetValue(exploreType, out result);
		return result;
	}

	// Token: 0x0600CB4C RID: 52044 RVA: 0x00363C49 File Offset: 0x00361E49
	public List<ExploreAreaItemData> GetAllExploreAreaItemData()
	{
		return this.ExploreAreaItemDataList;
	}

	// Token: 0x0600CB4D RID: 52045 RVA: 0x00363C51 File Offset: 0x00361E51
	public int GetProgress()
	{
		return this.ExploreProgress;
	}

	// Token: 0x0600CB4E RID: 52046 RVA: 0x00363C59 File Offset: 0x00361E59
	public string GetNameId()
	{
		return this.TitleId;
	}

	// Token: 0x0600CB4F RID: 52047 RVA: 0x00363C61 File Offset: 0x00361E61
	public int GetSortIndex()
	{
		return this.AreaSortIndex;
	}

	// Token: 0x0600CB50 RID: 52048 RVA: 0x00363C69 File Offset: 0x00361E69
	public int GetNextStageNeedProgress()
	{
		return this.NextStageNeedProgress;
	}

	// Token: 0x0600CB51 RID: 52049 RVA: 0x00363C74 File Offset: 0x00361E74
	public float GetStageProgress(bool isPercentage = false)
	{
		int num = isPercentage ? 100 : 1;
		return (float)this.GetProgress() / (float)this.GetNextStageNeedProgress() * (float)num;
	}

	// Token: 0x0600CB52 RID: 52050 RVA: 0x00363C9C File Offset: 0x00361E9C
	public List<DailyActivityDefine.IActivityGoalData> GetStageRewardDataList()
	{
		return this.StageRewardDataList;
	}

	// Token: 0x0600CB53 RID: 52051 RVA: 0x00363CA4 File Offset: 0x00361EA4
	public void UpdateAchievedStageReward(int rewardId)
	{
		DailyActivityDefine.IActivityGoalData activityGoalData;
		if (this.StageRewardDataMap.TryGetValue(rewardId, out activityGoalData))
		{
			activityGoalData.Achieved = true;
			activityGoalData.State = EDailyActiveState.FinishedAndTaken;
		}
	}

	// Token: 0x0600CB54 RID: 52052 RVA: 0x00363CD0 File Offset: 0x00361ED0
	public bool HasCanTakeStageReward()
	{
		using (List<DailyActivityDefine.IActivityGoalData>.Enumerator enumerator = this.StageRewardDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State == EDailyActiveState.FinishedAndNotTaken)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600CB55 RID: 52053 RVA: 0x00363D2C File Offset: 0x00361F2C
	public bool IsCollectAllStageReward()
	{
		using (List<DailyActivityDefine.IActivityGoalData>.Enumerator enumerator = this.StageRewardDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State != EDailyActiveState.FinishedAndTaken)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600CB56 RID: 52054 RVA: 0x00363D88 File Offset: 0x00361F88
	public bool IsShowRecommendPlayPoint()
	{
		using (List<ExploreAreaItemData>.Enumerator enumerator = this.ExploreAreaItemDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsShowRecommendPlayPoint)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600CB57 RID: 52055 RVA: 0x00363DE4 File Offset: 0x00361FE4
	public List<ExploreAreaItemData> GetRecommendExploreItemDataList(bool hasNumLimit = true)
	{
		List<ExploreAreaItemData> list = new List<ExploreAreaItemData>();
		foreach (ExploreAreaItemData exploreAreaItemData in this.ExploreAreaItemDataList)
		{
			if (exploreAreaItemData.IsShowRecommendPlayPoint)
			{
				list.Add(exploreAreaItemData);
				if (hasNumLimit && list.Count >= 2)
				{
					break;
				}
			}
		}
		return list;
	}

	// Token: 0x0600CB58 RID: 52056 RVA: 0x00363E54 File Offset: 0x00362054
	public List<ExploreAreaItemData> GetShowRecommendExploreItemDataList()
	{
		List<ExploreAreaItemData> list = new List<ExploreAreaItemData>();
		List<ExploreAreaItemData> recommendExploreItemDataList = this.GetRecommendExploreItemDataList(true);
		Dictionary<int, AreaExplorePlayState> localAreaExplorePlayStateMap = this.GetLocalAreaExplorePlayStateMap();
		foreach (ExploreAreaItemData exploreAreaItemData in recommendExploreItemDataList)
		{
			AreaExplorePlayState areaExplorePlayState;
			if (localAreaExplorePlayStateMap.TryGetValue((int)exploreAreaItemData.ExploreType, out areaExplorePlayState))
			{
				List<IExplorePlayProgressItemData> playProgressDataList = exploreAreaItemData.PlayProgressDataList;
				for (int i = 0; i < playProgressDataList.Count; i++)
				{
					IExplorePlayProgressItemData explorePlayProgressItemData = playProgressDataList[i];
					EPlayPointState eplayPointState = areaExplorePlayState.PlayPointStateList[i];
					bool flag = eplayPointState == EPlayPointState.Locked;
					bool flag2 = explorePlayProgressItemData.PlayPointState == EPlayPointState.ToBeCompleted;
					if (flag && flag2)
					{
						explorePlayProgressItemData.LastPlayPointState = new EPlayPointState?(eplayPointState);
					}
				}
				localAreaExplorePlayStateMap.Remove((int)exploreAreaItemData.ExploreType);
			}
			else
			{
				exploreAreaItemData.IsNewRecommendPlay = true;
			}
			list.Add(exploreAreaItemData);
		}
		foreach (KeyValuePair<int, AreaExplorePlayState> keyValuePair in localAreaExplorePlayStateMap)
		{
			int key = keyValuePair.Key;
			AreaExplorePlayState value = keyValuePair.Value;
			ExploreAreaItemData exploreAreaItemData2;
			if (this.ExploreAreaItemDataMap.TryGetValue((EExploreType)key, out exploreAreaItemData2))
			{
				if (!exploreAreaItemData2.IsFinishedPlayPoint)
				{
					this.LogUnFinishLocalExploreItemData(value);
				}
				else
				{
					list.Add(exploreAreaItemData2);
				}
			}
			else
			{
				this.LogNotLocalExploreItemData(value);
			}
		}
		this.SortExploreAreaItemDataList(list);
		List<ExploreAreaItemData> list2 = new List<ExploreAreaItemData>();
		List<ExploreAreaItemData> list3 = new List<ExploreAreaItemData>();
		foreach (ExploreAreaItemData exploreAreaItemData3 in list)
		{
			if (exploreAreaItemData3.IsFinishedPlayPoint)
			{
				list2.Add(exploreAreaItemData3);
			}
			else if (exploreAreaItemData3.IsNewRecommendPlay)
			{
				list3.Add(exploreAreaItemData3);
			}
			else
			{
				for (int j = 0; j < list3.Count; j++)
				{
					ExploreAreaItemData exploreAreaItemData4 = list3[j];
					if (j < list2.Count)
					{
						list2[j].SetSequenceData(exploreAreaItemData4);
						exploreAreaItemData4.SetFlagSequenceData(true);
					}
				}
				list3.Clear();
				list2.Clear();
			}
		}
		List<ExploreAreaItemData> list4 = new List<ExploreAreaItemData>();
		foreach (ExploreAreaItemData exploreAreaItemData5 in list)
		{
			if (!exploreAreaItemData5.GetFlagSequenceDataAndClean())
			{
				list4.Add(exploreAreaItemData5);
			}
		}
		return list4;
	}

	// Token: 0x0600CB59 RID: 52057 RVA: 0x003640D8 File Offset: 0x003622D8
	public void UpdatePlayPointData(Dictionary<int, LevelPlayStateMsg> idMap)
	{
		this.LogExploreAreaItemTypeInfo();
		foreach (KeyValuePair<int, List<int>> keyValuePair in this.GetExploreTypeMapByIdMap(idMap))
		{
			int key = keyValuePair.Key;
			List<int> value = keyValuePair.Value;
			ExploreAreaItemData exploreAreaItemData;
			if (this.ExploreAreaItemDataMap.TryGetValue((EExploreType)key, out exploreAreaItemData))
			{
				exploreAreaItemData.ClearPlayPointData();
				foreach (int num in value)
				{
					LevelPlayStateMsg levelPlayStateMsg;
					if (idMap.TryGetValue(num, out levelPlayStateMsg))
					{
						int num2 = num;
						EPlayPointState playPointState = this.GetPlayPointState(num2, levelPlayStateMsg, exploreAreaItemData);
						exploreAreaItemData.AddPlayPointData(new PlayPointInfo
						{
							PlayId = num2,
							EntityId = levelPlayStateMsg.LevelPlayEntityId,
							PlayState = playPointState,
							IsClear = new bool?(levelPlayStateMsg.HideGroupInfo != null && levelPlayStateMsg.HideGroupInfo.Length > 0),
							ClearInfo = levelPlayStateMsg.HideGroupInfo,
							LevelPlayMarkUnlock = new bool?(levelPlayStateMsg.LevelPlayMarkUnlock),
							IsUnlock = levelPlayStateMsg.IsUnlock
						});
					}
				}
				exploreAreaItemData.PlayPointDataAddFinish();
			}
		}
		this.FlagUpdatePlayPointData = true;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.AreaPlayPointUpdate, this.AreaId);
	}

	// Token: 0x0600CB5A RID: 52058 RVA: 0x00364274 File Offset: 0x00362474
	public void UpdateTraceEntities(int exploratoryDegree, int[] entities)
	{
		int key;
		ExploreAreaItemData exploreAreaItemData;
		if (this.ExploreAreaItemSubTypeMap.TryGetValue(exploratoryDegree, out key) && this.ExploreAreaItemDataMap.TryGetValue((EExploreType)key, out exploreAreaItemData))
		{
			exploreAreaItemData.SetEntityList(entities);
		}
	}

	// Token: 0x0600CB5B RID: 52059 RVA: 0x003642A8 File Offset: 0x003624A8
	private EPlayPointState GetPlayPointState(int playIdNum, LevelPlayStateMsg playData, ExploreAreaItemData itemData)
	{
		EPlayPointState eplayPointState = ServerPlayState2Client.Map[playData.StateType];
		if (eplayPointState == EPlayPointState.Completed)
		{
			return eplayPointState;
		}
		if (playData.CompleteNumber > 0)
		{
			MapMark? mapMarkByPlayId = itemData.GetMapMarkByPlayId(playIdNum);
			if (mapMarkByPlayId != null && mapMarkByPlayId.GetValueOrDefault().HistoryState == 1)
			{
				return EPlayPointState.Completed;
			}
		}
		if (eplayPointState == EPlayPointState.Locked)
		{
			MapMark? mapMarkByPlayId2 = itemData.GetMapMarkByPlayId(playIdNum);
			if (mapMarkByPlayId2 != null && ModelBase<MapModel>.Instance.IsConfigMarkIdUnlock(mapMarkByPlayId2.Value.MarkId))
			{
				return EPlayPointState.ToBeCompleted;
			}
		}
		return eplayPointState;
	}

	// Token: 0x0600CB5C RID: 52060 RVA: 0x00364334 File Offset: 0x00362534
	private Dictionary<int, List<int>> GetExploreTypeMapByIdMap(Dictionary<int, LevelPlayStateMsg> idMap)
	{
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (KeyValuePair<int, LevelPlayStateMsg> keyValuePair in idMap)
		{
			int key = keyValuePair.Key;
			LevelPlayStateMsg value = keyValuePair.Value;
			int key2;
			if (this.ExploreAreaItemSubTypeMap.TryGetValue(value.ExploratoryType, out key2))
			{
				if (!dictionary.ContainsKey(key2))
				{
					dictionary[key2] = new List<int>();
				}
				dictionary[key2].Add(key);
			}
		}
		return dictionary;
	}

	// Token: 0x0600CB5D RID: 52061 RVA: 0x003643D0 File Offset: 0x003625D0
	[Conditional("UE_BUILD_SHIPPING")]
	public void LogExploreAreaItemTypeInfo()
	{
		foreach (ExploreAreaItemData exploreAreaItemData in this.ExploreAreaItemDataList)
		{
		}
	}

	// Token: 0x0600CB5E RID: 52062 RVA: 0x0036441C File Offset: 0x0036261C
	public UniTask CheckUpdatePlayPointData()
	{
		ExploreAreaData.<CheckUpdatePlayPointData>d__49 <CheckUpdatePlayPointData>d__;
		<CheckUpdatePlayPointData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckUpdatePlayPointData>d__.<>4__this = this;
		<CheckUpdatePlayPointData>d__.<>1__state = -1;
		<CheckUpdatePlayPointData>d__.<>t__builder.Start<ExploreAreaData.<CheckUpdatePlayPointData>d__49>(ref <CheckUpdatePlayPointData>d__);
		return <CheckUpdatePlayPointData>d__.<>t__builder.Task;
	}

	// Token: 0x0600CB5F RID: 52063 RVA: 0x0036445F File Offset: 0x0036265F
	public void ClearFlagUpdatePlayPointData()
	{
		this.FlagUpdatePlayPointData = false;
	}

	// Token: 0x0600CB60 RID: 52064 RVA: 0x00364468 File Offset: 0x00362668
	public UniTask RequestPlayPointData()
	{
		ExploreAreaData.<RequestPlayPointData>d__51 <RequestPlayPointData>d__;
		<RequestPlayPointData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPlayPointData>d__.<>4__this = this;
		<RequestPlayPointData>d__.<>1__state = -1;
		<RequestPlayPointData>d__.<>t__builder.Start<ExploreAreaData.<RequestPlayPointData>d__51>(ref <RequestPlayPointData>d__);
		return <RequestPlayPointData>d__.<>t__builder.Task;
	}

	// Token: 0x0600CB61 RID: 52065 RVA: 0x003644AB File Offset: 0x003626AB
	public int GetSceneId()
	{
		return this.MapId;
	}

	// Token: 0x0600CB62 RID: 52066 RVA: 0x003644B4 File Offset: 0x003626B4
	public List<IMapExploreStoryItemData> GetStoryList()
	{
		int progress = this.GetProgress();
		float localAreaStoryProgress = this.GetLocalAreaStoryProgress();
		IReadOnlyList<AreaReport> storyList = ConfigBase<AreaConfig>.Instance.GetStoryList(this.AreaId);
		List<IMapExploreStoryItemData> list = new List<IMapExploreStoryItemData>();
		if (storyList == null)
		{
			return list;
		}
		foreach (AreaReport areaReport in storyList)
		{
			MapExploreStoryItemData mapExploreStoryItemData = new MapExploreStoryItemData
			{
				IsOpen = (progress >= areaReport.Unlock)
			};
			if (mapExploreStoryItemData.IsOpen)
			{
				mapExploreStoryItemData.StoryContent = areaReport.Content;
				mapExploreStoryItemData.StoryTitle = areaReport.StageTitle;
			}
			mapExploreStoryItemData.LockedDesc = areaReport.LockText;
			mapExploreStoryItemData.IsNewOpen = new bool?(mapExploreStoryItemData.IsOpen && (float)areaReport.Unlock > localAreaStoryProgress);
			list.Add(mapExploreStoryItemData);
		}
		return list;
	}

	// Token: 0x0600CB63 RID: 52067 RVA: 0x003645A4 File Offset: 0x003627A4
	public float GetStoryProgress(bool isPercentage = false)
	{
		IReadOnlyList<AreaReport> storyList = ConfigBase<AreaConfig>.Instance.GetStoryList(this.AreaId);
		if (storyList == null)
		{
			return 0f;
		}
		int num = isPercentage ? 100 : 1;
		int progress = this.GetProgress();
		int num2;
		if (storyList.Count <= 0)
		{
			num2 = this.MaxExploreProgress;
		}
		else
		{
			IReadOnlyList<AreaReport> readOnlyList = storyList;
			num2 = readOnlyList[readOnlyList.Count - 1].Unlock;
		}
		int num3 = num2;
		int num4 = num3;
		for (int i = 0; i < storyList.Count; i++)
		{
			if (storyList[i].Unlock > progress)
			{
				num4 = ((i > 0) ? storyList[i - 1].Unlock : 0);
				break;
			}
		}
		return (float)num4 / (float)num3 * (float)num;
	}

	// Token: 0x0600CB64 RID: 52068 RVA: 0x00364658 File Offset: 0x00362858
	public bool HasNewStoryUnlocked()
	{
		if (ConfigBase<AreaConfig>.Instance.GetStoryList(this.AreaId) == null)
		{
			return false;
		}
		float localAreaStoryProgress = this.GetLocalAreaStoryProgress();
		if (this.GetStoryProgress(true) > localAreaStoryProgress)
		{
			this.FlagSaveLocalAreaStoryProgress = true;
			return true;
		}
		return false;
	}

	// Token: 0x0600CB65 RID: 52069 RVA: 0x00364694 File Offset: 0x00362894
	public float GetLocalAreaStoryProgress()
	{
		return (LocalStorage.GetGlobal<Dictionary<int, float>>(ELocalStorageGlobalKey.AreaStoryProgress, null) ?? new Dictionary<int, float>()).GetValueOrDefault(this.AreaId, 0f);
	}

	// Token: 0x0600CB66 RID: 52070 RVA: 0x003646B8 File Offset: 0x003628B8
	public bool SaveLocalAreaStoryProgress()
	{
		if (!this.FlagSaveLocalAreaStoryProgress)
		{
			return false;
		}
		Dictionary<int, float> dictionary = LocalStorage.GetGlobal<Dictionary<int, float>>(ELocalStorageGlobalKey.AreaStoryProgress, null) ?? new Dictionary<int, float>();
		dictionary[this.AreaId] = this.GetStoryProgress(true);
		LocalStorage.SetGlobal<Dictionary<int, float>>(ELocalStorageGlobalKey.AreaStoryProgress, dictionary);
		this.FlagSaveLocalAreaStoryProgress = true;
		Singleton<EventSystem>.Instance.Emit(EEventName.AreaStoryProgressSave);
		return true;
	}

	// Token: 0x0600CB67 RID: 52071 RVA: 0x00364715 File Offset: 0x00362915
	private int GetIconPercentIndex()
	{
		return (int)((float)this.GetProgress() / 25f);
	}

	// Token: 0x0600CB68 RID: 52072 RVA: 0x00364728 File Offset: 0x00362928
	public IMapAreaOnlyShowItemData GetIconPercentData(ELocalStorageGlobalKey key)
	{
		int iconPercentIndex = this.GetIconPercentIndex();
		int num = Math.Min(iconPercentIndex, this.GetLocalIconPercent(key));
		int openCount = num;
		int num2 = Math.Max(0, iconPercentIndex - num);
		if (num2 > 0)
		{
			this.FlagSaveLocalIconPercent[key] = true;
		}
		return new MapAreaOnlyShowItemData
		{
			OpenCount = openCount,
			NewOpenCount = num2,
			IconPath = this.PreviewImage
		};
	}

	// Token: 0x0600CB69 RID: 52073 RVA: 0x00364786 File Offset: 0x00362986
	public IMapAreaOnlyShowItemData GetIconPercentDataAreaShow()
	{
		return this.GetIconPercentData(ELocalStorageGlobalKey.IconPercentAreaShow);
	}

	// Token: 0x0600CB6A RID: 52074 RVA: 0x00364793 File Offset: 0x00362993
	public void SaveLocalIconPercentAreaShow()
	{
		this.SaveLocalIconPercent(ELocalStorageGlobalKey.IconPercentAreaShow);
	}

	// Token: 0x0600CB6B RID: 52075 RVA: 0x003647A0 File Offset: 0x003629A0
	public IMapAreaOnlyShowItemData GetIconPercentDataAreaStory()
	{
		return this.GetIconPercentData(ELocalStorageGlobalKey.IconPercentAreaStory);
	}

	// Token: 0x0600CB6C RID: 52076 RVA: 0x003647AD File Offset: 0x003629AD
	public void SaveLocalIconPercentAreaStory()
	{
		this.SaveLocalIconPercent(ELocalStorageGlobalKey.IconPercentAreaStory);
	}

	// Token: 0x0600CB6D RID: 52077 RVA: 0x003647BA File Offset: 0x003629BA
	private int GetLocalIconPercent(ELocalStorageGlobalKey key)
	{
		return (LocalStorage.GetGlobal<Dictionary<int, int>>(key, null) ?? new Dictionary<int, int>()).GetValueOrDefault(this.AreaId, 0);
	}

	// Token: 0x0600CB6E RID: 52078 RVA: 0x003647D8 File Offset: 0x003629D8
	private void SaveLocalIconPercent(ELocalStorageGlobalKey key)
	{
		if (!this.FlagSaveLocalIconPercent[key])
		{
			return;
		}
		Dictionary<int, int> dictionary = LocalStorage.GetGlobal<Dictionary<int, int>>(key, null) ?? new Dictionary<int, int>();
		dictionary[this.AreaId] = this.GetIconPercentIndex();
		LocalStorage.SetGlobal<Dictionary<int, int>>(key, dictionary);
		this.FlagSaveLocalIconPercent[key] = false;
	}

	// Token: 0x0600CB6F RID: 52079 RVA: 0x0036482C File Offset: 0x00362A2C
	public string GetStoryViewTitle()
	{
		string text = "AreaReportName_Text";
		string nameId = this.GetNameId();
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(text, text);
		string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(nameId, nameId);
		return StringUtils.Format(multiTextByKey, new string[]
		{
			multiTextByKey2
		});
	}

	// Token: 0x0600CB70 RID: 52080 RVA: 0x00364870 File Offset: 0x00362A70
	public void SaveLocalAreaExplorePlayState()
	{
		if (this.FlagSaveLocalAreaExplorePlayState)
		{
			return;
		}
		if (!this.IsShowRecommendPlayPoint())
		{
			return;
		}
		Dictionary<int, Dictionary<int, AreaExplorePlayState>> dictionary = LocalStorage.GetGlobal<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>(ELocalStorageGlobalKey.AreaExplorePlayState, null) ?? new Dictionary<int, Dictionary<int, AreaExplorePlayState>>();
		dictionary[this.AreaId] = this.GetAreaExplorePlayStateMap();
		LocalStorage.SetGlobal<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>(ELocalStorageGlobalKey.AreaExplorePlayState, dictionary);
		this.FlagSaveLocalAreaExplorePlayState = true;
	}

	// Token: 0x0600CB71 RID: 52081 RVA: 0x003648C9 File Offset: 0x00362AC9
	public void ClearFlagSaveLocalAreaExplorePlayState()
	{
		this.FlagSaveLocalAreaExplorePlayState = false;
	}

	// Token: 0x0600CB72 RID: 52082 RVA: 0x003648D2 File Offset: 0x00362AD2
	public void ClearLocalAreaExplorePlayState()
	{
		LocalStorage.SetGlobal<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>(ELocalStorageGlobalKey.AreaExplorePlayState, new Dictionary<int, Dictionary<int, AreaExplorePlayState>>());
	}

	// Token: 0x0600CB73 RID: 52083 RVA: 0x003648E4 File Offset: 0x00362AE4
	private Dictionary<int, AreaExplorePlayState> GetAreaExplorePlayStateMap()
	{
		Dictionary<int, AreaExplorePlayState> dictionary = new Dictionary<int, AreaExplorePlayState>();
		foreach (ExploreAreaItemData exploreAreaItemData in this.GetRecommendExploreItemDataList(true))
		{
			AreaExplorePlayState value = new AreaExplorePlayState
			{
				ExploreType = exploreAreaItemData.ExploreType,
				PlayPointStateList = exploreAreaItemData.GetPlayPointStateList().ToList<EPlayPointState>()
			};
			dictionary[(int)exploreAreaItemData.ExploreType] = value;
		}
		return dictionary;
	}

	// Token: 0x0600CB74 RID: 52084 RVA: 0x00364968 File Offset: 0x00362B68
	public Dictionary<int, AreaExplorePlayState> GetLocalAreaExplorePlayStateMap()
	{
		Dictionary<int, AreaExplorePlayState> result;
		if ((LocalStorage.GetGlobal<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>(ELocalStorageGlobalKey.AreaExplorePlayState, null) ?? new Dictionary<int, Dictionary<int, AreaExplorePlayState>>()).TryGetValue(this.AreaId, out result))
		{
			return result;
		}
		return new Dictionary<int, AreaExplorePlayState>();
	}

	// Token: 0x0600CB75 RID: 52085 RVA: 0x0036499F File Offset: 0x00362B9F
	public void LogInfo()
	{
	}

	// Token: 0x0600CB76 RID: 52086 RVA: 0x003649A4 File Offset: 0x00362BA4
	public List<ExploreAreaItemData> GetLocalFinishRecommendExploreItems()
	{
		if (this.IsShowRecommendPlayPoint())
		{
			return new List<ExploreAreaItemData>();
		}
		Dictionary<int, AreaExplorePlayState> localAreaExplorePlayStateMap = this.GetLocalAreaExplorePlayStateMap();
		List<ExploreAreaItemData> list = new List<ExploreAreaItemData>();
		foreach (KeyValuePair<int, AreaExplorePlayState> keyValuePair in localAreaExplorePlayStateMap)
		{
			AreaExplorePlayState value = keyValuePair.Value;
			ExploreAreaItemData item;
			if (this.ExploreAreaItemDataMap.TryGetValue(value.ExploreType, out item))
			{
				list.Add(item);
			}
			else
			{
				this.LogNotLocalExploreItemData(value);
			}
		}
		return list;
	}

	// Token: 0x0600CB77 RID: 52087 RVA: 0x00364A34 File Offset: 0x00362C34
	[Conditional("UE_BUILD_SHIPPING")]
	private void LogNotLocalExploreItemData(IAreaExplorePlayState data)
	{
	}

	// Token: 0x0600CB78 RID: 52088 RVA: 0x00364A36 File Offset: 0x00362C36
	[Conditional("UE_BUILD_SHIPPING")]
	private void LogUnFinishLocalExploreItemData(IAreaExplorePlayState data)
	{
	}

	// Token: 0x0600CB79 RID: 52089 RVA: 0x00364A38 File Offset: 0x00362C38
	public ExploreAreaData()
	{
		Dictionary<ELocalStorageGlobalKey, bool> dictionary = new Dictionary<ELocalStorageGlobalKey, bool>();
		dictionary[ELocalStorageGlobalKey.IconPercentAreaShow] = false;
		dictionary[ELocalStorageGlobalKey.IconPercentAreaStory] = false;
		this.FlagSaveLocalIconPercent = dictionary;
		this.PreviewImage = "";
		base..ctor();
	}

	// Token: 0x0400612E RID: 24878
	public int AreaId;

	// Token: 0x0400612F RID: 24879
	public int CountryId;

	// Token: 0x04006130 RID: 24880
	public int StateId;

	// Token: 0x04006131 RID: 24881
	public int MapId;

	// Token: 0x04006132 RID: 24882
	private int ExploreProgress;

	// Token: 0x04006133 RID: 24883
	private int NextStageNeedProgress = 1;

	// Token: 0x04006134 RID: 24884
	public readonly int MaxExploreProgress = 100;

	// Token: 0x04006135 RID: 24885
	private readonly Dictionary<EExploreType, ExploreAreaItemData> ExploreAreaItemDataMap = new Dictionary<EExploreType, ExploreAreaItemData>();

	// Token: 0x04006136 RID: 24886
	private readonly List<ExploreAreaItemData> ExploreAreaItemDataList = new List<ExploreAreaItemData>();

	// Token: 0x04006137 RID: 24887
	private readonly Dictionary<int, int> ExploreAreaItemSubTypeMap = new Dictionary<int, int>();

	// Token: 0x04006138 RID: 24888
	private string TitleId = "";

	// Token: 0x04006139 RID: 24889
	private int AreaSortIndex;

	// Token: 0x0400613A RID: 24890
	private readonly List<DailyActivityDefine.IActivityGoalData> StageRewardDataList = new List<DailyActivityDefine.IActivityGoalData>();

	// Token: 0x0400613B RID: 24891
	private readonly Dictionary<int, DailyActivityDefine.IActivityGoalData> StageRewardDataMap = new Dictionary<int, DailyActivityDefine.IActivityGoalData>();

	// Token: 0x0400613C RID: 24892
	private bool FlagUpdatePlayPointData;

	// Token: 0x0400613D RID: 24893
	private bool FlagSaveLocalAreaStoryProgress;

	// Token: 0x0400613E RID: 24894
	private readonly Dictionary<ELocalStorageGlobalKey, bool> FlagSaveLocalIconPercent;

	// Token: 0x0400613F RID: 24895
	private bool FlagSaveLocalAreaExplorePlayState;

	// Token: 0x04006140 RID: 24896
	public string PreviewImage;
}
