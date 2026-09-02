using System;

// Token: 0x0200246E RID: 9326
public interface IPhantomManagerConfigNewSettingDetailInfo
{
	// Token: 0x170016B5 RID: 5813
	// (get) Token: 0x0601210B RID: 73995
	// (set) Token: 0x0601210C RID: 73996
	int FetterId { get; set; }

	// Token: 0x170016B6 RID: 5814
	// (get) Token: 0x0601210D RID: 73997
	// (set) Token: 0x0601210E RID: 73998
	int Cost { get; set; }

	// Token: 0x170016B7 RID: 5815
	// (get) Token: 0x0601210F RID: 73999
	// (set) Token: 0x06012110 RID: 74000
	int MainPropId { get; set; }

	// Token: 0x170016B8 RID: 5816
	// (get) Token: 0x06012111 RID: 74001
	// (set) Token: 0x06012112 RID: 74002
	bool IsEdit { get; set; }
}
