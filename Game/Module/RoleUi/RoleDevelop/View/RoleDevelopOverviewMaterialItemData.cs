using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050B3 RID: 20659
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopOverviewMaterialItemData : IRoleDevelopOverviewMaterialItemData
	{
		// Token: 0x17008C0B RID: 35851
		// (get) Token: 0x060353A7 RID: 218023 RVA: 0x00D57BA9 File Offset: 0x00D55DA9
		// (set) Token: 0x060353A8 RID: 218024 RVA: 0x00D57BB1 File Offset: 0x00D55DB1
		public RoleDevelopItemGroup GroupItem { get; set; }

		// Token: 0x17008C0C RID: 35852
		// (get) Token: 0x060353A9 RID: 218025 RVA: 0x00D57BBA File Offset: 0x00D55DBA
		// (set) Token: 0x060353AA RID: 218026 RVA: 0x00D57BC2 File Offset: 0x00D55DC2
		public Action<RoleDevelopItemGroup> JumpCallback { get; set; }
	}
}
