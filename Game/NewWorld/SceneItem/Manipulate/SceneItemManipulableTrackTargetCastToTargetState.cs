using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200485D RID: 18525
	[NullableContext(2)]
	[Nullable(0)]
	internal class SceneItemManipulableTrackTargetCastToTargetState : SceneItemManipulableCastState
	{
		// Token: 0x060302FC RID: 197372 RVA: 0x00BB2AE6 File Offset: 0x00BB0CE6
		[NullableContext(1)]
		public SceneItemManipulableTrackTargetCastToTargetState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, cameraShake, gamepadShake)
		{
		}

		// Token: 0x060302FD RID: 197373 RVA: 0x00BB2AF4 File Offset: 0x00BB0CF4
		[NullableContext(1)]
		public void SetTargetActorWithPart(BaseActorComponent targetActor, [Nullable(2)] CharacterPart targetPart)
		{
			this.TargetActor = targetActor;
			if (targetPart != null)
			{
				CharacterActorComponent characterActorComponent = targetActor as CharacterActorComponent;
				this.TargetSkeletalMesh = ((characterActorComponent != null) ? characterActorComponent.Actor.Mesh : null);
				this.TargetSocketName = targetPart.PartSocketName;
			}
		}

		// Token: 0x060302FE RID: 197374 RVA: 0x00BB2B38 File Offset: 0x00BB0D38
		protected override void OnEnter()
		{
			base.OnEnter();
			if (this.TargetActor == null)
			{
				return;
			}
			IThrowMotionTrackTarget throwMotionTrackTarget = this.SceneItem.Config.ThrowCfg.MotionConfig as IThrowMotionTrackTarget;
			this.Speed = new float?(throwMotionTrackTarget.Velocity);
			if (!StringUtils.IsEmpty(throwMotionTrackTarget.VelocityCurve))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(throwMotionTrackTarget.VelocityCurve, delegate([Nullable(2)] UCurveFloat result, string _)
				{
					this.SpeedCurve = result;
				}, 100, "js_undefined");
			}
			this.AngularSpeed = new float?(throwMotionTrackTarget.AngularVelocity);
			if (!StringUtils.IsEmpty(throwMotionTrackTarget.AngularVelocityCurve))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(throwMotionTrackTarget.AngularVelocityCurve, delegate([Nullable(2)] UCurveFloat result, string _)
				{
					this.AngularSpeedCurve = result;
				}, 100, "js_undefined");
			}
			this.CurrentDirection = global::Vector.Create();
			if (throwMotionTrackTarget.VelocityOffset != null)
			{
				global::Rotator b = global::Rotator.Create(throwMotionTrackTarget.VelocityOffset.Y.GetValueOrDefault(), throwMotionTrackTarget.VelocityOffset.Z.GetValueOrDefault(), throwMotionTrackTarget.VelocityOffset.X.GetValueOrDefault());
				global::Rotator rotator = global::Rotator.Create(ControllerBase<CameraController>.Instance.MainModel.CameraRotator);
				Singleton<MathUtils>.Instance.ComposeRotator(rotator, b, rotator);
				rotator.Vector(this.CurrentDirection);
			}
			else
			{
				ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Vector(this.CurrentDirection);
			}
			this.CurrentDirection.Normalize(9.99999993922529E-09);
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.LockEntityThrowing);
			}
		}

		// Token: 0x060302FF RID: 197375 RVA: 0x00BB2CC8 File Offset: 0x00BB0EC8
		protected override void OnTick(float delta)
		{
			base.OnTick(delta);
			this.Timer += delta;
			float num = this.AngularSpeed.GetValueOrDefault();
			UCurveFloat angularSpeedCurve = this.AngularSpeedCurve;
			if (angularSpeedCurve != null && angularSpeedCurve.IsValid())
			{
				num *= this.AngularSpeedCurve.GetFloatValue(this.Timer);
			}
			float num2 = this.Speed.GetValueOrDefault();
			UCurveFloat speedCurve = this.SpeedCurve;
			if (speedCurve != null && speedCurve.IsValid())
			{
				num2 *= this.SpeedCurve.GetFloatValue(this.Timer);
			}
			this.CurrentDirection.Normalize(9.99999993922529E-09);
			global::Vector vector = global::Vector.Create();
			if (this.TargetSocketName != null)
			{
				global::Vector vector2 = vector;
				FVectorDouble fvectorDouble = this.TargetSkeletalMesh.D_GetSocketLocation(this.TargetSocketName.Value);
				vector2.DeepCopy(fvectorDouble);
			}
			else
			{
				vector.DeepCopy(this.TargetActor.ActorLocationProxy);
			}
			global::Vector vector3 = global::Vector.Create(this.SceneItem.ActorComp.ActorLocationProxy);
			global::Vector vector4 = global::Vector.Create(vector);
			vector4.SubtractionEqual(vector3);
			vector4.Normalize(9.99999993922529E-09);
			float num3 = (float)(Math.Acos(global::Vector.DotProduct(this.CurrentDirection, vector4)) * 57.295780181884766);
			num3 = Singleton<MathUtils>.Instance.Clamp(num3, -num * delta, num * delta);
			global::Vector vector5 = global::Vector.Create();
			global::Vector.CrossProduct(this.CurrentDirection, vector4, vector5);
			this.CurrentDirection.RotateAngleAxis((double)num3, vector5, this.CurrentDirection);
			global::Vector vector6 = global::Vector.Create(vector3);
			global::Vector vector7 = global::Vector.Create(this.CurrentDirection);
			vector7.MultiplyEqual((double)(num2 * delta));
			vector6.AdditionEqual(vector7);
			this.SceneItem.ActorComp.SetActorLocation(vector6.ToUeVector(false), "unknown", true);
			if (this.SceneItem.ManipulateBaseConfig.随速度调整朝向 && !this.AfterHit)
			{
				FVectorDouble fvectorDouble = this.SceneItem.ActorComp.ActorLocation;
				FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
				FVectorDouble fvectorDouble2 = this.CurrentDirection.ToUeVector(false);
				FVectorDouble fvectorDouble3 = actorLocation + fvectorDouble2;
				FRotator value = UKismetMathLibrary.D_FindLookAtRotation(fvectorDouble, fvectorDouble3);
				this.SceneItem.ActorComp.SetActorRotation(value, "[ManipulableCastState.UpdateRotationAccordingToVelocity]", false);
			}
		}

		// Token: 0x0401BAB0 RID: 113328
		private BaseActorComponent TargetActor;

		// Token: 0x0401BAB1 RID: 113329
		private USkeletalMeshComponent TargetSkeletalMesh;

		// Token: 0x0401BAB2 RID: 113330
		private FName? TargetSocketName;

		// Token: 0x0401BAB3 RID: 113331
		private float? Speed;

		// Token: 0x0401BAB4 RID: 113332
		private UCurveFloat SpeedCurve;

		// Token: 0x0401BAB5 RID: 113333
		private float? AngularSpeed;

		// Token: 0x0401BAB6 RID: 113334
		private UCurveFloat AngularSpeedCurve;

		// Token: 0x0401BAB7 RID: 113335
		private global::Vector CurrentDirection;
	}
}
