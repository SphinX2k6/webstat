using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.HonamiStory
{
	// Token: 0x02005C7F RID: 23679
	[NullableContext(1)]
	[Nullable(0)]
	public class MascotCollectInfoData : IMascotCollectInfoData
	{
		// Token: 0x170097FE RID: 38910
		// (get) Token: 0x0603BD3B RID: 245051 RVA: 0x00F2B317 File Offset: 0x00F29517
		// (set) Token: 0x0603BD3C RID: 245052 RVA: 0x00F2B31F File Offset: 0x00F2951F
		public HonamiStoryAreaData AreaData { get; set; }

		// Token: 0x170097FF RID: 38911
		// (get) Token: 0x0603BD3D RID: 245053 RVA: 0x00F2B328 File Offset: 0x00F29528
		// (set) Token: 0x0603BD3E RID: 245054 RVA: 0x00F2B330 File Offset: 0x00F29530
		public List<HonamiStoryMascotData> MascotDataList { get; set; } = new List<HonamiStoryMascotData>();
	}
}
