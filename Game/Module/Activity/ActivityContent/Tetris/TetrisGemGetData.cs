using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A4 RID: 25252
	public class TetrisGemGetData : ITetrisGemGetData
	{
		// Token: 0x17009C7B RID: 40059
		// (get) Token: 0x0603F8BE RID: 260286 RVA: 0x010493A5 File Offset: 0x010475A5
		// (set) Token: 0x0603F8BF RID: 260287 RVA: 0x010493AD File Offset: 0x010475AD
		public int GemId { get; set; }

		// Token: 0x17009C7C RID: 40060
		// (get) Token: 0x0603F8C0 RID: 260288 RVA: 0x010493B6 File Offset: 0x010475B6
		// (set) Token: 0x0603F8C1 RID: 260289 RVA: 0x010493BE File Offset: 0x010475BE
		public int GetGemCount { get; set; }
	}
}
