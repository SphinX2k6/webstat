using System;

// Token: 0x02002BA0 RID: 11168
public interface ISurvivorsHandbookItemDataBase
{
	// Token: 0x17001D3E RID: 7486
	// (get) Token: 0x060163E4 RID: 91108
	int Id { get; }

	// Token: 0x17001D3F RID: 7487
	// (get) Token: 0x060163E5 RID: 91109
	bool? LockState { get; }

	// Token: 0x17001D40 RID: 7488
	// (get) Token: 0x060163E6 RID: 91110
	// (set) Token: 0x060163E7 RID: 91111
	bool? IsNew { get; set; }
}
