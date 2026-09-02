using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062A5 RID: 25253
	[NullableContext(1)]
	public interface IComboData
	{
		// Token: 0x17009C7D RID: 40061
		// (get) Token: 0x0603F8C3 RID: 260291
		// (set) Token: 0x0603F8C4 RID: 260292
		int ClearedLines { get; set; }

		// Token: 0x17009C7E RID: 40062
		// (get) Token: 0x0603F8C5 RID: 260293
		// (set) Token: 0x0603F8C6 RID: 260294
		bool IsBoardEmpty { get; set; }

		// Token: 0x17009C7F RID: 40063
		// (get) Token: 0x0603F8C7 RID: 260295
		// (set) Token: 0x0603F8C8 RID: 260296
		int ComboCount { get; set; }

		// Token: 0x17009C80 RID: 40064
		// (get) Token: 0x0603F8C9 RID: 260297
		// (set) Token: 0x0603F8CA RID: 260298
		int Score { get; set; }

		// Token: 0x17009C81 RID: 40065
		// (get) Token: 0x0603F8CB RID: 260299
		// (set) Token: 0x0603F8CC RID: 260300
		List<ITetrisGemGetData> GemList { get; set; }

		// Token: 0x17009C82 RID: 40066
		// (get) Token: 0x0603F8CD RID: 260301
		// (set) Token: 0x0603F8CE RID: 260302
		List<int> ClearedRows { get; set; }

		// Token: 0x17009C83 RID: 40067
		// (get) Token: 0x0603F8CF RID: 260303
		// (set) Token: 0x0603F8D0 RID: 260304
		List<int> ClearedCols { get; set; }

		// Token: 0x17009C84 RID: 40068
		// (get) Token: 0x0603F8D1 RID: 260305
		// (set) Token: 0x0603F8D2 RID: 260306
		EGameMode GameMode { get; set; }
	}
}
