using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AFD RID: 11005
[NullableContext(1)]
public interface ISurvivorsWeaponWithBondInfo
{
	// Token: 0x17001CA9 RID: 7337
	// (get) Token: 0x06016005 RID: 90117
	SurvivorsWeaponGainData WeaponData { get; }

	// Token: 0x17001CAA RID: 7338
	// (get) Token: 0x06016006 RID: 90118
	int BondPosition { get; }
}
