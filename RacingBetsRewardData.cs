using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x020026E9 RID: 9961
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsRewardData
{
	// Token: 0x06013A9D RID: 80541 RVA: 0x0057BB88 File Offset: 0x00579D88
	public RacingBetsRewardData(int id)
	{
		this.Id = id;
		this.RewardConfig = ConfigBase<RacingBetsConfig>.Instance.GetRacingBetsReward(id);
	}

	// Token: 0x06013A9E RID: 80542 RVA: 0x0057BBA8 File Offset: 0x00579DA8
	public void Refresh(ConditionTaskData taskData)
	{
		this.TaskStatus = taskData.Status;
		this.CurTaskRate = taskData.Rate;
		this.TaskTarget = taskData.Target;
	}

	// Token: 0x06013A9F RID: 80543 RVA: 0x0057BBD0 File Offset: 0x00579DD0
	public ERacingBetsRewardType GetRewardType()
	{
		return (ERacingBetsRewardType)this.RewardConfig.Value.RewardType;
	}

	// Token: 0x06013AA0 RID: 80544 RVA: 0x0057BBF0 File Offset: 0x00579DF0
	public List<TItem> GetRewardList()
	{
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in this.RewardConfig.Value.TargetReward())
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
		}
		return list;
	}

	// Token: 0x06013AA1 RID: 80545 RVA: 0x0057BC78 File Offset: 0x00579E78
	public string GetRewardName()
	{
		return this.RewardConfig.Value.RewardName;
	}

	// Token: 0x06013AA2 RID: 80546 RVA: 0x0057BC98 File Offset: 0x00579E98
	public string GetProgressText()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (this.TaskStatus == ConditionTaskStatus.Undone)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurTaskRate);
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

	// Token: 0x06013AA3 RID: 80547 RVA: 0x0057BD1D File Offset: 0x00579F1D
	public ConditionTaskStatus GetTaskStatus()
	{
		return this.TaskStatus;
	}

	// Token: 0x06013AA4 RID: 80548 RVA: 0x0057BD25 File Offset: 0x00579F25
	public bool CanReceiveReward()
	{
		return this.TaskStatus == ConditionTaskStatus.TaskFinish;
	}

	// Token: 0x06013AA5 RID: 80549 RVA: 0x0057BD30 File Offset: 0x00579F30
	public bool IsTaskReceived()
	{
		return this.TaskStatus == ConditionTaskStatus.Received;
	}

	// Token: 0x040098F5 RID: 39157
	public readonly int Id;

	// Token: 0x040098F6 RID: 39158
	public readonly RacingBetsReward? RewardConfig;

	// Token: 0x040098F7 RID: 39159
	private ConditionTaskStatus TaskStatus;

	// Token: 0x040098F8 RID: 39160
	private int CurTaskRate;

	// Token: 0x040098F9 RID: 39161
	private int TaskTarget;
}
