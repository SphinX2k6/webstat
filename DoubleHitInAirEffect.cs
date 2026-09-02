using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x02003041 RID: 12353
[NullableContext(1)]
[Nullable(0)]
public class DoubleHitInAirEffect
{
	// Token: 0x06019492 RID: 103570 RVA: 0x00744BFC File Offset: 0x00742DFC
	public void FromUeHitEffect(SHitEffect hitEffect)
	{
		this.GravityScaleUp = hitEffect.落地反弹上升重力标量;
		this.GravityScaleDown = hitEffect.落地反弹下落重力标量;
		this.GravityScaleTop = hitEffect.落地反弹弧顶重力标量;
		Vector landingBounce = this.LandingBounce;
		FVector 落地反弹 = hitEffect.落地反弹;
		landingBounce.FromUeVector(落地反弹);
		this.VelocityTop = hitEffect.落地反弹速度阈值;
		this.Valid = true;
		this.Duration = hitEffect.落地反弹时长;
	}

	// Token: 0x06019493 RID: 103571 RVA: 0x00744C60 File Offset: 0x00742E60
	public void Finish()
	{
		this.Valid = false;
	}

	// Token: 0x0400C786 RID: 51078
	public float GravityScaleUp;

	// Token: 0x0400C787 RID: 51079
	public float GravityScaleDown;

	// Token: 0x0400C788 RID: 51080
	public float GravityScaleTop;

	// Token: 0x0400C789 RID: 51081
	public readonly Vector LandingBounce = Vector.Create();

	// Token: 0x0400C78A RID: 51082
	public float VelocityTop;

	// Token: 0x0400C78B RID: 51083
	public bool Valid;

	// Token: 0x0400C78C RID: 51084
	public float Duration;
}
