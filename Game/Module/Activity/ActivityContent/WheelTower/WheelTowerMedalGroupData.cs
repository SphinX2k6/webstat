using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006221 RID: 25121
	public class WheelTowerMedalGroupData : IWheelTowerMedalGroupData
	{
		// Token: 0x17009C17 RID: 39959
		// (get) Token: 0x0603F635 RID: 259637 RVA: 0x0103EE2E File Offset: 0x0103D02E
		// (set) Token: 0x0603F636 RID: 259638 RVA: 0x0103EE36 File Offset: 0x0103D036
		public int GroupId { get; set; }

		// Token: 0x17009C18 RID: 39960
		// (get) Token: 0x0603F637 RID: 259639 RVA: 0x0103EE3F File Offset: 0x0103D03F
		// (set) Token: 0x0603F638 RID: 259640 RVA: 0x0103EE47 File Offset: 0x0103D047
		public int SeasonId { get; set; }

		// Token: 0x17009C19 RID: 39961
		// (get) Token: 0x0603F639 RID: 259641 RVA: 0x0103EE50 File Offset: 0x0103D050
		// (set) Token: 0x0603F63A RID: 259642 RVA: 0x0103EE58 File Offset: 0x0103D058
		public int CycleId { get; set; }

		// Token: 0x17009C1A RID: 39962
		// (get) Token: 0x0603F63B RID: 259643 RVA: 0x0103EE61 File Offset: 0x0103D061
		// (set) Token: 0x0603F63C RID: 259644 RVA: 0x0103EE69 File Offset: 0x0103D069
		public int Progress { get; set; }

		// Token: 0x17009C1B RID: 39963
		// (get) Token: 0x0603F63D RID: 259645 RVA: 0x0103EE72 File Offset: 0x0103D072
		// (set) Token: 0x0603F63E RID: 259646 RVA: 0x0103EE7A File Offset: 0x0103D07A
		public long CompleteTime { get; set; }

		// Token: 0x17009C1C RID: 39964
		// (get) Token: 0x0603F63F RID: 259647 RVA: 0x0103EE83 File Offset: 0x0103D083
		// (set) Token: 0x0603F640 RID: 259648 RVA: 0x0103EE8B File Offset: 0x0103D08B
		public int CurrentMedalId { get; set; }

		// Token: 0x17009C1D RID: 39965
		// (get) Token: 0x0603F641 RID: 259649 RVA: 0x0103EE94 File Offset: 0x0103D094
		// (set) Token: 0x0603F642 RID: 259650 RVA: 0x0103EE9C File Offset: 0x0103D09C
		public int NextMedalId { get; set; }

		// Token: 0x17009C1E RID: 39966
		// (get) Token: 0x0603F643 RID: 259651 RVA: 0x0103EEA5 File Offset: 0x0103D0A5
		// (set) Token: 0x0603F644 RID: 259652 RVA: 0x0103EEAD File Offset: 0x0103D0AD
		public int CurrentTarget { get; set; }

		// Token: 0x17009C1F RID: 39967
		// (get) Token: 0x0603F645 RID: 259653 RVA: 0x0103EEB6 File Offset: 0x0103D0B6
		// (set) Token: 0x0603F646 RID: 259654 RVA: 0x0103EEBE File Offset: 0x0103D0BE
		public bool IsMaxLevel { get; set; }
	}
}
