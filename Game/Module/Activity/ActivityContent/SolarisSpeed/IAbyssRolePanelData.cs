using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x02006389 RID: 25481
	[NullableContext(1)]
	public interface IAbyssRolePanelData : ISolarSpeedRolePanelData
	{
		// Token: 0x17009D59 RID: 40281
		// (get) Token: 0x0603FFCC RID: 262092
		// (set) Token: 0x0603FFCD RID: 262093
		List<IAbyssDescData> MainDescData { get; set; }

		// Token: 0x17009D5A RID: 40282
		// (get) Token: 0x0603FFCE RID: 262094
		// (set) Token: 0x0603FFCF RID: 262095
		List<IAbyssDescData> SubDescData { get; set; }

		// Token: 0x17009D5B RID: 40283
		// (get) Token: 0x0603FFD0 RID: 262096
		// (set) Token: 0x0603FFD1 RID: 262097
		int LikeCount { get; set; }

		// Token: 0x17009D5C RID: 40284
		// (get) Token: 0x0603FFD2 RID: 262098
		// (set) Token: 0x0603FFD3 RID: 262099
		int? PlayerTitle { get; set; }

		// Token: 0x17009D5D RID: 40285
		// (get) Token: 0x0603FFD4 RID: 262100
		// (set) Token: 0x0603FFD5 RID: 262101
		int? PlayerTitleStarLevel { get; set; }

		// Token: 0x17009D5E RID: 40286
		// (get) Token: 0x0603FFD6 RID: 262102
		// (set) Token: 0x0603FFD7 RID: 262103
		int Sex { get; set; }
	}
}
