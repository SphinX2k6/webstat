using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BD2 RID: 19410
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapFishingCageSecondaryTipItemParam : IWorldMapFishingCageSecondaryTipItemParam, IWorldMapSecondaryTipItemParam
	{
		// Token: 0x170086FD RID: 34557
		// (get) Token: 0x06032A74 RID: 207476 RVA: 0x00CB00A0 File Offset: 0x00CAE2A0
		// (set) Token: 0x06032A75 RID: 207477 RVA: 0x00CB00A8 File Offset: 0x00CAE2A8
		public string Name { get; set; }

		// Token: 0x170086FE RID: 34558
		// (get) Token: 0x06032A76 RID: 207478 RVA: 0x00CB00B1 File Offset: 0x00CAE2B1
		// (set) Token: 0x06032A77 RID: 207479 RVA: 0x00CB00B9 File Offset: 0x00CAE2B9
		public string Desc { get; set; }

		// Token: 0x170086FF RID: 34559
		// (get) Token: 0x06032A78 RID: 207480 RVA: 0x00CB00C2 File Offset: 0x00CAE2C2
		// (set) Token: 0x06032A79 RID: 207481 RVA: 0x00CB00CA File Offset: 0x00CAE2CA
		public int RelativeId { get; set; }

		// Token: 0x17008700 RID: 34560
		// (get) Token: 0x06032A7A RID: 207482 RVA: 0x00CB00D3 File Offset: 0x00CAE2D3
		// (set) Token: 0x06032A7B RID: 207483 RVA: 0x00CB00DB File Offset: 0x00CAE2DB
		public EFishingCageSecondaryTipItemType TipItemType { get; set; }
	}
}
