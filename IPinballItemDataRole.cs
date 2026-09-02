using System;
using System.Runtime.CompilerServices;

// Token: 0x020014B8 RID: 5304
[NullableContext(2)]
public interface IPinballItemDataRole
{
	// Token: 0x17000C6C RID: 3180
	// (get) Token: 0x0600947E RID: 38014
	// (set) Token: 0x0600947F RID: 38015
	EPinballItemType Type { get; set; }

	// Token: 0x17000C6D RID: 3181
	// (get) Token: 0x06009480 RID: 38016
	// (set) Token: 0x06009481 RID: 38017
	int Id { get; set; }

	// Token: 0x17000C6E RID: 3182
	// (get) Token: 0x06009482 RID: 38018
	// (set) Token: 0x06009483 RID: 38019
	bool? IsRecommend { get; set; }

	// Token: 0x17000C6F RID: 3183
	// (get) Token: 0x06009484 RID: 38020
	// (set) Token: 0x06009485 RID: 38021
	int? BdId { get; set; }

	// Token: 0x17000C70 RID: 3184
	// (get) Token: 0x06009486 RID: 38022
	// (set) Token: 0x06009487 RID: 38023
	bool? IsLocked { get; set; }

	// Token: 0x17000C71 RID: 3185
	// (get) Token: 0x06009488 RID: 38024
	// (set) Token: 0x06009489 RID: 38025
	bool? IsUnavailable { get; set; }

	// Token: 0x17000C72 RID: 3186
	// (get) Token: 0x0600948A RID: 38026
	// (set) Token: 0x0600948B RID: 38027
	TableTextArgNew BottomText { get; set; }

	// Token: 0x17000C73 RID: 3187
	// (get) Token: 0x0600948C RID: 38028
	// (set) Token: 0x0600948D RID: 38029
	string BottomPlainText { get; set; }

	// Token: 0x17000C74 RID: 3188
	// (get) Token: 0x0600948E RID: 38030
	// (set) Token: 0x0600948F RID: 38031
	int? ClassId { get; set; }
}
