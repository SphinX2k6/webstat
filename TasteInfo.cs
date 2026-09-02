using System;
using System.Runtime.CompilerServices;

// Token: 0x0200101B RID: 4123
[NullableContext(1)]
[Nullable(0)]
public class TasteInfo : ITasteInfo
{
	// Token: 0x1700084A RID: 2122
	// (get) Token: 0x06006B41 RID: 27457 RVA: 0x001C1048 File Offset: 0x001BF248
	// (set) Token: 0x06006B42 RID: 27458 RVA: 0x001C1050 File Offset: 0x001BF250
	public EDrinksFlavorType Type { get; set; }

	// Token: 0x1700084B RID: 2123
	// (get) Token: 0x06006B43 RID: 27459 RVA: 0x001C1059 File Offset: 0x001BF259
	// (set) Token: 0x06006B44 RID: 27460 RVA: 0x001C1061 File Offset: 0x001BF261
	public string Key { get; set; } = "";

	// Token: 0x1700084C RID: 2124
	// (get) Token: 0x06006B45 RID: 27461 RVA: 0x001C106A File Offset: 0x001BF26A
	// (set) Token: 0x06006B46 RID: 27462 RVA: 0x001C1072 File Offset: 0x001BF272
	public string[] Value { get; set; } = Array.Empty<string>();
}
