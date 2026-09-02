using System;

// Token: 0x020019FB RID: 6651
public interface ISelectedData
{
	// Token: 0x17000F89 RID: 3977
	// (get) Token: 0x0600BE53 RID: 48723
	// (set) Token: 0x0600BE54 RID: 48724
	int ItemId { get; set; }

	// Token: 0x17000F8A RID: 3978
	// (get) Token: 0x0600BE55 RID: 48725
	// (set) Token: 0x0600BE56 RID: 48726
	int IncId { get; set; }

	// Token: 0x17000F8B RID: 3979
	// (get) Token: 0x0600BE57 RID: 48727
	// (set) Token: 0x0600BE58 RID: 48728
	int Count { get; set; }

	// Token: 0x17000F8C RID: 3980
	// (get) Token: 0x0600BE59 RID: 48729
	// (set) Token: 0x0600BE5A RID: 48730
	int SelectedCount { get; set; }

	// Token: 0x17000F8D RID: 3981
	// (get) Token: 0x0600BE5B RID: 48731
	// (set) Token: 0x0600BE5C RID: 48732
	bool? OnlyTextFlag { get; set; }
}
