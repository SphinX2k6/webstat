using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005579 RID: 21881
	[NullableContext(1)]
	public interface ICardDetailLockData
	{
		// Token: 0x17008F89 RID: 36745
		// (get) Token: 0x06037C0F RID: 228367
		// (set) Token: 0x06037C10 RID: 228368
		string Desc { get; set; }

		// Token: 0x17008F8A RID: 36746
		// (get) Token: 0x06037C11 RID: 228369
		// (set) Token: 0x06037C12 RID: 228370
		int RemainRound { get; set; }
	}
}
