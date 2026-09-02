using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x0200140D RID: 5133
[NullableContext(1)]
[Nullable(0)]
public class RewardTargetData
{
	// Token: 0x06008E49 RID: 36425 RVA: 0x00256188 File Offset: 0x00254388
	public RewardTargetData(int id)
	{
		this.Id = id;
	}

	// Token: 0x06008E4A RID: 36426 RVA: 0x002561A9 File Offset: 0x002543A9
	public bool IsFinished()
	{
		return this.Status == TrackMoonTargetState.TrackMoonTargetFinish;
	}

	// Token: 0x06008E4B RID: 36427 RVA: 0x002561B4 File Offset: 0x002543B4
	public bool IsTaken()
	{
		return this.Status == TrackMoonTargetState.TrackMoonTargetTaken;
	}

	// Token: 0x06008E4C RID: 36428 RVA: 0x002561C0 File Offset: 0x002543C0
	public List<TItem> GetRewardList()
	{
		Aki.Config.TrackMoonTarget rewardTargetById = ConfigBase<MoonChasingRewardConfig>.Instance.GetRewardTargetById(this.Id);
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(rewardTargetById.TargetReward);
		List<TItem> list = new List<TItem>();
		foreach (DicIntInt dicIntInt in dropPackage.Value.DropPreviewIter())
		{
			int key = dicIntInt.Key;
			int value = dicIntInt.Value;
			list.Add(new TItem
			{
				ItemData = new InventoryDefine.GetItemData(key, 0),
				Count = value
			});
		}
		return list;
	}

	// Token: 0x06008E4D RID: 36429 RVA: 0x00256278 File Offset: 0x00254478
	public TaskData ConvertToTaskData()
	{
		Aki.Config.TrackMoonTarget rewardTargetById = ConfigBase<MoonChasingRewardConfig>.Instance.GetRewardTargetById(this.Id);
		this.TaskData.TaskId = this.Id;
		this.TaskData.IsFinished = this.IsFinished();
		this.TaskData.IsTaken = this.IsTaken();
		this.TaskData.Status = TaskStateResolver.TrackMoonTargetState[this.Status];
		this.TaskData.RewardList = this.GetRewardList();
		this.TaskData.Current = this.Current;
		this.TaskData.Target = this.Target;
		this.TaskData.JumpId = rewardTargetById.TargetFunc;
		this.TaskData.TitleTextId = rewardTargetById.TargetName;
		this.TaskData.ReceiveDelegate = new TaskReceive(ControllerBase<MoonChasingController>.Instance.TrackMoonTargetRewardRequest);
		return this.TaskData;
	}

	// Token: 0x0400424E RID: 16974
	public TrackMoonTargetState Status;

	// Token: 0x0400424F RID: 16975
	private readonly TaskData TaskData = new TaskData();

	// Token: 0x04004250 RID: 16976
	public readonly int Id;

	// Token: 0x04004251 RID: 16977
	public int Current;

	// Token: 0x04004252 RID: 16978
	public int Target = 1;
}
