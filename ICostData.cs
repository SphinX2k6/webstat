using System;

// Token: 0x02002078 RID: 8312
public interface ICostData
{
	// Token: 0x170012DA RID: 4826
	// (get) Token: 0x0600FD4D RID: 64845
	// (set) Token: 0x0600FD4E RID: 64846
	int ItemId { get; set; }

	// Token: 0x170012DB RID: 4827
	// (get) Token: 0x0600FD4F RID: 64847
	// (set) Token: 0x0600FD50 RID: 64848
	int Count { get; set; }

	// Token: 0x170012DC RID: 4828
	// (get) Token: 0x0600FD51 RID: 64849
	// (set) Token: 0x0600FD52 RID: 64850
	int Cost { get; set; }
}
