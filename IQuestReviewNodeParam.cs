using System;
using System.Runtime.CompilerServices;

// Token: 0x02002677 RID: 9847
[NullableContext(1)]
public interface IQuestReviewNodeParam
{
	// Token: 0x17001832 RID: 6194
	// (get) Token: 0x060136A5 RID: 79525
	// (set) Token: 0x060136A6 RID: 79526
	[Nullable(2)]
	QuestReviewNodeData Data { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001833 RID: 6195
	// (get) Token: 0x060136A7 RID: 79527
	// (set) Token: 0x060136A8 RID: 79528
	bool IsLastSlotEmpty { get; set; }

	// Token: 0x17001834 RID: 6196
	// (get) Token: 0x060136A9 RID: 79529
	// (set) Token: 0x060136AA RID: 79530
	bool IsDestroy { get; set; }

	// Token: 0x17001835 RID: 6197
	// (get) Token: 0x060136AB RID: 79531
	// (set) Token: 0x060136AC RID: 79532
	bool IsLastSlot { get; set; }

	// Token: 0x17001836 RID: 6198
	// (get) Token: 0x060136AD RID: 79533
	// (set) Token: 0x060136AE RID: 79534
	string LineColorHex { get; set; }

	// Token: 0x17001837 RID: 6199
	// (get) Token: 0x060136AF RID: 79535
	// (set) Token: 0x060136B0 RID: 79536
	string StarIcon { get; set; }

	// Token: 0x17001838 RID: 6200
	// (get) Token: 0x060136B1 RID: 79537
	// (set) Token: 0x060136B2 RID: 79538
	string RoundIcon { get; set; }

	// Token: 0x17001839 RID: 6201
	// (get) Token: 0x060136B3 RID: 79539
	// (set) Token: 0x060136B4 RID: 79540
	int LineId { get; set; }

	// Token: 0x1700183A RID: 6202
	// (get) Token: 0x060136B5 RID: 79541
	// (set) Token: 0x060136B6 RID: 79542
	bool ShouldHide { get; set; }

	// Token: 0x1700183B RID: 6203
	// (get) Token: 0x060136B7 RID: 79543
	// (set) Token: 0x060136B8 RID: 79544
	int SlotIndex { get; set; }
}
