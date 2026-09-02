using System;
using System.Runtime.CompilerServices;

// Token: 0x02002530 RID: 9520
[NullableContext(1)]
public interface IVisionNewRecommendPreviewViewOpenParam
{
	// Token: 0x1700176E RID: 5998
	// (get) Token: 0x06012853 RID: 75859
	// (set) Token: 0x06012854 RID: 75860
	VisionNewRecommendProxy Proxy { get; set; }

	// Token: 0x1700176F RID: 5999
	// (get) Token: 0x06012855 RID: 75861
	// (set) Token: 0x06012856 RID: 75862
	[Nullable(2)]
	Action OnApplySuccess { [NullableContext(2)] get; [NullableContext(2)] set; }
}
