using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005088 RID: 20616
	public interface IRoleDevelopNeedItem
	{
		// Token: 0x17008BA7 RID: 35751
		// (get) Token: 0x0603523E RID: 217662
		// (set) Token: 0x0603523F RID: 217663
		int ItemId { get; set; }

		// Token: 0x17008BA8 RID: 35752
		// (get) Token: 0x06035240 RID: 217664
		// (set) Token: 0x06035241 RID: 217665
		int Count { get; set; }

		// Token: 0x17008BA9 RID: 35753
		// (get) Token: 0x06035242 RID: 217666
		// (set) Token: 0x06035243 RID: 217667
		EItemMaterialType? Type { get; set; }
	}
}
