using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RhythmShip.View
{
	// Token: 0x020064DA RID: 25818
	public interface IRhythmShipChoseLevelViewData
	{
		// Token: 0x17009E77 RID: 40567
		// (get) Token: 0x06040AC1 RID: 264897
		// (set) Token: 0x06040AC2 RID: 264898
		ERhythmShipPlanetType OpenShowType { get; set; }

		// Token: 0x17009E78 RID: 40568
		// (get) Token: 0x06040AC3 RID: 264899
		// (set) Token: 0x06040AC4 RID: 264900
		int? PlanetId { get; set; }

		// Token: 0x17009E79 RID: 40569
		// (get) Token: 0x06040AC5 RID: 264901
		// (set) Token: 0x06040AC6 RID: 264902
		int? LevelId { get; set; }

		// Token: 0x17009E7A RID: 40570
		// (get) Token: 0x06040AC7 RID: 264903
		// (set) Token: 0x06040AC8 RID: 264904
		int? SubLevelId { get; set; }
	}
}
