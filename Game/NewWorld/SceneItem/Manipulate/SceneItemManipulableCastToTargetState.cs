using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004852 RID: 18514
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulableCastToTargetState : SceneItemManipulableCastState
	{
		// Token: 0x0603029F RID: 197279 RVA: 0x00BAF0F2 File Offset: 0x00BAD2F2
		public SceneItemManipulableCastToTargetState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, cameraShake, gamepadShake)
		{
		}

		// Token: 0x060302A0 RID: 197280 RVA: 0x00BAF108 File Offset: 0x00BAD308
		public void SetTarget(Entity newValue)
		{
			this.TargetInternal = newValue;
		}

		// Token: 0x060302A1 RID: 197281 RVA: 0x00BAF111 File Offset: 0x00BAD311
		public override void SetEnterCallback(Action callback)
		{
			this.EnterCallback = callback;
		}

		// Token: 0x060302A2 RID: 197282 RVA: 0x00BAF11C File Offset: 0x00BAD31C
		protected override void OnEnter()
		{
			Entity targetInternal = this.TargetInternal;
			if (targetInternal == null || !targetInternal.Valid)
			{
				Singleton<Log>.Instance.Error(ELogModule.SceneItem, ELogAuthor.CH, "被控物没有进入CastToTarget时,没有设置目标", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			base.OnEnter();
			this.SceneItem.IsCanBeHeld = false;
			BaseActorComponent component = this.TargetInternal.GetComponent<BaseActorComponent>();
			this.SceneItem.TargetActorComponent = component;
			this.SceneItem.TargetOutletComponent = null;
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.LockEntityThrowing);
			}
			base.StartCast();
			base.CalcDirection();
			if (this.EnterCallback != null)
			{
				this.EnterCallback();
			}
		}

		// Token: 0x060302A3 RID: 197283 RVA: 0x00BAF1D8 File Offset: 0x00BAD3D8
		protected override void OnTick(float delta)
		{
			this.Timer += delta;
			float num = Singleton<MathUtils>.Instance.Clamp(this.Timer / this.CastDuration, 0f, 1f);
			if (this.SceneItem.CastCurve != null)
			{
				num = this.SceneItem.CastCurve.GetFloatValue(num);
			}
			global::Vector prevLocation = this.PrevLocation;
			FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
			prevLocation.DeepCopy(actorLocation);
			this.UpdateLocation(num);
			this.UpdateRotation();
			this.UpdateRotationAccordingToVelocity();
			this.CheckFinish();
		}

		// Token: 0x060302A4 RID: 197284 RVA: 0x00BAF26B File Offset: 0x00BAD46B
		protected override void OnExit()
		{
			base.OnExit();
			this.TargetInternal = null;
		}

		// Token: 0x060302A5 RID: 197285 RVA: 0x00BAF27C File Offset: 0x00BAD47C
		protected void UpdateRotation()
		{
			float num = 0f;
			IThrowMotion motionConfig = this.SceneItem.Config.ThrowCfg.MotionConfig;
			if (motionConfig.Type == EThrowMotion.Projectile)
			{
				num = (motionConfig as IProjectileMotion).AngularVelocity;
			}
			float angle = num * this.Timer;
			FRotator value = UKismetMathLibrary.RotatorFromAxisAndAngle(this.CastRotAxis.ToUeVectorOld(), angle);
			this.SceneItem.ActorComp.SetActorRotation(value, "[SceneItemManipulableCastToTargetState.UpdateLocation]", this.HitCallback != null);
		}

		// Token: 0x060302A6 RID: 197286 RVA: 0x00BAF2F4 File Offset: 0x00BAD4F4
		protected override void UpdateRotationAccordingToVelocity()
		{
			if (!this.SceneItem.ManipulateBaseConfig.随速度调整朝向)
			{
				return;
			}
			if (this.AfterHit)
			{
				return;
			}
			global::Vector vector = global::Vector.Create();
			this.SceneItem.ActorComp.ActorLocationProxy.Subtraction(this.PrevLocation, vector);
			vector.Normalize(9.99999993922529E-09);
			FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
			FVectorDouble actorLocation2 = this.SceneItem.ActorComp.ActorLocation;
			FVectorDouble fvectorDouble = vector.ToUeVector(false);
			FVectorDouble fvectorDouble2 = actorLocation2 + fvectorDouble;
			FRotator value = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, fvectorDouble2);
			this.SceneItem.ActorComp.SetActorRotation(value, "[ManipulableCastState.UpdateRotationAccordingToVelocity]", false);
		}

		// Token: 0x060302A7 RID: 197287 RVA: 0x00BAF3A8 File Offset: 0x00BAD5A8
		private void CheckFinish()
		{
			if (this.Timer >= this.CastDuration && this.CastDuration > 0f)
			{
				this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.DynamicWaitSleep;
				global::Vector vector = global::Vector.Create(this.SceneItem.ActorComp.ActorLocation);
				vector.SubtractionEqual(this.PrevLocation);
				vector.Normalize(9.99999993922529E-09);
				IThrowMotion motionConfig = this.SceneItem.Config.ThrowCfg.MotionConfig;
				if (motionConfig.Type != EThrowMotion.FreeFall)
				{
					IProjectileMotion projectileMotion = motionConfig as IProjectileMotion;
					if (projectileMotion != null)
					{
						vector.MultiplyEqual((double)projectileMotion.Velocity);
					}
					else
					{
						ICircumnutation circumnutation = motionConfig as ICircumnutation;
						if (circumnutation != null)
						{
							vector.MultiplyEqual((double)circumnutation.Velocity);
						}
						else
						{
							IThrowMotionTrackTarget throwMotionTrackTarget = motionConfig as IThrowMotionTrackTarget;
							if (throwMotionTrackTarget != null)
							{
								vector.MultiplyEqual((double)throwMotionTrackTarget.Velocity);
							}
							else
							{
								IThrowMotionLevitate throwMotionLevitate = motionConfig as IThrowMotionLevitate;
								if (throwMotionLevitate != null)
								{
									vector.MultiplyEqual((double)throwMotionLevitate.Velocity);
								}
							}
						}
					}
				}
				this.SceneItem.ActorComp.GetPrimitiveComponent().SetPhysicsLinearVelocity(vector.ToUeVectorOld(), false, default(FName));
			}
		}

		// Token: 0x0401BA6A RID: 113258
		[Nullable(2)]
		private Entity TargetInternal;

		// Token: 0x0401BA6B RID: 113259
		private readonly global::Vector PrevLocation = global::Vector.Create();
	}
}
