using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D16 RID: 3350
[NullableContext(1)]
[Nullable(0)]
public class AiAreaMemberData
{
	// Token: 0x06004405 RID: 17413 RVA: 0x00083962 File Offset: 0x00081B62
	public AiAreaMemberData(AiScheduleGroup group)
	{
		this.Group = group;
	}

	// Token: 0x1700032A RID: 810
	// (get) Token: 0x06004406 RID: 17414 RVA: 0x00083983 File Offset: 0x00081B83
	public AiScheduleGroup Group { get; }

	// Token: 0x040011DE RID: 4574
	public int AreaIndex = -1;

	// Token: 0x040011DF RID: 4575
	public bool InZone;

	// Token: 0x040011E0 RID: 4576
	public float AngleCenter;

	// Token: 0x040011E1 RID: 4577
	public float MaxAngleOffset;

	// Token: 0x040011E2 RID: 4578
	public float DistanceCenter;

	// Token: 0x040011E3 RID: 4579
	public float MaxDistanceOffset;

	// Token: 0x040011E4 RID: 4580
	public float NextUpdateCenterTime;

	// Token: 0x040011E5 RID: 4581
	public Vector CachedTargetLocation = Vector.Create();

	// Token: 0x040011E6 RID: 4582
	public float CachedControllerYaw;

	// Token: 0x040011E7 RID: 4583
	public bool IsAttacker;

	// Token: 0x040011E8 RID: 4584
	public bool HasAttack;

	// Token: 0x040011E9 RID: 4585
	public double NextScheduleTimeNoAttack;

	// Token: 0x040011EA RID: 4586
	public double NextScheduleTimeAttack;

	// Token: 0x040011EB RID: 4587
	public double NextScheduleTimeOut;

	// Token: 0x040011EC RID: 4588
	public double? NextScheduleTimeBeAttack;
}
