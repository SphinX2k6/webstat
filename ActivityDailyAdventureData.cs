using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020012C4 RID: 4804
[NullableContext(1)]
[Nullable(0)]
public class ActivityDailyAdventureData : ActivityBaseData
{
	// Token: 0x06008109 RID: 33033 RVA: 0x00221724 File Offset: 0x0021F924
	public void SetProgressPoint(int pt)
	{
		this.ProgressPoint = pt;
		foreach (DailyAdventureRewardData dailyAdventureRewardData in this.PointRewardMap.Values)
		{
			dailyAdventureRewardData.RefreshState(dailyAdventureRewardData.RewardState == ERewardState.FinishedAndClaimed, new int?(this.ProgressPoint));
		}
	}

	// Token: 0x0600810A RID: 33034 RVA: 0x00221794 File Offset: 0x0021F994
	protected unsafe override void PhraseEx(ActivityData data)
	{
		DailyAdventureActivity? activityDailyAdventureConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetActivityDailyAdventureConfig(base.Id);
		if (activityDailyAdventureConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[日常探险活动] 活动数据未找到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", base.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.CreatePointRewardMap(activityDailyAdventureConfig.Value.GetRewardListArray().ToList<int>());
		DailyAdventureActivityData dailyAdventureActivityData = data.DailyAdventureActivityData;
		if (dailyAdventureActivityData == null)
		{
			return;
		}
		this.ProgressPoint = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(13, 0);
		this.TaskInfoMap.Clear();
		foreach (DailyAdventureActivityTask dailyAdventureActivityTask in dailyAdventureActivityData.DailyAdventureActivityTasks)
		{
			DailyAdventureTaskData dailyAdventureTaskData = new DailyAdventureTaskData();
			dailyAdventureTaskData.TaskId = dailyAdventureActivityTask.Id;
			dailyAdventureTaskData.CurrentProgress = dailyAdventureActivityTask.Current;
			dailyAdventureTaskData.TargetProgress = dailyAdventureActivityTask.Target;
			dailyAdventureTaskData.TaskState = ActivityDailyAdventureDefine.RewardStateResolver[dailyAdventureActivityTask.Status];
			this.TaskInfoMap[dailyAdventureActivityTask.Id] = dailyAdventureTaskData;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.YYZ;
			string message2 = "[日常探险活动] 任务信息打印";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("TaskId", dailyAdventureActivityTask.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("State", dailyAdventureTaskData.TaskState);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		foreach (DailyAdventureRewardData dailyAdventureRewardData in this.PointRewardMap.Values)
		{
			bool hasTaken = dailyAdventureActivityData.PtRewardTaken.Contains(dailyAdventureRewardData.RewardId);
			dailyAdventureRewardData.RefreshState(hasTaken, new int?(this.ProgressPoint));
		}
	}

	// Token: 0x0600810B RID: 33035 RVA: 0x002219AC File Offset: 0x0021FBAC
	private void CreatePointRewardMap(List<int> rewardIdList)
	{
		this.PointRewardMap.Clear();
		foreach (int num in rewardIdList)
		{
			DailyAdventurePoint? dailyAdventurePointConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetDailyAdventurePointConfig(num);
			if (dailyAdventurePointConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[日常探险活动] 积分奖励数据不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			DailyAdventureRewardData dailyAdventureRewardData = new DailyAdventureRewardData();
			dailyAdventureRewardData.RewardId = num;
			dailyAdventureRewardData.Point = dailyAdventurePointConfig.Value.NeedPt;
			this.PointRewardMap[num] = dailyAdventureRewardData;
		}
	}

	// Token: 0x0600810C RID: 33036 RVA: 0x00221A78 File Offset: 0x0021FC78
	public List<DailyAdventureRewardData> GetAllPointReward()
	{
		return (from a in this.PointRewardMap.Values.ToList<DailyAdventureRewardData>()
		orderby a.RewardId
		select a).ToList<DailyAdventureRewardData>();
	}

	// Token: 0x0600810D RID: 33037 RVA: 0x00221AB4 File Offset: 0x0021FCB4
	public List<DailyAdventureTaskData> GetAllTaskInfo()
	{
		return (from a in this.TaskInfoMap.Values.ToList<DailyAdventureTaskData>()
		orderby a.TaskState, a.TaskId
		select a).ToList<DailyAdventureTaskData>();
	}

	// Token: 0x0600810E RID: 33038 RVA: 0x00221B20 File Offset: 0x0021FD20
	public void SetPointReward(int id, bool hasTaken)
	{
		DailyAdventureRewardData dailyAdventureRewardData;
		if (this.PointRewardMap.TryGetValue(id, out dailyAdventureRewardData))
		{
			dailyAdventureRewardData.RefreshState(hasTaken, new int?(this.ProgressPoint));
		}
	}

	// Token: 0x0600810F RID: 33039 RVA: 0x00221B50 File Offset: 0x0021FD50
	public void SetTaskInfo(int id, ERewardState? state = null, int? currentProgress = null)
	{
		DailyAdventureTaskData dailyAdventureTaskData;
		if (this.TaskInfoMap.TryGetValue(id, out dailyAdventureTaskData))
		{
			if (state != null)
			{
				dailyAdventureTaskData.TaskState = state.Value;
			}
			if (currentProgress != null)
			{
				dailyAdventureTaskData.CurrentProgress = currentProgress.Value;
			}
		}
	}

	// Token: 0x06008110 RID: 33040 RVA: 0x00221B9C File Offset: 0x0021FD9C
	public int GetDefaultMapMarkId()
	{
		DailyAdventureActivity? activityDailyAdventureConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetActivityDailyAdventureConfig(base.Id);
		if (activityDailyAdventureConfig == null)
		{
			return 0;
		}
		return activityDailyAdventureConfig.Value.AreaDefaultMarkId;
	}

	// Token: 0x06008111 RID: 33041 RVA: 0x00221BD4 File Offset: 0x0021FDD4
	public override bool GetExDataRedPointShowState()
	{
		return !this.IsAllPointRewardFinished() && (this.IsTaskHasReward() || this.IsPointHasReward() || this.IsDailyTips());
	}

	// Token: 0x06008112 RID: 33042 RVA: 0x00221BF8 File Offset: 0x0021FDF8
	protected override bool GetExDataFinishShowState()
	{
		return this.IsAllPointRewardFinished();
	}

	// Token: 0x06008113 RID: 33043 RVA: 0x00221C00 File Offset: 0x0021FE00
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06008114 RID: 33044 RVA: 0x00221C04 File Offset: 0x0021FE04
	public bool IsTaskHasReward()
	{
		using (Dictionary<int, DailyAdventureTaskData>.ValueCollection.Enumerator enumerator = this.TaskInfoMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.TaskState == ERewardState.FinishedAndUnClaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008115 RID: 33045 RVA: 0x00221C64 File Offset: 0x0021FE64
	public bool IsPointHasReward()
	{
		using (Dictionary<int, DailyAdventureRewardData>.ValueCollection.Enumerator enumerator = this.PointRewardMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RewardState == ERewardState.FinishedAndUnClaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008116 RID: 33046 RVA: 0x00221CC4 File Offset: 0x0021FEC4
	public bool IsDailyTips()
	{
		int num = (int)Singleton<TimeUtil>.Instance.GetCurrentCrossDayStamp();
		int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, 0, 0);
		return num != activityCacheData;
	}

	// Token: 0x06008117 RID: 33047 RVA: 0x00221CF8 File Offset: 0x0021FEF8
	public void ReadDailyTips()
	{
		double currentCrossDayStamp = Singleton<TimeUtil>.Instance.GetCurrentCrossDayStamp();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 1, 0, 0, (int)currentCrossDayStamp);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008118 RID: 33048 RVA: 0x00221D3C File Offset: 0x0021FF3C
	private bool IsAllPointRewardFinished()
	{
		using (Dictionary<int, DailyAdventureRewardData>.ValueCollection.Enumerator enumerator = this.PointRewardMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.RewardState != ERewardState.FinishedAndClaimed)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x04003D99 RID: 15769
	private const int DAILY_TIME_FLAG = 1;

	// Token: 0x04003D9A RID: 15770
	public int ProgressPoint;

	// Token: 0x04003D9B RID: 15771
	private readonly Dictionary<int, DailyAdventureRewardData> PointRewardMap = new Dictionary<int, DailyAdventureRewardData>();

	// Token: 0x04003D9C RID: 15772
	private readonly Dictionary<int, DailyAdventureTaskData> TaskInfoMap = new Dictionary<int, DailyAdventureTaskData>();
}
