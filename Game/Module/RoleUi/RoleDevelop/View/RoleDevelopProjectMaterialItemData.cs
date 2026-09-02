using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B8 RID: 20664
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopProjectMaterialItemData : IRoleDevelopProjectMaterialItemData
	{
		// Token: 0x17008C12 RID: 35858
		// (get) Token: 0x060353DE RID: 218078 RVA: 0x00D58CE9 File Offset: 0x00D56EE9
		// (set) Token: 0x060353DF RID: 218079 RVA: 0x00D58CF1 File Offset: 0x00D56EF1
		public RoleDevelopItemGroup GroupItem { get; set; }

		// Token: 0x17008C13 RID: 35859
		// (get) Token: 0x060353E0 RID: 218080 RVA: 0x00D58CFA File Offset: 0x00D56EFA
		// (set) Token: 0x060353E1 RID: 218081 RVA: 0x00D58D02 File Offset: 0x00D56F02
		public Action<RoleDevelopItemGroup> JumpCallback { get; set; }

		// Token: 0x17008C14 RID: 35860
		// (get) Token: 0x060353E2 RID: 218082 RVA: 0x00D58D0B File Offset: 0x00D56F0B
		// (set) Token: 0x060353E3 RID: 218083 RVA: 0x00D58D13 File Offset: 0x00D56F13
		public int? LogRoleId { get; set; }

		// Token: 0x17008C15 RID: 35861
		// (get) Token: 0x060353E4 RID: 218084 RVA: 0x00D58D1C File Offset: 0x00D56F1C
		// (set) Token: 0x060353E5 RID: 218085 RVA: 0x00D58D24 File Offset: 0x00D56F24
		public ERoleDevelopCategoryType? LogMainPage { get; set; }

		// Token: 0x17008C16 RID: 35862
		// (get) Token: 0x060353E6 RID: 218086 RVA: 0x00D58D2D File Offset: 0x00D56F2D
		// (set) Token: 0x060353E7 RID: 218087 RVA: 0x00D58D35 File Offset: 0x00D56F35
		public ERoleDevelopLogSubPage? LogSubPage { get; set; }
	}
}
