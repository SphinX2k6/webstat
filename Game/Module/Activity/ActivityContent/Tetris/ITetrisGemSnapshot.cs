using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062B3 RID: 25267
	[NullableContext(1)]
	public interface ITetrisGemSnapshot
	{
		// Token: 0x17009C98 RID: 40088
		// (get) Token: 0x0603F968 RID: 260456
		// (set) Token: 0x0603F969 RID: 260457
		Dictionary<EGemType, int> CollectedGems { get; set; }

		// Token: 0x17009C99 RID: 40089
		// (get) Token: 0x0603F96A RID: 260458
		// (set) Token: 0x0603F96B RID: 260459
		List<EGemType> CurrentGemBag { get; set; }

		// Token: 0x17009C9A RID: 40090
		// (get) Token: 0x0603F96C RID: 260460
		// (set) Token: 0x0603F96D RID: 260461
		Dictionary<EGemType, int> SpawnCounts { get; set; }
	}
}
