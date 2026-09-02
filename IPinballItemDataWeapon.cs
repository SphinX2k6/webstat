using System;

// Token: 0x020014B9 RID: 5305
public interface IPinballItemDataWeapon
{
	// Token: 0x17000C75 RID: 3189
	// (get) Token: 0x06009490 RID: 38032
	// (set) Token: 0x06009491 RID: 38033
	EPinballItemType Type { get; set; }

	// Token: 0x17000C76 RID: 3190
	// (get) Token: 0x06009492 RID: 38034
	// (set) Token: 0x06009493 RID: 38035
	int Id { get; set; }

	// Token: 0x17000C77 RID: 3191
	// (get) Token: 0x06009494 RID: 38036
	// (set) Token: 0x06009495 RID: 38037
	int IncId { get; set; }

	// Token: 0x17000C78 RID: 3192
	// (get) Token: 0x06009496 RID: 38038
	// (set) Token: 0x06009497 RID: 38039
	bool? IsUnavailable { get; set; }

	// Token: 0x17000C79 RID: 3193
	// (get) Token: 0x06009498 RID: 38040
	// (set) Token: 0x06009499 RID: 38041
	int? RoleId { get; set; }

	// Token: 0x17000C7A RID: 3194
	// (get) Token: 0x0600949A RID: 38042
	// (set) Token: 0x0600949B RID: 38043
	bool? IsLocked { get; set; }

	// Token: 0x17000C7B RID: 3195
	// (get) Token: 0x0600949C RID: 38044
	// (set) Token: 0x0600949D RID: 38045
	bool? NeedReduceBtn { get; set; }

	// Token: 0x17000C7C RID: 3196
	// (get) Token: 0x0600949E RID: 38046
	// (set) Token: 0x0600949F RID: 38047
	bool? IsRecommendedWeapon { get; set; }
}
