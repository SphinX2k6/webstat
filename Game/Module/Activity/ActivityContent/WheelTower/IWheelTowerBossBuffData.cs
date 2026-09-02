using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006203 RID: 25091
	public interface IWheelTowerBossBuffData
	{
		// Token: 0x17009B73 RID: 39795
		// (get) Token: 0x0603F4DE RID: 259294
		// (set) Token: 0x0603F4DF RID: 259295
		int Round { get; set; }

		// Token: 0x17009B74 RID: 39796
		// (get) Token: 0x0603F4E0 RID: 259296
		// (set) Token: 0x0603F4E1 RID: 259297
		int BuffId { get; set; }

		// Token: 0x17009B75 RID: 39797
		// (get) Token: 0x0603F4E2 RID: 259298
		// (set) Token: 0x0603F4E3 RID: 259299
		bool IsActivate { get; set; }
	}
}
