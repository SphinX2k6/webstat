using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002700 RID: 9984
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsBettingViewData : IRacingBetsBettingViewData
{
	// Token: 0x1700190F RID: 6415
	// (get) Token: 0x06013B20 RID: 80672 RVA: 0x0057D362 File Offset: 0x0057B562
	// (set) Token: 0x06013B21 RID: 80673 RVA: 0x0057D36A File Offset: 0x0057B56A
	public int SelectDangoId { get; set; }

	// Token: 0x17001910 RID: 6416
	// (get) Token: 0x06013B22 RID: 80674 RVA: 0x0057D373 File Offset: 0x0057B573
	// (set) Token: 0x06013B23 RID: 80675 RVA: 0x0057D37B File Offset: 0x0057B57B
	public RacingBetsLegMatchData LegMatchData { get; set; }

	// Token: 0x17001911 RID: 6417
	// (get) Token: 0x06013B24 RID: 80676 RVA: 0x0057D384 File Offset: 0x0057B584
	// (set) Token: 0x06013B25 RID: 80677 RVA: 0x0057D38C File Offset: 0x0057B58C
	public List<TsUiSceneDangoActor> DangoActorList { get; set; }
}
