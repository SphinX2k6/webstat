using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A8A RID: 10890
[NullableContext(2)]
public interface ISpecialTransitionFlowParams
{
	// Token: 0x17001C4D RID: 7245
	// (get) Token: 0x06015CD0 RID: 89296
	// (set) Token: 0x06015CD1 RID: 89297
	IFadeEffect FadeInEffect { get; set; }

	// Token: 0x17001C4E RID: 7246
	// (get) Token: 0x06015CD2 RID: 89298
	// (set) Token: 0x06015CD3 RID: 89299
	IFadeEffect FadeOutEffect { get; set; }

	// Token: 0x17001C4F RID: 7247
	// (get) Token: 0x06015CD4 RID: 89300
	// (set) Token: 0x06015CD5 RID: 89301
	float? KeepTime { get; set; }
}
