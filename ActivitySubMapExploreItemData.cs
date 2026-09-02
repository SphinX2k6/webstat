using System;
using System.Runtime.CompilerServices;

// Token: 0x0200137A RID: 4986
[NullableContext(1)]
[Nullable(0)]
public class ActivitySubMapExploreItemData : IActivitySubMapExploreItemData
{
	// Token: 0x17000B8B RID: 2955
	// (get) Token: 0x060088AE RID: 34990 RVA: 0x002405FA File Offset: 0x0023E7FA
	// (set) Token: 0x060088AF RID: 34991 RVA: 0x00240602 File Offset: 0x0023E802
	public int TaskId { get; set; }

	// Token: 0x17000B8C RID: 2956
	// (get) Token: 0x060088B0 RID: 34992 RVA: 0x0024060B File Offset: 0x0023E80B
	// (set) Token: 0x060088B1 RID: 34993 RVA: 0x00240613 File Offset: 0x0023E813
	public string RewardDesc { get; set; }

	// Token: 0x17000B8D RID: 2957
	// (get) Token: 0x060088B2 RID: 34994 RVA: 0x0024061C File Offset: 0x0023E81C
	// (set) Token: 0x060088B3 RID: 34995 RVA: 0x00240624 File Offset: 0x0023E824
	public int RewardItemId { get; set; }

	// Token: 0x17000B8E RID: 2958
	// (get) Token: 0x060088B4 RID: 34996 RVA: 0x0024062D File Offset: 0x0023E82D
	// (set) Token: 0x060088B5 RID: 34997 RVA: 0x00240635 File Offset: 0x0023E835
	public int? RewardItemCount { get; set; }

	// Token: 0x17000B8F RID: 2959
	// (get) Token: 0x060088B6 RID: 34998 RVA: 0x0024063E File Offset: 0x0023E83E
	// (set) Token: 0x060088B7 RID: 34999 RVA: 0x00240646 File Offset: 0x0023E846
	public bool IsComplete { get; set; }

	// Token: 0x17000B90 RID: 2960
	// (get) Token: 0x060088B8 RID: 35000 RVA: 0x0024064F File Offset: 0x0023E84F
	// (set) Token: 0x060088B9 RID: 35001 RVA: 0x00240657 File Offset: 0x0023E857
	public bool IsCanGet { get; set; }

	// Token: 0x17000B91 RID: 2961
	// (get) Token: 0x060088BA RID: 35002 RVA: 0x00240660 File Offset: 0x0023E860
	// (set) Token: 0x060088BB RID: 35003 RVA: 0x00240668 File Offset: 0x0023E868
	public bool IsRunning { get; set; }
}
