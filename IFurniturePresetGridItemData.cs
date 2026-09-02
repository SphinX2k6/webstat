using System;
using Aki.Config;

// Token: 0x0200109A RID: 4250
public interface IFurniturePresetGridItemData
{
	// Token: 0x17000902 RID: 2306
	// (get) Token: 0x06006ED5 RID: 28373
	// (set) Token: 0x06006ED6 RID: 28374
	Furniture FurnitureConfig { get; set; }

	// Token: 0x17000903 RID: 2307
	// (get) Token: 0x06006ED7 RID: 28375
	// (set) Token: 0x06006ED8 RID: 28376
	bool IsLock { get; set; }

	// Token: 0x17000904 RID: 2308
	// (get) Token: 0x06006ED9 RID: 28377
	// (set) Token: 0x06006EDA RID: 28378
	bool IsFinished { get; set; }
}
