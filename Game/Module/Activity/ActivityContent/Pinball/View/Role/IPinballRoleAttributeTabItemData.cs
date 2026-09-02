using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C9 RID: 26057
	[NullableContext(1)]
	public interface IPinballRoleAttributeTabItemData
	{
		// Token: 0x17009EF0 RID: 40688
		// (get) Token: 0x060411A8 RID: 266664
		// (set) Token: 0x060411A9 RID: 266665
		EPinballRoleAttributeTabIndex TabIndex { get; set; }

		// Token: 0x17009EF1 RID: 40689
		// (get) Token: 0x060411AA RID: 266666
		// (set) Token: 0x060411AB RID: 266667
		bool IsSelected { get; set; }

		// Token: 0x17009EF2 RID: 40690
		// (get) Token: 0x060411AC RID: 266668
		// (set) Token: 0x060411AD RID: 266669
		Action<EPinballRoleAttributeTabIndex> OnSelectedDelegate { get; set; }
	}
}
