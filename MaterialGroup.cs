using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020027EB RID: 10219
[NullableContext(1)]
[Nullable(0)]
public class MaterialGroup : IMaterialGroup
{
	// Token: 0x170019BF RID: 6591
	// (get) Token: 0x060142DB RID: 82651 RVA: 0x005A0B0C File Offset: 0x0059ED0C
	// (set) Token: 0x060142DC RID: 82652 RVA: 0x005A0B14 File Offset: 0x0059ED14
	public int Type { get; set; }

	// Token: 0x170019C0 RID: 6592
	// (get) Token: 0x060142DD RID: 82653 RVA: 0x005A0B1D File Offset: 0x0059ED1D
	// (set) Token: 0x060142DE RID: 82654 RVA: 0x005A0B25 File Offset: 0x0059ED25
	public List<IItemMaterial> Materials { get; set; }
}
