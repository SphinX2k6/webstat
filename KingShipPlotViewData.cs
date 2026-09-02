using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020020A3 RID: 8355
[NullableContext(1)]
[Nullable(0)]
public class KingShipPlotViewData : IKingShipPlotViewData
{
	// Token: 0x17001302 RID: 4866
	// (get) Token: 0x0600FF2C RID: 65324 RVA: 0x00461518 File Offset: 0x0045F718
	// (set) Token: 0x0600FF2D RID: 65325 RVA: 0x00461520 File Offset: 0x0045F720
	public string Path { get; set; }

	// Token: 0x17001303 RID: 4867
	// (get) Token: 0x0600FF2E RID: 65326 RVA: 0x00461529 File Offset: 0x0045F729
	// (set) Token: 0x0600FF2F RID: 65327 RVA: 0x00461531 File Offset: 0x0045F731
	public List<string> FlowId { get; set; }

	// Token: 0x17001304 RID: 4868
	// (get) Token: 0x0600FF30 RID: 65328 RVA: 0x0046153A File Offset: 0x0045F73A
	// (set) Token: 0x0600FF31 RID: 65329 RVA: 0x00461542 File Offset: 0x0045F742
	public Action OnCloseCallBack { get; set; }
}
