using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.PathLine;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200484F RID: 18511
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemManipulatableCastProjectileState : SceneItemManipulableCastState
	{
		// Token: 0x06030281 RID: 197249 RVA: 0x00BAE0A0 File Offset: 0x00BAC2A0
		[NullableContext(1)]
		public SceneItemManipulatableCastProjectileState(SceneItemManipulatableComponent SceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? CameraShake, [Nullable(2)] UKuroForceFeedbackEffect GamepadShake) : base(SceneItem, CameraShake, GamepadShake)
		{
		}

		// Token: 0x06030282 RID: 197250 RVA: 0x00BAE0C4 File Offset: 0x00BAC2C4
		protected override void OnEnter()
		{
			base.OnEnter();
			this.GeneratePredictProjectilePoints();
			this.MoveSpeed = this.SceneItem.ManipulateBaseConfig.抛物瞄准模式初速度;
			this.Distance = 0f;
			this.LastLocation = global::Vector.Create(this.SceneItem.LastHoldingLocation);
			this.IsAfterPortal = false;
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.FreeThrowing);
			}
			if (this.EnterCallback != null)
			{
				this.EnterCallback();
			}
		}

		// Token: 0x06030283 RID: 197251 RVA: 0x00BAE154 File Offset: 0x00BAC354
		protected override void OnTick(float delta)
		{
			float num = this.MoveSpeed * delta;
			this.Distance += num;
			FVectorDouble value;
			if (!this.IsAfterPortal)
			{
				value = this.SplineComponent.D_GetLocationAtDistanceAlongSpline(this.Distance, ESplineCoordinateSpace.World);
			}
			else
			{
				value = this.AfterPortalSplineComponent.D_GetLocationAtDistanceAlongSpline(this.Distance, ESplineCoordinateSpace.World);
			}
			this.SceneItem.ActorComp.SetActorLocation(value, "unknown", true);
			if (!this.IsAfterPortal && this.Distance >= this.SplineComponent.GetSplineLength())
			{
				if (this.AfterPortalSplineComponent == null)
				{
					this.SceneItem.CastFreeState.NeedNotifyServer = false;
					SceneItemManipulatableComponent sceneItem = this.SceneItem;
					if (sceneItem != null)
					{
						sceneItem.SetState(SceneItemManipulatableComponent.EManipulatableState.BeCastingFree, "CastProjectileState over spline and no afterPortal");
					}
				}
				else
				{
					this.IsAfterPortal = true;
					this.SceneItem.ActorComp.SetActorLocation(this.AfterPortalSplineComponent.D_GetLocationAtDistanceAlongSpline(0f, ESplineCoordinateSpace.World), "[SceneItemManipulatableCastProjectileState] OnTeleport", false);
					this.Distance = 0f;
				}
			}
			else if (this.IsAfterPortal && this.Distance >= this.AfterPortalSplineComponent.GetSplineLength())
			{
				SceneItemManipulatableComponent sceneItem2 = this.SceneItem;
				if (sceneItem2 != null)
				{
					sceneItem2.SetState(SceneItemManipulatableComponent.EManipulatableState.Reset, "CastProjectileState over spline");
				}
			}
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.DynamicWaitSleep;
			this.CurrentDirection = global::Vector.Create();
			this.SceneItem.ActorComp.ActorLocationProxy.Subtraction(this.LastLocation, this.CurrentDirection);
			this.CurrentDirection.Normalize(9.99999993922529E-09);
			this.LastLocation = global::Vector.Create(this.SceneItem.ActorComp.ActorLocation);
		}

		// Token: 0x06030284 RID: 197252 RVA: 0x00BAE2F4 File Offset: 0x00BAC4F4
		protected override void OnExit()
		{
			base.OnExit();
			this.SceneItem.ActorComp.GetPrimitiveComponent().SetPhysicsLinearVelocity(this.CurrentDirection.MultiplyEqual((double)this.MoveSpeed).ToUeVectorOld(), false, default(FName));
			AActor splineActor = this.SplineActor;
			if (splineActor != null && splineActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("SceneItemManipulatableCastProjectileState.OnExit1", this.SplineActor, null);
				this.SplineActor = null;
				this.SplineComponent = null;
			}
			AActor afterPortalSplineActor = this.AfterPortalSplineActor;
			if (afterPortalSplineActor != null && afterPortalSplineActor.IsValid())
			{
				Singleton<ActorSystem>.Instance.Put("SceneItemManipulatableCastProjectileState.OnExit2", this.AfterPortalSplineActor, null);
				this.AfterPortalSplineActor = null;
				this.AfterPortalSplineComponent = null;
			}
		}

		// Token: 0x06030285 RID: 197253 RVA: 0x00BAE3B0 File Offset: 0x00BAC5B0
		private void GeneratePredictProjectilePoints()
		{
			FVectorDouble newLocation = this.SceneItem.LastHoldingLocation.ToUeVector(false);
			TArray<FVectorDouble> projectilePath = ModelBase<ManipulaterModel>.Instance.GetProjectilePath();
			TArray<FVectorDouble> afterPortalProjectilePath = ModelBase<ManipulaterModel>.Instance.GetAfterPortalProjectilePath();
			global::Vector vector = global::Vector.Create(projectilePath.Get(projectilePath.Num() - 1));
			vector.SubtractionEqual(global::Vector.Create(projectilePath.Get(projectilePath.Num() - 2)));
			vector.Normalize(9.99999993922529E-09);
			if (afterPortalProjectilePath.Num() <= 0)
			{
				global::Vector vector2 = global::Vector.Create(projectilePath.Get(projectilePath.Num() - 1));
				vector2.AdditionEqual(vector.MultiplyEqual((double)(this.SceneItem.ManipulateBaseConfig.抛物瞄准射线检测半径 * 2f)));
				projectilePath.Add(vector2.ToUeVector(false));
			}
			else
			{
				global::Vector vector3 = global::Vector.Create(afterPortalProjectilePath.Get(afterPortalProjectilePath.Num() - 1));
				vector3.AdditionEqual(vector.MultiplyEqual((double)(this.SceneItem.ManipulateBaseConfig.抛物瞄准射线检测半径 * 2f)));
				afterPortalProjectilePath.Add(vector3.ToUeVector(false));
			}
			this.SplineActor = Singleton<ActorSystem>.Instance.Get(BP_BasePathLine_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
			this.SplineActor.D_K2_SetActorLocation(newLocation, false, ref WorldGlobal.SweepHitResult, true);
			this.SplineComponent = (this.SplineActor.GetComponentByClass(USplineComponent.StaticClass()) as USplineComponent);
			this.SplineComponent.D_SetSplinePoints(projectilePath, ESplineCoordinateSpace.Local, true);
			if (afterPortalProjectilePath.Num() > 0)
			{
				this.AfterPortalSplineActor = Singleton<ActorSystem>.Instance.Get(BP_BasePathLine_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
				FVectorDouble? afterPortalStartPosition = ModelBase<ManipulaterModel>.Instance.GetAfterPortalStartPosition();
				if (afterPortalStartPosition != null)
				{
					this.AfterPortalSplineActor.D_K2_SetActorLocation(afterPortalStartPosition.Value, false, ref WorldGlobal.SweepHitResult, true);
				}
				this.AfterPortalSplineComponent = (this.AfterPortalSplineActor.GetComponentByClass(USplineComponent.StaticClass()) as USplineComponent);
				this.AfterPortalSplineComponent.D_SetSplinePoints(afterPortalProjectilePath, ESplineCoordinateSpace.Local, true);
			}
		}

		// Token: 0x06030286 RID: 197254 RVA: 0x00BAE5BE File Offset: 0x00BAC7BE
		public override bool IsNoLockCasting()
		{
			return true;
		}

		// Token: 0x0401BA4E RID: 113230
		private USplineComponent SplineComponent;

		// Token: 0x0401BA4F RID: 113231
		private AActor SplineActor;

		// Token: 0x0401BA50 RID: 113232
		private USplineComponent AfterPortalSplineComponent;

		// Token: 0x0401BA51 RID: 113233
		private AActor AfterPortalSplineActor;

		// Token: 0x0401BA52 RID: 113234
		private float MoveSpeed;

		// Token: 0x0401BA53 RID: 113235
		private float Distance;

		// Token: 0x0401BA54 RID: 113236
		[Nullable(1)]
		private global::Vector LastLocation = global::Vector.Create();

		// Token: 0x0401BA55 RID: 113237
		[Nullable(1)]
		private global::Vector CurrentDirection = global::Vector.Create();

		// Token: 0x0401BA56 RID: 113238
		private bool IsAfterPortal;
	}
}
