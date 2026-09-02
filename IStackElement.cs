using System;
using System.Runtime.CompilerServices;

// Token: 0x020034CE RID: 13518
[NullableContext(1)]
public interface IStackElement
{
	// Token: 0x170026CE RID: 9934
	// (get) Token: 0x0601C901 RID: 116993
	// (set) Token: 0x0601C902 RID: 116994
	string Node { get; set; }

	// Token: 0x170026CF RID: 9935
	// (get) Token: 0x0601C903 RID: 116995
	// (set) Token: 0x0601C904 RID: 116996
	bool Traversing { get; set; }
}
