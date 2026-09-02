using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006381 RID: 25473
	[NullableContext(1)]
	public interface ITowerDefenseRolePanelData : ISolarSpeedRolePanelData
	{
		// Token: 0x17009D4B RID: 40267
		// (get) Token: 0x0603FFAC RID: 262060
		// (set) Token: 0x0603FFAD RID: 262061
		int BestTitle { get; set; }

		// Token: 0x17009D4C RID: 40268
		// (get) Token: 0x0603FFAE RID: 262062
		// (set) Token: 0x0603FFAF RID: 262063
		List<ITowerDefenseRoleDescData> DescDataList { get; set; }
	}
}
