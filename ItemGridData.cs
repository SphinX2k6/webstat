using System;

// Token: 0x0200116C RID: 4460
public class ItemGridData : IItemGridData
{
	// Token: 0x170009D3 RID: 2515
	// (get) Token: 0x0600756F RID: 30063 RVA: 0x001ECF34 File Offset: 0x001EB134
	// (set) Token: 0x06007570 RID: 30064 RVA: 0x001ECF3C File Offset: 0x001EB13C
	public TItem Item { get; set; }

	// Token: 0x170009D4 RID: 2516
	// (get) Token: 0x06007571 RID: 30065 RVA: 0x001ECF45 File Offset: 0x001EB145
	// (set) Token: 0x06007572 RID: 30066 RVA: 0x001ECF4D File Offset: 0x001EB14D
	public bool HasClaimed { get; set; }
}
