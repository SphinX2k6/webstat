using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006201 RID: 25089
	[NullableContext(1)]
	public interface IWheelTowerBossAttrData
	{
		// Token: 0x17009B6B RID: 39787
		// (get) Token: 0x0603F4CD RID: 259277
		// (set) Token: 0x0603F4CE RID: 259278
		string AttrName { get; set; }

		// Token: 0x17009B6C RID: 39788
		// (get) Token: 0x0603F4CF RID: 259279
		// (set) Token: 0x0603F4D0 RID: 259280
		int AttrLevel { get; set; }

		// Token: 0x17009B6D RID: 39789
		// (get) Token: 0x0603F4D1 RID: 259281
		// (set) Token: 0x0603F4D2 RID: 259282
		int ElementId { get; set; }

		// Token: 0x17009B6E RID: 39790
		// (get) Token: 0x0603F4D3 RID: 259283
		// (set) Token: 0x0603F4D4 RID: 259284
		List<int> TagIdList { get; set; }
	}
}
