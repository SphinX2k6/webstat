using System;

// Token: 0x02001721 RID: 5921
public class WuWuTaskPackData
{
	// Token: 0x17000DA5 RID: 3493
	// (get) Token: 0x0600A498 RID: 42136 RVA: 0x002B8698 File Offset: 0x002B6898
	public bool IsUnlock
	{
		get
		{
			return (double)this.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime();
		}
	}

	// Token: 0x04004E40 RID: 20032
	public int TaskPackId;

	// Token: 0x04004E41 RID: 20033
	public long UnlockTime;

	// Token: 0x04004E42 RID: 20034
	public bool HadReward;

	// Token: 0x04004E43 RID: 20035
	public int PrePackCfgId;
}
