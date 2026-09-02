using System;

// Token: 0x02002EC2 RID: 11970
public class AddPassiveSkillParam
{
	// Token: 0x1700213B RID: 8507
	// (get) Token: 0x0601894A RID: 100682 RVA: 0x006EAE48 File Offset: 0x006E9048
	// (set) Token: 0x0601894B RID: 100683 RVA: 0x006EAE50 File Offset: 0x006E9050
	public bool? NeedBroadcast { get; set; }

	// Token: 0x1700213C RID: 8508
	// (get) Token: 0x0601894C RID: 100684 RVA: 0x006EAE59 File Offset: 0x006E9059
	// (set) Token: 0x0601894D RID: 100685 RVA: 0x006EAE61 File Offset: 0x006E9061
	public long CombatMessageId { get; set; }

	// Token: 0x1700213D RID: 8509
	// (get) Token: 0x0601894E RID: 100686 RVA: 0x006EAE6A File Offset: 0x006E906A
	// (set) Token: 0x0601894F RID: 100687 RVA: 0x006EAE72 File Offset: 0x006E9072
	public long? PreMessageId { get; set; }
}
