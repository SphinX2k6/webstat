using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001178 RID: 4472
[NullableContext(1)]
[Nullable(0)]
public class ActivityCategoryTabData : IActivityCategoryTabData
{
	// Token: 0x170009ED RID: 2541
	// (get) Token: 0x060075B5 RID: 30133 RVA: 0x001ED210 File Offset: 0x001EB410
	// (set) Token: 0x060075B6 RID: 30134 RVA: 0x001ED218 File Offset: 0x001EB418
	public bool IsLineType { get; set; }

	// Token: 0x170009EE RID: 2542
	// (get) Token: 0x060075B7 RID: 30135 RVA: 0x001ED221 File Offset: 0x001EB421
	// (set) Token: 0x060075B8 RID: 30136 RVA: 0x001ED229 File Offset: 0x001EB429
	public int? Id { get; set; }

	// Token: 0x170009EF RID: 2543
	// (get) Token: 0x060075B9 RID: 30137 RVA: 0x001ED232 File Offset: 0x001EB432
	// (set) Token: 0x060075BA RID: 30138 RVA: 0x001ED23A File Offset: 0x001EB43A
	public string TextId { get; set; }

	// Token: 0x170009F0 RID: 2544
	// (get) Token: 0x060075BB RID: 30139 RVA: 0x001ED243 File Offset: 0x001EB443
	// (set) Token: 0x060075BC RID: 30140 RVA: 0x001ED24B File Offset: 0x001EB44B
	public string IconPath { get; set; }

	// Token: 0x170009F1 RID: 2545
	// (get) Token: 0x060075BD RID: 30141 RVA: 0x001ED254 File Offset: 0x001EB454
	// (set) Token: 0x060075BE RID: 30142 RVA: 0x001ED25C File Offset: 0x001EB45C
	public List<ActivityBaseData> Activities { get; set; }
}
