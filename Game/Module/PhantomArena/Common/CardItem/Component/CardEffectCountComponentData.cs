using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200554C RID: 21836
	public class CardEffectCountComponentData : ICardEffectCountComponentData
	{
		// Token: 0x17008F47 RID: 36679
		// (get) Token: 0x06037A83 RID: 227971 RVA: 0x00E1E3AB File Offset: 0x00E1C5AB
		// (set) Token: 0x06037A84 RID: 227972 RVA: 0x00E1E3B3 File Offset: 0x00E1C5B3
		public int EffectCount { get; set; }

		// Token: 0x17008F48 RID: 36680
		// (get) Token: 0x06037A85 RID: 227973 RVA: 0x00E1E3BC File Offset: 0x00E1C5BC
		// (set) Token: 0x06037A86 RID: 227974 RVA: 0x00E1E3C4 File Offset: 0x00E1C5C4
		public int EffectCountMax { get; set; }

		// Token: 0x17008F49 RID: 36681
		// (get) Token: 0x06037A87 RID: 227975 RVA: 0x00E1E3CD File Offset: 0x00E1C5CD
		// (set) Token: 0x06037A88 RID: 227976 RVA: 0x00E1E3D5 File Offset: 0x00E1C5D5
		public bool InFight { get; set; }
	}
}
