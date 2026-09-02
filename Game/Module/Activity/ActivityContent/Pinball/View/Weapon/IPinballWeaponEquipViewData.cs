using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065A9 RID: 26025
	[NullableContext(1)]
	public interface IPinballWeaponEquipViewData
	{
		// Token: 0x17009ED1 RID: 40657
		// (get) Token: 0x06041045 RID: 266309
		// (set) Token: 0x06041046 RID: 266310
		PinballActivityData ActivityData { get; set; }

		// Token: 0x17009ED2 RID: 40658
		// (get) Token: 0x06041047 RID: 266311
		// (set) Token: 0x06041048 RID: 266312
		PinballRoleDataBase RoleData { get; set; }
	}
}
