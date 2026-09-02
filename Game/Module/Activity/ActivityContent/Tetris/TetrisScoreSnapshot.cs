using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B1 RID: 25265
	public class TetrisScoreSnapshot : ITetrisScoreSnapshot
	{
		// Token: 0x17009C94 RID: 40084
		// (get) Token: 0x0603F954 RID: 260436 RVA: 0x0104C020 File Offset: 0x0104A220
		// (set) Token: 0x0603F955 RID: 260437 RVA: 0x0104C028 File Offset: 0x0104A228
		public int CurrentScore { get; set; }

		// Token: 0x17009C95 RID: 40085
		// (get) Token: 0x0603F956 RID: 260438 RVA: 0x0104C031 File Offset: 0x0104A231
		// (set) Token: 0x0603F957 RID: 260439 RVA: 0x0104C039 File Offset: 0x0104A239
		public int LastClearTurn { get; set; }

		// Token: 0x17009C96 RID: 40086
		// (get) Token: 0x0603F958 RID: 260440 RVA: 0x0104C042 File Offset: 0x0104A242
		// (set) Token: 0x0603F959 RID: 260441 RVA: 0x0104C04A File Offset: 0x0104A24A
		public int ComboCount { get; set; }

		// Token: 0x17009C97 RID: 40087
		// (get) Token: 0x0603F95A RID: 260442 RVA: 0x0104C053 File Offset: 0x0104A253
		// (set) Token: 0x0603F95B RID: 260443 RVA: 0x0104C05B File Offset: 0x0104A25B
		public int MaxComboCount { get; set; }
	}
}
