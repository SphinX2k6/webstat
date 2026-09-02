using System;
using System.Runtime.CompilerServices;

// Token: 0x020027FA RID: 10234
[NullableContext(1)]
public interface IButtonState
{
	// Token: 0x170019F8 RID: 6648
	// (get) Token: 0x06014355 RID: 82773
	// (set) Token: 0x06014356 RID: 82774
	string Text { get; set; }

	// Token: 0x170019F9 RID: 6649
	// (get) Token: 0x06014357 RID: 82775
	// (set) Token: 0x06014358 RID: 82776
	bool IsHighlight { get; set; }
}
