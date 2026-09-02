using System;

// Token: 0x0200246C RID: 9324
public interface IPhantomManagerConfigNewSettingInfo
{
	// Token: 0x170016AB RID: 5803
	// (get) Token: 0x060120F6 RID: 73974
	// (set) Token: 0x060120F7 RID: 73975
	int FetterId { get; set; }

	// Token: 0x170016AC RID: 5804
	// (get) Token: 0x060120F8 RID: 73976
	// (set) Token: 0x060120F9 RID: 73977
	int Cost { get; set; }

	// Token: 0x170016AD RID: 5805
	// (get) Token: 0x060120FA RID: 73978
	// (set) Token: 0x060120FB RID: 73979
	int Count { get; set; }

	// Token: 0x170016AE RID: 5806
	// (get) Token: 0x060120FC RID: 73980
	// (set) Token: 0x060120FD RID: 73981
	int ItemId { get; set; }

	// Token: 0x170016AF RID: 5807
	// (get) Token: 0x060120FE RID: 73982
	// (set) Token: 0x060120FF RID: 73983
	bool IsEdit { get; set; }
}
