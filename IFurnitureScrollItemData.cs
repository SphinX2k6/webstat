using System;
using Aki.Config;

// Token: 0x02001040 RID: 4160
public interface IFurnitureScrollItemData
{
	// Token: 0x17000866 RID: 2150
	// (get) Token: 0x06006C6D RID: 27757
	Furniture FurnitureConfig { get; }

	// Token: 0x17000867 RID: 2151
	// (get) Token: 0x06006C6E RID: 27758
	bool RedDotShowState { get; }

	// Token: 0x17000868 RID: 2152
	// (get) Token: 0x06006C6F RID: 27759
	bool IsSelected { get; }

	// Token: 0x17000869 RID: 2153
	// (get) Token: 0x06006C70 RID: 27760
	int LeftCount { get; }

	// Token: 0x1700086A RID: 2154
	// (get) Token: 0x06006C71 RID: 27761
	bool IsLock { get; }

	// Token: 0x1700086B RID: 2155
	// (get) Token: 0x06006C72 RID: 27762
	bool IsCheck { get; }
}
