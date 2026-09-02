using System;
using System.Runtime.CompilerServices;

// Token: 0x020027DC RID: 10204
[NullableContext(1)]
[Nullable(0)]
public class RoleDisplayModelBaseInitParams
{
	// Token: 0x170019A6 RID: 6566
	// (get) Token: 0x0601429C RID: 82588 RVA: 0x005A07A9 File Offset: 0x0059E9A9
	// (set) Token: 0x0601429D RID: 82589 RVA: 0x005A07B1 File Offset: 0x0059E9B1
	public int Id { get; set; }

	// Token: 0x170019A7 RID: 6567
	// (get) Token: 0x0601429E RID: 82590 RVA: 0x005A07BA File Offset: 0x0059E9BA
	// (set) Token: 0x0601429F RID: 82591 RVA: 0x005A07C2 File Offset: 0x0059E9C2
	public string Name { get; set; }

	// Token: 0x170019A8 RID: 6568
	// (get) Token: 0x060142A0 RID: 82592 RVA: 0x005A07CB File Offset: 0x0059E9CB
	// (set) Token: 0x060142A1 RID: 82593 RVA: 0x005A07D3 File Offset: 0x0059E9D3
	public int SkinId { get; set; }

	// Token: 0x170019A9 RID: 6569
	// (get) Token: 0x060142A2 RID: 82594 RVA: 0x005A07DC File Offset: 0x0059E9DC
	// (set) Token: 0x060142A3 RID: 82595 RVA: 0x005A07E4 File Offset: 0x0059E9E4
	public int ElementId { get; set; }

	// Token: 0x170019AA RID: 6570
	// (get) Token: 0x060142A4 RID: 82596 RVA: 0x005A07ED File Offset: 0x0059E9ED
	// (set) Token: 0x060142A5 RID: 82597 RVA: 0x005A07F5 File Offset: 0x0059E9F5
	public int Level { get; set; }

	// Token: 0x170019AB RID: 6571
	// (get) Token: 0x060142A6 RID: 82598 RVA: 0x005A07FE File Offset: 0x0059E9FE
	// (set) Token: 0x060142A7 RID: 82599 RVA: 0x005A0806 File Offset: 0x0059EA06
	public bool IsInTeam { get; set; }

	// Token: 0x170019AC RID: 6572
	// (get) Token: 0x060142A8 RID: 82600 RVA: 0x005A080F File Offset: 0x0059EA0F
	// (set) Token: 0x060142A9 RID: 82601 RVA: 0x005A0817 File Offset: 0x0059EA17
	public bool IsTrial { get; set; }

	// Token: 0x170019AD RID: 6573
	// (get) Token: 0x060142AA RID: 82602 RVA: 0x005A0820 File Offset: 0x0059EA20
	// (set) Token: 0x060142AB RID: 82603 RVA: 0x005A0828 File Offset: 0x0059EA28
	public bool IsNew { get; set; }

	// Token: 0x170019AE RID: 6574
	// (get) Token: 0x060142AC RID: 82604 RVA: 0x005A0831 File Offset: 0x0059EA31
	// (set) Token: 0x060142AD RID: 82605 RVA: 0x005A0839 File Offset: 0x0059EA39
	public ERoleTypeTag TypeTag { get; set; }
}
