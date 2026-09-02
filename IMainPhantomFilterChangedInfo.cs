using System;

// Token: 0x02002500 RID: 9472
public interface IMainPhantomFilterChangedInfo
{
	// Token: 0x1700175C RID: 5980
	// (get) Token: 0x06012640 RID: 75328
	// (set) Token: 0x06012641 RID: 75329
	int MonsterId { get; set; }

	// Token: 0x1700175D RID: 5981
	// (get) Token: 0x06012642 RID: 75330
	// (set) Token: 0x06012643 RID: 75331
	int FetterGroupId { get; set; }

	// Token: 0x1700175E RID: 5982
	// (get) Token: 0x06012644 RID: 75332
	// (set) Token: 0x06012645 RID: 75333
	int Cost { get; set; }

	// Token: 0x1700175F RID: 5983
	// (get) Token: 0x06012646 RID: 75334
	// (set) Token: 0x06012647 RID: 75335
	bool IsDeselect { get; set; }
}
