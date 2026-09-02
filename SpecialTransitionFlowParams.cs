using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A8B RID: 10891
[NullableContext(2)]
[Nullable(0)]
public class SpecialTransitionFlowParams : ISpecialTransitionFlowParams
{
	// Token: 0x17001C50 RID: 7248
	// (get) Token: 0x06015CD6 RID: 89302 RVA: 0x0060BE6D File Offset: 0x0060A06D
	// (set) Token: 0x06015CD7 RID: 89303 RVA: 0x0060BE75 File Offset: 0x0060A075
	public IFadeEffect FadeInEffect { get; set; }

	// Token: 0x17001C51 RID: 7249
	// (get) Token: 0x06015CD8 RID: 89304 RVA: 0x0060BE7E File Offset: 0x0060A07E
	// (set) Token: 0x06015CD9 RID: 89305 RVA: 0x0060BE86 File Offset: 0x0060A086
	public IFadeEffect FadeOutEffect { get; set; }

	// Token: 0x17001C52 RID: 7250
	// (get) Token: 0x06015CDA RID: 89306 RVA: 0x0060BE8F File Offset: 0x0060A08F
	// (set) Token: 0x06015CDB RID: 89307 RVA: 0x0060BE97 File Offset: 0x0060A097
	public float? KeepTime { get; set; }
}
