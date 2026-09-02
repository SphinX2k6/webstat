using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003015 RID: 12309
[NullableContext(2)]
[Nullable(0)]
public class VelocityAddition
{
	// Token: 0x06019166 RID: 102758 RVA: 0x007219E0 File Offset: 0x0071FBE0
	public float VelocityCurveFunc(float delta)
	{
		float currentValue = delta;
		switch (this.VelocityCurveType)
		{
		case EVelocityCurveType.Convex:
			currentValue = (float)Singleton<MathUtils>.Instance.BlendEaseIn((double)this.VelocityCurveMax, (double)this.VelocityCurveMin, delta, 2.0);
			break;
		case EVelocityCurveType.LinearityDown:
			currentValue = this.VelocityCurveMax + (this.VelocityCurveMin - this.VelocityCurveMax) * delta;
			break;
		case EVelocityCurveType.Concave:
			currentValue = (float)Singleton<MathUtils>.Instance.BlendEaseIn((double)this.VelocityCurveMin, (double)this.VelocityCurveMax, delta - 1f, 2.0);
			break;
		}
		return Singleton<MathUtils>.Instance.Clamp(currentValue, 0f, 1f);
	}

	// Token: 0x06019167 RID: 102759 RVA: 0x00721A8C File Offset: 0x0071FC8C
	public VelocityAddition(float duration, FVectorDouble velocity, UCurveFloat curveFloat, int movementMode, EVelocityCurveType velocityCurveType, float velocityCurveMin, float velocityCurveMax)
	{
		this.ElapsedTime = 0f;
		this.Duration = duration;
		this.Velocity = new FVectorDouble?(velocity);
		this.CurveFloat = curveFloat;
		this.MovementMode = movementMode;
		this.VelocityCurveType = velocityCurveType;
		this.VelocityCurveMin = velocityCurveMin;
		this.VelocityCurveMax = velocityCurveMax;
	}

	// Token: 0x0400C49D RID: 50333
	public float ElapsedTime;

	// Token: 0x0400C49E RID: 50334
	public float Duration;

	// Token: 0x0400C49F RID: 50335
	public FVectorDouble? Velocity;

	// Token: 0x0400C4A0 RID: 50336
	public UCurveFloat CurveFloat;

	// Token: 0x0400C4A1 RID: 50337
	public int MovementMode;

	// Token: 0x0400C4A2 RID: 50338
	public EVelocityCurveType VelocityCurveType;

	// Token: 0x0400C4A3 RID: 50339
	public float VelocityCurveMin;

	// Token: 0x0400C4A4 RID: 50340
	public float VelocityCurveMax;
}
