using System;
using System.Runtime.CompilerServices;

// Token: 0x020012E9 RID: 4841
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyRoundBuffData : IDangoMonopolyRoundBuffData
{
	// Token: 0x17000B03 RID: 2819
	// (get) Token: 0x06008318 RID: 33560 RVA: 0x0022AB84 File Offset: 0x00228D84
	// (set) Token: 0x06008319 RID: 33561 RVA: 0x0022AB8C File Offset: 0x00228D8C
	public int DangoId { get; set; }

	// Token: 0x17000B04 RID: 2820
	// (get) Token: 0x0600831A RID: 33562 RVA: 0x0022AB95 File Offset: 0x00228D95
	// (set) Token: 0x0600831B RID: 33563 RVA: 0x0022AB9D File Offset: 0x00228D9D
	public int PropertyId { get; set; }

	// Token: 0x17000B05 RID: 2821
	// (get) Token: 0x0600831C RID: 33564 RVA: 0x0022ABA6 File Offset: 0x00228DA6
	// (set) Token: 0x0600831D RID: 33565 RVA: 0x0022ABAE File Offset: 0x00228DAE
	public int GridId { get; set; }

	// Token: 0x17000B06 RID: 2822
	// (get) Token: 0x0600831E RID: 33566 RVA: 0x0022ABB7 File Offset: 0x00228DB7
	// (set) Token: 0x0600831F RID: 33567 RVA: 0x0022ABBF File Offset: 0x00228DBF
	public bool IsActive { get; set; }

	// Token: 0x17000B07 RID: 2823
	// (get) Token: 0x06008320 RID: 33568 RVA: 0x0022ABC8 File Offset: 0x00228DC8
	// (set) Token: 0x06008321 RID: 33569 RVA: 0x0022ABD0 File Offset: 0x00228DD0
	public string DangoIcon { get; set; } = "";

	// Token: 0x17000B08 RID: 2824
	// (get) Token: 0x06008322 RID: 33570 RVA: 0x0022ABD9 File Offset: 0x00228DD9
	// (set) Token: 0x06008323 RID: 33571 RVA: 0x0022ABE1 File Offset: 0x00228DE1
	public string DangoName { get; set; } = "";

	// Token: 0x17000B09 RID: 2825
	// (get) Token: 0x06008324 RID: 33572 RVA: 0x0022ABEA File Offset: 0x00228DEA
	// (set) Token: 0x06008325 RID: 33573 RVA: 0x0022ABF2 File Offset: 0x00228DF2
	public string PropertyDesc { get; set; } = "";

	// Token: 0x17000B0A RID: 2826
	// (get) Token: 0x06008326 RID: 33574 RVA: 0x0022ABFB File Offset: 0x00228DFB
	// (set) Token: 0x06008327 RID: 33575 RVA: 0x0022AC03 File Offset: 0x00228E03
	public string PropertyTitle { get; set; } = "";
}
