using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005581 RID: 21889
	public class CardDetailEffectCountData : ICardDetailEffectCountData
	{
		// Token: 0x17008F9D RID: 36765
		// (get) Token: 0x06037C3D RID: 228413 RVA: 0x00E2276D File Offset: 0x00E2096D
		// (set) Token: 0x06037C3E RID: 228414 RVA: 0x00E22775 File Offset: 0x00E20975
		public int CurrentEffectCount { get; set; }

		// Token: 0x17008F9E RID: 36766
		// (get) Token: 0x06037C3F RID: 228415 RVA: 0x00E2277E File Offset: 0x00E2097E
		// (set) Token: 0x06037C40 RID: 228416 RVA: 0x00E22786 File Offset: 0x00E20986
		public int TotalEffectCount { get; set; }
	}
}
