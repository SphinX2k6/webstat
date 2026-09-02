using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006451 RID: 25681
	public interface IRoverlikeRogueLevelLineData
	{
		// Token: 0x17009E18 RID: 40472
		// (get) Token: 0x06040739 RID: 263993
		// (set) Token: 0x0604073A RID: 263994
		ERoverlikeRoadLayerType LayerType { get; set; }

		// Token: 0x17009E19 RID: 40473
		// (get) Token: 0x0604073B RID: 263995
		// (set) Token: 0x0604073C RID: 263996
		bool IsCurrent { get; set; }

		// Token: 0x17009E1A RID: 40474
		// (get) Token: 0x0604073D RID: 263997
		// (set) Token: 0x0604073E RID: 263998
		bool IsPassed { get; set; }

		// Token: 0x17009E1B RID: 40475
		// (get) Token: 0x0604073F RID: 263999
		// (set) Token: 0x06040740 RID: 264000
		bool ShowCurrent { get; set; }
	}
}
