using System;

// Token: 0x02002BDA RID: 11226
public class TowerReward
{
	// Token: 0x06016692 RID: 91794 RVA: 0x006392FF File Offset: 0x006374FF
	public TowerReward(int target, int rewardId, int index)
	{
		this.Target = target;
		this.RewardId = rewardId;
		this.Index = index;
	}

	// Token: 0x0400AD67 RID: 44391
	public bool? IsReceived = new bool?(false);

	// Token: 0x0400AD68 RID: 44392
	public int Target;

	// Token: 0x0400AD69 RID: 44393
	public int RewardId;

	// Token: 0x0400AD6A RID: 44394
	public int Index;
}
