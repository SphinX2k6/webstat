using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006421 RID: 25633
	[NullableContext(1)]
	[Nullable(0)]
	internal class ShopGridSortInfo : IShopGridSortInfo
	{
		// Token: 0x17009DF0 RID: 40432
		// (get) Token: 0x06040583 RID: 263555 RVA: 0x0107DCB1 File Offset: 0x0107BEB1
		// (set) Token: 0x06040584 RID: 263556 RVA: 0x0107DCB9 File Offset: 0x0107BEB9
		public IRoverlikeGameShopGridData Data { get; set; }

		// Token: 0x17009DF1 RID: 40433
		// (get) Token: 0x06040585 RID: 263557 RVA: 0x0107DCC2 File Offset: 0x0107BEC2
		// (set) Token: 0x06040586 RID: 263558 RVA: 0x0107DCCA File Offset: 0x0107BECA
		public int OriginalIndex { get; set; }
	}
}
