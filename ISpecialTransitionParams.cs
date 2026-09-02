using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A86 RID: 10886
[NullableContext(1)]
public interface ISpecialTransitionParams
{
	// Token: 0x17001C3F RID: 7231
	// (get) Token: 0x06015CB2 RID: 89266
	// (set) Token: 0x06015CB3 RID: 89267
	ISpecialTransitionViewParams ViewParams { get; set; }

	// Token: 0x17001C40 RID: 7232
	// (get) Token: 0x06015CB4 RID: 89268
	// (set) Token: 0x06015CB5 RID: 89269
	ISpecialTransitionFlowParams FlowParams { get; set; }

	// Token: 0x17001C41 RID: 7233
	// (get) Token: 0x06015CB6 RID: 89270
	// (set) Token: 0x06015CB7 RID: 89271
	ECustomScreenLoading? LoadingType { get; set; }
}
