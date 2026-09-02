using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4D RID: 23117
	[NullableContext(1)]
	public interface IKurotatoPopupItemDetailOpenParam
	{
		// Token: 0x17009544 RID: 38212
		// (get) Token: 0x0603A847 RID: 239687
		// (set) Token: 0x0603A848 RID: 239688
		int Index { get; set; }

		// Token: 0x17009545 RID: 38213
		// (get) Token: 0x0603A849 RID: 239689
		// (set) Token: 0x0603A84A RID: 239690
		List<KurotatoCardTip> CardData { get; set; }

		// Token: 0x17009546 RID: 38214
		// (get) Token: 0x0603A84B RID: 239691
		// (set) Token: 0x0603A84C RID: 239692
		bool? IsOutSide { get; set; }

		// Token: 0x17009547 RID: 38215
		// (get) Token: 0x0603A84D RID: 239693
		// (set) Token: 0x0603A84E RID: 239694
		[Nullable(2)]
		List<int> Price { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
