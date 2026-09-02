using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200557A RID: 21882
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailLockData : ICardDetailLockData
	{
		// Token: 0x17008F8B RID: 36747
		// (get) Token: 0x06037C13 RID: 228371 RVA: 0x00E22668 File Offset: 0x00E20868
		// (set) Token: 0x06037C14 RID: 228372 RVA: 0x00E22670 File Offset: 0x00E20870
		public string Desc { get; set; }

		// Token: 0x17008F8C RID: 36748
		// (get) Token: 0x06037C15 RID: 228373 RVA: 0x00E22679 File Offset: 0x00E20879
		// (set) Token: 0x06037C16 RID: 228374 RVA: 0x00E22681 File Offset: 0x00E20881
		public int RemainRound { get; set; }
	}
}
