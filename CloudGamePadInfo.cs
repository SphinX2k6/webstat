using System;

// Token: 0x02000E55 RID: 3669
public class CloudGamePadInfo : ICloudGamePadInfo
{
	// Token: 0x1700061F RID: 1567
	// (get) Token: 0x0600583F RID: 22591 RVA: 0x00106ADF File Offset: 0x00104CDF
	// (set) Token: 0x06005840 RID: 22592 RVA: 0x00106AE7 File Offset: 0x00104CE7
	public int IsConnectPad { get; set; }

	// Token: 0x17000620 RID: 1568
	// (get) Token: 0x06005841 RID: 22593 RVA: 0x00106AF0 File Offset: 0x00104CF0
	// (set) Token: 0x06005842 RID: 22594 RVA: 0x00106AF8 File Offset: 0x00104CF8
	public int VendorId { get; set; }

	// Token: 0x17000621 RID: 1569
	// (get) Token: 0x06005843 RID: 22595 RVA: 0x00106B01 File Offset: 0x00104D01
	// (set) Token: 0x06005844 RID: 22596 RVA: 0x00106B09 File Offset: 0x00104D09
	public int ProductId { get; set; }
}
