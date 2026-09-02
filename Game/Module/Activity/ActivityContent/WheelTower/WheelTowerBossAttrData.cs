using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006202 RID: 25090
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerBossAttrData : IWheelTowerBossAttrData
	{
		// Token: 0x17009B6F RID: 39791
		// (get) Token: 0x0603F4D5 RID: 259285 RVA: 0x0103E6FC File Offset: 0x0103C8FC
		// (set) Token: 0x0603F4D6 RID: 259286 RVA: 0x0103E704 File Offset: 0x0103C904
		public string AttrName { get; set; } = string.Empty;

		// Token: 0x17009B70 RID: 39792
		// (get) Token: 0x0603F4D7 RID: 259287 RVA: 0x0103E70D File Offset: 0x0103C90D
		// (set) Token: 0x0603F4D8 RID: 259288 RVA: 0x0103E715 File Offset: 0x0103C915
		public int AttrLevel { get; set; }

		// Token: 0x17009B71 RID: 39793
		// (get) Token: 0x0603F4D9 RID: 259289 RVA: 0x0103E71E File Offset: 0x0103C91E
		// (set) Token: 0x0603F4DA RID: 259290 RVA: 0x0103E726 File Offset: 0x0103C926
		public int ElementId { get; set; }

		// Token: 0x17009B72 RID: 39794
		// (get) Token: 0x0603F4DB RID: 259291 RVA: 0x0103E72F File Offset: 0x0103C92F
		// (set) Token: 0x0603F4DC RID: 259292 RVA: 0x0103E737 File Offset: 0x0103C937
		public List<int> TagIdList { get; set; } = new List<int>();
	}
}
