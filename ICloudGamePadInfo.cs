using System;

// Token: 0x02000E54 RID: 3668
public interface ICloudGamePadInfo
{
	// Token: 0x1700061C RID: 1564
	// (get) Token: 0x06005839 RID: 22585
	// (set) Token: 0x0600583A RID: 22586
	int IsConnectPad { get; set; }

	// Token: 0x1700061D RID: 1565
	// (get) Token: 0x0600583B RID: 22587
	// (set) Token: 0x0600583C RID: 22588
	int VendorId { get; set; }

	// Token: 0x1700061E RID: 1566
	// (get) Token: 0x0600583D RID: 22589
	// (set) Token: 0x0600583E RID: 22590
	int ProductId { get; set; }
}
