using System;
using Aki.Config;

// Token: 0x02001518 RID: 5400
public struct IRegressRewardItemInfo
{
	// Token: 0x17000CFC RID: 3324
	// (get) Token: 0x06009712 RID: 38674 RVA: 0x00278D73 File Offset: 0x00276F73
	// (set) Token: 0x06009713 RID: 38675 RVA: 0x00278D7B File Offset: 0x00276F7B
	public ItemInfo? ItemInfo { readonly get; set; }

	// Token: 0x17000CFD RID: 3325
	// (get) Token: 0x06009714 RID: 38676 RVA: 0x00278D84 File Offset: 0x00276F84
	// (set) Token: 0x06009715 RID: 38677 RVA: 0x00278D8C File Offset: 0x00276F8C
	public int ItemCount { readonly get; set; }

	// Token: 0x17000CFE RID: 3326
	// (get) Token: 0x06009716 RID: 38678 RVA: 0x00278D95 File Offset: 0x00276F95
	// (set) Token: 0x06009717 RID: 38679 RVA: 0x00278D9D File Offset: 0x00276F9D
	public ERegressRewardState RewardState { readonly get; set; }
}
