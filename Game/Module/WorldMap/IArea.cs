using System;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B1D RID: 19229
	public interface IArea
	{
		// Token: 0x1700859F RID: 34207
		// (get) Token: 0x060322C0 RID: 205504
		// (set) Token: 0x060322C1 RID: 205505
		double MinX { get; set; }

		// Token: 0x170085A0 RID: 34208
		// (get) Token: 0x060322C2 RID: 205506
		// (set) Token: 0x060322C3 RID: 205507
		double MaxX { get; set; }

		// Token: 0x170085A1 RID: 34209
		// (get) Token: 0x060322C4 RID: 205508
		// (set) Token: 0x060322C5 RID: 205509
		double MinY { get; set; }

		// Token: 0x170085A2 RID: 34210
		// (get) Token: 0x060322C6 RID: 205510
		// (set) Token: 0x060322C7 RID: 205511
		double MaxY { get; set; }
	}
}
