using System;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop
{
	// Token: 0x02005096 RID: 20630
	public interface IDropRewardItemData
	{
		// Token: 0x17008BCF RID: 35791
		// (get) Token: 0x06035294 RID: 217748
		// (set) Token: 0x06035295 RID: 217749
		int ItemId { get; set; }

		// Token: 0x17008BD0 RID: 35792
		// (get) Token: 0x06035296 RID: 217750
		// (set) Token: 0x06035297 RID: 217751
		int Count { get; set; }

		// Token: 0x17008BD1 RID: 35793
		// (get) Token: 0x06035298 RID: 217752
		// (set) Token: 0x06035299 RID: 217753
		bool HaveFinish { get; set; }
	}
}
