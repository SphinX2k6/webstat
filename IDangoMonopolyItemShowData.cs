using System;

// Token: 0x020012EC RID: 4844
public interface IDangoMonopolyItemShowData
{
	// Token: 0x17000B0B RID: 2827
	// (get) Token: 0x0600832A RID: 33578
	int Id { get; }

	// Token: 0x17000B0C RID: 2828
	// (get) Token: 0x0600832B RID: 33579
	int UniqueId { get; }

	// Token: 0x17000B0D RID: 2829
	// (get) Token: 0x0600832C RID: 33580
	// (set) Token: 0x0600832D RID: 33581
	int Num { get; set; }

	// Token: 0x17000B0E RID: 2830
	// (get) Token: 0x0600832E RID: 33582
	bool IsDouble { get; }
}
