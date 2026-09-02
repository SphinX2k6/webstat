using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;

// Token: 0x02000D22 RID: 3362
[NullableContext(1)]
[Nullable(0)]
internal class AttachParams
{
	// Token: 0x060044B8 RID: 17592 RVA: 0x00086F27 File Offset: 0x00085127
	public void Initialize(CharacterActorComponent actorComp, Vector attachTargetLocation, float totalDuration)
	{
		this.ElpasedDuration = 0f;
		this.TotalAnimDuration = totalDuration;
		AnimationUtils.GetRootLocationCurveValue(actorComp.Entity, this.PreFrameAnimLocation);
		AnimationUtils.GetRootLocationCurveValueWithDelta(actorComp.Entity, totalDuration, this.AnimEndLocation);
		this.UpdateAttachLocation(actorComp, attachTargetLocation);
	}

	// Token: 0x060044B9 RID: 17593 RVA: 0x00086F68 File Offset: 0x00085168
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

	// Token: 0x060044BA RID: 17594 RVA: 0x00086FC8 File Offset: 0x000851C8
	private void UpdateAnimationScale()
	{
		Vector tmpVector = AttachParams.TmpVector1;
		Vector tmpVector2 = AttachParams.TmpVector2;
		this.AttachEndLocation.Subtraction(this.AttachStartLocation, tmpVector);
		this.AttachRotator.Set(0f, (float)tmpVector.HeadingAngle(), 0f);
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(Vector.ZeroVectorProxy, this.AttachRotator, this.AnimDeltaLocation, tmpVector2);
		this.AnimScale.Set((!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.X, new double?(0.0001))) ? (tmpVector.X / tmpVector2.X) : 1.0, (!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.Y, new double?(0.0001))) ? (tmpVector.Y / tmpVector2.Y) : 1.0, (!Singleton<MathUtils>.Instance.IsNearlyZero(tmpVector2.Z, new double?(0.0001))) ? (tmpVector.Z / tmpVector2.Z) : 1.0);
	}

	// Token: 0x060044BB RID: 17595 RVA: 0x000870E0 File Offset: 0x000852E0
	public Vector StepFrameLocationOffset(CharacterActorComponent actorComp, float frameDeltaTime)
	{
		this.ElpasedDuration += frameDeltaTime;
		Vector tmpVector = AttachParams.TmpVector1;
		Vector tmpVector2 = AttachParams.TmpVector2;
		Vector tmpVector3 = AttachParams.TmpVector3;
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

	// Token: 0x0400123A RID: 4666
	public Vector AttachStartLocation = Vector.Create();

	// Token: 0x0400123B RID: 4667
	public Vector AttachEndLocation = Vector.Create();

	// Token: 0x0400123C RID: 4668
	public Rotator AttachRotator = Rotator.Create();

	// Token: 0x0400123D RID: 4669
	public Vector AnimEndLocation = Vector.Create();

	// Token: 0x0400123E RID: 4670
	public Vector AnimDeltaLocation = Vector.Create();

	// Token: 0x0400123F RID: 4671
	public Vector AnimScale = Vector.Create();

	// Token: 0x04001240 RID: 4672
	public Vector PreFrameAnimLocation = Vector.Create();

	// Token: 0x04001241 RID: 4673
	public float TotalAnimDuration;

	// Token: 0x04001242 RID: 4674
	public float ElpasedDuration;

	// Token: 0x04001243 RID: 4675
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector1 = Vector.Create();

	// Token: 0x04001244 RID: 4676
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector2 = Vector.Create();

	// Token: 0x04001245 RID: 4677
	[StaticVariableRuleIgnore]
	private static readonly Vector TmpVector3 = Vector.Create();
}
