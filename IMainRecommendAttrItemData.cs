using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002503 RID: 9475
[NullableContext(1)]
public interface IMainRecommendAttrItemData
{
	// Token: 0x17001764 RID: 5988
	// (get) Token: 0x06012683 RID: 75395
	// (set) Token: 0x06012684 RID: 75396
	[Nullable(2)]
	string CostLabel { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001765 RID: 5989
	// (get) Token: 0x06012685 RID: 75397
	// (set) Token: 0x06012686 RID: 75398
	List<RecommendItemData> Items { get; set; }
}
