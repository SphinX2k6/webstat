using System;

// Token: 0x02001002 RID: 4098
public interface IDrinksMixRoleInfo
{
	// Token: 0x1700083A RID: 2106
	// (get) Token: 0x06006A38 RID: 27192
	// (set) Token: 0x06006A39 RID: 27193
	int RoleId { get; set; }

	// Token: 0x1700083B RID: 2107
	// (get) Token: 0x06006A3A RID: 27194
	// (set) Token: 0x06006A3B RID: 27195
	bool FirstPass { get; set; }

	// Token: 0x1700083C RID: 2108
	// (get) Token: 0x06006A3C RID: 27196
	// (set) Token: 0x06006A3D RID: 27197
	bool MaxLike { get; set; }

	// Token: 0x1700083D RID: 2109
	// (get) Token: 0x06006A3E RID: 27198
	// (set) Token: 0x06006A3F RID: 27199
	bool RewardGet { get; set; }
}
