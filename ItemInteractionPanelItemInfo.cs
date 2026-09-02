using System;

// Token: 0x02001973 RID: 6515
public class ItemInteractionPanelItemInfo : IItemInteractionPanelItemInfo
{
	// Token: 0x17000F30 RID: 3888
	// (get) Token: 0x0600BB4A RID: 47946 RVA: 0x0031C335 File Offset: 0x0031A535
	// (set) Token: 0x0600BB4B RID: 47947 RVA: 0x0031C33D File Offset: 0x0031A53D
	public int ItemConfigId { get; set; }

	// Token: 0x17000F31 RID: 3889
	// (get) Token: 0x0600BB4C RID: 47948 RVA: 0x0031C346 File Offset: 0x0031A546
	// (set) Token: 0x0600BB4D RID: 47949 RVA: 0x0031C34E File Offset: 0x0031A54E
	public int CurrentCount { get; set; }

	// Token: 0x17000F32 RID: 3890
	// (get) Token: 0x0600BB4E RID: 47950 RVA: 0x0031C357 File Offset: 0x0031A557
	// (set) Token: 0x0600BB4F RID: 47951 RVA: 0x0031C35F File Offset: 0x0031A55F
	public int? NeedCount { get; set; }
}
