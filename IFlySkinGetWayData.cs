using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A52 RID: 10834
[NullableContext(1)]
public interface IFlySkinGetWayData
{
	// Token: 0x17001C12 RID: 7186
	// (get) Token: 0x06015B31 RID: 88881
	// (set) Token: 0x06015B32 RID: 88882
	int Id { get; set; }

	// Token: 0x17001C13 RID: 7187
	// (get) Token: 0x06015B33 RID: 88883
	// (set) Token: 0x06015B34 RID: 88884
	int ConfigId { get; set; }

	// Token: 0x17001C14 RID: 7188
	// (get) Token: 0x06015B35 RID: 88885
	// (set) Token: 0x06015B36 RID: 88886
	EFlySkinGetWayType Type { get; set; }

	// Token: 0x17001C15 RID: 7189
	// (get) Token: 0x06015B37 RID: 88887
	// (set) Token: 0x06015B38 RID: 88888
	string Text { get; set; }

	// Token: 0x17001C16 RID: 7190
	// (get) Token: 0x06015B39 RID: 88889
	// (set) Token: 0x06015B3A RID: 88890
	int SortIndex { get; set; }
}
