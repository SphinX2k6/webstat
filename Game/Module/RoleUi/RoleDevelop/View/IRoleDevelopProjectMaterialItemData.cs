using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B7 RID: 20663
	[NullableContext(1)]
	public interface IRoleDevelopProjectMaterialItemData
	{
		// Token: 0x17008C0D RID: 35853
		// (get) Token: 0x060353D4 RID: 218068
		// (set) Token: 0x060353D5 RID: 218069
		RoleDevelopItemGroup GroupItem { get; set; }

		// Token: 0x17008C0E RID: 35854
		// (get) Token: 0x060353D6 RID: 218070
		// (set) Token: 0x060353D7 RID: 218071
		Action<RoleDevelopItemGroup> JumpCallback { get; set; }

		// Token: 0x17008C0F RID: 35855
		// (get) Token: 0x060353D8 RID: 218072
		// (set) Token: 0x060353D9 RID: 218073
		int? LogRoleId { get; set; }

		// Token: 0x17008C10 RID: 35856
		// (get) Token: 0x060353DA RID: 218074
		// (set) Token: 0x060353DB RID: 218075
		ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008C11 RID: 35857
		// (get) Token: 0x060353DC RID: 218076
		// (set) Token: 0x060353DD RID: 218077
		ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
