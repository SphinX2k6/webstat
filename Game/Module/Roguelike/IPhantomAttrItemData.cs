using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005160 RID: 20832
	[NullableContext(1)]
	public interface IPhantomAttrItemData
	{
		// Token: 0x17008C7B RID: 35963
		// (get) Token: 0x060359D3 RID: 219603
		// (set) Token: 0x060359D4 RID: 219604
		AffixEntry AffixEntry { get; set; }

		// Token: 0x17008C7C RID: 35964
		// (get) Token: 0x060359D5 RID: 219605
		// (set) Token: 0x060359D6 RID: 219606
		RoguelikeInfo RoguelikeInfo { get; set; }
	}
}
