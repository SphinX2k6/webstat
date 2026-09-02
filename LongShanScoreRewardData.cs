using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001356 RID: 4950
[NullableContext(1)]
[Nullable(0)]
public class LongShanScoreRewardData
{
	// Token: 0x06008790 RID: 34704 RVA: 0x0023B990 File Offset: 0x00239B90
	public List<TItem> GetPreviewReward()
	{
		if (this.Rewards.Count == 0)
		{
			List<TItem> result = new List<TItem>();
			if (this.DropId == 0)
			{
				return result;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(this.DropId);
			this.Rewards = dropPackagePreviewItemList;
		}
		return this.Rewards;
	}

	// Token: 0x06008791 RID: 34705 RVA: 0x0023B9D8 File Offset: 0x00239BD8
	public EActivityTaskState GetState()
	{
		if (this.Achieved)
		{
			return EActivityTaskState.FinishedAndClaimed;
		}
		if (this.GetCurrentScore == null)
		{
			return EActivityTaskState.Active;
		}
		if (this.GetCurrentScore() >= this.Goal)
		{
			return EActivityTaskState.FinishedAndUnclaimed;
		}
		return EActivityTaskState.Active;
	}

	// Token: 0x04003FD1 RID: 16337
	public int Id;

	// Token: 0x04003FD2 RID: 16338
	public int Goal;

	// Token: 0x04003FD3 RID: 16339
	public bool Achieved;

	// Token: 0x04003FD4 RID: 16340
	public int DropId;

	// Token: 0x04003FD5 RID: 16341
	private List<TItem> Rewards = new List<TItem>();

	// Token: 0x04003FD6 RID: 16342
	[Nullable(2)]
	public Func<int> GetCurrentScore;
}
