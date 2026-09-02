using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054E8 RID: 21736
	[NullableContext(1)]
	public interface IDeckBuilderCardDeleteViewData
	{
		// Token: 0x17008EB8 RID: 36536
		// (get) Token: 0x06037647 RID: 226887
		// (set) Token: 0x06037648 RID: 226888
		HashSet<ECardElement> EnabledElementSet { get; set; }

		// Token: 0x17008EB9 RID: 36537
		// (get) Token: 0x06037649 RID: 226889
		// (set) Token: 0x0603764A RID: 226890
		Action<HashSet<ECardElement>> DeleteFunc { get; set; }
	}
}
