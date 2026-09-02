using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062EB RID: 25323
	public class EndLessEndOpenParam : IEndLessEndOpenParam
	{
		// Token: 0x17009CAF RID: 40111
		// (get) Token: 0x0603FAB0 RID: 260784 RVA: 0x01052A79 File Offset: 0x01050C79
		// (set) Token: 0x0603FAB1 RID: 260785 RVA: 0x01052A81 File Offset: 0x01050C81
		public int Score { get; set; }

		// Token: 0x17009CB0 RID: 40112
		// (get) Token: 0x0603FAB2 RID: 260786 RVA: 0x01052A8A File Offset: 0x01050C8A
		// (set) Token: 0x0603FAB3 RID: 260787 RVA: 0x01052A92 File Offset: 0x01050C92
		public bool IsQuit { get; set; }
	}
}
