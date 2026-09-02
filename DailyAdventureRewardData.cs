using System;

// Token: 0x020012C7 RID: 4807
public class DailyAdventureRewardData
{
	// Token: 0x0600811B RID: 33051 RVA: 0x00221DCC File Offset: 0x0021FFCC
	public void RefreshState(bool hasTaken, int? currentPoint = null)
	{
		if (hasTaken)
		{
			this.RewardState = ERewardState.FinishedAndClaimed;
			return;
		}
		if (currentPoint != null)
		{
			int? num = currentPoint;
			int point = this.Point;
			this.RewardState = ((num.GetValueOrDefault() >= point & num != null) ? ERewardState.FinishedAndUnClaimed : ERewardState.Progress);
		}
	}

	// Token: 0x04003DA5 RID: 15781
	public int RewardId;

	// Token: 0x04003DA6 RID: 15782
	public int Point;

	// Token: 0x04003DA7 RID: 15783
	public ERewardState RewardState = ERewardState.Progress;
}
