using System;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054E6 RID: 21734
	public interface IDeckBuilderCardDeleteFilterItemData
	{
		// Token: 0x17008EB5 RID: 36533
		// (get) Token: 0x06037640 RID: 226880
		ECardElement Element { get; }

		// Token: 0x17008EB6 RID: 36534
		// (get) Token: 0x06037641 RID: 226881
		bool Enabled { get; }

		// Token: 0x17008EB7 RID: 36535
		// (get) Token: 0x06037642 RID: 226882
		bool Selected { get; }
	}
}
