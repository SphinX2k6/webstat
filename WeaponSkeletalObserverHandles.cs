using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D0B RID: 11531
[NullableContext(1)]
[Nullable(0)]
public class WeaponSkeletalObserverHandles
{
	// Token: 0x0601744D RID: 95309 RVA: 0x006733DD File Offset: 0x006715DD
	public WeaponSkeletalObserverHandles(SkeletalObserverHandle weaponObserver, SkeletalObserverHandle weaponScabbardObserver)
	{
		this.WeaponObserver = weaponObserver;
		this.WeaponScabbardObserver = weaponScabbardObserver;
	}

	// Token: 0x0400B2D4 RID: 45780
	public SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B2D5 RID: 45781
	public SkeletalObserverHandle WeaponScabbardObserver;
}
