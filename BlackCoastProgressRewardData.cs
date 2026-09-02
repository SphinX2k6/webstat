using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001267 RID: 4711
[NullableContext(1)]
[Nullable(0)]
public class BlackCoastProgressRewardData
{
	// Token: 0x06007DA4 RID: 32164 RVA: 0x002124DC File Offset: 0x002106DC
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

	// Token: 0x06007DA5 RID: 32165 RVA: 0x00212524 File Offset: 0x00210724
	public EActivityTaskState GetState()
	{
		if (this.Achieved)
		{
			return EActivityTaskState.FinishedAndClaimed;
		}
		if (this.GetCurrentGoal == null)
		{
			return EActivityTaskState.Active;
		}
		if (this.GetCurrentGoal() >= this.Goal)
		{
			return EActivityTaskState.FinishedAndUnclaimed;
		}
		return EActivityTaskState.Active;
	}

	// Token: 0x04003C4A RID: 15434
	public int Id;

	// Token: 0x04003C4B RID: 15435
	public int Goal;

	// Token: 0x04003C4C RID: 15436
	public bool Achieved;

	// Token: 0x04003C4D RID: 15437
	public int DropId;

	// Token: 0x04003C4E RID: 15438
	private List<TItem> Rewards = new List<TItem>();

	// Token: 0x04003C4F RID: 15439
	[Nullable(2)]
	public Func<int> GetCurrentGoal;
}
