using System;

// Token: 0x020020D6 RID: 8406
public interface IHonamiStoryLoadingData : ISpecialCustomLoadingData
{
	// Token: 0x1700134E RID: 4942
	// (get) Token: 0x060100EB RID: 65771
	// (set) Token: 0x060100EC RID: 65772
	int? LoadingId { get; set; }

	// Token: 0x1700134F RID: 4943
	// (get) Token: 0x060100ED RID: 65773
	// (set) Token: 0x060100EE RID: 65774
	int? BtId { get; set; }

	// Token: 0x17001350 RID: 4944
	// (get) Token: 0x060100EF RID: 65775
	// (set) Token: 0x060100F0 RID: 65776
	int? Timing { get; set; }
}
