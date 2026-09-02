using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;

namespace CSharpScript.Game.Module.PhantomArena.Battle
{
	// Token: 0x020055A1 RID: 21921
	[NullableContext(1)]
	public interface IPhantomArenaBattleLoadingInfo
	{
		// Token: 0x17008FC9 RID: 36809
		// (get) Token: 0x06037CC4 RID: 228548
		// (set) Token: 0x06037CC5 RID: 228549
		int Index { get; set; }

		// Token: 0x17008FCA RID: 36810
		// (get) Token: 0x06037CC6 RID: 228550
		// (set) Token: 0x06037CC7 RID: 228551
		bool IsMe { get; set; }

		// Token: 0x17008FCB RID: 36811
		// (get) Token: 0x06037CC8 RID: 228552
		// (set) Token: 0x06037CC9 RID: 228553
		PhantomCardData CardData { get; set; }
	}
}
