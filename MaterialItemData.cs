using System;

// Token: 0x020027F1 RID: 10225
public class MaterialItemData : IMaterialItemData, IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019D1 RID: 6609
	// (get) Token: 0x06014302 RID: 82690 RVA: 0x005A0BBD File Offset: 0x0059EDBD
	// (set) Token: 0x06014303 RID: 82691 RVA: 0x005A0BC5 File Offset: 0x0059EDC5
	public ERoleDevItemType Type { get; set; }

	// Token: 0x170019D2 RID: 6610
	// (get) Token: 0x06014304 RID: 82692 RVA: 0x005A0BCE File Offset: 0x0059EDCE
	// (set) Token: 0x06014305 RID: 82693 RVA: 0x005A0BD6 File Offset: 0x0059EDD6
	public int ItemId { get; set; }

	// Token: 0x170019D3 RID: 6611
	// (get) Token: 0x06014306 RID: 82694 RVA: 0x005A0BDF File Offset: 0x0059EDDF
	// (set) Token: 0x06014307 RID: 82695 RVA: 0x005A0BE7 File Offset: 0x0059EDE7
	public int RequiredCount { get; set; }
}
