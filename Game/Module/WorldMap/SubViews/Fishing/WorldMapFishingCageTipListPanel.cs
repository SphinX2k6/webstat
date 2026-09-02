using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Fishing
{
	// Token: 0x02004BBD RID: 19389
	public class WorldMapFishingCageTipListPanel : WorldMapSecondaryTipListPanel
	{
		// Token: 0x060329D5 RID: 207317 RVA: 0x00CAD82C File Offset: 0x00CABA2C
		[NullableContext(1)]
		protected override WorldMapSecondaryTipListItem CreateListItem()
		{
			return new WorldMapFishingCageTipListItem();
		}
	}
}
