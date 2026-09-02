using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Action
{
	// Token: 0x02006FB3 RID: 28595
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowVehicleMoveWithPathLine : LevelFlowActionBase
	{
		// Token: 0x06045249 RID: 283209 RVA: 0x0120ACD4 File Offset: 0x01208ED4
		public LevelFlowVehicleMoveWithPathLine Init(VehicleMoveWithPathLine params_)
		{
			this.Params = params_;
			return this;
		}

		// Token: 0x0604524A RID: 283210 RVA: 0x0120ACE0 File Offset: 0x01208EE0
		protected override void OnExecute()
		{
			if (this.Params == null)
			{
				base.FinishExecute(false);
				return;
			}
			ETargetVehicle type = this.Params.TargetVehicle.Type;
			if (type == ETargetVehicle.Current)
			{
				this.Entity_ = this.GetVehicleEntityFromPlayerRole();
				this.ChangeControlState();
				return;
			}
			if (type != ETargetVehicle.Appointed)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "不支持的目标类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", this.Params.TargetVehicle.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			IAppointedVehicle appointedVehicle = this.Params.TargetVehicle as IAppointedVehicle;
			base.CreateWaitEntityTask(appointedVehicle.VehicleId);
		}

		// Token: 0x0604524B RID: 283211 RVA: 0x0120AD88 File Offset: 0x01208F88
		protected override void ExecuteWhenEntitiesReady()
		{
			this.GetTargetVehicleEntity(this.Params.TargetVehicle);
			this.ChangeControlState();
		}

		// Token: 0x0604524C RID: 283212 RVA: 0x0120ADA4 File Offset: 0x01208FA4
		private void GetTargetVehicleEntity(ITargetVehicle config)
		{
			ETargetVehicle type = config.Type;
			if (type == ETargetVehicle.Current)
			{
				this.Entity_ = this.GetVehicleEntityFromPlayerRole();
				return;
			}
			if (type != ETargetVehicle.Appointed)
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "不支持的目标类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", config.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById((config as IAppointedVehicle).VehicleId);
			this.Entity_ = ((entityById != null) ? entityById.Entity : null);
		}

		// Token: 0x0604524D RID: 283213 RVA: 0x0120AE28 File Offset: 0x01209028
		[NullableContext(2)]
		private Entity GetVehicleEntityFromPlayerRole()
		{
			if (Global.BaseCharacter == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "获取玩家载具失败，找不到全局玩家角色", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			Entity entity = Global.BaseCharacter.CharacterActorComponent.Entity;
			CharacterDriveVehicleComponent characterDriveVehicleComponent = (entity != null) ? entity.GetComponent<CharacterDriveVehicleComponent>() : null;
			if (characterDriveVehicleComponent == null)
			{
				return null;
			}
			return characterDriveVehicleComponent.VehicleEntity;
		}

		// Token: 0x0604524E RID: 283214 RVA: 0x0120AE80 File Offset: 0x01209080
		private void ChangeControlState()
		{
			if (this.Entity_ == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YJX, "设置载具控制状态失败，无法找到目标实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			EVehicleControlType type = this.Params.ControlType.Type;
			if (type != EVehicleControlType.EnterPathMoving)
			{
				if (type == EVehicleControlType.ExitPathMoving)
				{
					int splineEntityId = this.Params.SplineEntityId;
					VehicleSplineMoveComponent component = this.Entity_.GetComponent<VehicleSplineMoveComponent>();
					if (component != null)
					{
						component.ResetExtraMoveParams();
					}
					if (component != null)
					{
						component.EndSplineMove(splineEntityId);
					}
				}
			}
			else
			{
				IVehicleEnterPathMove vehicleEnterPathMove = this.Params.ControlType as IVehicleEnterPathMove;
				int splineEntityId2 = this.Params.SplineEntityId;
				VehicleSplineMoveComponent component2 = this.Entity_.GetComponent<VehicleSplineMoveComponent>();
				if (component2 != null)
				{
					component2.SetExtraMoveParams(vehicleEnterPathMove.ControlParams);
				}
				if (component2 != null)
				{
					component2.StartSplineMove(splineEntityId2, vehicleEnterPathMove.Pattern, false);
				}
				if (ModelBase<LevelFlowModel>.Instance.IsDebug)
				{
					USplineComponent splineComponent = ModelBase<GameSplineModel>.Instance.LoadAndGetSplineComponent(splineEntityId2, this.Entity_.Id, EIdType.EntityId);
					this.DrawDebugInfo(splineComponent, vehicleEnterPathMove.Pattern.MaxOffsetDistance.GetValueOrDefault());
				}
			}
			base.FinishExecute(true);
		}

		// Token: 0x0604524F RID: 283215 RVA: 0x0120AFA4 File Offset: 0x012091A4
		protected unsafe override void LogExecuteInfo()
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.LevelFlow;
			ELogAuthor author = ELogAuthor.BB;
			string message = "执行行为";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionId", this.ActionId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionName", base.GetType().Name);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ControlType", this.Params.ControlType.Type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("SplineEntityId", this.Params.SplineEntityId);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}

		// Token: 0x06045250 RID: 283216 RVA: 0x0120B070 File Offset: 0x01209270
		private void DrawDebugInfo(USplineComponent splineComponent, float radius)
		{
			float splineLength = splineComponent.GetSplineLength();
			for (float num = 0f; num <= splineLength; num += 100f)
			{
				FVectorDouble? fvectorDouble = (splineComponent != null) ? new FVectorDouble?(splineComponent.D_GetLocationAtDistanceAlongSpline(num, ESplineCoordinateSpace.World)) : null;
				FVectorDouble? fvectorDouble2 = (splineComponent != null) ? new FVectorDouble?(splineComponent.D_GetDirectionAtDistanceAlongSpline(num, ESplineCoordinateSpace.World)) : null;
				FVectorDouble valueOrDefault = fvectorDouble2.GetValueOrDefault();
				valueOrDefault.Normalize(9.99999993922529E-09);
				FVectorDouble? fvectorDouble4;
				FVectorDouble? fvectorDouble3 = fvectorDouble4 = fvectorDouble;
				FVectorDouble? fvectorDouble5 = fvectorDouble2;
				double scale = (double)100;
				FVectorDouble? fvectorDouble6;
				if (fvectorDouble5 == null)
				{
					fvectorDouble6 = null;
				}
				else
				{
					valueOrDefault = fvectorDouble5.GetValueOrDefault();
					fvectorDouble6 = new FVectorDouble?(valueOrDefault * scale);
				}
				FVectorDouble? fvectorDouble7 = fvectorDouble6;
				FVectorDouble? fvectorDouble8;
				if (!(fvectorDouble4 != null & fvectorDouble7 != null))
				{
					fvectorDouble8 = null;
				}
				else
				{
					FVectorDouble valueOrDefault2 = fvectorDouble4.GetValueOrDefault();
					FVectorDouble valueOrDefault3 = fvectorDouble7.GetValueOrDefault();
					fvectorDouble8 = new FVectorDouble?(valueOrDefault2 + valueOrDefault3);
				}
				FVectorDouble? fvectorDouble9 = fvectorDouble8;
				UKismetSystemLibrary.D_DrawDebugCylinder(GlobalData.World, fvectorDouble3.GetValueOrDefault(), fvectorDouble9.GetValueOrDefault(), radius, 16, new FLinearColor?(new FLinearColor(0f, 1f, 0f, 1f)), 60f, 1f);
			}
		}

		// Token: 0x0402693E RID: 158014
		[Nullable(2)]
		private Entity Entity_;

		// Token: 0x0402693F RID: 158015
		[Nullable(2)]
		private VehicleMoveWithPathLine Params;
	}
}
