using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020020A2 RID: 8354
[NullableContext(1)]
public interface IKingShipPlotViewData
{
	// Token: 0x170012FF RID: 4863
	// (get) Token: 0x0600FF26 RID: 65318
	// (set) Token: 0x0600FF27 RID: 65319
	string Path { get; set; }

	// Token: 0x17001300 RID: 4864
	// (get) Token: 0x0600FF28 RID: 65320
	// (set) Token: 0x0600FF29 RID: 65321
	List<string> FlowId { get; set; }

	// Token: 0x17001301 RID: 4865
	// (get) Token: 0x0600FF2A RID: 65322
	// (set) Token: 0x0600FF2B RID: 65323
	Action OnCloseCallBack { get; set; }
}
