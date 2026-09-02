using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046EA RID: 18154
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class SyncSplineMoveController : ControllerBase<SyncSplineMoveController>
	{
		// Token: 0x0602F38F RID: 193423 RVA: 0x00B31528 File Offset: 0x00B2F728
		protected override bool OnInit()
		{
			Singleton<Net>.Instance.Register<MoveSplineStatusNotify>(ENotifyMessageId.MoveSplineStatusNotify, new Action<MoveSplineStatusNotify, Net.CallbackStatus>(this.OnMoveSplineStatusNotify));
			return true;
		}

		// Token: 0x0602F390 RID: 193424 RVA: 0x00B31547 File Offset: 0x00B2F747
		protected override bool OnClear()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.MoveSplineStatusNotify);
			return true;
		}

		// Token: 0x0602F391 RID: 193425 RVA: 0x00B3155C File Offset: 0x00B2F75C
		[NullableContext(2)]
		private unsafe void OnMoveSplineStatusNotify(MoveSplineStatusNotify data, Net.CallbackStatus _)
		{
			if (data == null)
			{
				return;
			}
			long creatureId = Singleton<MathUtils>.Instance.LongToNumber(data.EntityId);
			WaitEntityTask.Create("MoveSplineStatusNotify", creatureId, delegate(bool? waitResult)
			{
				if (!waitResult.GetValueOrDefault())
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Movement;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[MoveSplineStatusNotify] 实体等待出错";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureId", creatureId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineId", data.SplineEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Status", this.SplineMoveStatusLogString[data.MoveStatus]);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					return;
				}
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureId);
				if (entity == null || !entity.Valid)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Movement;
					ELogAuthor author2 = ELogAuthor.ZYL;
					string message2 = "[MoveSplineStatusNotify] 无法获取对应实体";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("CreatureId", creatureId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SplineId", data.SplineEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Status", this.SplineMoveStatusLogString[data.MoveStatus]);
					instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
					return;
				}
				if (entity == null || !entity.IsInit)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Movement;
					ELogAuthor author3 = ELogAuthor.ZYL;
					string message3 = "[MoveSplineStatusNotify] 实体未初始化";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("CreatureId", creatureId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SplineId", data.SplineEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("Status", this.SplineMoveStatusLogString[data.MoveStatus]);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
					return;
				}
				this.RecvSyncSplineMoveStatus(entity.Entity, data);
			}, 60000, true, true);
		}

		// Token: 0x0602F392 RID: 193426 RVA: 0x00B315C8 File Offset: 0x00B2F7C8
		private void RecvSyncSplineMoveStatus(Entity entity, MoveSplineStatusNotify data)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			EEntityType? eentityType = (component != null) ? new EEntityType?(component.GetEntityType()) : null;
			if (eentityType != null)
			{
				EEntityType valueOrDefault = eentityType.GetValueOrDefault();
				if (valueOrDefault != EEntityType.SceneItem)
				{
					if (valueOrDefault == EEntityType.Vehicle)
					{
						this.RecvSyncVehicleSplineMoveStatus(entity, data);
						return;
					}
				}
				else
				{
					this.RecvSyncSceneItemSplineMoveStatus(entity, data);
				}
			}
		}

		// Token: 0x0602F393 RID: 193427 RVA: 0x00B31620 File Offset: 0x00B2F820
		private void RecvSyncSceneItemSplineMoveStatus(Entity entity, MoveSplineStatusNotify data)
		{
			SceneItemMoveComponent component = entity.GetComponent<SceneItemMoveComponent>();
			if (component == null || !component.Valid)
			{
				return;
			}
			switch (data.MoveStatus)
			{
			case MoveStatus.Stop:
				component.OnRecvSyncSplineStop(data.SplineEntityId, data.MoveSplineConfig, data.SceneItemRuntimeData);
				return;
			case MoveStatus.Moving:
				component.OnRecvSyncSplineMoving(data.SplineEntityId, data.MoveSplineConfig, data.SceneItemRuntimeData);
				return;
			case MoveStatus.Interrupt:
				component.OnRecvSyncSplineInterrupt(data.SplineEntityId, data.MoveSplineConfig, data.SceneItemRuntimeData);
				return;
			case MoveStatus.Switch:
				component.OnRecvSyncSplineSwitch(data.SplineEntityId, data.MoveSplineConfig, data.SceneItemRuntimeData);
				return;
			default:
				return;
			}
		}

		// Token: 0x0602F394 RID: 193428 RVA: 0x00B316C8 File Offset: 0x00B2F8C8
		public unsafe void SendSyncSceneItemSplineMoveRunning(long creatureDataId, int splineId, float? curDistanceAlongSpline, IVector curPos, [Nullable(2)] IRotator curRot)
		{
			SceneItemMoveSplineRequest sceneItemMoveSplineRequest = SceneItemMoveSplineRequest.Create();
			sceneItemMoveSplineRequest.EntityId = creatureDataId;
			sceneItemMoveSplineRequest.SplineEntityId = splineId;
			sceneItemMoveSplineRequest.MoveStatus = MoveStatus.Moving;
			sceneItemMoveSplineRequest.RuntimeData = SceneItemSplineRuntimeData.Create();
			sceneItemMoveSplineRequest.RuntimeData.DistanceAlongPath = curDistanceAlongSpline.GetValueOrDefault(-1f);
			sceneItemMoveSplineRequest.RuntimeData.CurPos = Aki.Protocol.Vector.Create();
			sceneItemMoveSplineRequest.RuntimeData.CurPos.X = (float)curPos.X;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Y = (float)curPos.Y;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Z = (float)curPos.Z;
			if (curRot != null)
			{
				sceneItemMoveSplineRequest.RuntimeData.CurRot = Aki.Protocol.Rotator.Create();
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Roll = curRot.Roll;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Pitch = curRot.Pitch;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Yaw = curRot.Yaw;
			}
			Singleton<Net>.Instance.Call<SceneItemMoveSplineResponse>(ERequestMessageId.SceneItemMoveSplineRequest, sceneItemMoveSplineRequest, delegate(SceneItemMoveSplineResponse resp, Net.CallbackStatus _)
			{
				if (resp == null || resp.ErrorCode != ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SyncSplineMoveController.SendSyncSceneItemSplineMoveRunning] 发送同步场景物件样条移动运行中信息: 失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineId", splineId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ErrorCode", (resp != null) ? new ErrorCode?(resp.ErrorCode) : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}, 0);
		}

		// Token: 0x0602F395 RID: 193429 RVA: 0x00B31800 File Offset: 0x00B2FA00
		public unsafe void SendSyncSceneItemSplineMoveEnd(long creatureDataId, int splineId, float? curDistanceAlongSpline, IVector curPos, [Nullable(2)] IRotator curRot, bool isInterrupt)
		{
			SceneItemMoveSplineRequest sceneItemMoveSplineRequest = SceneItemMoveSplineRequest.Create();
			sceneItemMoveSplineRequest.EntityId = creatureDataId;
			sceneItemMoveSplineRequest.SplineEntityId = splineId;
			sceneItemMoveSplineRequest.MoveStatus = (isInterrupt ? MoveStatus.Interrupt : MoveStatus.Stop);
			sceneItemMoveSplineRequest.RuntimeData = SceneItemSplineRuntimeData.Create();
			sceneItemMoveSplineRequest.RuntimeData.DistanceAlongPath = curDistanceAlongSpline.GetValueOrDefault(-1f);
			sceneItemMoveSplineRequest.RuntimeData.CurPos = Aki.Protocol.Vector.Create();
			sceneItemMoveSplineRequest.RuntimeData.CurPos.X = (float)curPos.X;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Y = (float)curPos.Y;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Z = (float)curPos.Z;
			if (curRot != null)
			{
				sceneItemMoveSplineRequest.RuntimeData.CurRot = Aki.Protocol.Rotator.Create();
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Roll = curRot.Roll;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Pitch = curRot.Pitch;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Yaw = curRot.Yaw;
			}
			Singleton<Net>.Instance.Call<SceneItemMoveSplineResponse>(ERequestMessageId.SceneItemMoveSplineRequest, sceneItemMoveSplineRequest, delegate(SceneItemMoveSplineResponse resp, Net.CallbackStatus _)
			{
				if (resp == null || resp.ErrorCode != ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SyncSplineMoveController.SendSyncSceneItemSplineMoveEnd] 发送同步场景物件样条移动中断/结束信息: 失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineId", splineId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ErrorCode", (resp != null) ? new ErrorCode?(resp.ErrorCode) : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}, 0);
		}

		// Token: 0x0602F396 RID: 193430 RVA: 0x00B31940 File Offset: 0x00B2FB40
		public unsafe void SendSyncSceneItemSplineMoveSwitch(long creatureDataId, int newSplineId, MoveSplineConfig newMoveSplineConfig, IVector curPos, [Nullable(2)] IRotator curRot)
		{
			SceneItemMoveSplineRequest sceneItemMoveSplineRequest = SceneItemMoveSplineRequest.Create();
			sceneItemMoveSplineRequest.EntityId = creatureDataId;
			sceneItemMoveSplineRequest.SplineEntityId = newSplineId;
			sceneItemMoveSplineRequest.MoveStatus = MoveStatus.Switch;
			sceneItemMoveSplineRequest.MoveSplineConfig = newMoveSplineConfig;
			sceneItemMoveSplineRequest.RuntimeData = SceneItemSplineRuntimeData.Create();
			sceneItemMoveSplineRequest.RuntimeData.DistanceAlongPath = -1f;
			sceneItemMoveSplineRequest.RuntimeData.CurPos = Aki.Protocol.Vector.Create();
			sceneItemMoveSplineRequest.RuntimeData.CurPos.X = (float)curPos.X;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Y = (float)curPos.Y;
			sceneItemMoveSplineRequest.RuntimeData.CurPos.Z = (float)curPos.Z;
			if (curRot != null)
			{
				sceneItemMoveSplineRequest.RuntimeData.CurRot = Aki.Protocol.Rotator.Create();
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Roll = curRot.Roll;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Pitch = curRot.Pitch;
				sceneItemMoveSplineRequest.RuntimeData.CurRot.Yaw = curRot.Yaw;
			}
			Singleton<Net>.Instance.Call<SceneItemMoveSplineResponse>(ERequestMessageId.SceneItemMoveSplineRequest, sceneItemMoveSplineRequest, delegate(SceneItemMoveSplineResponse resp, Net.CallbackStatus _)
			{
				if (resp == null || resp.ErrorCode != ErrorCode.Success)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SceneItem;
					ELogAuthor author = ELogAuthor.ZYL;
					string message = "[SyncSplineMoveController.SendSyncSceneItemSplineMoveSwitch] 发送同步场景物件样条移动切换样条信息: 失败";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("CreatureDataId", creatureDataId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("NewSplineId", newSplineId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ErrorCode", (resp != null) ? new ErrorCode?(resp.ErrorCode) : null);
					instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				}
			}, 0);
		}

		// Token: 0x0602F397 RID: 193431 RVA: 0x00B31A78 File Offset: 0x00B2FC78
		private void RecvSyncVehicleSplineMoveStatus(Entity entity, MoveSplineStatusNotify data)
		{
			switch (data.MoveStatus)
			{
			case MoveStatus.Stop:
			case MoveStatus.Interrupt:
				this.SyncVehicleStopMove(entity);
				return;
			case MoveStatus.Moving:
				this.SyncVehicleMoveAlongPath(entity, data.SplineEntityId);
				return;
			default:
				return;
			}
		}

		// Token: 0x0602F398 RID: 193432 RVA: 0x00B31AB4 File Offset: 0x00B2FCB4
		private unsafe void SendSyncVehicleSplineMoveEndRequest(Entity entity, int splineId, bool bInterrupt)
		{
			CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
			if (component == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Movement;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "[SyncSplineMoveController.MoveSplineStatusNotify] 结束时无法获取对应实体CreatureData";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", entity.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplineId", splineId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsInterrupt", bInterrupt);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			long creatureDataId = component.GetCreatureDataId();
			StopMoveSplineRequest stopMoveSplineRequest = StopMoveSplineRequest.Create();
			stopMoveSplineRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(creatureDataId);
			stopMoveSplineRequest.SplineEntityId = splineId;
			stopMoveSplineRequest.IsInterrupt = bInterrupt;
			Singleton<Net>.Instance.Call<StopMoveSplineResponse>(ERequestMessageId.StopMoveSplineRequest, stopMoveSplineRequest, null, 0);
		}

		// Token: 0x0602F399 RID: 193433 RVA: 0x00B31B8C File Offset: 0x00B2FD8C
		public void SyncVehicleMoveAlongPath(Entity entity, int splineId)
		{
			SyncSplineMoveController.<>c__DisplayClass12_0 CS$<>8__locals1 = new SyncSplineMoveController.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.entity = entity;
			CS$<>8__locals1.splineId = splineId;
			VehicleMoveComponent component = CS$<>8__locals1.entity.GetComponent<VehicleMoveComponent>();
			if (component == null)
			{
				return;
			}
			int movingSplineId = component.GetMovingSplineId();
			if (movingSplineId != 0 && movingSplineId != CS$<>8__locals1.splineId)
			{
				component.StopMove();
			}
			component.MoveAlongPath(new IMoveVehicleConfig
			{
				SplineId = CS$<>8__locals1.splineId,
				StartFromNearest = new bool?(true),
				OnMoveEndHandle = new Action<bool>(CS$<>8__locals1.<SyncVehicleMoveAlongPath>g__OnMoveEndWrapper|0)
			});
		}

		// Token: 0x0602F39A RID: 193434 RVA: 0x00B31C14 File Offset: 0x00B2FE14
		public void SyncVehicleStopMove(Entity entity)
		{
			VehicleMoveComponent component = entity.GetComponent<VehicleMoveComponent>();
			if (component == null)
			{
				return;
			}
			component.StopMove();
		}

		// Token: 0x0602F39B RID: 193435 RVA: 0x00B31C34 File Offset: 0x00B2FE34
		public SyncSplineMoveController()
		{
			Dictionary<MoveStatus, string> dictionary = new Dictionary<MoveStatus, string>();
			dictionary[MoveStatus.Interrupt] = "中断";
			dictionary[MoveStatus.Moving] = "运行";
			dictionary[MoveStatus.Stop] = "停止";
			dictionary[MoveStatus.Switch] = "切换";
			this.SplineMoveStatusLogString = dictionary;
			base..ctor();
		}

		// Token: 0x0401AE72 RID: 110194
		private readonly Dictionary<MoveStatus, string> SplineMoveStatusLogString;

		// Token: 0x0401AE73 RID: 110195
		private const int WAIT_ENTITY_TIMEOUT = 60000;
	}
}
