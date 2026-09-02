using System;

// Token: 0x020019FC RID: 6652
public class SelectedData : ISelectedData
{
	// Token: 0x17000F8E RID: 3982
	// (get) Token: 0x0600BE5D RID: 48733 RVA: 0x0032656E File Offset: 0x0032476E
	// (set) Token: 0x0600BE5E RID: 48734 RVA: 0x00326576 File Offset: 0x00324776
	public int ItemId { get; set; }

	// Token: 0x17000F8F RID: 3983
	// (get) Token: 0x0600BE5F RID: 48735 RVA: 0x0032657F File Offset: 0x0032477F
	// (set) Token: 0x0600BE60 RID: 48736 RVA: 0x00326587 File Offset: 0x00324787
	public int IncId { get; set; }

	// Token: 0x17000F90 RID: 3984
	// (get) Token: 0x0600BE61 RID: 48737 RVA: 0x00326590 File Offset: 0x00324790
	// (set) Token: 0x0600BE62 RID: 48738 RVA: 0x00326598 File Offset: 0x00324798
	public int Count { get; set; }

	// Token: 0x17000F91 RID: 3985
	// (get) Token: 0x0600BE63 RID: 48739 RVA: 0x003265A1 File Offset: 0x003247A1
	// (set) Token: 0x0600BE64 RID: 48740 RVA: 0x003265A9 File Offset: 0x003247A9
	public int SelectedCount { get; set; }

	// Token: 0x17000F92 RID: 3986
	// (get) Token: 0x0600BE65 RID: 48741 RVA: 0x003265B2 File Offset: 0x003247B2
	// (set) Token: 0x0600BE66 RID: 48742 RVA: 0x003265BA File Offset: 0x003247BA
	public bool? OnlyTextFlag { get; set; }
}
