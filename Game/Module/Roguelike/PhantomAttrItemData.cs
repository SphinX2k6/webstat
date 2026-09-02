using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005161 RID: 20833
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomAttrItemData : IPhantomAttrItemData
	{
		// Token: 0x17008C7D RID: 35965
		// (get) Token: 0x060359D7 RID: 219607 RVA: 0x00D7773B File Offset: 0x00D7593B
		// (set) Token: 0x060359D8 RID: 219608 RVA: 0x00D77743 File Offset: 0x00D75943
		public AffixEntry AffixEntry { get; set; }

		// Token: 0x17008C7E RID: 35966
		// (get) Token: 0x060359D9 RID: 219609 RVA: 0x00D7774C File Offset: 0x00D7594C
		// (set) Token: 0x060359DA RID: 219610 RVA: 0x00D77754 File Offset: 0x00D75954
		public RoguelikeInfo RoguelikeInfo { get; set; }
	}
}
