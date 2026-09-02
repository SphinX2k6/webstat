using System;

// Token: 0x020028F2 RID: 10482
public class TrialRoleCreateData : ITrialRoleCreateData
{
	// Token: 0x17001B58 RID: 7000
	// (get) Token: 0x06014D28 RID: 85288 RVA: 0x005C44BC File Offset: 0x005C26BC
	// (set) Token: 0x06014D29 RID: 85289 RVA: 0x005C44C4 File Offset: 0x005C26C4
	public int TrialRoleId { get; set; }

	// Token: 0x17001B59 RID: 7001
	// (get) Token: 0x06014D2A RID: 85290 RVA: 0x005C44CD File Offset: 0x005C26CD
	// (set) Token: 0x06014D2B RID: 85291 RVA: 0x005C44D5 File Offset: 0x005C26D5
	public bool IsUnlocked { get; set; }
}
