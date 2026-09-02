using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006204 RID: 25092
	public class WheelTowerBossBuffData : IWheelTowerBossBuffData
	{
		// Token: 0x17009B76 RID: 39798
		// (get) Token: 0x0603F4E4 RID: 259300 RVA: 0x0103E75E File Offset: 0x0103C95E
		// (set) Token: 0x0603F4E5 RID: 259301 RVA: 0x0103E766 File Offset: 0x0103C966
		public int Round { get; set; }

		// Token: 0x17009B77 RID: 39799
		// (get) Token: 0x0603F4E6 RID: 259302 RVA: 0x0103E76F File Offset: 0x0103C96F
		// (set) Token: 0x0603F4E7 RID: 259303 RVA: 0x0103E777 File Offset: 0x0103C977
		public int BuffId { get; set; }

		// Token: 0x17009B78 RID: 39800
		// (get) Token: 0x0603F4E8 RID: 259304 RVA: 0x0103E780 File Offset: 0x0103C980
		// (set) Token: 0x0603F4E9 RID: 259305 RVA: 0x0103E788 File Offset: 0x0103C988
		public bool IsActivate { get; set; }
	}
}
