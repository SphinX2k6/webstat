using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005575 RID: 21877
	public class CardAttributeData : ICardAttributeData
	{
		// Token: 0x17008F82 RID: 36738
		// (get) Token: 0x06037BE8 RID: 228328 RVA: 0x00E21CE0 File Offset: 0x00E1FEE0
		// (set) Token: 0x06037BE9 RID: 228329 RVA: 0x00E21CE8 File Offset: 0x00E1FEE8
		public int Cost { get; set; }

		// Token: 0x17008F83 RID: 36739
		// (get) Token: 0x06037BEA RID: 228330 RVA: 0x00E21CF1 File Offset: 0x00E1FEF1
		// (set) Token: 0x06037BEB RID: 228331 RVA: 0x00E21CF9 File Offset: 0x00E1FEF9
		public int Attack { get; set; }

		// Token: 0x17008F84 RID: 36740
		// (get) Token: 0x06037BEC RID: 228332 RVA: 0x00E21D02 File Offset: 0x00E1FF02
		// (set) Token: 0x06037BED RID: 228333 RVA: 0x00E21D0A File Offset: 0x00E1FF0A
		public int Life { get; set; }
	}
}
