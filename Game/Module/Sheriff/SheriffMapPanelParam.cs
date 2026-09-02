using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB4 RID: 20404
	[NullableContext(2)]
	[Nullable(0)]
	public class SheriffMapPanelParam : ISheriffMapPanelParam
	{
		// Token: 0x17008A6E RID: 35438
		// (get) Token: 0x06034A5C RID: 215644 RVA: 0x00D3497A File Offset: 0x00D32B7A
		// (set) Token: 0x06034A5D RID: 215645 RVA: 0x00D34982 File Offset: 0x00D32B82
		public ESheriffMainTabType? TabType { get; set; }

		// Token: 0x17008A6F RID: 35439
		// (get) Token: 0x06034A5E RID: 215646 RVA: 0x00D3498B File Offset: 0x00D32B8B
		// (set) Token: 0x06034A5F RID: 215647 RVA: 0x00D34993 File Offset: 0x00D32B93
		public int? TargetMarkId { get; set; }

		// Token: 0x17008A70 RID: 35440
		// (get) Token: 0x06034A60 RID: 215648 RVA: 0x00D3499C File Offset: 0x00D32B9C
		// (set) Token: 0x06034A61 RID: 215649 RVA: 0x00D349A4 File Offset: 0x00D32BA4
		public bool? IsError { get; set; }

		// Token: 0x17008A71 RID: 35441
		// (get) Token: 0x06034A62 RID: 215650 RVA: 0x00D349AD File Offset: 0x00D32BAD
		// (set) Token: 0x06034A63 RID: 215651 RVA: 0x00D349B5 File Offset: 0x00D32BB5
		public Action OnPanelOpened { get; set; }
	}
}
