using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002FA5 RID: 12197
[NullableContext(1)]
[Nullable(0)]
public class GameplayCueFollow : GameplayCueEffect
{
	// Token: 0x06018E00 RID: 101888 RVA: 0x0070B2CC File Offset: 0x007094CC
	protected override void OnInit()
	{
		base.OnInit();
		this.IsLockRevolution = this.CueConfig.BLockRevolution;
		this.InterpSpeed = (float)this.CueConfig.InterpSpeed;
		Aki.Config.Vector value = this.CueConfig.FaultTolerance.Value;
		this.FaultTolerance = global::Vector.Create((double)Math.Abs(value.X), (double)Math.Abs(value.Y), (double)Math.Abs(value.Z));
		this.FarthestDistance = (float)this.CueConfig.FarthestDistance;
		Aki.Config.Vector value2 = this.CueConfig.LockRotation.Value;
		global::Vector vector = global::Vector.Create((double)value2.X, (double)value2.Y, (double)value2.Z);
		this.IsLockRotation = !vector.IsZero();
		vector.Rotation(this.LockRotation);
		this.IsLockCamera = this.CueConfig.LockCamera;
		WorldEntity entity = this.EntityHandle.Entity;
		this.MoveComp = ((entity != null) ? entity.GetComponent<BaseMoveComponent>() : null);
	}

	// Token: 0x06018E01 RID: 101889 RVA: 0x0070B3D5 File Offset: 0x007095D5
	protected override void OnTick(float delta)
	{
		base.OnTick(delta);
		this.RefreshEffectLocationAndRotation(new float?(delta));
	}

	// Token: 0x06018E02 RID: 101890 RVA: 0x0070B3EC File Offset: 0x007095EC
	protected override void AttachEffect(bool _ = false)
	{
		this.RefreshEffectLocationAndRotation(null);
	}

	// Token: 0x06018E03 RID: 101891 RVA: 0x0070B408 File Offset: 0x00709608
	protected override void SetTargetMeshAndSocket()
	{
		base.SetTargetMeshAndSocket();
		Transform socketTransform = this.SocketTransform;
		FTransformDouble ftransformDouble = this.TargetMesh.D_GetSocketTransform(this.TargetSocket, ERelativeTransformSpace.RTS_World);
		socketTransform.FromUeTransform(ftransformDouble);
		this.RelativeTransform.ComposeTransforms(this.SocketTransform, this.TargetTransform);
		global::Vector actorLocation = this.ActorLocation;
		FVectorDouble fvectorDouble = this.ActorInternal.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		this.ClosestDistance = global::Vector.Dist2D(this.TargetTransform.GetLocation(), this.ActorLocation);
	}

	// Token: 0x06018E04 RID: 101892 RVA: 0x0070B488 File Offset: 0x00709688
	private void RefreshEffectLocationAndRotation(float? delta = null)
	{
		if (!Singleton<EffectSystem>.Instance.IsValid(this.EffectViewHandle))
		{
			return;
		}
		OneOf<KuroEffectActorHandle, AActor> effectActor = Singleton<EffectSystem>.Instance.GetEffectActor(this.EffectViewHandle);
		global::Vector currentLocation = this.CurrentLocation;
		FVectorDouble fvectorDouble = effectActor.D_K2_GetActorLocation();
		currentLocation.FromUeVector(fvectorDouble);
		Rotator currentRotation = this.CurrentRotation;
		FRotator frotator = effectActor.K2_GetActorRotation();
		currentRotation.FromUeRotator(frotator);
		if (this.IsLockRevolution)
		{
			if (this.IsStandardGravity())
			{
				global::Vector targetLocation = this.TargetLocation;
				fvectorDouble = this.TargetMesh.D_GetSocketLocation(this.TargetSocket);
				targetLocation.FromUeVector(fvectorDouble);
				this.TargetLocation.AdditionEqual(this.RelativeTransform.GetLocation());
				Rotator targetRotation = this.TargetRotation;
				frotator = this.TargetMesh.GetSocketRotation(this.TargetSocket);
				targetRotation.FromUeRotator(frotator);
			}
			else
			{
				global::Vector targetLocation2 = this.TargetLocation;
				fvectorDouble = this.TargetMesh.D_GetSocketLocation(this.TargetSocket);
				targetLocation2.FromUeVector(fvectorDouble);
				if (this.TempLocationInGravity == null)
				{
					this.TempLocationInGravity = new global::Vector();
				}
				global::Vector location = this.RelativeTransform.GetLocation();
				FightCamera fightCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera;
				Quat quat;
				if (fightCamera == null)
				{
					quat = null;
				}
				else
				{
					FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
					quat = ((logicComponent != null) ? logicComponent.GravityQuat : null);
				}
				Quat quat2 = quat;
				if (quat2 != null)
				{
					quat2.RotateVector(location, this.TempLocationInGravity);
				}
				else
				{
					this.TempLocationInGravity.FromUeVector(location);
				}
				this.TargetLocation.AdditionEqual(this.TempLocationInGravity);
				Rotator targetRotation2 = this.TargetRotation;
				frotator = this.TargetMesh.GetSocketRotation(this.TargetSocket);
				targetRotation2.FromUeRotator(frotator);
			}
		}
		else
		{
			Transform socketTransform = this.SocketTransform;
			FTransformDouble ftransformDouble = this.TargetMesh.D_GetSocketTransform(this.TargetSocket, ERelativeTransformSpace.RTS_World);
			socketTransform.FromUeTransform(ftransformDouble);
			if (this.IsLockCamera)
			{
				if (this.IsStandardGravity())
				{
					this.CameraRotation.Pitch = 0f;
					this.CameraRotation.Yaw = ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw;
					this.CameraRotation.Roll = 0f;
				}
				else
				{
					FightCamera fightCamera2 = ModelBase<CameraModel>.Instance.MainModel.FightCamera;
					float? num;
					if (fightCamera2 == null)
					{
						num = null;
					}
					else
					{
						FightCameraLogicComponent logicComponent2 = fightCamera2.LogicComponent;
						num = ((logicComponent2 != null) ? new float?(logicComponent2.CameraRotationInGravity.Yaw) : null);
					}
					float? num2 = num;
					if (num2 != null)
					{
						if (this.TempRotationInGravity == null)
						{
							this.TempRotationInGravity = Rotator.Create(0f, 0f, 0f);
						}
						this.TempRotationInGravity.Yaw = num2.Value;
						CameraUtility.GetRotatorInNormal(this.TempRotationInGravity, this.CameraRotation);
					}
				}
				this.SocketTransform.SetRotation(this.CameraRotation.Quaternion(null));
			}
			this.RelativeTransform.ComposeTransforms(this.SocketTransform, this.TargetTransform);
			this.TargetLocation = this.TargetTransform.GetLocation();
			this.TargetRotation = this.TargetTransform.GetRotation().Rotator(null);
		}
		if (delta != null)
		{
			double num3 = global::Vector.Distance(this.CurrentLocation, this.TargetLocation);
			if (num3 < 0.10000000149011612)
			{
				this.IsMoving = false;
				return;
			}
			this.CorrectTargetByTolerance(this.CurrentLocation, this.TargetLocation);
			this.CorrectTargetByFarthestDistance(this.CurrentLocation, this.TargetLocation, this.CurrentRotation, this.TargetRotation, num3);
			Singleton<MathUtils>.Instance.VectorInterpTo(this.CurrentLocation, this.TargetLocation, (double)delta.Value, (double)this.InterpSpeed, this.TargetLocation);
			Singleton<MathUtils>.Instance.RotatorInterpTo(this.CurrentRotation, this.TargetRotation, (double)delta.Value, (double)this.InterpSpeed, this.TargetRotation);
		}
		global::Vector actorLocation = this.ActorLocation;
		fvectorDouble = this.ActorInternal.D_K2_GetActorLocation();
		actorLocation.FromUeVector(fvectorDouble);
		if (!this.CurrentRotation.Equals(this.TargetRotation, 0.1f) && global::Vector.Dist2D(this.TargetLocation, this.ActorLocation) < this.ClosestDistance && this.IsStandardGravity())
		{
			this.ActorLocation.Z = this.TargetLocation.Z;
			this.TargetLocation.Subtraction(this.ActorLocation, this.Direction);
			this.Direction.Normalize(9.99999993922529E-09);
			this.Direction.MultiplyEqual(this.ClosestDistance);
			this.ActorLocation.Addition(this.Direction, this.TargetLocation);
		}
		OneOf<KuroEffectActorHandle, AActor> self = effectActor;
		fvectorDouble = this.TargetLocation.ToUeVector(false);
		frotator = (this.IsLockRotation ? this.GetLockRotation().ToUeRotator() : this.TargetRotation.ToUeRotator());
		self.D_K2_SetActorLocationAndRotation(fvectorDouble, frotator, false, ref WorldGlobal.SweepHitResult, true);
	}

	// Token: 0x06018E05 RID: 101893 RVA: 0x0070B92C File Offset: 0x00709B2C
	private void CorrectTargetByTolerance(global::Vector currentLocation, global::Vector targetLocation)
	{
		if (!this.IsMoving)
		{
			targetLocation.X = Singleton<MathUtils>.Instance.Clamp(currentLocation.X, targetLocation.X - this.FaultTolerance.X, targetLocation.X + this.FaultTolerance.X);
			bool flag = targetLocation.X != currentLocation.X;
			targetLocation.Y = Singleton<MathUtils>.Instance.Clamp(currentLocation.Y, targetLocation.Y - this.FaultTolerance.Y, targetLocation.Y + this.FaultTolerance.Y);
			bool flag2 = targetLocation.Y != currentLocation.Y;
			targetLocation.Z = Singleton<MathUtils>.Instance.Clamp(currentLocation.Z, targetLocation.Z - this.FaultTolerance.Z, targetLocation.Z + this.FaultTolerance.Z);
			bool flag3 = targetLocation.Z != currentLocation.Z;
			if (flag || flag2 || flag3)
			{
				this.IsMoving = true;
			}
		}
	}

	// Token: 0x06018E06 RID: 101894 RVA: 0x0070BA34 File Offset: 0x00709C34
	private void CorrectTargetByFarthestDistance(global::Vector currentLocation, global::Vector targetLocation, Rotator currentRotation, Rotator targetRotation, double distance)
	{
		double num = (double)this.FarthestDistance / Math.Max(distance, 0.10000000149011612);
		if (num < 1.0)
		{
			global::Vector.Lerp(targetLocation, currentLocation, num, this.BorderLocation);
			Rotator.Lerp(targetRotation, currentRotation, (float)num, this.BorderRotation);
			currentLocation.DeepCopy(this.BorderLocation);
			currentRotation.DeepCopy(this.BorderRotation);
		}
	}

	// Token: 0x06018E07 RID: 101895 RVA: 0x0070BA9C File Offset: 0x00709C9C
	private bool IsStandardGravity()
	{
		return this.MoveComp == null || this.MoveComp.IsStandardGravity;
	}

	// Token: 0x06018E08 RID: 101896 RVA: 0x0070BAB4 File Offset: 0x00709CB4
	private Rotator GetLockRotation()
	{
		if (this.IsStandardGravity())
		{
			return this.LockRotation;
		}
		FightCamera fightCamera = ModelBase<CameraModel>.Instance.MainModel.FightCamera;
		Quat quat;
		if (fightCamera == null)
		{
			quat = null;
		}
		else
		{
			FightCameraLogicComponent logicComponent = fightCamera.LogicComponent;
			quat = ((logicComponent != null) ? logicComponent.GravityQuat : null);
		}
		Quat quat2 = quat;
		if (quat2 != null)
		{
			if (this.LockRotationInGravity == null)
			{
				this.LockRotationInGravity = Rotator.Create();
			}
			quat2.Rotator(this.LockRotationInGravity);
			this.LockRotationInGravity.AdditionEqual(this.LockRotation);
			return this.LockRotationInGravity;
		}
		return this.LockRotation;
	}

	// Token: 0x0400C244 RID: 49732
	private const float MAGIC_NUMBER = 0.1f;

	// Token: 0x0400C245 RID: 49733
	private readonly global::Vector ActorLocation = global::Vector.Create();

	// Token: 0x0400C246 RID: 49734
	private readonly global::Vector Direction = global::Vector.Create();

	// Token: 0x0400C247 RID: 49735
	private readonly global::Vector BorderLocation = global::Vector.Create();

	// Token: 0x0400C248 RID: 49736
	private readonly Rotator BorderRotation = Rotator.Create();

	// Token: 0x0400C249 RID: 49737
	private readonly global::Vector CurrentLocation = global::Vector.Create();

	// Token: 0x0400C24A RID: 49738
	private readonly Rotator CurrentRotation = Rotator.Create();

	// Token: 0x0400C24B RID: 49739
	private global::Vector TargetLocation = global::Vector.Create();

	// Token: 0x0400C24C RID: 49740
	private Rotator TargetRotation = Rotator.Create();

	// Token: 0x0400C24D RID: 49741
	private bool IsLockRevolution;

	// Token: 0x0400C24E RID: 49742
	private bool IsLockRotation;

	// Token: 0x0400C24F RID: 49743
	private bool IsLockCamera;

	// Token: 0x0400C250 RID: 49744
	private readonly Rotator LockRotation = Rotator.Create();

	// Token: 0x0400C251 RID: 49745
	private readonly Rotator CameraRotation = Rotator.Create();

	// Token: 0x0400C252 RID: 49746
	private float InterpSpeed;

	// Token: 0x0400C253 RID: 49747
	[Nullable(2)]
	private global::Vector FaultTolerance;

	// Token: 0x0400C254 RID: 49748
	private float FarthestDistance;

	// Token: 0x0400C255 RID: 49749
	private double ClosestDistance;

	// Token: 0x0400C256 RID: 49750
	private bool IsMoving;

	// Token: 0x0400C257 RID: 49751
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x0400C258 RID: 49752
	[Nullable(2)]
	private global::Vector TempLocationInGravity;

	// Token: 0x0400C259 RID: 49753
	[Nullable(2)]
	private Rotator TempRotationInGravity;

	// Token: 0x0400C25A RID: 49754
	[Nullable(2)]
	private Rotator LockRotationInGravity;
}
