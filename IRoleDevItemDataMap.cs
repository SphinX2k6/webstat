using System;
using System.Runtime.CompilerServices;

// Token: 0x020027F6 RID: 10230
[NullableContext(1)]
public interface IRoleDevItemDataMap
{
	// Token: 0x170019E2 RID: 6626
	// (get) Token: 0x06014327 RID: 82727
	// (set) Token: 0x06014328 RID: 82728
	IMaterialItemData Material { get; set; }

	// Token: 0x170019E3 RID: 6627
	// (get) Token: 0x06014329 RID: 82729
	// (set) Token: 0x0601432A RID: 82730
	IDropRewardItemData Reward { get; set; }

	// Token: 0x170019E4 RID: 6628
	// (get) Token: 0x0601432B RID: 82731
	// (set) Token: 0x0601432C RID: 82732
	IPhantomMonsterItemData Monster { get; set; }
}
