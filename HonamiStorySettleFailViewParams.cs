using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001F79 RID: 8057
[NullableContext(1)]
[Nullable(0)]
public class HonamiStorySettleFailViewParams : IHonamiStorySettleFailViewParams
{
	// Token: 0x17001271 RID: 4721
	// (get) Token: 0x0600F17B RID: 61819 RVA: 0x0041FE40 File Offset: 0x0041E040
	// (set) Token: 0x0600F17C RID: 61820 RVA: 0x0041FE48 File Offset: 0x0041E048
	public List<IHonamiStorySettleItemParams> DisplayItems { get; set; } = new List<IHonamiStorySettleItemParams>();

	// Token: 0x17001272 RID: 4722
	// (get) Token: 0x0600F17D RID: 61821 RVA: 0x0041FE51 File Offset: 0x0041E051
	// (set) Token: 0x0600F17E RID: 61822 RVA: 0x0041FE59 File Offset: 0x0041E059
	public int TotalReward { get; set; }

	// Token: 0x17001273 RID: 4723
	// (get) Token: 0x0600F17F RID: 61823 RVA: 0x0041FE62 File Offset: 0x0041E062
	// (set) Token: 0x0600F180 RID: 61824 RVA: 0x0041FE6A File Offset: 0x0041E06A
	public bool IsNewRecord { get; set; }

	// Token: 0x17001274 RID: 4724
	// (get) Token: 0x0600F181 RID: 61825 RVA: 0x0041FE73 File Offset: 0x0041E073
	// (set) Token: 0x0600F182 RID: 61826 RVA: 0x0041FE7B File Offset: 0x0041E07B
	public int FailAddProportion { get; set; }
}
