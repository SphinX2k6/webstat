using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D4 RID: 26068
	public interface IPinballRoleHeadItemData
	{
		// Token: 0x17009F00 RID: 40704
		// (get) Token: 0x060411FC RID: 266748
		// (set) Token: 0x060411FD RID: 266749
		PinballRoleConfig RoleConfig { get; set; }

		// Token: 0x17009F01 RID: 40705
		// (get) Token: 0x060411FE RID: 266750
		// (set) Token: 0x060411FF RID: 266751
		bool IsSelected { get; set; }

		// Token: 0x17009F02 RID: 40706
		// (get) Token: 0x06041200 RID: 266752
		// (set) Token: 0x06041201 RID: 266753
		bool IsLocked { get; set; }

		// Token: 0x17009F03 RID: 40707
		// (get) Token: 0x06041202 RID: 266754
		// (set) Token: 0x06041203 RID: 266755
		bool IsTrail { get; set; }

		// Token: 0x17009F04 RID: 40708
		// (get) Token: 0x06041204 RID: 266756
		// (set) Token: 0x06041205 RID: 266757
		bool NeedRedDot { get; set; }
	}
}
