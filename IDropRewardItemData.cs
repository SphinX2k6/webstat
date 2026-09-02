using System;

// Token: 0x020027F2 RID: 10226
public interface IDropRewardItemData : IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019D4 RID: 6612
	// (get) Token: 0x06014309 RID: 82697
	// (set) Token: 0x0601430A RID: 82698
	int ItemId { get; set; }

	// Token: 0x170019D5 RID: 6613
	// (get) Token: 0x0601430B RID: 82699
	// (set) Token: 0x0601430C RID: 82700
	int Count { get; set; }

	// Token: 0x170019D6 RID: 6614
	// (get) Token: 0x0601430D RID: 82701
	// (set) Token: 0x0601430E RID: 82702
	bool HaveFinish { get; set; }
}
