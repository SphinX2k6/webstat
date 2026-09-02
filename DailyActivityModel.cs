using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02001A99 RID: 6809
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class DailyActivityModel : ModelBase<DailyActivityModel>
{
	// Token: 0x17000FEE RID: 4078
	// (get) Token: 0x0600C2FA RID: 49914 RVA: 0x00335FE0 File Offset: 0x003341E0
	public int ActivityValue
	{
		get
		{
			return this.Activity;
		}
	}

	// Token: 0x17000FEF RID: 4079
	// (get) Token: 0x0600C2FB RID: 49915 RVA: 0x00335FE8 File Offset: 0x003341E8
	public int ActivityMaxValue
	{
		get
		{
			return this.MaxActivity;
		}
	}

	// Token: 0x17000FF0 RID: 4080
	// (get) Token: 0x0600C2FC RID: 49916 RVA: 0x00335FF0 File Offset: 0x003341F0
	public Dictionary<int, DailyActivityDefine.IActivityGoalData> DailyActivityGoalMap
	{
		get
		{
			return this.GoalDataMap;
		}
	}

	// Token: 0x17000FF1 RID: 4081
	// (get) Token: 0x0600C2FD RID: 49917 RVA: 0x00335FF8 File Offset: 0x003341F8
	public List<DailyActiveTaskData> DailyActivityTaskList
	{
		get
		{
			return this.TaskDataList;
		}
	}

	// Token: 0x17000FF2 RID: 4082
	// (get) Token: 0x0600C2FE RID: 49918 RVA: 0x00336000 File Offset: 0x00334200
	public long DayEndTime
	{
		get
		{
			return this.DayEnd;
		}
	}

	// Token: 0x17000FF3 RID: 4083
	// (get) Token: 0x0600C2FF RID: 49919 RVA: 0x00336008 File Offset: 0x00334208
	// (set) Token: 0x0600C300 RID: 49920 RVA: 0x00336010 File Offset: 0x00334210
	[Nullable(2)]
	public RewardPopupData RewardData
	{
		[NullableContext(2)]
		get
		{
			return this.RewardPopupData;
		}
		[NullableContext(2)]
		set
		{
			this.RewardPopupData = value;
		}
	}

	// Token: 0x0600C301 RID: 49921 RVA: 0x00336019 File Offset: 0x00334219
	public bool ShouldShowLivenessRewardDoubleTag(int itemConfigId)
	{
		return itemConfigId == 1 && this.IsUnionExpDoubleBonusActive();
	}

	// Token: 0x0600C302 RID: 49922 RVA: 0x00336027 File Offset: 0x00334227
	public bool IsUnionExpDoubleBonusActive()
	{
		return this.GetUnionExpDoubleBonusEndTime() > 0L;
	}

	// Token: 0x0600C303 RID: 49923 RVA: 0x00336034 File Offset: 0x00334234
	public long GetUnionExpDoubleBonusEndTime()
	{
		List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.NewPlayerSupportActivityV2);
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		long num = 0L;
		foreach (ActivityBaseData activityBaseData in currentActivitiesByType)
		{
			ActivityNewPlayerSupportActivityV2Data activityNewPlayerSupportActivityV2Data = activityBaseData as ActivityNewPlayerSupportActivityV2Data;
			if (activityNewPlayerSupportActivityV2Data != null && activityNewPlayerSupportActivityV2Data.CheckIfInShowTime())
			{
				long nbLivenessEndShowTime = activityNewPlayerSupportActivityV2Data.NbLivenessEndShowTime;
				if (nbLivenessEndShowTime > 0L && serverTime < (double)nbLivenessEndShowTime && nbLivenessEndShowTime > num)
				{
					num = nbLivenessEndShowTime;
				}
			}
		}
		return num;
	}

	// Token: 0x0600C304 RID: 49924 RVA: 0x003360C4 File Offset: 0x003342C4
	public bool TryGetActiveLivenessUnionExpBonusSplitRule(out DailyActivityModel.LivenessUnionExpBonusSplitRule rule)
	{
		rule = default(DailyActivityModel.LivenessUnionExpBonusSplitRule);
		if (!this.IsUnionExpDoubleBonusActive())
		{
			return false;
		}
		rule = new DailyActivityModel.LivenessUnionExpBonusSplitRule
		{
			BonusPercent = 50
		};
		return true;
	}

	// Token: 0x0600C305 RID: 49925 RVA: 0x003360FC File Offset: 0x003342FC
	[NullableContext(2)]
	public string GetUnionExpDoubleBonusRemainArgForBanner()
	{
		long unionExpDoubleBonusEndTime = this.GetUnionExpDoubleBonusEndTime();
		if (unionExpDoubleBonusEndTime <= 0L)
		{
			return null;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)unionExpDoubleBonusEndTime - serverTime, 0.0);
		if (num <= 0.0)
		{
			return null;
		}
		if (num <= Singleton<TimeUtil>.Instance.Minute)
		{
			return ConfigMultiTextLang.GetLocalTextNew("Text_RefreshText_Text01", null) ?? "";
		}
		CommonDefine.ETimeType value = (num >= 86400.0) ? CommonDefine.ETimeType.Day : ((num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute);
		CommonDefine.ETimeType value2 = (num >= 86400.0) ? CommonDefine.ETimeType.Hour : ((num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second);
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2)).CountDownText ?? "";
	}

	// Token: 0x0600C306 RID: 49926 RVA: 0x003361CC File Offset: 0x003343CC
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600C307 RID: 49927 RVA: 0x003361CF File Offset: 0x003343CF
	public void EmitDailyActivityStateCheck()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.DailyActivityStateNotify);
	}

	// Token: 0x0600C308 RID: 49928 RVA: 0x003361E1 File Offset: 0x003343E1
	public int? GetWeeklyChallengeRefreshTime()
	{
		return ((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenDailyActivityTab)).Get(999);
	}

	// Token: 0x0600C309 RID: 49929 RVA: 0x003361FE File Offset: 0x003343FE
	public void SetWeeklyChallengeRefreshTime(int time)
	{
		((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenDailyActivityTab)).Set(999, time);
	}

	// Token: 0x0600C30A RID: 49930 RVA: 0x0033621C File Offset: 0x0033441C
	public int? GetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab tab)
	{
		return ((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenDailyActivityTab)).Get((int)tab);
	}

	// Token: 0x0600C30B RID: 49931 RVA: 0x00336235 File Offset: 0x00334435
	public void SetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab tab, int time)
	{
		((ServerStorageMap)ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.FirstOpenDailyActivityTab)).Set((int)tab, time);
	}

	// Token: 0x0600C30C RID: 49932 RVA: 0x00336250 File Offset: 0x00334450
	public void MarkWeeklyPlayOpened()
	{
		long weeklyEndTime = ModelBase<WeeklyChallengeModel>.Instance.WeeklyEndTime;
		if (weeklyEndTime <= 0L)
		{
			return;
		}
		if ((long)this.GetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab.Weekly).GetValueOrDefault() == weeklyEndTime)
		{
			return;
		}
		this.SetFirstOpenTabTime(DailyActivityDefine.EDailyActivityMainTab.Weekly, (int)weeklyEndTime);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyChallengeRefreshRedDotChanged);
	}

	// Token: 0x0600C30D RID: 49933 RVA: 0x0033629C File Offset: 0x0033449C
	public void InitGoalData()
	{
		this.GoalDataMap = new Dictionary<int, DailyActivityDefine.IActivityGoalData>();
		IReadOnlyList<Liveness> allActivityGoalData = ConfigBase<DailyActivityConfig>.Instance.GetAllActivityGoalData();
		foreach (Liveness liveness in allActivityGoalData)
		{
			Dictionary<int, int> dropShowInfo = ConfigBase<DailyActivityConfig>.Instance.GetDropShowInfo(liveness.DropId);
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair in dropShowInfo)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
			}
			ActivityGoalData value2 = new ActivityGoalData
			{
				Id = liveness.Id,
				Goal = liveness.Goal,
				Rewards = list,
				Achieved = false,
				State = EDailyActiveState.Unfinished
			};
			this.GoalDataMap.Add(liveness.Id, value2);
		}
		this.MaxActivity = allActivityGoalData[allActivityGoalData.Count - 1].Goal;
	}

	// Token: 0x0600C30E RID: 49934 RVA: 0x003363D8 File Offset: 0x003345D8
	public List<int> GetCanRewardIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in this.DailyActivityGoalMap)
		{
			if (keyValuePair.Value.State == EDailyActiveState.FinishedAndNotTaken)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600C30F RID: 49935 RVA: 0x00336448 File Offset: 0x00334648
	public void RefreshActivityInfo(int[] goalIds)
	{
		foreach (int key in goalIds)
		{
			DailyActivityDefine.IActivityGoalData activityGoalData;
			if (this.GoalDataMap.TryGetValue(key, out activityGoalData))
			{
				activityGoalData.Achieved = true;
				activityGoalData.State = this.GetActivityGoalState(activityGoalData.Goal, true);
			}
		}
		Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>>(EEventName.DailyActivityRewardTake, goalIds);
		this.EmitDailyActivityStateCheck();
	}

	// Token: 0x0600C310 RID: 49936 RVA: 0x003364AC File Offset: 0x003346AC
	public void RefreshActivityValue(int value)
	{
		this.Activity = value;
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in this.GoalDataMap)
		{
			DailyActivityDefine.IActivityGoalData value2 = keyValuePair.Value;
			value2.State = this.GetActivityGoalState(value2.Goal, value2.Achieved);
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.DailyActivityValueChange, this.Activity);
		this.EmitDailyActivityStateCheck();
	}

	// Token: 0x0600C311 RID: 49937 RVA: 0x0033653C File Offset: 0x0033473C
	public List<TItem> GetActivityRewardById(int id)
	{
		return this.GoalDataMap[id].Rewards;
	}

	// Token: 0x0600C312 RID: 49938 RVA: 0x00336550 File Offset: 0x00334750
	public void RefreshDailyActivityData(LivenessInfo activityInfo)
	{
		this.Activity = ((activityInfo != null) ? activityInfo.LivenessCount : 0);
		this.DayEnd = ((activityInfo != null) ? activityInfo.DayEnd : 0L);
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in this.GoalDataMap)
		{
			DailyActivityDefine.IActivityGoalData value = keyValuePair.Value;
			bool flag = activityInfo.RewardedLiveness.Contains(value.Id);
			value.Achieved = flag;
			value.State = this.GetActivityGoalState(value.Goal, flag);
		}
		this.AreaId = activityInfo.AreaId;
		this.TaskDataList.Clear();
		foreach (Aki.Protocol.LivenessTask livenessTask in activityInfo.Tasks)
		{
			DailyActiveTaskData dailyActiveTaskData = new DailyActiveTaskData();
			dailyActiveTaskData.TaskId = new int?(livenessTask.Id);
			dailyActiveTaskData.CurrentProgress = new int?(livenessTask.Current);
			dailyActiveTaskData.TargetProgress = new int?(livenessTask.Target);
			dailyActiveTaskData.IsFunctionUnlock = livenessTask.IsConditionUnlock;
			if (!livenessTask.IsFinished)
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.Unfinished;
			}
			else if (!livenessTask.IsTaken)
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.FinishedAndNotTaken;
			}
			else
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.FinishedAndTaken;
			}
			Aki.Config.LivenessTask value2 = ConfigBase<DailyActivityConfig>.Instance.GetActivityTaskConfigById(livenessTask.Id).Value;
			dailyActiveTaskData.Sort = value2.SortRank;
			List<TItem> list = new List<TItem>();
			foreach (KeyValuePair<int, int> keyValuePair2 in value2.TaskReward())
			{
				int num;
				int num2;
				keyValuePair2.Deconstruct(out num, out num2);
				int itemId = num;
				int count = num2;
				list.Add(new TItem(new InventoryDefine.GetItemData(itemId, 0), count));
			}
			dailyActiveTaskData.RewardItemList = list;
			this.TaskDataList.Add(dailyActiveTaskData);
		}
		this.SortTaskDataList();
		Singleton<EventSystem>.Instance.Emit(EEventName.DailyActivityRefresh);
		this.EmitDailyActivityStateCheck();
	}

	// Token: 0x0600C313 RID: 49939 RVA: 0x003367B8 File Offset: 0x003349B8
	public void UpdateDailyActivityData(LivenessInfo activityInfo)
	{
		this.Activity = ((activityInfo != null) ? activityInfo.LivenessCount : 0);
		foreach (int key in activityInfo.RewardedLiveness)
		{
			DailyActivityDefine.IActivityGoalData activityGoalData;
			if (this.GoalDataMap.TryGetValue(key, out activityGoalData))
			{
				activityGoalData.Achieved = true;
				activityGoalData.State = this.GetActivityGoalState(activityGoalData.Goal, true);
			}
		}
		this.AreaId = activityInfo.AreaId;
		foreach (Aki.Protocol.LivenessTask livenessTask in activityInfo.Tasks)
		{
			DailyActiveTaskData dailyActiveTaskData = null;
			foreach (DailyActiveTaskData dailyActiveTaskData2 in this.TaskDataList)
			{
				int? taskId = dailyActiveTaskData2.TaskId;
				int id = livenessTask.Id;
				if (taskId.GetValueOrDefault() == id & taskId != null)
				{
					dailyActiveTaskData = dailyActiveTaskData2;
					break;
				}
			}
			dailyActiveTaskData.CurrentProgress = new int?(livenessTask.Current);
			if (!livenessTask.IsFinished)
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.Unfinished;
			}
			else if (!livenessTask.IsTaken)
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.FinishedAndNotTaken;
			}
			else
			{
				dailyActiveTaskData.TaskState = EDailyActiveState.FinishedAndTaken;
			}
		}
		this.SortTaskDataList();
		Singleton<EventSystem>.Instance.Emit(EEventName.DailyActivityTaskUpdate);
		this.EmitDailyActivityStateCheck();
	}

	// Token: 0x0600C314 RID: 49940 RVA: 0x0033694C File Offset: 0x00334B4C
	public void SortTaskDataList()
	{
		this.TaskDataList.Sort(delegate(DailyActiveTaskData a, DailyActiveTaskData b)
		{
			if (a.TaskState != b.TaskState)
			{
				return a.TaskState - b.TaskState;
			}
			if (a.Sort == b.Sort)
			{
				return a.TaskId.Value - b.TaskId.Value;
			}
			return a.Sort - b.Sort;
		});
	}

	// Token: 0x0600C315 RID: 49941 RVA: 0x00336978 File Offset: 0x00334B78
	public EDailyActiveState GetActivityGoalState(int goalValue, bool isClaimed)
	{
		EDailyActiveState result = EDailyActiveState.Unfinished;
		if (isClaimed)
		{
			result = EDailyActiveState.FinishedAndTaken;
		}
		else if (this.ActivityValue >= goalValue)
		{
			result = EDailyActiveState.FinishedAndNotTaken;
		}
		return result;
	}

	// Token: 0x0600C316 RID: 49942 RVA: 0x0033699C File Offset: 0x00334B9C
	private bool CheckIsTaskRewardWaitTake()
	{
		if (this.Activity >= this.MaxActivity)
		{
			return false;
		}
		using (List<DailyActiveTaskData>.Enumerator enumerator = this.DailyActivityTaskList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TaskState == EDailyActiveState.FinishedAndNotTaken)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600C317 RID: 49943 RVA: 0x00336A08 File Offset: 0x00334C08
	private bool CheckIsActivityRewardWaitTake()
	{
		bool result = false;
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in this.GoalDataMap)
		{
			if (keyValuePair.Value.State == EDailyActiveState.FinishedAndNotTaken)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600C318 RID: 49944 RVA: 0x00336A6C File Offset: 0x00334C6C
	public bool CheckIsRewardWaitTake()
	{
		return this.CheckIsTaskRewardWaitTake() || this.CheckIsActivityRewardWaitTake();
	}

	// Token: 0x0600C319 RID: 49945 RVA: 0x00336A7E File Offset: 0x00334C7E
	public bool CheckIsFinish()
	{
		return this.Activity >= this.MaxActivity;
	}

	// Token: 0x0600C31A RID: 49946 RVA: 0x00336A94 File Offset: 0x00334C94
	public int GetLastNotTaken()
	{
		int result = 0;
		List<int> list = new List<int>(this.DailyActivityGoalMap.Keys);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			int key = list[i];
			DailyActivityDefine.IActivityGoalData activityGoalData;
			if (this.DailyActivityGoalMap.TryGetValue(key, out activityGoalData) && activityGoalData.State == EDailyActiveState.FinishedAndNotTaken)
			{
				result = i + 1;
				break;
			}
		}
		return result;
	}

	// Token: 0x04005D6A RID: 23914
	private int Activity;

	// Token: 0x04005D6B RID: 23915
	private int MaxActivity;

	// Token: 0x04005D6C RID: 23916
	private Dictionary<int, DailyActivityDefine.IActivityGoalData> GoalDataMap = new Dictionary<int, DailyActivityDefine.IActivityGoalData>();

	// Token: 0x04005D6D RID: 23917
	private List<DailyActiveTaskData> TaskDataList = new List<DailyActiveTaskData>();

	// Token: 0x04005D6E RID: 23918
	private long DayEnd;

	// Token: 0x04005D6F RID: 23919
	[Nullable(2)]
	private RewardPopupData RewardPopupData;

	// Token: 0x04005D70 RID: 23920
	public int AreaId;

	// Token: 0x04005D71 RID: 23921
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RewardItemData> ShowRewardList;

	// Token: 0x02007D5D RID: 32093
	[NullableContext(0)]
	public readonly struct LivenessUnionExpBonusSplitRule
	{
		// Token: 0x1700A831 RID: 43057
		// (get) Token: 0x06047D84 RID: 294276 RVA: 0x0132A3C9 File Offset: 0x013285C9
		// (set) Token: 0x06047D85 RID: 294277 RVA: 0x0132A3D1 File Offset: 0x013285D1
		public int BonusPercent { get; set; }
	}
}
