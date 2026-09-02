using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005508 RID: 21768
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderSortFilterItemData : IDeckBuilderSortFilterItemData
	{
		// Token: 0x17008F1D RID: 36637
		// (get) Token: 0x060377D5 RID: 227285 RVA: 0x00E120BC File Offset: 0x00E102BC
		// (set) Token: 0x060377D6 RID: 227286 RVA: 0x00E120C4 File Offset: 0x00E102C4
		public int ConfigId { get; set; }

		// Token: 0x17008F1E RID: 36638
		// (get) Token: 0x060377D7 RID: 227287 RVA: 0x00E120CD File Offset: 0x00E102CD
		// (set) Token: 0x060377D8 RID: 227288 RVA: 0x00E120D5 File Offset: 0x00E102D5
		public string Name { get; set; } = string.Empty;
	}
}
