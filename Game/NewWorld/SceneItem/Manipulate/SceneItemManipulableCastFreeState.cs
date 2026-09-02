using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484E RID: 18510
	public class SceneItemManipulableCastFreeState : SceneItemManipulableCastState
	{
		// Token: 0x0603027B RID: 197243 RVA: 0x00BADF13 File Offset: 0x00BAC113
		[NullableContext(1)]
		public SceneItemManipulableCastFreeState(SceneItemManipulatableComponent SceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? CameraShake, [Nullable(2)] UKuroForceFeedbackEffect GamepadShake) : base(SceneItem, CameraShake, GamepadShake)
		{
		}

		// Token: 0x0603027C RID: 197244 RVA: 0x00BADF29 File Offset: 0x00BAC129
		public void SetForward(FVector newValue)
		{
			this.Forward = newValue;
		}

		// Token: 0x0603027D RID: 197245 RVA: 0x00BADF34 File Offset: 0x00BAC134
		protected override void OnEnter()
		{
			base.OnEnter();
			float scale = 1f;
			float num = 0f;
			IThrowMotion motionConfig = this.SceneItem.Config.ThrowCfg.MotionConfig;
			if (motionConfig.Type == EThrowMotion.Projectile)
			{
				IProjectileMotion projectileMotion = motionConfig as IProjectileMotion;
				scale = projectileMotion.Velocity;
				num = projectileMotion.AngularVelocity;
			}
			this.SceneItem.IsCanBeHeld = false;
			if (this.NeedResetPhysicsMode)
			{
				this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.DynamicWaitSleep;
			}
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.FreeThrowing);
			}
			global::Vector vector = global::Vector.Create(UKismetMathLibrary.RandomUnitVector());
			UPrimitiveComponent primitiveComponent = this.SceneItem.ActorComp.GetPrimitiveComponent();
			primitiveComponent.SetPhysicsLinearVelocity(this.Forward * scale, false, default(FName));
			FVectorDouble fvectorDouble = vector.ToUeVector(false);
			FVectorDouble fvectorDouble2 = fvectorDouble * (double)num;
			primitiveComponent.SetPhysicsAngularVelocityInDegrees(fvectorDouble2, false, default(FName));
			this.SceneItem.TargetActorComponent = null;
			this.SceneItem.TargetOutletComponent = null;
			if (this.EnterCallback != null)
			{
				this.EnterCallback();
			}
		}

		// Token: 0x0603027E RID: 197246 RVA: 0x00BAE05F File Offset: 0x00BAC25F
		protected override void OnTick(float delta)
		{
			this.UpdateRotationAccordingToVelocity();
		}

		// Token: 0x0603027F RID: 197247 RVA: 0x00BAE068 File Offset: 0x00BAC268
		protected override void OnChangeMoveController(bool isAutonomous)
		{
			if (isAutonomous)
			{
				if (this.SceneItem != null)
				{
					SceneItemActorComponent actorComp = this.SceneItem.ActorComp;
					if (actorComp != null)
					{
						actorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.DynamicWaitSleep;
						return;
					}
				}
			}
			else
			{
				this.OnExit();
			}
		}

		// Token: 0x06030280 RID: 197248 RVA: 0x00BAE09D File Offset: 0x00BAC29D
		public override bool IsNoLockCasting()
		{
			return true;
		}

		// Token: 0x0401BA4D RID: 113229
		private FVector Forward = new FVector();
	}
}
