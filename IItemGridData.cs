using System;

// Token: 0x0200116B RID: 4459
public interface IItemGridData
{
	// Token: 0x170009D1 RID: 2513
	// (get) Token: 0x0600756B RID: 30059
	// (set) Token: 0x0600756C RID: 30060
	TItem Item { get; set; }

	// Token: 0x170009D2 RID: 2514
	// (get) Token: 0x0600756D RID: 30061
	// (set) Token: 0x0600756E RID: 30062
	bool HasClaimed { get; set; }
}
