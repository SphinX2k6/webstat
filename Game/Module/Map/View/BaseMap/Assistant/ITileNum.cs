using System;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant
{
	// Token: 0x020057F6 RID: 22518
	public interface ITileNum
	{
		// Token: 0x170091E7 RID: 37351
		// (get) Token: 0x0603947F RID: 234623
		// (set) Token: 0x06039480 RID: 234624
		int MaxX { get; set; }

		// Token: 0x170091E8 RID: 37352
		// (get) Token: 0x06039481 RID: 234625
		// (set) Token: 0x06039482 RID: 234626
		int MinX { get; set; }

		// Token: 0x170091E9 RID: 37353
		// (get) Token: 0x06039483 RID: 234627
		// (set) Token: 0x06039484 RID: 234628
		int MaxY { get; set; }

		// Token: 0x170091EA RID: 37354
		// (get) Token: 0x06039485 RID: 234629
		// (set) Token: 0x06039486 RID: 234630
		int MinY { get; set; }
	}
}
