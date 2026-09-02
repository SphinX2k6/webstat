using System;

// Token: 0x020027CE RID: 10190
public class RoleWeaponData : IRoleWeaponData
{
	// Token: 0x17001994 RID: 6548
	// (get) Token: 0x06014277 RID: 82551 RVA: 0x005A04EE File Offset: 0x0059E6EE
	// (set) Token: 0x06014278 RID: 82552 RVA: 0x005A04F6 File Offset: 0x0059E6F6
	public int WeaponId { get; set; }

	// Token: 0x17001995 RID: 6549
	// (get) Token: 0x06014279 RID: 82553 RVA: 0x005A04FF File Offset: 0x0059E6FF
	// (set) Token: 0x0601427A RID: 82554 RVA: 0x005A0507 File Offset: 0x0059E707
	public int WeaponLevel { get; set; }

	// Token: 0x17001996 RID: 6550
	// (get) Token: 0x0601427B RID: 82555 RVA: 0x005A0510 File Offset: 0x0059E710
	// (set) Token: 0x0601427C RID: 82556 RVA: 0x005A0518 File Offset: 0x0059E718
	public int WeaponBreachLevel { get; set; }

	// Token: 0x17001997 RID: 6551
	// (get) Token: 0x0601427D RID: 82557 RVA: 0x005A0521 File Offset: 0x0059E721
	// (set) Token: 0x0601427E RID: 82558 RVA: 0x005A0529 File Offset: 0x0059E729
	public int WeaponResonanceLevel { get; set; }
}
