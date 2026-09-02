using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020011C6 RID: 4550
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class AvignonModel : ModelBase<AvignonModel>
{
	// Token: 0x060077E2 RID: 30690 RVA: 0x001F6275 File Offset: 0x001F4475
	protected override bool OnInit()
	{
		this.AvignonProtocolData = new AvignonProtocolData();
		return true;
	}

	// Token: 0x060077E3 RID: 30691 RVA: 0x001F6284 File Offset: 0x001F4484
	public void AvignonInfoUpdate(AvignonTaskNotify notify)
	{
		foreach (ActivityBaseData activityBaseData in this.GetActivityDataList())
		{
			AvignonProtocolData avignonProtocolData = activityBaseData as AvignonProtocolData;
			if (notify.ActivityTask != null)
			{
				avignonProtocolData.UpdateTask(notify.ActivityTask);
			}
			int unLockStepId = notify.UnLockStepId;
			avignonProtocolData.UnlockStage(notify.UnLockStepId);
		}
		int avignonActivityId = this.GetAvignonActivityId();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, avignonActivityId);
	}

	// Token: 0x060077E4 RID: 30692 RVA: 0x001F6314 File Offset: 0x001F4514
	public void UpdateTaskRewardStatus(int taskId)
	{
		foreach (ActivityBaseData activityBaseData in this.GetActivityDataList())
		{
			(activityBaseData as AvignonProtocolData).TaskRewardGot(taskId);
			int avignonActivityId = this.GetAvignonActivityId();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, avignonActivityId);
		}
	}

	// Token: 0x060077E5 RID: 30693 RVA: 0x001F6384 File Offset: 0x001F4584
	public void ReadRedDot()
	{
		int avignonActivityId = this.GetAvignonActivityId();
		ModelBase<ActivityModel>.Instance.SaveActivityData(avignonActivityId, 100, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, avignonActivityId);
	}

	// Token: 0x060077E6 RID: 30694 RVA: 0x001F63BC File Offset: 0x001F45BC
	public void SaveNewStageFlag(int stageId)
	{
		AvignonStageInfo avignonStageInfo = this.GetAvignonStageInfo(stageId);
		if (avignonStageInfo == null || !avignonStageInfo.HasNewStageFlag())
		{
			return;
		}
		int avignonActivityId = this.GetAvignonActivityId();
		ModelBase<ActivityModel>.Instance.SaveActivityData(avignonActivityId, stageId, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, avignonActivityId);
	}

	// Token: 0x060077E7 RID: 30695 RVA: 0x001F6404 File Offset: 0x001F4604
	public bool CheckRedDot()
	{
		int avignonActivityId = this.GetAvignonActivityId();
		if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(avignonActivityId, 0, 100, 0, 0) == 0)
		{
			return true;
		}
		foreach (int stageId in this.GetAvignonAllStagesId())
		{
			AvignonStageInfo avignonStageInfo = this.GetAvignonStageInfo(stageId);
			if (avignonStageInfo != null && avignonStageInfo.HasNewStageFlag())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060077E8 RID: 30696 RVA: 0x001F645E File Offset: 0x001F465E
	public AvignonProtocolData GetAvigonoProtocolData()
	{
		return this.AvignonProtocolData;
	}

	// Token: 0x060077E9 RID: 30697 RVA: 0x001F6466 File Offset: 0x001F4666
	[NullableContext(2)]
	public AvignonStageInfo GetAvignonStageInfo(int stageId)
	{
		AvignonProtocolData avignonProtocolData = this.AvignonProtocolData;
		if (avignonProtocolData == null)
		{
			return null;
		}
		return avignonProtocolData.GetStageInfo(stageId);
	}

	// Token: 0x060077EA RID: 30698 RVA: 0x001F647A File Offset: 0x001F467A
	public int[] GetAvignonAllStagesId()
	{
		return this.AvignonProtocolData.GetAllStagesId();
	}

	// Token: 0x060077EB RID: 30699 RVA: 0x001F6487 File Offset: 0x001F4687
	public string GetAvignonActivityName()
	{
		return this.AvignonProtocolData.GetTitle();
	}

	// Token: 0x060077EC RID: 30700 RVA: 0x001F6494 File Offset: 0x001F4694
	public int GetAvignonActivityId()
	{
		return this.AvignonProtocolData.Id;
	}

	// Token: 0x060077ED RID: 30701 RVA: 0x001F64A1 File Offset: 0x001F46A1
	private List<ActivityBaseData> GetActivityDataList()
	{
		return ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.Avignon);
	}

	// Token: 0x04003A02 RID: 14850
	private const int AVIGNON_RED_DOT_CACHE_KEY = 100;

	// Token: 0x04003A03 RID: 14851
	private AvignonProtocolData AvignonProtocolData;
}
