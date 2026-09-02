using System;

// Token: 0x02001003 RID: 4099
public class DrinksMixRoleInfo : IDrinksMixRoleInfo
{
	// Token: 0x1700083E RID: 2110
	// (get) Token: 0x06006A40 RID: 27200 RVA: 0x001BB9D2 File Offset: 0x001B9BD2
	// (set) Token: 0x06006A41 RID: 27201 RVA: 0x001BB9DA File Offset: 0x001B9BDA
	public int RoleId { get; set; }

	// Token: 0x1700083F RID: 2111
	// (get) Token: 0x06006A42 RID: 27202 RVA: 0x001BB9E3 File Offset: 0x001B9BE3
	// (set) Token: 0x06006A43 RID: 27203 RVA: 0x001BB9EB File Offset: 0x001B9BEB
	public bool FirstPass { get; set; }

	// Token: 0x17000840 RID: 2112
	// (get) Token: 0x06006A44 RID: 27204 RVA: 0x001BB9F4 File Offset: 0x001B9BF4
	// (set) Token: 0x06006A45 RID: 27205 RVA: 0x001BB9FC File Offset: 0x001B9BFC
	public bool MaxLike { get; set; }

	// Token: 0x17000841 RID: 2113
	// (get) Token: 0x06006A46 RID: 27206 RVA: 0x001BBA05 File Offset: 0x001B9C05
	// (set) Token: 0x06006A47 RID: 27207 RVA: 0x001BBA0D File Offset: 0x001B9C0D
	public bool RewardGet { get; set; }
}
