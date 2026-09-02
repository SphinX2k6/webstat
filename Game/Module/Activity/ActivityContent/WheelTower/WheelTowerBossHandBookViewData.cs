using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200620A RID: 25098
	public class WheelTowerBossHandBookViewData : IWheelTowerBossHandBookViewData
	{
		// Token: 0x17009B87 RID: 39815
		// (get) Token: 0x0603F509 RID: 259337 RVA: 0x0103E809 File Offset: 0x0103CA09
		// (set) Token: 0x0603F50A RID: 259338 RVA: 0x0103E811 File Offset: 0x0103CA11
		public bool IsEndless { get; set; }

		// Token: 0x17009B88 RID: 39816
		// (get) Token: 0x0603F50B RID: 259339 RVA: 0x0103E81A File Offset: 0x0103CA1A
		// (set) Token: 0x0603F50C RID: 259340 RVA: 0x0103E822 File Offset: 0x0103CA22
		public int BossId { get; set; }

		// Token: 0x17009B89 RID: 39817
		// (get) Token: 0x0603F50D RID: 259341 RVA: 0x0103E82B File Offset: 0x0103CA2B
		// (set) Token: 0x0603F50E RID: 259342 RVA: 0x0103E833 File Offset: 0x0103CA33
		public int BossRound { get; set; }

		// Token: 0x17009B8A RID: 39818
		// (get) Token: 0x0603F50F RID: 259343 RVA: 0x0103E83C File Offset: 0x0103CA3C
		// (set) Token: 0x0603F510 RID: 259344 RVA: 0x0103E844 File Offset: 0x0103CA44
		public int TeamRound { get; set; }
	}
}
