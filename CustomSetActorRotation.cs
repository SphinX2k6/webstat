using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002EA9 RID: 11945
[NullableContext(1)]
[Nullable(0)]
public class CustomSetActorRotation : CustomActionBase
{
	// Token: 0x0601883A RID: 100410 RVA: 0x006DFCD4 File Offset: 0x006DDED4
	public CustomSetActorRotation(CharacterActorComponent actorComp, BaseActorComponent targetActorComp, CharacterAnimationComponent animComp, double angle, ECustomSetRotationType rotationType, [Nullable(2)] Action callback = null, int modelBufferTime = 200)
	{
		this.ActorComp = actorComp;
		this.TargetActorComp = targetActorComp;
		this.AnimComp = animComp;
		this.Angle = angle;
		this.RotationType = rotationType;
		this.Callback = callback;
		this.ModelBufferTime = modelBufferTime;
	}

	// Token: 0x0601883B RID: 100411 RVA: 0x006DFD40 File Offset: 0x006DDF40
	protected override void OnRunAction()
	{
		if (this.ActorComp == null || this.AnimComp == null || this.TargetActorComp == null)
		{
			base.Finish(false);
			return;
		}
		this.DeltaTime = 0f;
		this.CacheVector2.DeepCopy(this.ActorComp.ActorGravityDirectProxy);
		this.CacheVector2.UnaryNegation(this.CacheVector2);
		this.CacheVector2.Normalize(9.99999993922529E-09);
		if (this.RotationType == ECustomSetRotationType.FaceToTarget)
		{
			this.CacheVector.DeepCopy(this.TargetActorComp.ActorLocationProxy);
			this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
			if (this.Angle != 0.0)
			{
				this.CacheVector.RotateAngleAxis(this.Angle, this.CacheVector2, this.CacheVector);
				return;
			}
		}
		else if (this.RotationType == ECustomSetRotationType.TargetForward)
		{
			this.CacheVector.DeepCopy(this.TargetActorComp.ActorForwardProxy);
			if (this.Angle != 0.0)
			{
				this.CacheVector.RotateAngleAxis(this.Angle, this.CacheVector2, this.CacheVector);
			}
		}
	}

	// Token: 0x0601883C RID: 100412 RVA: 0x006DFE68 File Offset: 0x006DE068
	protected override void OnCheckFinish(float deltaTime)
	{
		if (this.IsFinish)
		{
			return;
		}
		this.DeltaTime += deltaTime;
		double value = (double)Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(this.ActorComp, this.ActorComp.ActorForwardProxy, this.CacheVector);
		if (this.DeltaTime > 1000f || this.CacheVector.IsNearlyZero(9.999999747378752E-05) || Math.Abs(value) < 10.0)
		{
			if (this.CacheVector.IsNearlyZero(9.999999747378752E-05))
			{
				this.CacheRotator.DeepCopy(this.ActorComp.ActorRotationProxy);
			}
			else
			{
				Singleton<MathUtils>.Instance.LookRotationUpFirst(this.CacheVector, this.CacheVector2, this.CacheRotator);
			}
			CharacterAnimationComponent animComp = this.AnimComp;
			FTransformDouble? ftransformDouble = (animComp != null) ? new FTransformDouble?(animComp.GetMeshTransform()) : null;
			if (ftransformDouble != null)
			{
				this.ActorComp.SetActorRotation(this.CacheRotator.ToUeRotator(), "[CharacterCustomActionComponent]", false);
				this.ActorComp.ClearInput(false, true);
				CharacterAnimationComponent animComp2 = this.AnimComp;
				if (animComp2 != null)
				{
					animComp2.SetModelBuffer(ftransformDouble.Value, (float)this.ModelBufferTime);
				}
			}
			base.Finish(true);
			return;
		}
		this.ActorComp.SetInputFacing(this.CacheVector, true);
		this.ActorComp.SetOverrideTurnSpeed(new float?((float)180));
	}

	// Token: 0x0400BD31 RID: 48433
	private readonly Vector CacheVector = Vector.Create();

	// Token: 0x0400BD32 RID: 48434
	private readonly Vector CacheVector2 = Vector.Create();

	// Token: 0x0400BD33 RID: 48435
	private readonly Rotator CacheRotator = Rotator.Create();

	// Token: 0x0400BD34 RID: 48436
	private float DeltaTime;

	// Token: 0x0400BD35 RID: 48437
	private readonly CharacterActorComponent ActorComp;

	// Token: 0x0400BD36 RID: 48438
	private readonly BaseActorComponent TargetActorComp;

	// Token: 0x0400BD37 RID: 48439
	private readonly CharacterAnimationComponent AnimComp;

	// Token: 0x0400BD38 RID: 48440
	private readonly double Angle;

	// Token: 0x0400BD39 RID: 48441
	private readonly ECustomSetRotationType RotationType;

	// Token: 0x0400BD3A RID: 48442
	private readonly int ModelBufferTime;
}
