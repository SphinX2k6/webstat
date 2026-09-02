using System;

// Token: 0x020014DB RID: 5339
public class PinballItemDataItem : IPinballItemDataItem
{
	// Token: 0x17000CD5 RID: 3285
	// (get) Token: 0x0600955B RID: 38235 RVA: 0x00270904 File Offset: 0x0026EB04
	// (set) Token: 0x0600955C RID: 38236 RVA: 0x0027090C File Offset: 0x0026EB0C
	public EPinballItemType Type { get; set; }

	// Token: 0x17000CD6 RID: 3286
	// (get) Token: 0x0600955D RID: 38237 RVA: 0x00270915 File Offset: 0x0026EB15
	// (set) Token: 0x0600955E RID: 38238 RVA: 0x0027091D File Offset: 0x0026EB1D
	public TItem Item { get; set; }
}
