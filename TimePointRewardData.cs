using System;

// Token: 0x020015D2 RID: 5586
public class TimePointRewardData
{
	// Token: 0x17000D4E RID: 3406
	// (get) Token: 0x06009D36 RID: 40246 RVA: 0x00292774 File Offset: 0x00290974
	public ETimePointRewardState RewardState
	{
		get
		{
			if (this.HasClaimed)
			{
				return ETimePointRewardState.UnlockAndClaimed;
			}
			if (this.HasUnlock)
			{
				return ETimePointRewardState.UnlockAndUnClaimed;
			}
			return ETimePointRewardState.Lock;
		}
	}

	// Token: 0x0400486C RID: 18540
	public int Id;

	// Token: 0x0400486D RID: 18541
	public long RewardTime;

	// Token: 0x0400486E RID: 18542
	public bool HasClaimed;

	// Token: 0x0400486F RID: 18543
	public bool HasUnlock;
}
