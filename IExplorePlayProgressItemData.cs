using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B74 RID: 7028
[NullableContext(2)]
public interface IExplorePlayProgressItemData
{
	// Token: 0x1700105B RID: 4187
	// (get) Token: 0x0600CC04 RID: 52228
	// (set) Token: 0x0600CC05 RID: 52229
	EExploreType ExploreType { get; set; }

	// Token: 0x1700105C RID: 4188
	// (get) Token: 0x0600CC06 RID: 52230
	// (set) Token: 0x0600CC07 RID: 52231
	EPlayPointType PlayPointType { get; set; }

	// Token: 0x1700105D RID: 4189
	// (get) Token: 0x0600CC08 RID: 52232
	// (set) Token: 0x0600CC09 RID: 52233
	EPlayPointState PlayPointState { get; set; }

	// Token: 0x1700105E RID: 4190
	// (get) Token: 0x0600CC0A RID: 52234
	// (set) Token: 0x0600CC0B RID: 52235
	int? PlayPointId { get; set; }

	// Token: 0x1700105F RID: 4191
	// (get) Token: 0x0600CC0C RID: 52236
	// (set) Token: 0x0600CC0D RID: 52237
	EPlayPointState? LastPlayPointState { get; set; }

	// Token: 0x17001060 RID: 4192
	// (get) Token: 0x0600CC0E RID: 52238
	// (set) Token: 0x0600CC0F RID: 52239
	int? EntityId { get; set; }

	// Token: 0x17001061 RID: 4193
	// (get) Token: 0x0600CC10 RID: 52240
	// (set) Token: 0x0600CC11 RID: 52241
	bool? IgnoreHiddenType { get; set; }

	// Token: 0x17001062 RID: 4194
	// (get) Token: 0x0600CC12 RID: 52242
	// (set) Token: 0x0600CC13 RID: 52243
	bool? IsClear { get; set; }

	// Token: 0x17001063 RID: 4195
	// (get) Token: 0x0600CC14 RID: 52244
	// (set) Token: 0x0600CC15 RID: 52245
	string ClearInfo { get; set; }

	// Token: 0x17001064 RID: 4196
	// (get) Token: 0x0600CC16 RID: 52246
	// (set) Token: 0x0600CC17 RID: 52247
	bool? IsUnlock { get; set; }
}
