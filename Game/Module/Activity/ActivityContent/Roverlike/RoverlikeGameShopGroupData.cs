using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641A RID: 25626
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeGameShopGroupData : IRoverlikeGameShopGroupData
	{
		// Token: 0x17009DEB RID: 40427
		// (get) Token: 0x06040553 RID: 263507 RVA: 0x0107D338 File Offset: 0x0107B538
		// (set) Token: 0x06040554 RID: 263508 RVA: 0x0107D340 File Offset: 0x0107B540
		public ERoverlikeGameShopItemType GroupType { get; set; }

		// Token: 0x17009DEC RID: 40428
		// (get) Token: 0x06040555 RID: 263509 RVA: 0x0107D349 File Offset: 0x0107B549
		// (set) Token: 0x06040556 RID: 263510 RVA: 0x0107D351 File Offset: 0x0107B551
		public string TitleTextKey { get; set; }

		// Token: 0x17009DED RID: 40429
		// (get) Token: 0x06040557 RID: 263511 RVA: 0x0107D35A File Offset: 0x0107B55A
		// (set) Token: 0x06040558 RID: 263512 RVA: 0x0107D362 File Offset: 0x0107B562
		public List<IRoverlikeGameShopGridData> Grids { get; set; }
	}
}
