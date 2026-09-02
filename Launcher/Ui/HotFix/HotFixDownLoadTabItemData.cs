using System;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004503 RID: 17667
	public class HotFixDownLoadTabItemData : IHotFixDownLoadTabItemData, IHotFixLayoutData
	{
		// Token: 0x17008043 RID: 32835
		// (get) Token: 0x0602E8F0 RID: 190704 RVA: 0x00B080D8 File Offset: 0x00B062D8
		// (set) Token: 0x0602E8F1 RID: 190705 RVA: 0x00B080E0 File Offset: 0x00B062E0
		public int? Index { get; set; }

		// Token: 0x17008044 RID: 32836
		// (get) Token: 0x0602E8F2 RID: 190706 RVA: 0x00B080E9 File Offset: 0x00B062E9
		// (set) Token: 0x0602E8F3 RID: 190707 RVA: 0x00B080F1 File Offset: 0x00B062F1
		public int TabId { get; set; }
	}
}
