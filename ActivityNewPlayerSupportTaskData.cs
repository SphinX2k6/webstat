using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Reward;

// Token: 0x0200146D RID: 5229
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewPlayerSupportTaskData
{
	// Token: 0x0600924A RID: 37450 RVA: 0x0026978E File Offset: 0x0026798E
	public ActivityNewPlayerSupportTaskData(int id)
	{
		this.Id = id;
		this.TaskConfig = ConfigBase<ActivityNewPlayerSupportConfig>.Instance.GetTaskConfig(id);
	}

	// Token: 0x0600924B RID: 37451 RVA: 0x002697AE File Offset: 0x002679AE
	public void Refresh(ConditionTask taskData)
	{
		this.TaskStatus = taskData.Status;
		this.TaskCurrent = taskData.Current;
		this.TaskTarget = taskData.Target;
	}

	// Token: 0x0600924C RID: 37452 RVA: 0x002697D4 File Offset: 0x002679D4
	public List<TItem> GetRewardList()
	{
		int normalDropId = this.TaskConfig.NormalDropId;
		if (normalDropId <= 0)
		{
			return new List<TItem>();
		}
		return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(normalDropId);
	}

	// Token: 0x0600924D RID: 37453 RVA: 0x00269808 File Offset: 0x00267A08
	public string GetRewardName()
	{
		return this.TaskConfig.RewardName;
	}

	// Token: 0x0600924E RID: 37454 RVA: 0x00269824 File Offset: 0x00267A24
	public string GetProgressText()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (this.TaskStatus == ConditionTaskState.ConditionTaskRunning)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskCurrent);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.TaskTarget);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600924F RID: 37455 RVA: 0x002698A9 File Offset: 0x00267AA9
	public void SetTaskStatus(ConditionTaskState status)
	{
		this.TaskStatus = status;
	}

	// Token: 0x06009250 RID: 37456 RVA: 0x002698B2 File Offset: 0x00267AB2
	public ConditionTaskState GetTaskStatus()
	{
		return this.TaskStatus;
	}

	// Token: 0x06009251 RID: 37457 RVA: 0x002698BA File Offset: 0x00267ABA
	public int GetTaskTarget()
	{
		return this.TaskTarget;
	}

	// Token: 0x06009252 RID: 37458 RVA: 0x002698C2 File Offset: 0x00267AC2
	public bool CanReceiveReward()
	{
		return this.TaskStatus == ConditionTaskState.ConditionTaskFinish;
	}

	// Token: 0x06009253 RID: 37459 RVA: 0x002698CD File Offset: 0x00267ACD
	public bool IsTaskReceived()
	{
		return this.TaskStatus == ConditionTaskState.ConditionTaskTaken;
	}

	// Token: 0x06009254 RID: 37460 RVA: 0x002698D8 File Offset: 0x00267AD8
	public bool IsTaskRunning()
	{
		return this.TaskStatus == ConditionTaskState.ConditionTaskRunning;
	}

	// Token: 0x040043BF RID: 17343
	public readonly int Id;

	// Token: 0x040043C0 RID: 17344
	public readonly NewPlayerSupportTask TaskConfig;

	// Token: 0x040043C1 RID: 17345
	private ConditionTaskState TaskStatus;

	// Token: 0x040043C2 RID: 17346
	private int TaskCurrent;

	// Token: 0x040043C3 RID: 17347
	private int TaskTarget;
}
