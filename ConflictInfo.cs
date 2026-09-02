using System;

// Token: 0x0200170B RID: 5899
public class ConflictInfo : IConflictInfo
{
	// Token: 0x17000D95 RID: 3477
	// (get) Token: 0x0600A39E RID: 41886 RVA: 0x002B3D70 File Offset: 0x002B1F70
	// (set) Token: 0x0600A39F RID: 41887 RVA: 0x002B3D78 File Offset: 0x002B1F78
	public int RoleId { get; set; }

	// Token: 0x17000D96 RID: 3478
	// (get) Token: 0x0600A3A0 RID: 41888 RVA: 0x002B3D81 File Offset: 0x002B1F81
	// (set) Token: 0x0600A3A1 RID: 41889 RVA: 0x002B3D89 File Offset: 0x002B1F89
	public bool WeaponConflict { get; set; }

	// Token: 0x17000D97 RID: 3479
	// (get) Token: 0x0600A3A2 RID: 41890 RVA: 0x002B3D92 File Offset: 0x002B1F92
	// (set) Token: 0x0600A3A3 RID: 41891 RVA: 0x002B3D9A File Offset: 0x002B1F9A
	public bool PhantomConflict { get; set; }
}
