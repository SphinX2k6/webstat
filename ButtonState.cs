using System;
using System.Runtime.CompilerServices;

// Token: 0x020027FB RID: 10235
[NullableContext(1)]
[Nullable(0)]
public class ButtonState : IButtonState
{
	// Token: 0x170019FA RID: 6650
	// (get) Token: 0x06014359 RID: 82777 RVA: 0x005A0D5B File Offset: 0x0059EF5B
	// (set) Token: 0x0601435A RID: 82778 RVA: 0x005A0D63 File Offset: 0x0059EF63
	public string Text { get; set; } = string.Empty;

	// Token: 0x170019FB RID: 6651
	// (get) Token: 0x0601435B RID: 82779 RVA: 0x005A0D6C File Offset: 0x0059EF6C
	// (set) Token: 0x0601435C RID: 82780 RVA: 0x005A0D74 File Offset: 0x0059EF74
	public bool IsHighlight { get; set; }
}
