using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x020061F6 RID: 25078
	[NullableContext(1)]
	public interface IRoleInfo
	{
		// Token: 0x17009B53 RID: 39763
		// (get) Token: 0x0603F499 RID: 259225
		// (set) Token: 0x0603F49A RID: 259226
		int RoleId { get; set; }

		// Token: 0x17009B54 RID: 39764
		// (get) Token: 0x0603F49B RID: 259227
		// (set) Token: 0x0603F49C RID: 259228
		int Weapon { get; set; }

		// Token: 0x17009B55 RID: 39765
		// (get) Token: 0x0603F49D RID: 259229
		// (set) Token: 0x0603F49E RID: 259230
		List<int> Phantom { get; set; }
	}
}
