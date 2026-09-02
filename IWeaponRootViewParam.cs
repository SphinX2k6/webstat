using System;

// Token: 0x02002D0C RID: 11532
public interface IWeaponRootViewParam
{
	// Token: 0x17001EA8 RID: 7848
	// (get) Token: 0x0601744E RID: 95310
	// (set) Token: 0x0601744F RID: 95311
	int WeaponIncId { get; set; }

	// Token: 0x17001EA9 RID: 7849
	// (get) Token: 0x06017450 RID: 95312
	// (set) Token: 0x06017451 RID: 95313
	int WeaponSkinId { get; set; }

	// Token: 0x17001EAA RID: 7850
	// (get) Token: 0x06017452 RID: 95314
	// (set) Token: 0x06017453 RID: 95315
	bool IsFromRoleRootView { get; set; }
}
