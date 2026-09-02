using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PayShop
{
	// Token: 0x020056B7 RID: 22199
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemData : IItemData
	{
		// Token: 0x170090B4 RID: 37044
		// (get) Token: 0x060387EE RID: 231406 RVA: 0x00E4FE3C File Offset: 0x00E4E03C
		// (set) Token: 0x060387EF RID: 231407 RVA: 0x00E4FE44 File Offset: 0x00E4E044
		public int Quality { get; set; }

		// Token: 0x170090B5 RID: 37045
		// (get) Token: 0x060387F0 RID: 231408 RVA: 0x00E4FE4D File Offset: 0x00E4E04D
		// (set) Token: 0x060387F1 RID: 231409 RVA: 0x00E4FE55 File Offset: 0x00E4E055
		public int ItemId { get; set; }

		// Token: 0x170090B6 RID: 37046
		// (get) Token: 0x060387F2 RID: 231410 RVA: 0x00E4FE5E File Offset: 0x00E4E05E
		// (set) Token: 0x060387F3 RID: 231411 RVA: 0x00E4FE66 File Offset: 0x00E4E066
		public string Name { get; set; }

		// Token: 0x170090B7 RID: 37047
		// (get) Token: 0x060387F4 RID: 231412 RVA: 0x00E4FE6F File Offset: 0x00E4E06F
		// (set) Token: 0x060387F5 RID: 231413 RVA: 0x00E4FE77 File Offset: 0x00E4E077
		public EItemQualityType QualityType { get; set; }
	}
}
