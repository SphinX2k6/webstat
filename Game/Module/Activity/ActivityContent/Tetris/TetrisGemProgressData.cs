using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A2 RID: 25250
	public class TetrisGemProgressData : ITetrisGemProgressData
	{
		// Token: 0x17009C76 RID: 40054
		// (get) Token: 0x0603F8B3 RID: 260275 RVA: 0x0104936A File Offset: 0x0104756A
		// (set) Token: 0x0603F8B4 RID: 260276 RVA: 0x01049372 File Offset: 0x01047572
		public int GemId { get; set; }

		// Token: 0x17009C77 RID: 40055
		// (get) Token: 0x0603F8B5 RID: 260277 RVA: 0x0104937B File Offset: 0x0104757B
		// (set) Token: 0x0603F8B6 RID: 260278 RVA: 0x01049383 File Offset: 0x01047583
		public int CurrentGemCount { get; set; }

		// Token: 0x17009C78 RID: 40056
		// (get) Token: 0x0603F8B7 RID: 260279 RVA: 0x0104938C File Offset: 0x0104758C
		// (set) Token: 0x0603F8B8 RID: 260280 RVA: 0x01049394 File Offset: 0x01047594
		public int TargetGemCount { get; set; }
	}
}
