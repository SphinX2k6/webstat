using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x0200508B RID: 20619
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopItemGroup : IRoleDevelopItemGroup
	{
		// Token: 0x17008BAF RID: 35759
		// (get) Token: 0x0603524F RID: 217679 RVA: 0x00D52E7D File Offset: 0x00D5107D
		// (set) Token: 0x06035250 RID: 217680 RVA: 0x00D52E85 File Offset: 0x00D51085
		public EItemMaterialType Type { get; set; }

		// Token: 0x17008BB0 RID: 35760
		// (get) Token: 0x06035251 RID: 217681 RVA: 0x00D52E8E File Offset: 0x00D5108E
		// (set) Token: 0x06035252 RID: 217682 RVA: 0x00D52E96 File Offset: 0x00D51096
		public List<RoleDevelopNeedItem> Items { get; set; }
	}
}
