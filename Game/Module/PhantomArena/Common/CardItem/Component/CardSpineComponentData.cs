using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005557 RID: 21847
	[NullableContext(1)]
	[Nullable(0)]
	public class CardSpineComponentData : ICardSpineComponentData
	{
		// Token: 0x17008F54 RID: 36692
		// (get) Token: 0x06037AC6 RID: 228038 RVA: 0x00E1ECAA File Offset: 0x00E1CEAA
		// (set) Token: 0x06037AC7 RID: 228039 RVA: 0x00E1ECB2 File Offset: 0x00E1CEB2
		public CardSpineData CardSpineData { get; set; }

		// Token: 0x17008F55 RID: 36693
		// (get) Token: 0x06037AC8 RID: 228040 RVA: 0x00E1ECBB File Offset: 0x00E1CEBB
		// (set) Token: 0x06037AC9 RID: 228041 RVA: 0x00E1ECC3 File Offset: 0x00E1CEC3
		public bool ShowSpine { get; set; }
	}
}
