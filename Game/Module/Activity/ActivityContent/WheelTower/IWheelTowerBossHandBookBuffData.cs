using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006205 RID: 25093
	[NullableContext(1)]
	public interface IWheelTowerBossHandBookBuffData
	{
		// Token: 0x17009B79 RID: 39801
		// (get) Token: 0x0603F4EB RID: 259307
		// (set) Token: 0x0603F4EC RID: 259308
		int Round { get; set; }

		// Token: 0x17009B7A RID: 39802
		// (get) Token: 0x0603F4ED RID: 259309
		// (set) Token: 0x0603F4EE RID: 259310
		List<int> BuffIdList { get; set; }

		// Token: 0x17009B7B RID: 39803
		// (get) Token: 0x0603F4EF RID: 259311
		// (set) Token: 0x0603F4F0 RID: 259312
		bool IsActivate { get; set; }
	}
}
