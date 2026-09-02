using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005034 RID: 20532
	public interface IItemMaterial
	{
		// Token: 0x17008AE1 RID: 35553
		// (get) Token: 0x06034E00 RID: 216576
		// (set) Token: 0x06034E01 RID: 216577
		int ItemId { get; set; }

		// Token: 0x17008AE2 RID: 35554
		// (get) Token: 0x06034E02 RID: 216578
		// (set) Token: 0x06034E03 RID: 216579
		int RequiredCount { get; set; }
	}
}
