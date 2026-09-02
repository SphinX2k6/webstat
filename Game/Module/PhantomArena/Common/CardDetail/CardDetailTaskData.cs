using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200558B RID: 21899
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailTaskData : ICardDetailTaskData
	{
		// Token: 0x17008FAF RID: 36783
		// (get) Token: 0x06037C70 RID: 228464 RVA: 0x00E22BEF File Offset: 0x00E20DEF
		// (set) Token: 0x06037C71 RID: 228465 RVA: 0x00E22BF7 File Offset: 0x00E20DF7
		public string Desc { get; set; }

		// Token: 0x17008FB0 RID: 36784
		// (get) Token: 0x06037C72 RID: 228466 RVA: 0x00E22C00 File Offset: 0x00E20E00
		// (set) Token: 0x06037C73 RID: 228467 RVA: 0x00E22C08 File Offset: 0x00E20E08
		public int CurrentProgress { get; set; }
	}
}
