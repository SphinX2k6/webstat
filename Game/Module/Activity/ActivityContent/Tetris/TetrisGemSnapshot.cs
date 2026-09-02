using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B4 RID: 25268
	[NullableContext(1)]
	[Nullable(0)]
	public class TetrisGemSnapshot : ITetrisGemSnapshot
	{
		// Token: 0x17009C9B RID: 40091
		// (get) Token: 0x0603F96E RID: 260462 RVA: 0x0104C303 File Offset: 0x0104A503
		// (set) Token: 0x0603F96F RID: 260463 RVA: 0x0104C30B File Offset: 0x0104A50B
		public Dictionary<EGemType, int> CollectedGems { get; set; }

		// Token: 0x17009C9C RID: 40092
		// (get) Token: 0x0603F970 RID: 260464 RVA: 0x0104C314 File Offset: 0x0104A514
		// (set) Token: 0x0603F971 RID: 260465 RVA: 0x0104C31C File Offset: 0x0104A51C
		public List<EGemType> CurrentGemBag { get; set; }

		// Token: 0x17009C9D RID: 40093
		// (get) Token: 0x0603F972 RID: 260466 RVA: 0x0104C325 File Offset: 0x0104A525
		// (set) Token: 0x0603F973 RID: 260467 RVA: 0x0104C32D File Offset: 0x0104A52D
		public Dictionary<EGemType, int> SpawnCounts { get; set; }
	}
}
