using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002DB5 RID: 11701
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BulletConstant : Singleton<BulletConstant>
{
	// Token: 0x0400B5AC RID: 46508
	public readonly FName ProfileNameWater = new FName("水体");

	// Token: 0x0400B5AD RID: 46509
	public readonly FName ProfileNameOnlyBullet = new FName("Bullet_OnlyBullet");

	// Token: 0x0400B5AE RID: 46510
	public readonly Rotator RotateToRight = Rotator.Create(0f, -90f, 0f);

	// Token: 0x0400B5AF RID: 46511
	public bool OpenCollisionLog;

	// Token: 0x0400B5B0 RID: 46512
	public bool OpenMoveLog;

	// Token: 0x0400B5B1 RID: 46513
	public bool OpenCreateLog;

	// Token: 0x0400B5B2 RID: 46514
	public bool OpenHitActorLog;

	// Token: 0x0400B5B3 RID: 46515
	public bool OpenDestroyLog;

	// Token: 0x0400B5B4 RID: 46516
	public bool OpenActionStat;

	// Token: 0x0400B5B5 RID: 46517
	public readonly bool OpenAllActionStat;

	// Token: 0x0400B5B6 RID: 46518
	public readonly bool OpenPoolCheck;

	// Token: 0x0400B5B7 RID: 46519
	public readonly bool OpenClearCheck;

	// Token: 0x0400B5B8 RID: 46520
	public readonly bool OpenActorRecycleCheck;

	// Token: 0x0400B5B9 RID: 46521
	public readonly bool CollisionCompVisibleInEditor = true;

	// Token: 0x0400B5BA RID: 46522
	public readonly float SuperHighSpeed = 12000f;

	// Token: 0x0400B5BB RID: 46523
	public readonly float HighSpeed = 5000f;

	// Token: 0x0400B5BC RID: 46524
	public readonly int FactorBoxSix = 6;

	// Token: 0x0400B5BD RID: 46525
	public readonly int FactorBoxTwelve = 12;

	// Token: 0x0400B5BE RID: 46526
	public readonly FName HitCase = new FName("HitCase");

	// Token: 0x0400B5BF RID: 46527
	public readonly string MoveCylinder = "CollisionCylinder";

	// Token: 0x0400B5C0 RID: 46528
	public readonly string RegionKey = "Region";
}
