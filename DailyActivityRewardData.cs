using System;

// Token: 0x02001AA0 RID: 6816
public class DailyActivityRewardData
{
	// Token: 0x0600C34B RID: 49995 RVA: 0x00337432 File Offset: 0x00335632
	public DailyActivityRewardData(int rewardId, double progress, int maxIndex)
	{
		this.RewardId = rewardId;
		this.Progress = progress;
		this.MaxIndex = maxIndex;
	}

	// Token: 0x04005D87 RID: 23943
	public int MaxIndex;

	// Token: 0x04005D88 RID: 23944
	public double Progress;

	// Token: 0x04005D89 RID: 23945
	public int RewardId;
}
