using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200556D RID: 21869
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDetailDurationData : ICardDetailDurationData
	{
		// Token: 0x17008F7D RID: 36733
		// (get) Token: 0x06037BCA RID: 228298 RVA: 0x00E218FE File Offset: 0x00E1FAFE
		// (set) Token: 0x06037BCB RID: 228299 RVA: 0x00E21906 File Offset: 0x00E1FB06
		public string Tips { get; set; }

		// Token: 0x17008F7E RID: 36734
		// (get) Token: 0x06037BCC RID: 228300 RVA: 0x00E2190F File Offset: 0x00E1FB0F
		// (set) Token: 0x06037BCD RID: 228301 RVA: 0x00E21917 File Offset: 0x00E1FB17
		public string DurationDesc { get; set; }
	}
}
