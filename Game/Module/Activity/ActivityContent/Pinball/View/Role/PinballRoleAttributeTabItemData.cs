using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065CA RID: 26058
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleAttributeTabItemData : IPinballRoleAttributeTabItemData
	{
		// Token: 0x17009EF3 RID: 40691
		// (get) Token: 0x060411AE RID: 266670 RVA: 0x010B40AA File Offset: 0x010B22AA
		// (set) Token: 0x060411AF RID: 266671 RVA: 0x010B40B2 File Offset: 0x010B22B2
		public EPinballRoleAttributeTabIndex TabIndex { get; set; }

		// Token: 0x17009EF4 RID: 40692
		// (get) Token: 0x060411B0 RID: 266672 RVA: 0x010B40BB File Offset: 0x010B22BB
		// (set) Token: 0x060411B1 RID: 266673 RVA: 0x010B40C3 File Offset: 0x010B22C3
		public bool IsSelected { get; set; }

		// Token: 0x17009EF5 RID: 40693
		// (get) Token: 0x060411B2 RID: 266674 RVA: 0x010B40CC File Offset: 0x010B22CC
		// (set) Token: 0x060411B3 RID: 266675 RVA: 0x010B40D4 File Offset: 0x010B22D4
		public Action<EPinballRoleAttributeTabIndex> OnSelectedDelegate { get; set; }
	}
}
