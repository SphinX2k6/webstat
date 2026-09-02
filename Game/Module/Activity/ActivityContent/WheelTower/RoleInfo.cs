using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F7 RID: 25079
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleInfo : IRoleInfo
	{
		// Token: 0x17009B56 RID: 39766
		// (get) Token: 0x0603F49F RID: 259231 RVA: 0x0103E5EF File Offset: 0x0103C7EF
		// (set) Token: 0x0603F4A0 RID: 259232 RVA: 0x0103E5F7 File Offset: 0x0103C7F7
		public int RoleId { get; set; }

		// Token: 0x17009B57 RID: 39767
		// (get) Token: 0x0603F4A1 RID: 259233 RVA: 0x0103E600 File Offset: 0x0103C800
		// (set) Token: 0x0603F4A2 RID: 259234 RVA: 0x0103E608 File Offset: 0x0103C808
		public int Weapon { get; set; }

		// Token: 0x17009B58 RID: 39768
		// (get) Token: 0x0603F4A3 RID: 259235 RVA: 0x0103E611 File Offset: 0x0103C811
		// (set) Token: 0x0603F4A4 RID: 259236 RVA: 0x0103E619 File Offset: 0x0103C819
		public List<int> Phantom { get; set; } = new List<int>();
	}
}
