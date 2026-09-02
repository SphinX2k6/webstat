using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B0 RID: 25264
	public interface ITetrisScoreSnapshot
	{
		// Token: 0x17009C90 RID: 40080
		// (get) Token: 0x0603F94C RID: 260428
		// (set) Token: 0x0603F94D RID: 260429
		int CurrentScore { get; set; }

		// Token: 0x17009C91 RID: 40081
		// (get) Token: 0x0603F94E RID: 260430
		// (set) Token: 0x0603F94F RID: 260431
		int LastClearTurn { get; set; }

		// Token: 0x17009C92 RID: 40082
		// (get) Token: 0x0603F950 RID: 260432
		// (set) Token: 0x0603F951 RID: 260433
		int ComboCount { get; set; }

		// Token: 0x17009C93 RID: 40083
		// (get) Token: 0x0603F952 RID: 260434
		// (set) Token: 0x0603F953 RID: 260435
		int MaxComboCount { get; set; }
	}
}
