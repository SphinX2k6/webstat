using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02002A88 RID: 10888
[NullableContext(2)]
public interface ISpecialTransitionViewParams
{
	// Token: 0x17001C45 RID: 7237
	// (get) Token: 0x06015CBF RID: 89279
	// (set) Token: 0x06015CC0 RID: 89280
	int? SpineId { get; set; }

	// Token: 0x17001C46 RID: 7238
	// (get) Token: 0x06015CC1 RID: 89281
	// (set) Token: 0x06015CC2 RID: 89282
	string BgPath { get; set; }

	// Token: 0x17001C47 RID: 7239
	// (get) Token: 0x06015CC3 RID: 89283
	// (set) Token: 0x06015CC4 RID: 89284
	ICustomShowUi CustomShowUi { get; set; }

	// Token: 0x17001C48 RID: 7240
	// (get) Token: 0x06015CC5 RID: 89285
	// (set) Token: 0x06015CC6 RID: 89286
	string AkEvent { get; set; }
}
