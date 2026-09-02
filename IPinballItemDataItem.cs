using System;

// Token: 0x020014BA RID: 5306
public interface IPinballItemDataItem
{
	// Token: 0x17000C7D RID: 3197
	// (get) Token: 0x060094A0 RID: 38048
	// (set) Token: 0x060094A1 RID: 38049
	EPinballItemType Type { get; set; }

	// Token: 0x17000C7E RID: 3198
	// (get) Token: 0x060094A2 RID: 38050
	// (set) Token: 0x060094A3 RID: 38051
	TItem Item { get; set; }
}
