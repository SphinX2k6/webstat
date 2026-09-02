using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A87 RID: 10887
[NullableContext(1)]
[Nullable(0)]
public class SpecialTransitionParams : ISpecialTransitionParams
{
	// Token: 0x17001C42 RID: 7234
	// (get) Token: 0x06015CB8 RID: 89272 RVA: 0x0060BDE6 File Offset: 0x00609FE6
	// (set) Token: 0x06015CB9 RID: 89273 RVA: 0x0060BDEE File Offset: 0x00609FEE
	public ISpecialTransitionViewParams ViewParams { get; set; }

	// Token: 0x17001C43 RID: 7235
	// (get) Token: 0x06015CBA RID: 89274 RVA: 0x0060BDF7 File Offset: 0x00609FF7
	// (set) Token: 0x06015CBB RID: 89275 RVA: 0x0060BDFF File Offset: 0x00609FFF
	public ISpecialTransitionFlowParams FlowParams { get; set; }

	// Token: 0x17001C44 RID: 7236
	// (get) Token: 0x06015CBC RID: 89276 RVA: 0x0060BE08 File Offset: 0x0060A008
	// (set) Token: 0x06015CBD RID: 89277 RVA: 0x0060BE10 File Offset: 0x0060A010
	public ECustomScreenLoading? LoadingType { get; set; }
}
