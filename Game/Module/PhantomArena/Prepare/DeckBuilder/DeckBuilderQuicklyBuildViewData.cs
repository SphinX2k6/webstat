using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005505 RID: 21765
	[NullableContext(1)]
	[Nullable(0)]
	public class DeckBuilderQuicklyBuildViewData : IDeckBuilderQuicklyBuildViewData
	{
		// Token: 0x17008F1B RID: 36635
		// (get) Token: 0x060377B4 RID: 227252 RVA: 0x00E11A04 File Offset: 0x00E0FC04
		// (set) Token: 0x060377B5 RID: 227253 RVA: 0x00E11A0C File Offset: 0x00E0FC0C
		public int ActivityId { get; set; }

		// Token: 0x17008F1C RID: 36636
		// (get) Token: 0x060377B6 RID: 227254 RVA: 0x00E11A15 File Offset: 0x00E0FC15
		// (set) Token: 0x060377B7 RID: 227255 RVA: 0x00E11A1D File Offset: 0x00E0FC1D
		public Action<DeckInfo> ConfirmCallback { get; set; }
	}
}
