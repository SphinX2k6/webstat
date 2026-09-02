using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054F8 RID: 21752
	[NullableContext(1)]
	public interface IDeckBuilderCardSlotItemData
	{
		// Token: 0x17008ED5 RID: 36565
		// (get) Token: 0x060376C3 RID: 227011
		// (set) Token: 0x060376C4 RID: 227012
		DeckCardSlotInfo SlotInfo { get; set; }

		// Token: 0x17008ED6 RID: 36566
		// (get) Token: 0x060376C5 RID: 227013
		// (set) Token: 0x060376C6 RID: 227014
		bool Locked { get; set; }

		// Token: 0x17008ED7 RID: 36567
		// (get) Token: 0x060376C7 RID: 227015
		// (set) Token: 0x060376C8 RID: 227016
		bool RedDotState { get; set; }

		// Token: 0x17008ED8 RID: 36568
		// (get) Token: 0x060376C9 RID: 227017
		// (set) Token: 0x060376CA RID: 227018
		bool OutlookUnlocked { get; set; }

		// Token: 0x17008ED9 RID: 36569
		// (get) Token: 0x060376CB RID: 227019
		// (set) Token: 0x060376CC RID: 227020
		bool NeedPlayAddAnim { get; set; }
	}
}
