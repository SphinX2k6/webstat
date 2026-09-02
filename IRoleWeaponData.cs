using System;

// Token: 0x020027CD RID: 10189
public interface IRoleWeaponData
{
	// Token: 0x17001990 RID: 6544
	// (get) Token: 0x0601426F RID: 82543
	// (set) Token: 0x06014270 RID: 82544
	int WeaponId { get; set; }

	// Token: 0x17001991 RID: 6545
	// (get) Token: 0x06014271 RID: 82545
	// (set) Token: 0x06014272 RID: 82546
	int WeaponLevel { get; set; }

	// Token: 0x17001992 RID: 6546
	// (get) Token: 0x06014273 RID: 82547
	// (set) Token: 0x06014274 RID: 82548
	int WeaponBreachLevel { get; set; }

	// Token: 0x17001993 RID: 6547
	// (get) Token: 0x06014275 RID: 82549
	// (set) Token: 0x06014276 RID: 82550
	int WeaponResonanceLevel { get; set; }
}
