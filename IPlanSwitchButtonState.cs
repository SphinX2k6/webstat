using System;
using System.Runtime.CompilerServices;

// Token: 0x020027FC RID: 10236
[NullableContext(1)]
public interface IPlanSwitchButtonState
{
	// Token: 0x170019FC RID: 6652
	// (get) Token: 0x0601435E RID: 82782
	// (set) Token: 0x0601435F RID: 82783
	bool IsShow { get; set; }

	// Token: 0x170019FD RID: 6653
	// (get) Token: 0x06014360 RID: 82784
	// (set) Token: 0x06014361 RID: 82785
	string Text { get; set; }

	// Token: 0x170019FE RID: 6654
	// (get) Token: 0x06014362 RID: 82786
	// (set) Token: 0x06014363 RID: 82787
	bool IsHighlight { get; set; }
}
