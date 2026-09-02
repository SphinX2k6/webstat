using System;
using System.Runtime.CompilerServices;

// Token: 0x020025D3 RID: 9683
[NullableContext(1)]
public interface IInfoData
{
	// Token: 0x170017B6 RID: 6070
	// (get) Token: 0x06012EE9 RID: 77545
	// (set) Token: 0x06012EEA RID: 77546
	string Text { get; set; }

	// Token: 0x170017B7 RID: 6071
	// (get) Token: 0x06012EEB RID: 77547
	// (set) Token: 0x06012EEC RID: 77548
	bool IsFinish { get; set; }

	// Token: 0x170017B8 RID: 6072
	// (get) Token: 0x06012EED RID: 77549
	// (set) Token: 0x06012EEE RID: 77550
	bool IsOptionFinished { get; set; }
}
