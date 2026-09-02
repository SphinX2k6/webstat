using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002504 RID: 9476
[NullableContext(1)]
[Nullable(0)]
public class MainRecommendAttrItemData : IMainRecommendAttrItemData
{
	// Token: 0x17001766 RID: 5990
	// (get) Token: 0x06012687 RID: 75399 RVA: 0x0051053E File Offset: 0x0050E73E
	// (set) Token: 0x06012688 RID: 75400 RVA: 0x00510546 File Offset: 0x0050E746
	[Nullable(2)]
	public string CostLabel { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001767 RID: 5991
	// (get) Token: 0x06012689 RID: 75401 RVA: 0x0051054F File Offset: 0x0050E74F
	// (set) Token: 0x0601268A RID: 75402 RVA: 0x00510557 File Offset: 0x0050E757
	public List<RecommendItemData> Items { get; set; } = new List<RecommendItemData>();
}
