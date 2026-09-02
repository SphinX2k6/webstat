using System;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BD1 RID: 19409
	public interface IWorldMapFishingCageSecondaryTipItemParam : IWorldMapSecondaryTipItemParam
	{
		// Token: 0x170086FB RID: 34555
		// (get) Token: 0x06032A70 RID: 207472
		// (set) Token: 0x06032A71 RID: 207473
		int RelativeId { get; set; }

		// Token: 0x170086FC RID: 34556
		// (get) Token: 0x06032A72 RID: 207474
		// (set) Token: 0x06032A73 RID: 207475
		EFishingCageSecondaryTipItemType TipItemType { get; set; }
	}
}
