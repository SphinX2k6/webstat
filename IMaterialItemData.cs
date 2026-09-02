using System;

// Token: 0x020027F0 RID: 10224
public interface IMaterialItemData : IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019CF RID: 6607
	// (get) Token: 0x060142FE RID: 82686
	// (set) Token: 0x060142FF RID: 82687
	int ItemId { get; set; }

	// Token: 0x170019D0 RID: 6608
	// (get) Token: 0x06014300 RID: 82688
	// (set) Token: 0x06014301 RID: 82689
	int RequiredCount { get; set; }
}
