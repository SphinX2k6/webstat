using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005036 RID: 20534
	[NullableContext(1)]
	public interface IMaterialGroup
	{
		// Token: 0x17008AE5 RID: 35557
		// (get) Token: 0x06034E09 RID: 216585
		// (set) Token: 0x06034E0A RID: 216586
		int Type { get; set; }

		// Token: 0x17008AE6 RID: 35558
		// (get) Token: 0x06034E0B RID: 216587
		// (set) Token: 0x06034E0C RID: 216588
		List<IItemMaterial> Materials { get; set; }
	}
}
