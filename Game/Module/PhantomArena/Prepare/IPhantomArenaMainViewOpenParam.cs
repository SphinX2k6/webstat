using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder;

namespace CSharpScript.Game.Module.PhantomArena.Prepare
{
	// Token: 0x020054A6 RID: 21670
	[NullableContext(2)]
	public interface IPhantomArenaMainViewOpenParam
	{
		// Token: 0x17008E1E RID: 36382
		// (get) Token: 0x06037288 RID: 225928
		// (set) Token: 0x06037289 RID: 225929
		int ChallengeId { get; set; }

		// Token: 0x17008E1F RID: 36383
		// (get) Token: 0x0603728A RID: 225930
		// (set) Token: 0x0603728B RID: 225931
		EPhantomArenaChildViewName OpenView { get; set; }

		// Token: 0x17008E20 RID: 36384
		// (get) Token: 0x0603728C RID: 225932
		// (set) Token: 0x0603728D RID: 225933
		int ActivityId { get; set; }

		// Token: 0x17008E21 RID: 36385
		// (get) Token: 0x0603728E RID: 225934
		// (set) Token: 0x0603728F RID: 225935
		DeckInfo RecommendDeck { get; set; }
	}
}
