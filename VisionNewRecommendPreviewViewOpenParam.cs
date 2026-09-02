using System;
using System.Runtime.CompilerServices;

// Token: 0x02002531 RID: 9521
[NullableContext(1)]
[Nullable(0)]
public class VisionNewRecommendPreviewViewOpenParam : IVisionNewRecommendPreviewViewOpenParam
{
	// Token: 0x17001770 RID: 6000
	// (get) Token: 0x06012857 RID: 75863 RVA: 0x0051A336 File Offset: 0x00518536
	// (set) Token: 0x06012858 RID: 75864 RVA: 0x0051A33E File Offset: 0x0051853E
	public VisionNewRecommendProxy Proxy { get; set; }

	// Token: 0x17001771 RID: 6001
	// (get) Token: 0x06012859 RID: 75865 RVA: 0x0051A347 File Offset: 0x00518547
	// (set) Token: 0x0601285A RID: 75866 RVA: 0x0051A34F File Offset: 0x0051854F
	[Nullable(2)]
	public Action OnApplySuccess { [NullableContext(2)] get; [NullableContext(2)] set; }
}
