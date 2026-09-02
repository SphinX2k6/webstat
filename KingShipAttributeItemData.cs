using System;

// Token: 0x02002093 RID: 8339
public class KingShipAttributeItemData : IKingShipAttributeItemData
{
	// Token: 0x170012EC RID: 4844
	// (get) Token: 0x0600FE68 RID: 65128 RVA: 0x0045C363 File Offset: 0x0045A563
	// (set) Token: 0x0600FE69 RID: 65129 RVA: 0x0045C36B File Offset: 0x0045A56B
	public int AttributeId { get; set; }

	// Token: 0x170012ED RID: 4845
	// (get) Token: 0x0600FE6A RID: 65130 RVA: 0x0045C374 File Offset: 0x0045A574
	// (set) Token: 0x0600FE6B RID: 65131 RVA: 0x0045C37C File Offset: 0x0045A57C
	public int MaxCount { get; set; }

	// Token: 0x170012EE RID: 4846
	// (get) Token: 0x0600FE6C RID: 65132 RVA: 0x0045C385 File Offset: 0x0045A585
	// (set) Token: 0x0600FE6D RID: 65133 RVA: 0x0045C38D File Offset: 0x0045A58D
	public int MinCount { get; set; }

	// Token: 0x170012EF RID: 4847
	// (get) Token: 0x0600FE6E RID: 65134 RVA: 0x0045C396 File Offset: 0x0045A596
	// (set) Token: 0x0600FE6F RID: 65135 RVA: 0x0045C39E File Offset: 0x0045A59E
	public int Current { get; set; }

	// Token: 0x170012F0 RID: 4848
	// (get) Token: 0x0600FE70 RID: 65136 RVA: 0x0045C3A7 File Offset: 0x0045A5A7
	// (set) Token: 0x0600FE71 RID: 65137 RVA: 0x0045C3AF File Offset: 0x0045A5AF
	public bool IsDefaultEnable { get; set; }
}
