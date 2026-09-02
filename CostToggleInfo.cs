using System;

// Token: 0x020024CD RID: 9421
public class CostToggleInfo : ICostToggleInfo
{
	// Token: 0x1700174C RID: 5964
	// (get) Token: 0x0601249D RID: 74909 RVA: 0x005072B6 File Offset: 0x005054B6
	// (set) Token: 0x0601249E RID: 74910 RVA: 0x005072BE File Offset: 0x005054BE
	public int Component { get; set; }

	// Token: 0x1700174D RID: 5965
	// (get) Token: 0x0601249F RID: 74911 RVA: 0x005072C7 File Offset: 0x005054C7
	// (set) Token: 0x060124A0 RID: 74912 RVA: 0x005072CF File Offset: 0x005054CF
	public int CostValue { get; set; }
}
