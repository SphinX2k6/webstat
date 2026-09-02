using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC2 RID: 20418
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffReportPopParam : ISheriffReportPopParam
	{
		// Token: 0x17008A8A RID: 35466
		// (get) Token: 0x06034A99 RID: 215705 RVA: 0x00D34B6B File Offset: 0x00D32D6B
		// (set) Token: 0x06034A9A RID: 215706 RVA: 0x00D34B73 File Offset: 0x00D32D73
		public int CriminalId { get; set; }

		// Token: 0x17008A8B RID: 35467
		// (get) Token: 0x06034A9B RID: 215707 RVA: 0x00D34B7C File Offset: 0x00D32D7C
		// (set) Token: 0x06034A9C RID: 215708 RVA: 0x00D34B84 File Offset: 0x00D32D84
		public Action CloseCallback { get; set; } = delegate()
		{
		};
	}
}
