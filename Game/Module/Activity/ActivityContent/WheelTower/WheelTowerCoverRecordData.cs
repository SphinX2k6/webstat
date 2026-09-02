using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620C RID: 25100
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerCoverRecordData : IWheelTowerCoverRecordData
	{
		// Token: 0x17009B93 RID: 39827
		// (get) Token: 0x0603F522 RID: 259362 RVA: 0x0103E855 File Offset: 0x0103CA55
		// (set) Token: 0x0603F523 RID: 259363 RVA: 0x0103E85D File Offset: 0x0103CA5D
		public int TotalScore { get; set; }

		// Token: 0x17009B94 RID: 39828
		// (get) Token: 0x0603F524 RID: 259364 RVA: 0x0103E866 File Offset: 0x0103CA66
		// (set) Token: 0x0603F525 RID: 259365 RVA: 0x0103E86E File Offset: 0x0103CA6E
		public int TeamScore { get; set; }

		// Token: 0x17009B95 RID: 39829
		// (get) Token: 0x0603F526 RID: 259366 RVA: 0x0103E877 File Offset: 0x0103CA77
		// (set) Token: 0x0603F527 RID: 259367 RVA: 0x0103E87F File Offset: 0x0103CA7F
		public List<int> TeamRoleIdList { get; set; } = new List<int>();

		// Token: 0x17009B96 RID: 39830
		// (get) Token: 0x0603F528 RID: 259368 RVA: 0x0103E888 File Offset: 0x0103CA88
		// (set) Token: 0x0603F529 RID: 259369 RVA: 0x0103E890 File Offset: 0x0103CA90
		public int BuffId { get; set; }

		// Token: 0x17009B97 RID: 39831
		// (get) Token: 0x0603F52A RID: 259370 RVA: 0x0103E899 File Offset: 0x0103CA99
		// (set) Token: 0x0603F52B RID: 259371 RVA: 0x0103E8A1 File Offset: 0x0103CAA1
		public int BossRound { get; set; }

		// Token: 0x17009B98 RID: 39832
		// (get) Token: 0x0603F52C RID: 259372 RVA: 0x0103E8AA File Offset: 0x0103CAAA
		// (set) Token: 0x0603F52D RID: 259373 RVA: 0x0103E8B2 File Offset: 0x0103CAB2
		public int BossWave { get; set; }

		// Token: 0x17009B99 RID: 39833
		// (get) Token: 0x0603F52E RID: 259374 RVA: 0x0103E8BB File Offset: 0x0103CABB
		// (set) Token: 0x0603F52F RID: 259375 RVA: 0x0103E8C3 File Offset: 0x0103CAC3
		public int NeedChallengeBossWaveNum { get; set; }

		// Token: 0x17009B9A RID: 39834
		// (get) Token: 0x0603F530 RID: 259376 RVA: 0x0103E8CC File Offset: 0x0103CACC
		// (set) Token: 0x0603F531 RID: 259377 RVA: 0x0103E8D4 File Offset: 0x0103CAD4
		public int AddTeamScore { get; set; }
	}
}
