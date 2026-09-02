using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Weapon
{
	// Token: 0x020065AA RID: 26026
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballWeaponEquipViewData : IPinballWeaponEquipViewData
	{
		// Token: 0x17009ED3 RID: 40659
		// (get) Token: 0x06041049 RID: 266313 RVA: 0x010AE796 File Offset: 0x010AC996
		// (set) Token: 0x0604104A RID: 266314 RVA: 0x010AE79E File Offset: 0x010AC99E
		public PinballActivityData ActivityData { get; set; }

		// Token: 0x17009ED4 RID: 40660
		// (get) Token: 0x0604104B RID: 266315 RVA: 0x010AE7A7 File Offset: 0x010AC9A7
		// (set) Token: 0x0604104C RID: 266316 RVA: 0x010AE7AF File Offset: 0x010AC9AF
		public PinballRoleDataBase RoleData { get; set; }
	}
}
