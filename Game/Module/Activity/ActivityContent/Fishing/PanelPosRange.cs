using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067FC RID: 26620
	public class PanelPosRange : IPanelPosRange
	{
		// Token: 0x1700A143 RID: 41283
		// (get) Token: 0x060425CE RID: 271822 RVA: 0x01104609 File Offset: 0x01102809
		// (set) Token: 0x060425CF RID: 271823 RVA: 0x01104611 File Offset: 0x01102811
		public int RowStartIndex { get; set; }

		// Token: 0x1700A144 RID: 41284
		// (get) Token: 0x060425D0 RID: 271824 RVA: 0x0110461A File Offset: 0x0110281A
		// (set) Token: 0x060425D1 RID: 271825 RVA: 0x01104622 File Offset: 0x01102822
		public int RowEndIndex { get; set; }

		// Token: 0x1700A145 RID: 41285
		// (get) Token: 0x060425D2 RID: 271826 RVA: 0x0110462B File Offset: 0x0110282B
		// (set) Token: 0x060425D3 RID: 271827 RVA: 0x01104633 File Offset: 0x01102833
		public int ColStartIndex { get; set; }

		// Token: 0x1700A146 RID: 41286
		// (get) Token: 0x060425D4 RID: 271828 RVA: 0x0110463C File Offset: 0x0110283C
		// (set) Token: 0x060425D5 RID: 271829 RVA: 0x01104644 File Offset: 0x01102844
		public int ColEndIndex { get; set; }
	}
}
