using System;

namespace CSharpScript.Game.Module.RoleDev
{
	// Token: 0x02005035 RID: 20533
	public class ItemMaterial : IItemMaterial
	{
		// Token: 0x17008AE3 RID: 35555
		// (get) Token: 0x06034E04 RID: 216580 RVA: 0x00D46661 File Offset: 0x00D44861
		// (set) Token: 0x06034E05 RID: 216581 RVA: 0x00D46669 File Offset: 0x00D44869
		public int ItemId { get; set; }

		// Token: 0x17008AE4 RID: 35556
		// (get) Token: 0x06034E06 RID: 216582 RVA: 0x00D46672 File Offset: 0x00D44872
		// (set) Token: 0x06034E07 RID: 216583 RVA: 0x00D4667A File Offset: 0x00D4487A
		public int RequiredCount { get; set; }
	}
}
