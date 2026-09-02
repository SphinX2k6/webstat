using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;

// Token: 0x020013E9 RID: 5097
[NullableContext(1)]
[Nullable(0)]
public class HandbookRewardData
{
	// Token: 0x06008D4F RID: 36175 RVA: 0x00252680 File Offset: 0x00250880
	public List<TItem> GetPreviewReward()
	{
		if (this.Rewards.Count != 0)
		{
			return this.Rewards;
		}
		if (this.DropId == 0)
		{
			return new List<TItem>();
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(this.DropId);
		if (dropPackagePreviewItemList != null)
		{
			this.Rewards = dropPackagePreviewItemList;
		}
		return this.Rewards;
	}

	// Token: 0x06008D50 RID: 36176 RVA: 0x002526D0 File Offset: 0x002508D0
	public EHandbookRewardState GetState(int currentGoal)
	{
		if (this.Achieved)
		{
			return EHandbookRewardState.FinishedAndClaimed;
		}
		if (currentGoal >= this.Goal)
		{
			return EHandbookRewardState.FinishedAndUnclaimed;
		}
		return EHandbookRewardState.Active;
	}

	// Token: 0x040041CD RID: 16845
	public int Id;

	// Token: 0x040041CE RID: 16846
	public int Goal;

	// Token: 0x040041CF RID: 16847
	public bool Achieved;

	// Token: 0x040041D0 RID: 16848
	public int DropId;

	// Token: 0x040041D1 RID: 16849
	private List<TItem> Rewards = new List<TItem>();
}
