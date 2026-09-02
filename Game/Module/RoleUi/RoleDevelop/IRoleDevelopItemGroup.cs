using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200508A RID: 20618
	[NullableContext(1)]
	public interface IRoleDevelopItemGroup
	{
		// Token: 0x17008BAD RID: 35757
		// (get) Token: 0x0603524B RID: 217675
		// (set) Token: 0x0603524C RID: 217676
		EItemMaterialType Type { get; set; }

		// Token: 0x17008BAE RID: 35758
		// (get) Token: 0x0603524D RID: 217677
		// (set) Token: 0x0603524E RID: 217678
		List<RoleDevelopNeedItem> Items { get; set; }
	}
}
