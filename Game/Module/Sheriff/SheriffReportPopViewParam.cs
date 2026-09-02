using System;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC4 RID: 20420
	public class SheriffReportPopViewParam : ISheriffReportPopViewParam
	{
		// Token: 0x17008A8E RID: 35470
		// (get) Token: 0x06034AA2 RID: 215714 RVA: 0x00D34BBA File Offset: 0x00D32DBA
		// (set) Token: 0x06034AA3 RID: 215715 RVA: 0x00D34BC2 File Offset: 0x00D32DC2
		public int CriminalId { get; set; }

		// Token: 0x17008A8F RID: 35471
		// (get) Token: 0x06034AA4 RID: 215716 RVA: 0x00D34BCB File Offset: 0x00D32DCB
		// (set) Token: 0x06034AA5 RID: 215717 RVA: 0x00D34BD3 File Offset: 0x00D32DD3
		public bool BothPage { get; set; }
	}
}
