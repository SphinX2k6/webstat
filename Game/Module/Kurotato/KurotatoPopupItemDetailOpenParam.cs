using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A4E RID: 23118
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoPopupItemDetailOpenParam : IKurotatoPopupItemDetailOpenParam
	{
		// Token: 0x17009548 RID: 38216
		// (get) Token: 0x0603A84F RID: 239695 RVA: 0x00ED3029 File Offset: 0x00ED1229
		// (set) Token: 0x0603A850 RID: 239696 RVA: 0x00ED3031 File Offset: 0x00ED1231
		public int Index { get; set; }

		// Token: 0x17009549 RID: 38217
		// (get) Token: 0x0603A851 RID: 239697 RVA: 0x00ED303A File Offset: 0x00ED123A
		// (set) Token: 0x0603A852 RID: 239698 RVA: 0x00ED3042 File Offset: 0x00ED1242
		public List<KurotatoCardTip> CardData { get; set; }

		// Token: 0x1700954A RID: 38218
		// (get) Token: 0x0603A853 RID: 239699 RVA: 0x00ED304B File Offset: 0x00ED124B
		// (set) Token: 0x0603A854 RID: 239700 RVA: 0x00ED3053 File Offset: 0x00ED1253
		public bool? IsOutSide { get; set; }

		// Token: 0x1700954B RID: 38219
		// (get) Token: 0x0603A855 RID: 239701 RVA: 0x00ED305C File Offset: 0x00ED125C
		// (set) Token: 0x0603A856 RID: 239702 RVA: 0x00ED3064 File Offset: 0x00ED1264
		[Nullable(2)]
		public List<int> Price { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
