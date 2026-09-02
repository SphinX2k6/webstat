using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BD0 RID: 19408
	[NullableContext(1)]
	[Nullable(0)]
	public class WorldMapSecondaryTipItemParam : IWorldMapSecondaryTipItemParam
	{
		// Token: 0x170086F9 RID: 34553
		// (get) Token: 0x06032A6B RID: 207467 RVA: 0x00CB0076 File Offset: 0x00CAE276
		// (set) Token: 0x06032A6C RID: 207468 RVA: 0x00CB007E File Offset: 0x00CAE27E
		public string Name { get; set; }

		// Token: 0x170086FA RID: 34554
		// (get) Token: 0x06032A6D RID: 207469 RVA: 0x00CB0087 File Offset: 0x00CAE287
		// (set) Token: 0x06032A6E RID: 207470 RVA: 0x00CB008F File Offset: 0x00CAE28F
		public string Desc { get; set; }
	}
}
