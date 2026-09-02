using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B2 RID: 20658
	[NullableContext(1)]
	public interface IRoleDevelopOverviewMaterialItemData
	{
		// Token: 0x17008C09 RID: 35849
		// (get) Token: 0x060353A3 RID: 218019
		// (set) Token: 0x060353A4 RID: 218020
		RoleDevelopItemGroup GroupItem { get; set; }

		// Token: 0x17008C0A RID: 35850
		// (get) Token: 0x060353A5 RID: 218021
		// (set) Token: 0x060353A6 RID: 218022
		Action<RoleDevelopItemGroup> JumpCallback { get; set; }
	}
}
