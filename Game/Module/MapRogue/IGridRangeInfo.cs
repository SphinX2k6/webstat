using System;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005907 RID: 22791
	public interface IGridRangeInfo
	{
		// Token: 0x170093D7 RID: 37847
		// (get) Token: 0x06039D40 RID: 236864
		// (set) Token: 0x06039D41 RID: 236865
		double CenterX { get; set; }

		// Token: 0x170093D8 RID: 37848
		// (get) Token: 0x06039D42 RID: 236866
		// (set) Token: 0x06039D43 RID: 236867
		double CenterY { get; set; }

		// Token: 0x170093D9 RID: 37849
		// (get) Token: 0x06039D44 RID: 236868
		// (set) Token: 0x06039D45 RID: 236869
		double RadiusX { get; set; }

		// Token: 0x170093DA RID: 37850
		// (get) Token: 0x06039D46 RID: 236870
		// (set) Token: 0x06039D47 RID: 236871
		double RadiusY { get; set; }
	}
}
