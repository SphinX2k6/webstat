using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;

// Token: 0x02000D25 RID: 3365
[NullableContext(1)]
[Nullable(0)]
internal class AttachGroupMonsterParams
{
	// Token: 0x060044F7 RID: 17655 RVA: 0x0008804F File Offset: 0x0008624F
	public void Initialize(CharacterActorComponent actorComp, Vector attachTargetLocation, float totalDuration)
	{
		this.ElpasedDuration = 0f;
		this.TotalAnimDuration = totalDuration;
		AnimationUtils.GetRootLocationCurveValue(actorComp.Entity, this.PreFrameAnimLocation);
		AnimationUtils.GetRootLocationCurveValueWithDelta(actorComp.Entity, totalDuration, this.AnimEndLocation);
		this.UpdateAttachLocation(actorComp, attachTargetLocation);
	}

	// Token: 0x060044F8 RID: 17656 RVA: 0x00088090 File Offset: 0x00086290
	public void UpdateAttachLocation(CharacterActorComponent actorComp, Vector attachEndLocation)
	{
		if (attachEndLocation.Equals(this.AttachEndLocation, 0.0001))
		{
			return;
		}
		this.AttachStartLocation.DeepCopy(actorComp.FloorLocation);
		this.AttachEndLocation.DeepCopy(attachEndLocation);
		this.AnimEndLocation.Subtraction(this.PreFrameAnimLocation, this.AnimDeltaLocation);
		this.UpdateAnimationScale();
	}

	// Token: 0x060044F9 RID: 17657 RVA: 0x000880F0 File Offset: 0x000862F0
	private void UpdateAnimationScale()
	{
		Vector tmpVector = AttachGroupMonsterParams.TmpVector1;
		Vector tmpVector2 = AttachGroupMonsterParams.TmpVector2;
		this.AttachEndLocation.Subtraction(this.AttachStartLocation, tmpVector);
		this.AttachRotator.Set(0f, (float)tmpVector.HeadingAngle(), 0f);
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(Vector.ZeroVectorProxy, this.AttachRotator, this.AnimDeltaLocation, tmpVector2);
		this.AnimScale.Set((!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.X, new double?(0.0001))) ? (tmpVector.X / tmpVector2.X) : 1.0, (!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.Y, new double?(0.0001))) ? (tmpVector.Y / tmpVector2.Y) : 1.0, (!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.Z, new double?(0.0001))) ? (tmpVector.Z / tmpVector2.Z) : 1.0);
	}

	// Token: 0x060044FA RID: 17658 RVA: 0x00088208 File Offset: 0x00086408
	public Vector StepFrameLocationOffset(CharacterActorComponent actorComp, float frameDeltaTime)
	{
		this.ElpasedDuration += frameDeltaTime;
		Vector tmpVector = AttachGroupMonsterParams.TmpVector1;
		Vector tmpVector2 = AttachGroupMonsterParams.TmpVector2;
		Vector tmpVector3 = AttachGroupMonsterParams.TmpVector3;
		if (this.ElpasedDuration > this.TotalAnimDuration)
		{
			tmpVector.DeepCopy(this.AnimEndLocation);
		}
		else
		{
			AnimationUtils.GetRootLocationCurveValue(actorComp.Entity, tmpVector);
		}
		tmpVector.Subtraction(this.PreFrameAnimLocation, tmpVector2);
		this.PreFrameAnimLocation.DeepCopy(tmpVector);
		Singleton<MathUtils>.Instance.InverseTransformPosition(Vector.ZeroVectorProxy, this.AttachRotator, this.AnimScale, tmpVector2, tmpVector3);
		return tmpVector3;
	}

	// Token: 0x0400125D RID: 4701
	public Vector AttachStartLocation = Vector.Create();

	// Token: 0x0400125E RID: 4702
	public Vector AttachEndLocation = Vector.Create();

	// Token: 0x0400125F RID: 4703
	public Rotator AttachRotator = Rotator.Create();

	// Token: 0x04001260 RID: 4704
	public Vector AnimEndLocation = Vector.Create();

	// Token: 0x04001261 RID: 4705
	public Vector AnimDeltaLocation = Vector.Create();

	// Token: 0x04001262 RID: 4706
	public Vector AnimScale = Vector.Create();

	// Token: 0x04001263 RID: 4707
	public Vector PreFrameAnimLocation = Vector.Create();

	// Token: 0x04001264 RID: 4708
	public float TotalAnimDuration;

	// Token: 0x04001265 RID: 4709
	public float ElpasedDuration;

	// Token: 0x04001266 RID: 4710
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x04001267 RID: 4711
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x04001268 RID: 4712
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector3 = Vector.Create();
}
