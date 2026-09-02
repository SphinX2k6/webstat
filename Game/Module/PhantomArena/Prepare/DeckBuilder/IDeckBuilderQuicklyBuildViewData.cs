using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005504 RID: 21764
	[NullableContext(1)]
	public interface IDeckBuilderQuicklyBuildViewData
	{
		// Token: 0x17008F19 RID: 36633
		// (get) Token: 0x060377B0 RID: 227248
		// (set) Token: 0x060377B1 RID: 227249
		int ActivityId { get; set; }

		// Token: 0x17008F1A RID: 36634
		// (get) Token: 0x060377B2 RID: 227250
		// (set) Token: 0x060377B3 RID: 227251
		Action<DeckInfo> ConfirmCallback { get; set; }
	}
}
