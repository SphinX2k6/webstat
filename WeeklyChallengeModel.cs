using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

// Token: 0x02002D29 RID: 11561
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WeeklyChallengeModel : ModelBase<WeeklyChallengeModel>
{
	// Token: 0x17001EB5 RID: 7861
	// (get) Token: 0x06017549 RID: 95561 RVA: 0x00677FAF File Offset: 0x006761AF
	public int WeeklyConfigId
	{
		get
		{
			return this.ConfigId;
		}
	}

	// Token: 0x17001EB6 RID: 7862
	// (get) Token: 0x0601754A RID: 95562 RVA: 0x00677FB7 File Offset: 0x006761B7
	public List<int> WeeklyPlayIds
	{
		get
		{
			return new List<int>(this.WeeklyPlayDataMap.Keys);
		}
	}

	// Token: 0x17001EB7 RID: 7863
	// (get) Token: 0x0601754B RID: 95563 RVA: 0x00677FC9 File Offset: 0x006761C9
	public long WeeklyBeginTime
	{
		get
		{
			return this.BeginTime;
		}
	}

	// Token: 0x17001EB8 RID: 7864
	// (get) Token: 0x0601754C RID: 95564 RVA: 0x00677FD1 File Offset: 0x006761D1
	public long WeeklyEndTime
	{
		get
		{
			return this.EndTime;
		}
	}

	// Token: 0x17001EB9 RID: 7865
	// (get) Token: 0x0601754D RID: 95565 RVA: 0x00677FD9 File Offset: 0x006761D9
	public int WeeklyCurrentScore
	{
		get
		{
			return this.CurrentScore;
		}
	}

	// Token: 0x17001EBA RID: 7866
	// (get) Token: 0x0601754E RID: 95566 RVA: 0x00677FE1 File Offset: 0x006761E1
	public List<int> WeeklyClaimedScoreTaskIds
	{
		get
		{
			return this.ClaimedScoreTaskIds;
		}
	}

	// Token: 0x17001EBB RID: 7867
	// (get) Token: 0x0601754F RID: 95567 RVA: 0x00677FE9 File Offset: 0x006761E9
	public int WeeklyWorldLevel
	{
		get
		{
			return this.WorldLevel;
		}
	}

	// Token: 0x17001EBC RID: 7868
	// (get) Token: 0x06017550 RID: 95568 RVA: 0x00677FF1 File Offset: 0x006761F1
	public int WeeklyMaxScore
	{
		get
		{
			return this.ScoreMax;
		}
	}

	// Token: 0x17001EBD RID: 7869
	// (get) Token: 0x06017551 RID: 95569 RVA: 0x00677FF9 File Offset: 0x006761F9
	public IReadOnlyDictionary<int, DailyActivityDefine.IActivityGoalData> WeeklyGoalMap
	{
		get
		{
			return this.ScoreGoalMap;
		}
	}

	// Token: 0x06017552 RID: 95570 RVA: 0x00678001 File Offset: 0x00676201
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		return true;
	}

	// Token: 0x06017553 RID: 95571 RVA: 0x00678020 File Offset: 0x00676220
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
		return true;
	}

	// Token: 0x06017554 RID: 95572 RVA: 0x00678040 File Offset: 0x00676240
	public void RefreshData(WeeklyFrameworkInfo info)
	{
		this.ConfigId = info.ConfigId;
		this.BeginTime = info.BeginTime;
		this.EndTime = info.EndTime;
		this.ClaimedScoreTaskIds = new List<int>(info.ScoreTasks);
		this.WorldLevel = info.WorldLevel;
		this.RefreshWeeklyPlayData(info.WeeklyPlayDatas);
		this.InitGoalData();
		this.RefreshGoalMapClaimedState();
		this.RefreshCurrentScore();
		this.ReportEndTimeRefreshLogEvent();
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyChallengeRefresh);
	}

	// Token: 0x06017555 RID: 95573 RVA: 0x006780C4 File Offset: 0x006762C4
	public void InitGoalData()
	{
		if (this.ScoreGoalMap.Count != 0 && this.LastInitWorldLevel == this.WorldLevel)
		{
			foreach (DailyActivityDefine.IActivityGoalData activityGoalData in this.ScoreGoalMap.Values)
			{
				activityGoalData.Achieved = false;
				activityGoalData.State = EDailyActiveState.Unfinished;
			}
			return;
		}
		this.ScoreGoalMap.Clear();
		WeeklyChallengeConfig instance = ConfigBase<WeeklyChallengeConfig>.Instance;
		IReadOnlyList<WeeklyFrameAward> readOnlyList = (instance != null) ? instance.GetAllScoreRewardTasks() : null;
		if (readOnlyList == null || readOnlyList.Count == 0)
		{
			return;
		}
		foreach (WeeklyFrameAward weeklyFrameAward in readOnlyList)
		{
			List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(weeklyFrameAward.DropId, new int?(this.WorldLevel));
			ActivityGoalData value = new ActivityGoalData
			{
				Id = weeklyFrameAward.Id,
				Goal = weeklyFrameAward.Score,
				Rewards = exchangeRewardPreviewRewardList,
				Achieved = false,
				State = EDailyActiveState.Unfinished
			};
			this.ScoreGoalMap[weeklyFrameAward.Id] = value;
		}
		this.ScoreMax = readOnlyList[readOnlyList.Count - 1].Score;
		this.LastInitWorldLevel = this.WorldLevel;
	}

	// Token: 0x06017556 RID: 95574 RVA: 0x0067822C File Offset: 0x0067642C
	private void RefreshGoalMapClaimedState()
	{
		foreach (DailyActivityDefine.IActivityGoalData activityGoalData in this.ScoreGoalMap.Values)
		{
			bool flag = this.ClaimedScoreTaskIds.Contains(activityGoalData.Id);
			activityGoalData.Achieved = flag;
			activityGoalData.State = this.GetGoalState(activityGoalData.Goal, flag);
		}
	}

	// Token: 0x06017557 RID: 95575 RVA: 0x006782AC File Offset: 0x006764AC
	public EDailyActiveState GetGoalState(int goalScore, bool isClaimed)
	{
		if (isClaimed)
		{
			return EDailyActiveState.FinishedAndTaken;
		}
		if (this.CurrentScore >= goalScore)
		{
			return EDailyActiveState.FinishedAndNotTaken;
		}
		return EDailyActiveState.Unfinished;
	}

	// Token: 0x06017558 RID: 95576 RVA: 0x006782C0 File Offset: 0x006764C0
	public List<int> GetCanRewardIdList()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, DailyActivityDefine.IActivityGoalData> keyValuePair in this.ScoreGoalMap)
		{
			if (keyValuePair.Value.State == EDailyActiveState.FinishedAndNotTaken)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x06017559 RID: 95577 RVA: 0x00678330 File Offset: 0x00676530
	private void RefreshWeeklyPlayData(RepeatedField<Aki.Protocol.WeeklyPlayData> dataList)
	{
		this.WeeklyPlayDataMap.Clear();
		foreach (Aki.Protocol.WeeklyPlayData weeklyPlayData in dataList)
		{
			this.WeeklyPlayDataMap[weeklyPlayData.Id] = new global::WeeklyPlayData
			{
				PlayId = weeklyPlayData.Id,
				Type = weeklyPlayData.Type,
				HasRecord = this.CheckIsSaved(weeklyPlayData)
			};
		}
	}

	// Token: 0x0601755A RID: 95578 RVA: 0x006783B8 File Offset: 0x006765B8
	[NullableContext(2)]
	public global::WeeklyPlayData GetWeeklyPlayData(int playId)
	{
		return this.WeeklyPlayDataMap.GetValueOrDefault(playId);
	}

	// Token: 0x0601755B RID: 95579 RVA: 0x006783C8 File Offset: 0x006765C8
	private bool CheckIsSaved(Aki.Protocol.WeeklyPlayData data)
	{
		ActivityType type = data.Type;
		if (type != ActivityType.RogueWeekly)
		{
			return type == ActivityType.FloroRanchActivity && data.FloroFarmPlayData != null && data.FloroFarmPlayData.HasRecord;
		}
		return data.RogueWeeklyPlayData != null && data.RogueWeeklyPlayData.HasRecord;
	}

	// Token: 0x0601755C RID: 95580 RVA: 0x00678418 File Offset: 0x00676618
	public List<TItem> GetRewardById(int id)
	{
		DailyActivityDefine.IActivityGoalData activityGoalData;
		if (!this.ScoreGoalMap.TryGetValue(id, out activityGoalData))
		{
			return new List<TItem>();
		}
		return activityGoalData.Rewards;
	}

	// Token: 0x0601755D RID: 95581 RVA: 0x00678444 File Offset: 0x00676644
	private int GetScoreId()
	{
		return ConfigCommonParamById.GetIntConfig("WeeklyChallengeScoreId").GetValueOrDefault();
	}

	// Token: 0x0601755E RID: 95582 RVA: 0x00678464 File Offset: 0x00676664
	public string GetWeeklyScoreStr()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurrentScore);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ScoreMax);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0601755F RID: 95583 RVA: 0x006784A8 File Offset: 0x006766A8
	public void RefreshCurrentScore()
	{
		int scoreId = this.GetScoreId();
		if (scoreId <= 0)
		{
			return;
		}
		InventoryModel instance = ModelBase<InventoryModel>.Instance;
		this.CurrentScore = ((instance != null) ? instance.GetItemCountByConfigId(scoreId, 0) : 0);
		foreach (DailyActivityDefine.IActivityGoalData activityGoalData in this.ScoreGoalMap.Values)
		{
			if (!activityGoalData.Achieved)
			{
				activityGoalData.State = this.GetGoalState(activityGoalData.Goal, false);
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyChallengeScoreChanged);
	}

	// Token: 0x06017560 RID: 95584 RVA: 0x0067854C File Offset: 0x0067674C
	public void OnScoreTasksClaimed(List<int> taskIds)
	{
		foreach (int num in taskIds)
		{
			if (!this.ClaimedScoreTaskIds.Contains(num))
			{
				this.ClaimedScoreTaskIds.Add(num);
			}
			DailyActivityDefine.IActivityGoalData activityGoalData;
			if (this.ScoreGoalMap.TryGetValue(num, out activityGoalData))
			{
				activityGoalData.Achieved = true;
				activityGoalData.State = EDailyActiveState.FinishedAndTaken;
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyChallengeRewardStateChanged);
	}

	// Token: 0x06017561 RID: 95585 RVA: 0x006785DC File Offset: 0x006767DC
	public bool IsScoreTaskClaimed(int taskId)
	{
		return this.ClaimedScoreTaskIds.Contains(taskId);
	}

	// Token: 0x06017562 RID: 95586 RVA: 0x006785EC File Offset: 0x006767EC
	public bool CheckIsRewardWaitTake()
	{
		if (this.ConfigId == 0)
		{
			return false;
		}
		WeeklyChallengeConfig instance = ConfigBase<WeeklyChallengeConfig>.Instance;
		IReadOnlyList<WeeklyFrameAward> readOnlyList = (instance != null) ? instance.GetAllScoreRewardTasks() : null;
		if (readOnlyList == null)
		{
			return false;
		}
		foreach (WeeklyFrameAward weeklyFrameAward in readOnlyList)
		{
			if (this.CurrentScore >= weeklyFrameAward.Score && !this.IsScoreTaskClaimed(weeklyFrameAward.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06017563 RID: 95587 RVA: 0x00678674 File Offset: 0x00676874
	public bool CheckIsFinish()
	{
		return this.ConfigId == 0 || this.ScoreMax <= 0 || this.CurrentScore >= this.ScoreMax;
	}

	// Token: 0x06017564 RID: 95588 RVA: 0x0067869C File Offset: 0x0067689C
	public int GetLastNotTaken()
	{
		int result = 0;
		List<int> list = new List<int>(this.ScoreGoalMap.Keys);
		for (int i = list.Count - 1; i >= 0; i--)
		{
			DailyActivityDefine.IActivityGoalData activityGoalData;
			if (this.ScoreGoalMap.TryGetValue(list[i], out activityGoalData) && activityGoalData.State == EDailyActiveState.FinishedAndNotTaken)
			{
				result = i + 1;
				break;
			}
		}
		return result;
	}

	// Token: 0x06017565 RID: 95589 RVA: 0x006786F5 File Offset: 0x006768F5
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		if (configId == this.GetScoreId())
		{
			this.RefreshCurrentScore();
		}
	}

	// Token: 0x06017566 RID: 95590 RVA: 0x00678708 File Offset: 0x00676908
	public void ReportEndTimeRefreshLogEvent()
	{
		int? weeklyChallengeRefreshTime = ModelBase<DailyActivityModel>.Instance.GetWeeklyChallengeRefreshTime();
		int num = (int)this.WeeklyEndTime;
		int num2 = num;
		int? num3 = weeklyChallengeRefreshTime;
		if (!(num2 == num3.GetValueOrDefault() & num3 != null))
		{
			WeeklyChallengeEndTimeRefreshLogEvent weeklyChallengeEndTimeRefreshLogEvent = new WeeklyChallengeEndTimeRefreshLogEvent();
			weeklyChallengeEndTimeRefreshLogEvent.i_season_id = this.WeeklyConfigId;
			ControllerBase<LogReportController>.Instance.LogReport(weeklyChallengeEndTimeRefreshLogEvent);
			ModelBase<DailyActivityModel>.Instance.SetWeeklyChallengeRefreshTime(num);
		}
	}

	// Token: 0x0400B337 RID: 45879
	private int ConfigId;

	// Token: 0x0400B338 RID: 45880
	private long BeginTime;

	// Token: 0x0400B339 RID: 45881
	private long EndTime;

	// Token: 0x0400B33A RID: 45882
	private List<int> ClaimedScoreTaskIds = new List<int>();

	// Token: 0x0400B33B RID: 45883
	private int WorldLevel;

	// Token: 0x0400B33C RID: 45884
	private int LastInitWorldLevel = -1;

	// Token: 0x0400B33D RID: 45885
	private int CurrentScore;

	// Token: 0x0400B33E RID: 45886
	private int ScoreMax;

	// Token: 0x0400B33F RID: 45887
	private readonly Dictionary<int, DailyActivityDefine.IActivityGoalData> ScoreGoalMap = new Dictionary<int, DailyActivityDefine.IActivityGoalData>();

	// Token: 0x0400B340 RID: 45888
	private readonly Dictionary<int, global::WeeklyPlayData> WeeklyPlayDataMap = new Dictionary<int, global::WeeklyPlayData>();
}
