using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DB4 RID: 11700
[NullableContext(1)]
[Nullable(0)]
public class BulletHitEffectConf
{
	// Token: 0x06017991 RID: 96657 RVA: 0x00690254 File Offset: 0x0068E454
	public BulletHitEffectConf(SBulletEffectOnHitConf data)
	{
		this.EnableHighLimit = data.启用约束;
		this.HighLimit = Vector2D.Create();
		this.Scale = Vector.Create();
		this.HighLimit.FromUeVector2D(data.高度约束);
		Vector scale = this.Scale;
		FVector 大小缩放 = data.大小缩放;
		scale.FromUeVector(大小缩放);
	}

	// Token: 0x0400B5A9 RID: 46505
	public readonly Vector2D HighLimit;

	// Token: 0x0400B5AA RID: 46506
	public readonly Vector Scale;

	// Token: 0x0400B5AB RID: 46507
	public readonly bool EnableHighLimit;
}
