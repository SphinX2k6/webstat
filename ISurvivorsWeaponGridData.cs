using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AFB RID: 11003
[NullableContext(2)]
public interface ISurvivorsWeaponGridData
{
	// Token: 0x17001C9F RID: 7327
	// (get) Token: 0x06015FF5 RID: 90101
	SurvivorsWeaponGainData WeaponData { get; }

	// Token: 0x17001CA0 RID: 7328
	// (get) Token: 0x06015FF6 RID: 90102
	int? BondPosition { get; }

	// Token: 0x17001CA1 RID: 7329
	// (get) Token: 0x06015FF7 RID: 90103
	bool IsLock { get; }

	// Token: 0x17001CA2 RID: 7330
	// (get) Token: 0x06015FF8 RID: 90104
	int? UnlockBatch { get; }

	// Token: 0x17001CA3 RID: 7331
	// (get) Token: 0x06015FF9 RID: 90105
	bool IsDisable { get; }
}
