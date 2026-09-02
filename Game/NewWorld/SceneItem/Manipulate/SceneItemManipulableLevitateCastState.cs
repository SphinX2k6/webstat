using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Camera;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x02004857 RID: 18519
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulableLevitateCastState : SceneItemManipulableCastState, IStaticVariableResetter
	{
		// Token: 0x060302CF RID: 197327 RVA: 0x00BB17D8 File Offset: 0x00BAF9D8
		static SceneItemManipulableLevitateCastState()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(SceneItemManipulableLevitateCastState.CreateStaticDefaultValue), new Action(SceneItemManipulableLevitateCastState.ResetStaticDefaultValue));
		}

		// Token: 0x060302D0 RID: 197328 RVA: 0x00BB17F7 File Offset: 0x00BAF9F7
		public static void CreateStaticDefaultValue()
		{
			SceneItemManipulableLevitateCastState._sphereTrace = null;
		}

		// Token: 0x060302D1 RID: 197329 RVA: 0x00BB17FF File Offset: 0x00BAF9FF
		public static void ResetStaticDefaultValue()
		{
			SceneItemManipulableLevitateCastState._sphereTrace = null;
		}

		// Token: 0x060302D2 RID: 197330 RVA: 0x00BB1808 File Offset: 0x00BAFA08
		public SceneItemManipulableLevitateCastState(SceneItemManipulatableComponent sceneItem, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<UCameraShakeBase> cameraShake, [Nullable(2)] UKuroForceFeedbackEffect gamepadShake) : base(sceneItem, new TSubclassOf<UCameraShakeBase>?(cameraShake), gamepadShake)
		{
			this.LevitateConfig = (IThrowMotionLevitate)this.SceneItem.Config.ThrowCfg.MotionConfig;
			this.Velocity = this.LevitateConfig.Velocity;
			this.VelocityDirection = global::Vector.Create();
			IRenderTrajectoryConfig renderTrajectoryConfig = this.LevitateConfig.RenderTrajectoryConfig;
			float? num = (renderTrajectoryConfig != null) ? new float?(renderTrajectoryConfig.Time) : null;
			this.LifeTime = ((num != null && num.GetValueOrDefault() != 0f) ? Math.Min(num.Value, this.LevitateConfig.MoveTime) : this.LevitateConfig.MoveTime);
			this.TotalDistance = this.Velocity * this.LifeTime;
			this.MaxDistance = this.TotalDistance;
			if (!StringUtils.IsEmpty(this.LevitateConfig.VelocityCurve))
			{
				Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(this.LevitateConfig.VelocityCurve, delegate([Nullable(2)] UCurveFloat result, string _)
				{
					this.VelocityCurve = result;
					List<global::Vector> castPath = this.GetCastPath(true);
					global::Vector v = castPath[0];
					List<global::Vector> list = castPath;
					this.MaxDistance = (float)global::Vector.Dist(v, list[list.Count - 1]);
				}, 100, "js_undefined");
			}
		}

		// Token: 0x060302D3 RID: 197331 RVA: 0x00BB1958 File Offset: 0x00BAFB58
		protected override void OnEnter()
		{
			base.OnEnter();
			this.SimulationTimer = 0f;
			this.PrevLoc.DeepCopy(this.MoveStartLocation);
			this.SceneItem.ActorComp.Owner.OnActorHit.Add(new Action<AActor, AActor, FVector, FHitResult>(this.StopOnHit));
			this.SceneItem.ActorComp.PhysicsMode = SceneItemActorComponent.EPhysicsMode.Kinematic;
			this.SceneItem.ForceMoving = true;
		}

		// Token: 0x060302D4 RID: 197332 RVA: 0x00BB19CA File Offset: 0x00BAFBCA
		protected override void OnExit()
		{
			this.SceneItem.ActorComp.Owner.OnActorHit.Remove(new Action<AActor, AActor, FVector, FHitResult>(this.StopOnHit));
			this.SceneItem.ForceMoving = false;
			this.RequestToLevitate();
		}

		// Token: 0x060302D5 RID: 197333 RVA: 0x00BB1A04 File Offset: 0x00BAFC04
		private void RequestToLevitate()
		{
			BeControlledEntityHoverRequest beControlledEntityHoverRequest = BeControlledEntityHoverRequest.Create();
			beControlledEntityHoverRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.SceneItem.ActorComp.CreatureData.GetCreatureDataId());
			Singleton<Net>.Instance.Call<BeControlledEntityHoverResponse>(ERequestMessageId.BeControlledEntityHoverRequest, beControlledEntityHoverRequest, delegate(BeControlledEntityHoverResponse response, Net.CallbackStatus _)
			{
				ErrorCode? errorCode = (response != null) ? new ErrorCode?(response.ErrorCode) : null;
				if (errorCode == null || errorCode.GetValueOrDefault() != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.BeControlledEntityHoverResponse, null, true, true);
				}
			}, 0);
		}

		// Token: 0x060302D6 RID: 197334 RVA: 0x00BB1A6C File Offset: 0x00BAFC6C
		public void SetVelocityDirection(global::Vector dire)
		{
			this.VelocityDirection.DeepCopy(dire);
		}

		// Token: 0x060302D7 RID: 197335 RVA: 0x00BB1A7A File Offset: 0x00BAFC7A
		protected override void OnTick(float delta)
		{
			this.UpdateLocation(delta);
			this.UpdateRotationAccordingToVelocity();
		}

		// Token: 0x060302D8 RID: 197336 RVA: 0x00BB1A8C File Offset: 0x00BAFC8C
		protected override void UpdateLocation(float delta)
		{
			this.SimulationTimer += delta;
			this.SimulationTimer = Math.Min(this.SimulationTimer, this.LifeTime);
			global::Vector location = this.GetLocation(this.PrevLoc, delta);
			if (this.SceneItem.CurrentState != this)
			{
				return;
			}
			this.SceneItem.ActorComp.SetActorLocation(location.ToUeVector(false), "[SceneItemManipulableLevitateCastState.UpdateLocation]", true);
			this.PrevLoc = location;
			if (location.Equals(this.MoveEndLocation, 9.999999747378752E-05) && this.SceneItem.CurrentState == this)
			{
				SceneItemManipulatableComponent sceneItem = this.SceneItem;
				if (sceneItem != null)
				{
					sceneItem.SetState(SceneItemManipulatableComponent.EManipulatableState.Reset, "LevitateCastState Finish");
				}
			}
			if (this.SimulationTimer >= this.LifeTime && this.SceneItem.CurrentState == this)
			{
				SceneItemManipulatableComponent sceneItem2 = this.SceneItem;
				if (sceneItem2 == null)
				{
					return;
				}
				sceneItem2.SetState(SceneItemManipulatableComponent.EManipulatableState.Reset, "LevitateCastState OverTime");
			}
		}

		// Token: 0x060302D9 RID: 197337 RVA: 0x00BB1B70 File Offset: 0x00BAFD70
		private global::Vector GetLocation(global::Vector startLoc, float timeStep)
		{
			global::Vector vector = global::Vector.Create();
			this.MoveDirection.Multiply((double)(this.Velocity * timeStep), vector);
			UCurveFloat velocityCurve = this.VelocityCurve;
			if (velocityCurve != null && velocityCurve.IsValid())
			{
				vector.MultiplyEqual((double)this.VelocityCurve.GetFloatValue(this.SimulationTimer));
			}
			vector.Set((double)(MathF.Floor((float)vector.X * 100f) / 100f), (double)(MathF.Floor((float)vector.Y * 100f) / 100f), (double)(MathF.Floor((float)vector.Z * 100f) / 100f));
			startLoc.Addition(vector, vector);
			if (global::Vector.Distance(vector, this.MoveStartLocation) > (double)this.TotalDistance)
			{
				vector = this.MoveEndLocation;
			}
			return vector;
		}

		// Token: 0x060302DA RID: 197338 RVA: 0x00BB1C40 File Offset: 0x00BAFE40
		public List<global::Vector> GetCastPath(bool ignoreTrace = false)
		{
			if (!ignoreTrace)
			{
				this.GetTraceResult();
			}
			else
			{
				ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Vector(this.MoveDirection);
				global::Vector moveStartLocation = this.MoveStartLocation;
				FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
				moveStartLocation.DeepCopy(actorLocation);
			}
			List<global::Vector> list = new List<global::Vector>();
			global::Vector vector = global::Vector.Create(this.MoveStartLocation);
			list.Add(vector);
			float lifeTime = this.LifeTime;
			this.SimulationTimer = 0f;
			for (float num = 0f; num < lifeTime; num += this.TimeStepLimit)
			{
				this.SimulationTimer += this.TimeStepLimit;
				global::Vector location = this.GetLocation(vector, this.TimeStepLimit);
				vector = location;
				list.Add(location);
				if (location.Equals(this.MoveEndLocation, 9.999999747378752E-05))
				{
					break;
				}
			}
			return list;
		}

		// Token: 0x060302DB RID: 197339 RVA: 0x00BB1D1C File Offset: 0x00BAFF1C
		private void InitTraceInfo()
		{
			SceneItemManipulableLevitateCastState._sphereTrace = new UTraceSphereElement();
			SceneItemManipulableLevitateCastState._sphereTrace.WorldContextObject = this.SceneItem.ActorComp.Owner;
			SceneItemManipulableLevitateCastState._sphereTrace.bIsSingle = true;
			SceneItemManipulableLevitateCastState._sphereTrace.bIgnoreSelf = true;
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			tarray.Add(KuroObjectTypeQuery.WorldStatic);
			tarray.Add(KuroObjectTypeQuery.Pawn);
			tarray.Add(KuroObjectTypeQuery.PawnMonster);
			tarray.Add(KuroObjectTypeQuery.Destructible);
			SceneItemManipulableLevitateCastState._sphereTrace.SetObjectTypesQuery(ref tarray);
			SceneItemManipulatableComponent sceneItem = this.SceneItem;
			object obj;
			if (sceneItem == null)
			{
				obj = null;
			}
			else
			{
				TeleControl2 config = sceneItem.Config;
				obj = ((config != null) ? config.ThrowCfg.MotionConfig : null);
			}
			IThrowMotionLevitate throwMotionLevitate = obj as IThrowMotionLevitate;
			UTraceSphereElement sphereTrace = SceneItemManipulableLevitateCastState._sphereTrace;
			float? num = (throwMotionLevitate != null) ? throwMotionLevitate.RayRadius : null;
			sphereTrace.Radius = ((num != null && num.GetValueOrDefault() != 0f) ? throwMotionLevitate.RayRadius.Value : 50f);
			SceneItemManipulableLevitateCastState._sphereTrace.DrawTime = 5f;
		}

		// Token: 0x060302DC RID: 197340 RVA: 0x00BB1E38 File Offset: 0x00BB0038
		private void GetTraceResult()
		{
			global::Vector moveStartLocation = this.MoveStartLocation;
			FVectorDouble actorLocation = this.SceneItem.ActorComp.ActorLocation;
			moveStartLocation.DeepCopy(actorLocation);
			global::Vector vector = global::Vector.Create(0.0, 0.0, 0.0);
			ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Vector(vector);
			if (SceneItemManipulableLevitateCastState._sphereTrace == null)
			{
				this.InitTraceInfo();
			}
			global::Vector vector2 = global::Vector.Create(ControllerBase<CameraController>.Instance.MainModel.CameraLocation);
			global::Vector vector3 = global::Vector.Create(vector2);
			vector3.AdditionEqual(vector.MultiplyEqual((double)this.MaxDistance));
			Singleton<TraceElementCommon>.Instance.SetStartLocation(SceneItemManipulableLevitateCastState._sphereTrace, vector2);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(SceneItemManipulableLevitateCastState._sphereTrace, vector3);
			bool flag = Singleton<TraceElementCommon>.Instance.SphereTrace(SceneItemManipulableLevitateCastState._sphereTrace, "[SceneItemManipulableLevitateCastState.GetTraceResult]");
			this.MoveEndLocation.DeepCopy(vector3);
			if (flag && SceneItemManipulableLevitateCastState._sphereTrace.HitResult.bBlockingHit)
			{
				Singleton<TraceElementCommon>.Instance.GetHitLocation(SceneItemManipulableLevitateCastState._sphereTrace.HitResult, 0, this.MoveEndLocation);
			}
			this.TotalDistance = (float)global::Vector.Dist(this.MoveStartLocation, this.MoveEndLocation);
			this.MoveDirection.DeepCopy(this.MoveEndLocation);
			this.MoveDirection.SubtractionEqual(this.MoveStartLocation);
			this.MoveDirection.Normalize(9.99999993922529E-09);
		}

		// Token: 0x060302DD RID: 197341 RVA: 0x00BB1F94 File Offset: 0x00BB0194
		[NullableContext(2)]
		private void StopOnHit(AActor selfActor, AActor otherActor, FVector vector, [Nullable(1)] FHitResult hitResult)
		{
			SceneItemManipulatableComponent sceneItem = this.SceneItem;
			if (sceneItem == null)
			{
				return;
			}
			sceneItem.SetState(SceneItemManipulatableComponent.EManipulatableState.Reset, "LevitateCastState OnHit");
		}

		// Token: 0x060302DE RID: 197342 RVA: 0x00BB1FAC File Offset: 0x00BB01AC
		public override bool IsNoLockCasting()
		{
			return true;
		}

		// Token: 0x0401BA90 RID: 113296
		private const float SPHERE_TRACE_RADIUS = 50f;

		// Token: 0x0401BA91 RID: 113297
		private const string PROFILE_KEY = "[SceneItemManipulableLevitateCastState.GetTraceResult]";

		// Token: 0x0401BA92 RID: 113298
		[Nullable(2)]
		private readonly IThrowMotionLevitate LevitateConfig;

		// Token: 0x0401BA93 RID: 113299
		[Nullable(2)]
		private static UTraceSphereElement _sphereTrace;

		// Token: 0x0401BA94 RID: 113300
		private readonly float Velocity;

		// Token: 0x0401BA95 RID: 113301
		[Nullable(2)]
		private readonly global::Vector VelocityDirection;

		// Token: 0x0401BA96 RID: 113302
		[Nullable(2)]
		private UCurveFloat VelocityCurve;

		// Token: 0x0401BA97 RID: 113303
		private readonly float LifeTime;

		// Token: 0x0401BA98 RID: 113304
		private readonly float TimeStepLimit = 0.033f;

		// Token: 0x0401BA99 RID: 113305
		private float SimulationTimer;

		// Token: 0x0401BA9A RID: 113306
		private global::Vector PrevLoc = global::Vector.Create();

		// Token: 0x0401BA9B RID: 113307
		private float MaxDistance;

		// Token: 0x0401BA9C RID: 113308
		private float TotalDistance;

		// Token: 0x0401BA9D RID: 113309
		private readonly global::Vector MoveStartLocation = global::Vector.Create();

		// Token: 0x0401BA9E RID: 113310
		private readonly global::Vector MoveEndLocation = global::Vector.Create();

		// Token: 0x0401BA9F RID: 113311
		private readonly global::Vector MoveDirection = global::Vector.Create();
	}
}
