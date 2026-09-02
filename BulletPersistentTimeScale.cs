using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x02002E09 RID: 11785
[NullableContext(2)]
[Nullable(0)]
public class BulletPersistentTimeScale
{
	// Token: 0x06017D21 RID: 97569 RVA: 0x006A4CAC File Offset: 0x006A2EAC
	public BulletPersistentTimeScale(Vector centerLocation, float radius, float startTime, int priority, float timeDilation, UCurveFloat curve, float duration, ETimeScaleSourceType sourceType, int timeScaleId)
	{
		this.CenterLocation = centerLocation;
		this.Radius = radius;
		this.StartTime = startTime;
		this.Priority = priority;
		this.TimeDilation = timeDilation;
		this.Curve = curve;
		this.Duration = duration;
		this.SourceType = sourceType;
		this.TimeScaleId = timeScaleId;
	}

	// Token: 0x0400B8B0 RID: 47280
	public readonly Vector CenterLocation;

	// Token: 0x0400B8B1 RID: 47281
	public readonly float Radius;

	// Token: 0x0400B8B2 RID: 47282
	public readonly float StartTime;

	// Token: 0x0400B8B3 RID: 47283
	public readonly int Priority;

	// Token: 0x0400B8B4 RID: 47284
	public readonly float TimeDilation;

	// Token: 0x0400B8B5 RID: 47285
	public readonly UCurveFloat Curve;

	// Token: 0x0400B8B6 RID: 47286
	public readonly float Duration;

	// Token: 0x0400B8B7 RID: 47287
	public readonly ETimeScaleSourceType SourceType;

	// Token: 0x0400B8B8 RID: 47288
	public readonly int TimeScaleId;
}
