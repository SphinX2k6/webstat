using System;

// Token: 0x020021F1 RID: 8689
public class LordGymChallengeFailViewParam : ILordGymChallengeFailViewParam
{
	// Token: 0x1700143E RID: 5182
	// (get) Token: 0x0601062D RID: 67117 RVA: 0x0047A4B8 File Offset: 0x004786B8
	// (set) Token: 0x0601062E RID: 67118 RVA: 0x0047A4C0 File Offset: 0x004786C0
	public int LordId { get; set; }

	// Token: 0x1700143F RID: 5183
	// (get) Token: 0x0601062F RID: 67119 RVA: 0x0047A4C9 File Offset: 0x004786C9
	// (set) Token: 0x06010630 RID: 67120 RVA: 0x0047A4D1 File Offset: 0x004786D1
	public ELordGymVersion Version { get; set; }

	// Token: 0x17001440 RID: 5184
	// (get) Token: 0x06010631 RID: 67121 RVA: 0x0047A4DA File Offset: 0x004786DA
	// (set) Token: 0x06010632 RID: 67122 RVA: 0x0047A4E2 File Offset: 0x004786E2
	public bool IsFromGuide { get; set; }
}
