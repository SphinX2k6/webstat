using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200485C RID: 18524
	[NullableContext(2)]
	[Nullable(0)]
	public class SceneItemManipulableTrackTargetCastToFreeState : SceneItemManipulableCastState, IStaticVariableResetter
	{
		// Token: 0x060302F2 RID: 197362 RVA: 0x00BB2611 File Offset: 0x00BB0811
		[NullableContext(1)]
		public SceneItemManipulableTrackTargetCastToFreeState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase>? cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, cameraShake, gamepadShake)
		{
		}

		// Token: 0x060302F3 RID: 197363 RVA: 0x00BB261C File Offset: 0x00BB081C
		static SceneItemManipulableTrackTargetCastToFreeState()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SceneItemManipulableTrackTargetCastToFreeState.CreateStaticDefaultValue), new Action(SceneItemManipulableTrackTargetCastToFreeState.ResetStaticDefaultValue));
		}

		// Token: 0x060302F4 RID: 197364 RVA: 0x00BB263B File Offset: 0x00BB083B
		public static void CreateStaticDefaultValue()
		{
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace = null;
		}

		// Token: 0x060302F5 RID: 197365 RVA: 0x00BB2643 File Offset: 0x00BB0843
		public static void ResetStaticDefaultValue()
		{
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace = null;
		}

		// Token: 0x060302F6 RID: 197366 RVA: 0x00BB264B File Offset: 0x00BB084B
		[NullableContext(1)]
		public void SetStartCameraLocation(global::Vector inStartCameraLocation)
		{
			this.StartCameraLocation = inStartCameraLocation;
		}

		// Token: 0x060302F7 RID: 197367 RVA: 0x00BB2654 File Offset: 0x00BB0854
		protected override void OnEnter()
		{
			base.OnEnter();
			if (this.StartCameraLocation == null)
			{
				return;
			}
			this.IsPastEnd = false;
			this.MoveStartLocation = global::Vector.Create(this.SceneItem.ActorComp.ActorLocationProxy);
			IThrowMotionTrackTarget throwMotionTrackTarget = this.SceneItem.Config.ThrowCfg.MotionConfig as IThrowMotionTrackTarget;
			this.MoveSpeed = throwMotionTrackTarget.Velocity;
			this.TotalDistance = new float?(5000f);
			global::Vector vector = global::Vector.Create(0.0, 0.0, 0.0);
			ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Vector(vector);
			if (SceneItemManipulableTrackTargetCastToFreeState._sphereTrace == null)
			{
				this.InitTraceInfo();
			}
			global::Vector vector2 = global::Vector.Create(this.StartCameraLocation);
			vector2.AdditionEqual(vector.MultiplyEqual(5000.0));
			Singleton<TraceElementCommon>.Instance.SetStartLocation(SceneItemManipulableTrackTargetCastToFreeState._sphereTrace, this.StartCameraLocation);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(SceneItemManipulableTrackTargetCastToFreeState._sphereTrace, vector2);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(SceneItemManipulableTrackTargetCastToFreeState._sphereTrace, "[SceneItemManipulableTrackTargetCastToFreeState.OnEnter]");
			this.MoveEndLocation = global::Vector.Create(vector2);
			if (flag && SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.HitResult.bBlockingHit)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.HitResult, 0, this.MoveEndLocation);
				this.TotalDistance = new float?((float)global::Vector.Dist(this.MoveStartLocation, this.MoveEndLocation));
			}
			this.MoveDirection = global::Vector.Create(this.MoveEndLocation);
			this.MoveDirection.SubtractionEqual(this.MoveStartLocation);
			this.MoveDirection.Normalize(9.99999993922529E-09);
			if (this.NeedNotifyServer)
			{
				ControllerBase<LevelGamePlayController>.Instance.ManipulatableBeCastOrDrop2Server(this.SceneItem.Entity.Id, EControlState.FreeThrowing);
			}
			if (this.EnterCallback != null)
			{
				this.EnterCallback();
			}
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
		}

		// Token: 0x060302F8 RID: 197368 RVA: 0x00BB2840 File Offset: 0x00BB0A40
		private void InitTraceInfo()
		{
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace = new UTraceSphereElement();
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.WorldContextObject = this.SceneItem.ActorComp.Owner;
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.bIsSingle = true;
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.bIgnoreSelf = true;
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			tarray.Add(KuroObjectTypeQuery.WorldStatic);
			tarray.Add(KuroObjectTypeQuery.Pawn);
			tarray.Add(KuroObjectTypeQuery.PawnMonster);
			tarray.Add(KuroObjectTypeQuery.Destructible);
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.SetObjectTypesQuery(ref tarray);
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.Radius = 1f;
			SceneItemManipulableTrackTargetCastToFreeState._sphereTrace.DrawTime = 5f;
		}

		// Token: 0x060302F9 RID: 197369 RVA: 0x00BB28F7 File Offset: 0x00BB0AF7
		protected override void OnExit()
		{
			base.OnExit();
			this.StartCameraLocation = null;
		}

		// Token: 0x060302FA RID: 197370 RVA: 0x00BB2908 File Offset: 0x00BB0B08
		protected override void OnTick(float delta)
		{
			global::Vector vector = global::Vector.Create(global::Vector.Create(this.SceneItem.ActorComp.ActorLocationProxy));
			global::Vector vector2 = global::Vector.Create(this.MoveDirection);
			vector.AdditionEqual(vector2.MultiplyEqual((double)(this.MoveSpeed * delta)));
			if (!this.IsPastEnd)
			{
				this.SceneItem.ActorComp.SetActorLocation(vector.ToUeVector(false), "[SceneItemManipulableTrackTargetCastToFreeState.UpdateLocation]", true);
			}
			this.TotalDistance -= this.MoveSpeed * delta;
			if (!this.IsPastEnd)
			{
				float? totalDistance = this.TotalDistance;
				float num = 0f;
				if (totalDistance.GetValueOrDefault() <= num & totalDistance != null)
				{
					SceneItemManipulatableComponent sceneItem = this.SceneItem;
					if (((sceneItem != null) ? sceneItem.CurrentState : null) != this)
					{
						return;
					}
					this.IsPastEnd = true;
					this.SceneItem.TryEnableTick(false);
					this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.DynamicWaitSleep;
					vector2 = global::Vector.Create(this.MoveDirection);
					this.SceneItem.ActorComp.GetPrimitiveComponent().SetPhysicsLinearVelocity(vector2.MultiplyEqual((double)this.MoveSpeed).ToUeVectorOld(), false, default(FName));
				}
			}
			if (this.SceneItem.ManipulateBaseConfig.随速度调整朝向 && !this.AfterHit)
			{
				FVectorDouble fvectorDouble = global::Vector.Create(this.MoveDirection.ToUeVector(false)).ToUeVector(false);
				FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
				FVectorDouble actorLocation2 = this.SceneItem.ActorComp.ActorLocation;
				FVectorDouble fvectorDouble2 = actorLocation2 + fvectorDouble;
				FRotator value = UKismetMathLibrary.D_FindLookAtRotation(actorLocation, fvectorDouble2);
				this.SceneItem.ActorComp.SetActorRotation(value, "[ManipulableCastState.UpdateRotationAccordingToVelocity]", false);
			}
		}

		// Token: 0x060302FB RID: 197371 RVA: 0x00BB2AE3 File Offset: 0x00BB0CE3
		public override bool IsNoLockCasting()
		{
			return true;
		}

		// Token: 0x0401BAA5 RID: 113317
		[Nullable(1)]
		private const string PROFILE_KEY = "[SceneItemManipulableTrackTargetCastToFreeState.OnEnter]";

		// Token: 0x0401BAA6 RID: 113318
		private const float MAX_DISTANCE = 5000f;

		// Token: 0x0401BAA7 RID: 113319
		private const float SPHERE_TRACE_RADIUS = 1f;

		// Token: 0x0401BAA8 RID: 113320
		private static UTraceSphereElement _sphereTrace;

		// Token: 0x0401BAA9 RID: 113321
		private global::Vector StartCameraLocation;

		// Token: 0x0401BAAA RID: 113322
		private global::Vector MoveStartLocation;

		// Token: 0x0401BAAB RID: 113323
		private global::Vector MoveEndLocation;

		// Token: 0x0401BAAC RID: 113324
		private global::Vector MoveDirection;

		// Token: 0x0401BAAD RID: 113325
		private float? TotalDistance;

		// Token: 0x0401BAAE RID: 113326
		private bool IsPastEnd;

		// Token: 0x0401BAAF RID: 113327
		private float MoveSpeed;
	}
}
