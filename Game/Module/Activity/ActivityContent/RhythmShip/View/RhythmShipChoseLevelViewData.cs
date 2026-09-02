using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DB RID: 25819
	public class RhythmShipChoseLevelViewData : IRhythmShipChoseLevelViewData
	{
		// Token: 0x17009E7B RID: 40571
		// (get) Token: 0x06040AC9 RID: 264905 RVA: 0x0109433A File Offset: 0x0109253A
		// (set) Token: 0x06040ACA RID: 264906 RVA: 0x01094342 File Offset: 0x01092542
		public ERhythmShipPlanetType OpenShowType { get; set; }

		// Token: 0x17009E7C RID: 40572
		// (get) Token: 0x06040ACB RID: 264907 RVA: 0x0109434B File Offset: 0x0109254B
		// (set) Token: 0x06040ACC RID: 264908 RVA: 0x01094353 File Offset: 0x01092553
		public int? PlanetId { get; set; }

		// Token: 0x17009E7D RID: 40573
		// (get) Token: 0x06040ACD RID: 264909 RVA: 0x0109435C File Offset: 0x0109255C
		// (set) Token: 0x06040ACE RID: 264910 RVA: 0x01094364 File Offset: 0x01092564
		public int? LevelId { get; set; }

		// Token: 0x17009E7E RID: 40574
		// (get) Token: 0x06040ACF RID: 264911 RVA: 0x0109436D File Offset: 0x0109256D
		// (set) Token: 0x06040AD0 RID: 264912 RVA: 0x01094375 File Offset: 0x01092575
		public int? SubLevelId { get; set; }
	}
}
