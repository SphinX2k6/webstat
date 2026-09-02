using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.Settlement
{
	// Token: 0x02005A7E RID: 23166
	[NullableContext(1)]
	[Nullable(0)]
	internal class GridItemCellData
	{
		// Token: 0x17009591 RID: 38289
		// (get) Token: 0x0603A9F0 RID: 240112 RVA: 0x00ED9C0A File Offset: 0x00ED7E0A
		// (set) Token: 0x0603A9F1 RID: 240113 RVA: 0x00ED9C12 File Offset: 0x00ED7E12
		public IKurotatoSmallItemGridData Item { get; set; }

		// Token: 0x17009592 RID: 38290
		// (get) Token: 0x0603A9F2 RID: 240114 RVA: 0x00ED9C1B File Offset: 0x00ED7E1B
		// (set) Token: 0x0603A9F3 RID: 240115 RVA: 0x00ED9C23 File Offset: 0x00ED7E23
		[Nullable(2)]
		public Action OnClick { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
