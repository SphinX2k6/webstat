using System;
using Aki.Config;

// Token: 0x02001094 RID: 4244
public interface IFurnitureHandBookItemData
{
	// Token: 0x170008FC RID: 2300
	// (get) Token: 0x06006EB0 RID: 28336
	// (set) Token: 0x06006EB1 RID: 28337
	Furniture FurnitureConfig { get; set; }

	// Token: 0x170008FD RID: 2301
	// (get) Token: 0x06006EB2 RID: 28338
	// (set) Token: 0x06006EB3 RID: 28339
	bool IsLock { get; set; }

	// Token: 0x170008FE RID: 2302
	// (get) Token: 0x06006EB4 RID: 28340
	// (set) Token: 0x06006EB5 RID: 28341
	bool RedDotVisible { get; set; }
}
