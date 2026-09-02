using System;

// Token: 0x020027F3 RID: 10227
public class DropRewardItemData : IDropRewardItemData, IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019D7 RID: 6615
	// (get) Token: 0x0601430F RID: 82703 RVA: 0x005A0BF8 File Offset: 0x0059EDF8
	// (set) Token: 0x06014310 RID: 82704 RVA: 0x005A0C00 File Offset: 0x0059EE00
	public ERoleDevItemType Type { get; set; }

	// Token: 0x170019D8 RID: 6616
	// (get) Token: 0x06014311 RID: 82705 RVA: 0x005A0C09 File Offset: 0x0059EE09
	// (set) Token: 0x06014312 RID: 82706 RVA: 0x005A0C11 File Offset: 0x0059EE11
	public int ItemId { get; set; }

	// Token: 0x170019D9 RID: 6617
	// (get) Token: 0x06014313 RID: 82707 RVA: 0x005A0C1A File Offset: 0x0059EE1A
	// (set) Token: 0x06014314 RID: 82708 RVA: 0x005A0C22 File Offset: 0x0059EE22
	public int Count { get; set; }

	// Token: 0x170019DA RID: 6618
	// (get) Token: 0x06014315 RID: 82709 RVA: 0x005A0C2B File Offset: 0x0059EE2B
	// (set) Token: 0x06014316 RID: 82710 RVA: 0x005A0C33 File Offset: 0x0059EE33
	public bool HaveFinish { get; set; }
}
