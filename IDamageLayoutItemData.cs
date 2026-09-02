using System;

// Token: 0x020014B0 RID: 5296
public interface IDamageLayoutItemData
{
	// Token: 0x17000C60 RID: 3168
	// (get) Token: 0x0600944C RID: 37964
	// (set) Token: 0x0600944D RID: 37965
	int RoleId { get; set; }

	// Token: 0x17000C61 RID: 3169
	// (get) Token: 0x0600944E RID: 37966
	// (set) Token: 0x0600944F RID: 37967
	float Damage { get; set; }

	// Token: 0x17000C62 RID: 3170
	// (get) Token: 0x06009450 RID: 37968
	// (set) Token: 0x06009451 RID: 37969
	bool IsWin { get; set; }
}
