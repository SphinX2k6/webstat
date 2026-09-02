using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020027EA RID: 10218
[NullableContext(1)]
public interface IMaterialGroup
{
	// Token: 0x170019BD RID: 6589
	// (get) Token: 0x060142D7 RID: 82647
	// (set) Token: 0x060142D8 RID: 82648
	int Type { get; set; }

	// Token: 0x170019BE RID: 6590
	// (get) Token: 0x060142D9 RID: 82649
	// (set) Token: 0x060142DA RID: 82650
	List<IItemMaterial> Materials { get; set; }
}
