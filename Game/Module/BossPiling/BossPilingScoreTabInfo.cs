using System;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE6 RID: 24294
	public class BossPilingScoreTabInfo : IBossPilingScoreTabInfo
	{
		// Token: 0x17009A09 RID: 39433
		// (get) Token: 0x0603D0BC RID: 250044 RVA: 0x00F81144 File Offset: 0x00F7F344
		// (set) Token: 0x0603D0BD RID: 250045 RVA: 0x00F8114C File Offset: 0x00F7F34C
		public int BossHp { get; set; }

		// Token: 0x17009A0A RID: 39434
		// (get) Token: 0x0603D0BE RID: 250046 RVA: 0x00F81155 File Offset: 0x00F7F355
		// (set) Token: 0x0603D0BF RID: 250047 RVA: 0x00F8115D File Offset: 0x00F7F35D
		public int Quality { get; set; }

		// Token: 0x17009A0B RID: 39435
		// (get) Token: 0x0603D0C0 RID: 250048 RVA: 0x00F81166 File Offset: 0x00F7F366
		// (set) Token: 0x0603D0C1 RID: 250049 RVA: 0x00F8116E File Offset: 0x00F7F36E
		public bool IsAchieve { get; set; }
	}
}
