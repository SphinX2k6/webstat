using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020026FF RID: 9983
[NullableContext(1)]
public interface IRacingBetsBettingViewData
{
	// Token: 0x1700190C RID: 6412
	// (get) Token: 0x06013B1A RID: 80666
	// (set) Token: 0x06013B1B RID: 80667
	int SelectDangoId { get; set; }

	// Token: 0x1700190D RID: 6413
	// (get) Token: 0x06013B1C RID: 80668
	// (set) Token: 0x06013B1D RID: 80669
	RacingBetsLegMatchData LegMatchData { get; set; }

	// Token: 0x1700190E RID: 6414
	// (get) Token: 0x06013B1E RID: 80670
	// (set) Token: 0x06013B1F RID: 80671
	List<TsUiSceneDangoActor> DangoActorList { get; set; }
}
