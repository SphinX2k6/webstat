using System;
using System.Runtime.CompilerServices;

// Token: 0x02000EE7 RID: 3815
[NullableContext(1)]
[Nullable(0)]
public class XboxSetRegionData
{
	// Token: 0x170006ED RID: 1773
	// (get) Token: 0x06005E15 RID: 24085 RVA: 0x0017847F File Offset: 0x0017667F
	// (set) Token: 0x06005E16 RID: 24086 RVA: 0x00178487 File Offset: 0x00176687
	public int LoginType { get; set; }

	// Token: 0x170006EE RID: 1774
	// (get) Token: 0x06005E17 RID: 24087 RVA: 0x00178490 File Offset: 0x00176690
	// (set) Token: 0x06005E18 RID: 24088 RVA: 0x00178498 File Offset: 0x00176698
	public string Region { get; set; } = "";

	// Token: 0x170006EF RID: 1775
	// (get) Token: 0x06005E19 RID: 24089 RVA: 0x001784A1 File Offset: 0x001766A1
	// (set) Token: 0x06005E1A RID: 24090 RVA: 0x001784A9 File Offset: 0x001766A9
	public string UserId { get; set; } = "";

	// Token: 0x170006F0 RID: 1776
	// (get) Token: 0x06005E1B RID: 24091 RVA: 0x001784B2 File Offset: 0x001766B2
	// (set) Token: 0x06005E1C RID: 24092 RVA: 0x001784BA File Offset: 0x001766BA
	public string UserName { get; set; } = "";

	// Token: 0x170006F1 RID: 1777
	// (get) Token: 0x06005E1D RID: 24093 RVA: 0x001784C3 File Offset: 0x001766C3
	// (set) Token: 0x06005E1E RID: 24094 RVA: 0x001784CB File Offset: 0x001766CB
	public string Token { get; set; } = "";
}
