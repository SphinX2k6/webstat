using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common;
using CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006F9A RID: 28570
	[NullableContext(2)]
	[Nullable(0)]
	public class LevelFlowMotorRailTransitionAction : LevelFlowActionBase
	{
		// Token: 0x060451D3 RID: 283091 RVA: 0x012077FD File Offset: 0x012059FD
		[NullableContext(1)]
		public LevelFlowMotorRailTransitionAction Init(int entityId, int splineEntityId)
		{
			this.EntityId = entityId;
			this.SplineEntityId = splineEntityId;
			return this;
		}

		// Token: 0x060451D4 RID: 283092 RVA: 0x01207810 File Offset: 0x01205A10
		protected override void OnExecute()
		{
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.EntityId);
			if (entityById == null || !entityById.IsInit || entityById.Entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "[MoveWithSpline]实体无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("EntityId", this.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			WorldEntity entity = entityById.Entity;
			this.ActorComp = entity.GetComponent<VehicleActorComponent>();
			if (this.ActorComp == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "[MoveWithSpline]实体没有ActorComp";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId", entity.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			if (entity.GetComponent<VehicleMoveComponent>() == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelFlow;
				ELogAuthor author3 = ELogAuthor.BB;
				string message3 = "[MoveWithSpline]实体没有MoveComp";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("EntityId", entity.Id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				base.FinishExecute(false);
				return;
			}
			USplineComponent usplineComponent = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(this.SplineEntityId, entity.Id, EIdType.EntityId);
			SplineCurve splineCurve = new SplineCurve(10);
			splineCurve.Init(usplineComponent.SplineCurves.Position, usplineComponent.SplineCurves.ReparamTable.Points, usplineComponent.SplineCurves.Rotation, usplineComponent.SplineCurves.Scale);
			splineCurve.SetSplineTransform(Transform.Create(usplineComponent.D_GetSocketTransform(null, ERelativeTransformSpace.RTS_World)), true);
			MotorcycleRailMoveConfig other = new MotorcycleRailMoveConfig();
			MotorcycleJumpToRailMoveData motorcycleJumpToRailMoveData = new MotorcycleJumpToRailMoveData(entity, null);
			motorcycleJumpToRailMoveData.MoveConfig.DeepCopy(other);
			motorcycleJumpToRailMoveData.TargetSpline = splineCurve;
			motorcycleJumpToRailMoveData.GravityDir.DeepCopy(Singleton<GravityUtils>.Instance.GetGravityDirectForActor(this.ActorComp));
			motorcycleJumpToRailMoveData.MoveUpdater = new TRailMoveUpdater(this.VehicleRailMoveUpdater);
			motorcycleJumpToRailMoveData.MoveGetter = new TRailMoveGetter(this.VehicleRailMoveGetter);
			this.MoveData = motorcycleJumpToRailMoveData;
			motorcycleJumpToRailMoveData.Enter(null);
		}

		// Token: 0x060451D5 RID: 283093 RVA: 0x01207A0C File Offset: 0x01205C0C
		protected override void OnTick(float deltaTime)
		{
			if (this.MoveData == null)
			{
				base.FinishExecute(false);
				return;
			}
			if (this.MoveData.IsFinishMove)
			{
				base.FinishExecute(true);
				return;
			}
			MotorcycleJumpToRailMoveData moveData = this.MoveData;
			if (moveData == null)
			{
				return;
			}
			moveData.Tick(deltaTime);
		}

		// Token: 0x060451D6 RID: 283094 RVA: 0x01207A44 File Offset: 0x01205C44
		private void VehicleRailMoveUpdater(Vector loc, Rotator rot, Vector velocity, bool bSweep = true)
		{
			if (this.ActorComp == null)
			{
				return;
			}
			if (loc != null && rot != null)
			{
				this.ActorComp.SetActorLocationAndRotation(loc.ToUeVector(false), rot.ToUeRotator(), "LevelFlowMotorRailTransitionAction", false, null);
			}
			else if (loc != null)
			{
				this.ActorComp.SetActorLocation(loc.ToUeVector(false), "LevelFlowMotorRailTransitionAction", false);
			}
			else if (rot != null)
			{
				this.ActorComp.SetActorRotation(rot.ToUeRotator(), "LevelFlowMotorRailTransitionAction", false);
			}
			if (velocity != null)
			{
				VehicleMoveComponent vehicleMoveComp = this.ActorComp.VehicleMoveComp;
				UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (vehicleMoveComp != null) ? vehicleMoveComp.VehicleMovement : null;
				if (vehicleMoveComp != null)
				{
					vehicleMoveComp.SetForceSpeed(velocity);
				}
				UMotorWheelDisplayInfoObject umotorWheelDisplayInfoObject = (ukuroVehicleMovementComponent != null) ? ukuroVehicleMovementComponent.WheelDisplayInfosObj : null;
				if (umotorWheelDisplayInfoObject != null && umotorWheelDisplayInfoObject.DisplayInfos.Num() >= 2)
				{
					float wheelSpeed = (float)velocity.Size();
					umotorWheelDisplayInfoObject.DisplayInfos.Get(0).WheelSpeed = wheelSpeed;
					umotorWheelDisplayInfoObject.DisplayInfos.Get(1).WheelSpeed = wheelSpeed;
					umotorWheelDisplayInfoObject.DisplayInfos.Get(0).WheelAccel = 0f;
					umotorWheelDisplayInfoObject.DisplayInfos.Get(1).WheelAccel = 0f;
				}
				this.ActorComp.ResetCachedVelocityTime();
			}
		}

		// Token: 0x060451D7 RID: 283095 RVA: 0x01207B70 File Offset: 0x01205D70
		private bool VehicleRailMoveGetter(Vector outLoc, Rotator outRot, Vector outVelocity)
		{
			if (this.ActorComp == null)
			{
				return false;
			}
			if (outLoc != null)
			{
				outLoc.DeepCopy(this.ActorComp.ActorLocationProxy);
			}
			if (outRot != null)
			{
				outRot.DeepCopy(this.ActorComp.ActorRotationProxy);
			}
			if (outVelocity == null)
			{
				return true;
			}
			MotorcycleJumpToRailMoveData moveData = this.MoveData;
			if (moveData != null && moveData.GetVelocity(outVelocity))
			{
				return true;
			}
			TsBaseVehicle actor = this.ActorComp.Actor;
			UKuroVehicleMovementComponent ukuroVehicleMovementComponent = (actor != null) ? actor.VehicleMovementComponent : null;
			if (ukuroVehicleMovementComponent != null && ukuroVehicleMovementComponent.IsValid())
			{
				FVector velocity = ukuroVehicleMovementComponent.Velocity;
				outVelocity.FromUeVector(velocity);
				return true;
			}
			AActor owner = this.ActorComp.Owner;
			FVectorDouble? fvectorDouble = (owner != null) ? new FVectorDouble?(owner.D_GetVelocity()) : null;
			if (fvectorDouble != null)
			{
				FVectorDouble value = fvectorDouble.Value;
				outVelocity.FromUeVector(value);
				return true;
			}
			return false;
		}

		// Token: 0x060451D8 RID: 283096 RVA: 0x01207C44 File Offset: 0x01205E44
		protected unsafe override void LogExecuteInfo()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("EntityId", this.EntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SplineEntityId", this.SplineEntityId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x040268FE RID: 157950
		private int EntityId;

		// Token: 0x040268FF RID: 157951
		private int SplineEntityId;

		// Token: 0x04026900 RID: 157952
		private VehicleActorComponent ActorComp;

		// Token: 0x04026901 RID: 157953
		private MotorcycleJumpToRailMoveData MoveData;
	}
}
