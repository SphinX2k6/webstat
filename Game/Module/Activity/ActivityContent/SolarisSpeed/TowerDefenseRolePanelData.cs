using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006382 RID: 25474
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseRolePanelData : SolarSpeedRolePanelData, ITowerDefenseRolePanelData, ISolarSpeedRolePanelData
	{
		// Token: 0x17009D4D RID: 40269
		// (get) Token: 0x0603FFB0 RID: 262064 RVA: 0x01066AA7 File Offset: 0x01064CA7
		// (set) Token: 0x0603FFB1 RID: 262065 RVA: 0x01066AAF File Offset: 0x01064CAF
		public int BestTitle { get; set; }

		// Token: 0x17009D4E RID: 40270
		// (get) Token: 0x0603FFB2 RID: 262066 RVA: 0x01066AB8 File Offset: 0x01064CB8
		// (set) Token: 0x0603FFB3 RID: 262067 RVA: 0x01066AC0 File Offset: 0x01064CC0
		public List<ITowerDefenseRoleDescData> DescDataList { get; set; }
	}
}
