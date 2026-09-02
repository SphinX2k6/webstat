using System;

// Token: 0x0200270A RID: 9994
public class RacingBetsRedDotState : IRacingBetsRedDotState
{
	// Token: 0x17001944 RID: 6468
	// (get) Token: 0x06013B8F RID: 80783 RVA: 0x0057D555 File Offset: 0x0057B755
	// (set) Token: 0x06013B90 RID: 80784 RVA: 0x0057D55D File Offset: 0x0057B75D
	public bool HasViewed { get; set; }

	// Token: 0x17001945 RID: 6469
	// (get) Token: 0x06013B91 RID: 80785 RVA: 0x0057D566 File Offset: 0x0057B766
	// (set) Token: 0x06013B92 RID: 80786 RVA: 0x0057D56E File Offset: 0x0057B76E
	public long LastViewedData { get; set; }
}
