using System;

// Token: 0x0200122B RID: 4651
public interface IJumpToItemData
{
	// Token: 0x17000AA3 RID: 2723
	// (get) Token: 0x06007BBA RID: 31674
	// (set) Token: 0x06007BBB RID: 31675
	int LevelId { get; set; }

	// Token: 0x17000AA4 RID: 2724
	// (get) Token: 0x06007BBC RID: 31676
	// (set) Token: 0x06007BBD RID: 31677
	bool Done { get; set; }

	// Token: 0x17000AA5 RID: 2725
	// (get) Token: 0x06007BBE RID: 31678
	// (set) Token: 0x06007BBF RID: 31679
	bool IsUnlock { get; set; }

	// Token: 0x17000AA6 RID: 2726
	// (get) Token: 0x06007BC0 RID: 31680
	// (set) Token: 0x06007BC1 RID: 31681
	int StarNumber { get; set; }
}
