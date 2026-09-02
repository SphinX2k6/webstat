using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FBA RID: 20410
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffSubTabItemData : ISheriffSubTabItemData
	{
		// Token: 0x17008A80 RID: 35456
		// (get) Token: 0x06034A82 RID: 215682 RVA: 0x00D34A39 File Offset: 0x00D32C39
		// (set) Token: 0x06034A83 RID: 215683 RVA: 0x00D34A41 File Offset: 0x00D32C41
		public ESheriffSubTabType TabType { get; set; }

		// Token: 0x17008A81 RID: 35457
		// (get) Token: 0x06034A84 RID: 215684 RVA: 0x00D34A4A File Offset: 0x00D32C4A
		// (set) Token: 0x06034A85 RID: 215685 RVA: 0x00D34A52 File Offset: 0x00D32C52
		public string TabIcon { get; set; } = "";

		// Token: 0x17008A82 RID: 35458
		// (get) Token: 0x06034A86 RID: 215686 RVA: 0x00D34A5B File Offset: 0x00D32C5B
		// (set) Token: 0x06034A87 RID: 215687 RVA: 0x00D34A63 File Offset: 0x00D32C63
		public string TabTxt { get; set; } = "";

		// Token: 0x17008A83 RID: 35459
		// (get) Token: 0x06034A88 RID: 215688 RVA: 0x00D34A6C File Offset: 0x00D32C6C
		// (set) Token: 0x06034A89 RID: 215689 RVA: 0x00D34A74 File Offset: 0x00D32C74
		public bool IsFinished { get; set; }
	}
}
