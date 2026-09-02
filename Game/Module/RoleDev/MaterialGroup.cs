using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005037 RID: 20535
	[NullableContext(1)]
	[Nullable(0)]
	public class MaterialGroup : IMaterialGroup
	{
		// Token: 0x17008AE7 RID: 35559
		// (get) Token: 0x06034E0D RID: 216589 RVA: 0x00D4668B File Offset: 0x00D4488B
		// (set) Token: 0x06034E0E RID: 216590 RVA: 0x00D46693 File Offset: 0x00D44893
		public int Type { get; set; }

		// Token: 0x17008AE8 RID: 35560
		// (get) Token: 0x06034E0F RID: 216591 RVA: 0x00D4669C File Offset: 0x00D4489C
		// (set) Token: 0x06034E10 RID: 216592 RVA: 0x00D466A4 File Offset: 0x00D448A4
		public List<IItemMaterial> Materials { get; set; }
	}
}
