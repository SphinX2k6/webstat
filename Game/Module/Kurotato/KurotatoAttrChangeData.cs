using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A65 RID: 23141
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoAttrChangeData : IKurotatoAttrChangeData
	{
		// Token: 0x1700957E RID: 38270
		// (get) Token: 0x0603A8C2 RID: 239810 RVA: 0x00ED323D File Offset: 0x00ED143D
		// (set) Token: 0x0603A8C3 RID: 239811 RVA: 0x00ED3245 File Offset: 0x00ED1445
		public string Text { get; set; }

		// Token: 0x1700957F RID: 38271
		// (get) Token: 0x0603A8C4 RID: 239812 RVA: 0x00ED324E File Offset: 0x00ED144E
		// (set) Token: 0x0603A8C5 RID: 239813 RVA: 0x00ED3256 File Offset: 0x00ED1456
		public string IconPath { get; set; }
	}
}
