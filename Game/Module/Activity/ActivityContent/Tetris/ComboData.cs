using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A6 RID: 25254
	[NullableContext(1)]
	[Nullable(0)]
	public class ComboData : IComboData
	{
		// Token: 0x17009C85 RID: 40069
		// (get) Token: 0x0603F8D3 RID: 260307 RVA: 0x010493CF File Offset: 0x010475CF
		// (set) Token: 0x0603F8D4 RID: 260308 RVA: 0x010493D7 File Offset: 0x010475D7
		public int ClearedLines { get; set; }

		// Token: 0x17009C86 RID: 40070
		// (get) Token: 0x0603F8D5 RID: 260309 RVA: 0x010493E0 File Offset: 0x010475E0
		// (set) Token: 0x0603F8D6 RID: 260310 RVA: 0x010493E8 File Offset: 0x010475E8
		public bool IsBoardEmpty { get; set; }

		// Token: 0x17009C87 RID: 40071
		// (get) Token: 0x0603F8D7 RID: 260311 RVA: 0x010493F1 File Offset: 0x010475F1
		// (set) Token: 0x0603F8D8 RID: 260312 RVA: 0x010493F9 File Offset: 0x010475F9
		public int ComboCount { get; set; }

		// Token: 0x17009C88 RID: 40072
		// (get) Token: 0x0603F8D9 RID: 260313 RVA: 0x01049402 File Offset: 0x01047602
		// (set) Token: 0x0603F8DA RID: 260314 RVA: 0x0104940A File Offset: 0x0104760A
		public int Score { get; set; }

		// Token: 0x17009C89 RID: 40073
		// (get) Token: 0x0603F8DB RID: 260315 RVA: 0x01049413 File Offset: 0x01047613
		// (set) Token: 0x0603F8DC RID: 260316 RVA: 0x0104941B File Offset: 0x0104761B
		public List<ITetrisGemGetData> GemList { get; set; }

		// Token: 0x17009C8A RID: 40074
		// (get) Token: 0x0603F8DD RID: 260317 RVA: 0x01049424 File Offset: 0x01047624
		// (set) Token: 0x0603F8DE RID: 260318 RVA: 0x0104942C File Offset: 0x0104762C
		public List<int> ClearedRows { get; set; }

		// Token: 0x17009C8B RID: 40075
		// (get) Token: 0x0603F8DF RID: 260319 RVA: 0x01049435 File Offset: 0x01047635
		// (set) Token: 0x0603F8E0 RID: 260320 RVA: 0x0104943D File Offset: 0x0104763D
		public List<int> ClearedCols { get; set; }

		// Token: 0x17009C8C RID: 40076
		// (get) Token: 0x0603F8E1 RID: 260321 RVA: 0x01049446 File Offset: 0x01047646
		// (set) Token: 0x0603F8E2 RID: 260322 RVA: 0x0104944E File Offset: 0x0104764E
		public EGameMode GameMode { get; set; }
	}
}
