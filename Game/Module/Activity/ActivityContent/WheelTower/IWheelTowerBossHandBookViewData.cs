using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006209 RID: 25097
	public interface IWheelTowerBossHandBookViewData
	{
		// Token: 0x17009B83 RID: 39811
		// (get) Token: 0x0603F501 RID: 259329
		// (set) Token: 0x0603F502 RID: 259330
		bool IsEndless { get; set; }

		// Token: 0x17009B84 RID: 39812
		// (get) Token: 0x0603F503 RID: 259331
		// (set) Token: 0x0603F504 RID: 259332
		int BossId { get; set; }

		// Token: 0x17009B85 RID: 39813
		// (get) Token: 0x0603F505 RID: 259333
		// (set) Token: 0x0603F506 RID: 259334
		int BossRound { get; set; }

		// Token: 0x17009B86 RID: 39814
		// (get) Token: 0x0603F507 RID: 259335
		// (set) Token: 0x0603F508 RID: 259336
		int TeamRound { get; set; }
	}
}
