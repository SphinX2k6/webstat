using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A54 RID: 23124
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttrDisplay : IKurotatoAttrDisplay
	{
		// Token: 0x1700955B RID: 38235
		// (get) Token: 0x0603A878 RID: 239736 RVA: 0x00ED30EB File Offset: 0x00ED12EB
		// (set) Token: 0x0603A879 RID: 239737 RVA: 0x00ED30F3 File Offset: 0x00ED12F3
		public string Icon { get; set; }

		// Token: 0x1700955C RID: 38236
		// (get) Token: 0x0603A87A RID: 239738 RVA: 0x00ED30FC File Offset: 0x00ED12FC
		// (set) Token: 0x0603A87B RID: 239739 RVA: 0x00ED3104 File Offset: 0x00ED1304
		public string Text { get; set; }

		// Token: 0x1700955D RID: 38237
		// (get) Token: 0x0603A87C RID: 239740 RVA: 0x00ED310D File Offset: 0x00ED130D
		// (set) Token: 0x0603A87D RID: 239741 RVA: 0x00ED3115 File Offset: 0x00ED1315
		public int PropertyId { get; set; }
	}
}
