using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006206 RID: 25094
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerBossHandBookBuffData : IWheelTowerBossHandBookBuffData
	{
		// Token: 0x17009B7C RID: 39804
		// (get) Token: 0x0603F4F1 RID: 259313 RVA: 0x0103E799 File Offset: 0x0103C999
		// (set) Token: 0x0603F4F2 RID: 259314 RVA: 0x0103E7A1 File Offset: 0x0103C9A1
		public int Round { get; set; }

		// Token: 0x17009B7D RID: 39805
		// (get) Token: 0x0603F4F3 RID: 259315 RVA: 0x0103E7AA File Offset: 0x0103C9AA
		// (set) Token: 0x0603F4F4 RID: 259316 RVA: 0x0103E7B2 File Offset: 0x0103C9B2
		public List<int> BuffIdList { get; set; } = new List<int>();

		// Token: 0x17009B7E RID: 39806
		// (get) Token: 0x0603F4F5 RID: 259317 RVA: 0x0103E7BB File Offset: 0x0103C9BB
		// (set) Token: 0x0603F4F6 RID: 259318 RVA: 0x0103E7C3 File Offset: 0x0103C9C3
		public bool IsActivate { get; set; }
	}
}
