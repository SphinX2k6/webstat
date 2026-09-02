using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C7E RID: 23678
	[NullableContext(1)]
	public interface IMascotCollectInfoData
	{
		// Token: 0x170097FC RID: 38908
		// (get) Token: 0x0603BD37 RID: 245047
		// (set) Token: 0x0603BD38 RID: 245048
		HonamiStoryAreaData AreaData { get; set; }

		// Token: 0x170097FD RID: 38909
		// (get) Token: 0x0603BD39 RID: 245049
		// (set) Token: 0x0603BD3A RID: 245050
		List<HonamiStoryMascotData> MascotDataList { get; set; }
	}
}
