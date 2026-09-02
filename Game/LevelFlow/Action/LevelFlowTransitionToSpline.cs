using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB0 RID: 28592
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowTransitionToSpline : LevelFlowActionBase
	{
		// Token: 0x0604523C RID: 283196 RVA: 0x0120A634 File Offset: 0x01208834
		public LevelFlowTransitionToSpline Init(LevelFlowTransitionToSplineParam param)
		{
			this.Param = param;
			return this;
		}

		// Token: 0x0604523D RID: 283197 RVA: 0x0120A640 File Offset: 0x01208840
		protected override void OnExecute()
		{
			if (this.Param == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "[LevelFlowTransitionToSpline]Param is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(this.Param.EntityId);
			if (entityById == null || !entityById.IsInit || entityById.Entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "[MoveWithSpline]实体无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("PbDataId", this.Param.EntityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.FinishExecute(false);
				return;
			}
			WorldEntity entity = entityById.Entity;
			if (entity.GetComponent<VehicleMoveComponent>() == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelFlow;
				ELogAuthor author2 = ELogAuthor.BB;
				string message2 = "[MoveWithSpline]实体没有MoveComp";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PbDataId", entity.Id);
				instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false);
				return;
			}
			Transform transform = Transform.Create(ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(this.Param.SplineId, entity.Id, EIdType.EntityId).D_GetTransformAtDistanceAlongSpline(0f, ESplineCoordinateSpace.World, false));
			if (this.Param.SnapToWall)
			{
				this.SnapSplineTransformToWall(transform);
			}
			VehiclePathMoveTask vehiclePathMoveTask = ControllerBase<VehiclePathMoveController>.Instance.CreateMotorcycleMoveToTask(entity, transform, (double)this.Param.Speed);
			if (vehiclePathMoveTask == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "CreateMotorcycleMoveToTask failed", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			vehiclePathMoveTask.CurveInfo.SplineId = -this.Param.SplineId;
			vehiclePathMoveTask.NeedSync = false;
			vehiclePathMoveTask.SimulateRotation = this.Param.SimulateRotation;
			vehiclePathMoveTask.KeepForward = this.Param.KeepForward;
			vehiclePathMoveTask.OnMoveEndHandle = new Action<bool>(base.FinishExecute);
			ControllerBase<VehiclePathMoveController>.Instance.AddSplineMoveTask(vehiclePathMoveTask);
		}

		// Token: 0x0604523E RID: 283198 RVA: 0x0120A820 File Offset: 0x01208A20
		private void SnapSplineTransformToWall(Transform outTransform)
		{
			UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
			utraceSphereElement.bIsSingle = true;
			utraceSphereElement.bIgnoreSelf = true;
			utraceSphereElement.WorldContextObject = GlobalData.World;
			utraceSphereElement.Radius = 30f;
			utraceSphereElement.bTraceComplex = false;
			utraceSphereElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			utraceSphereElement.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStaticIgnoreBullet);
			float traceStartOffset = this.TraceStartOffset;
			float traceLength = this.TraceLength;
			Vector vector = Vector.Create();
			outTransform.GetRotation().RotateVector(Vector.UpVectorProxy, vector);
			Vector vector2 = Vector.Create();
			vector.GetSafeNormal(vector2, 9.99999993922529E-09);
			vector2.MultiplyEqual((double)traceStartOffset);
			vector2.AdditionEqual(outTransform.GetLocation());
			Vector vector3 = Vector.Create();
			vector.GetSafeNormal(vector3, 9.99999993922529E-09);
			vector3.MultiplyEqual((double)(-(double)traceLength));
			vector3.AdditionEqual(outTransform.GetLocation());
			Singleton<TraceElementCommon>.Instance.SetStartLocation(utraceSphereElement, vector2);
			Singleton<TraceElementCommon>.Instance.SetEndLocation(utraceSphereElement, vector3);
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(utraceSphereElement, "BuildWallSpline") && utraceSphereElement.HitResult != null)
			{
				Vector vector4 = Vector.Create();
				Singleton<TraceElementCommon>.Instance.GetImpactPoint(utraceSphereElement.HitResult, 0, vector4);
				Vector vector5 = Vector.Create();
				Singleton<TraceElementCommon>.Instance.GetImpactNormal(utraceSphereElement.HitResult, 0, vector5);
				vector5.Multiply((double)this.MotorcycleOffset, vector5);
				vector4.AdditionEqual(vector5);
				outTransform.SetLocation(vector4);
			}
		}

		// Token: 0x04026936 RID: 158006
		[Nullable(2)]
		private LevelFlowTransitionToSplineParam Param;

		// Token: 0x04026937 RID: 158007
		public float TraceLength = 1000f;

		// Token: 0x04026938 RID: 158008
		public float TraceStartOffset = 500f;

		// Token: 0x04026939 RID: 158009
		private readonly float MotorcycleOffset;
	}
}
