using System;
using System.Runtime.CompilerServices;

// Token: 0x0200101A RID: 4122
[NullableContext(1)]
public interface ITasteInfo
{
	// Token: 0x17000847 RID: 2119
	// (get) Token: 0x06006B3B RID: 27451
	// (set) Token: 0x06006B3C RID: 27452
	EDrinksFlavorType Type { get; set; }

	// Token: 0x17000848 RID: 2120
	// (get) Token: 0x06006B3D RID: 27453
	// (set) Token: 0x06006B3E RID: 27454
	string Key { get; set; }

	// Token: 0x17000849 RID: 2121
	// (get) Token: 0x06006B3F RID: 27455
	// (set) Token: 0x06006B40 RID: 27456
	string[] Value { get; set; }
}
