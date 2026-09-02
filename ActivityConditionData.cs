using System;
using System.Runtime.CompilerServices;

// Token: 0x02001175 RID: 4469
[NullableContext(1)]
[Nullable(0)]
public class ActivityConditionData : IActivityConditionData
{
	// Token: 0x170009E2 RID: 2530
	// (get) Token: 0x0600759E RID: 30110 RVA: 0x001ED19C File Offset: 0x001EB39C
	// (set) Token: 0x0600759F RID: 30111 RVA: 0x001ED1A4 File Offset: 0x001EB3A4
	public int ConditionId { get; set; }

	// Token: 0x170009E3 RID: 2531
	// (get) Token: 0x060075A0 RID: 30112 RVA: 0x001ED1AD File Offset: 0x001EB3AD
	// (set) Token: 0x060075A1 RID: 30113 RVA: 0x001ED1B5 File Offset: 0x001EB3B5
	public string ConditionTextId { get; set; }

	// Token: 0x170009E4 RID: 2532
	// (get) Token: 0x060075A2 RID: 30114 RVA: 0x001ED1BE File Offset: 0x001EB3BE
	// (set) Token: 0x060075A3 RID: 30115 RVA: 0x001ED1C6 File Offset: 0x001EB3C6
	public bool IsFinished { get; set; }

	// Token: 0x170009E5 RID: 2533
	// (get) Token: 0x060075A4 RID: 30116 RVA: 0x001ED1CF File Offset: 0x001EB3CF
	// (set) Token: 0x060075A5 RID: 30117 RVA: 0x001ED1D7 File Offset: 0x001EB3D7
	public int AccessId { get; set; }

	// Token: 0x170009E6 RID: 2534
	// (get) Token: 0x060075A6 RID: 30118 RVA: 0x001ED1E0 File Offset: 0x001EB3E0
	// (set) Token: 0x060075A7 RID: 30119 RVA: 0x001ED1E8 File Offset: 0x001EB3E8
	public int AccessType { get; set; }
}
