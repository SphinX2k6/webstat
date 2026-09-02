using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003407 RID: 13319
[NullableContext(1)]
[Nullable(0)]
public class EffectTriggerActionParameterNames
{
	// Token: 0x0601BD04 RID: 113924 RVA: 0x0084BD38 File Offset: 0x00849F38
	public EffectTriggerActionParameterNames(IReadOnlyList<FName> trigger, IReadOnlyList<FName> duration, IReadOnlyList<FName> attackRadius, IReadOnlyList<FName> attackMagnitude, IReadOnlyList<FName> actorLocation, IReadOnlyList<FName> curveFloat, IReadOnlyList<FName> elapsedTime, IReadOnlyList<FName> textureHeight)
	{
		this.Trigger = trigger;
		this.Duration = duration;
		this.AttackRadius = attackRadius;
		this.AttackMagnitude = attackMagnitude;
		this.ActorLocation = actorLocation;
		this.CurveFloat = curveFloat;
		this.ElapsedTime = elapsedTime;
		this.TextureHeight = textureHeight;
	}

	// Token: 0x0400E08F RID: 57487
	public readonly IReadOnlyList<FName> Trigger;

	// Token: 0x0400E090 RID: 57488
	public readonly IReadOnlyList<FName> Duration;

	// Token: 0x0400E091 RID: 57489
	public readonly IReadOnlyList<FName> AttackRadius;

	// Token: 0x0400E092 RID: 57490
	public readonly IReadOnlyList<FName> AttackMagnitude;

	// Token: 0x0400E093 RID: 57491
	public readonly IReadOnlyList<FName> ActorLocation;

	// Token: 0x0400E094 RID: 57492
	public readonly IReadOnlyList<FName> CurveFloat;

	// Token: 0x0400E095 RID: 57493
	public readonly IReadOnlyList<FName> ElapsedTime;

	// Token: 0x0400E096 RID: 57494
	public readonly IReadOnlyList<FName> TextureHeight;
}
