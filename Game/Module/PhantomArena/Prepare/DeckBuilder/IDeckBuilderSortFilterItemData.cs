using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005509 RID: 21769
	[NullableContext(1)]
	public interface IDeckBuilderSortFilterItemData
	{
		// Token: 0x17008F1F RID: 36639
		// (get) Token: 0x060377DA RID: 227290
		int ConfigId { get; }

		// Token: 0x17008F20 RID: 36640
		// (get) Token: 0x060377DB RID: 227291
		string Name { get; }
	}
}
