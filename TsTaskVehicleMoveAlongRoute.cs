using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.Common;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C97 RID: 3223
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskVehicleMoveAlongRoute.TsTaskVehicleMoveAlongRoute_C")]
public class TsTaskVehicleMoveAlongRoute : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001CE RID: 462
	// (get) Token: 0x06003B9F RID: 15263 RVA: 0x0004E4F9 File Offset: 0x0004C6F9
	// (set) Token: 0x06003BA0 RID: 15264 RVA: 0x0004E509 File Offset: 0x0004C709
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MaxExecuteTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskVehicleMoveAlongRoute.__PropertyOffset_MaxExecuteTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskVehicleMoveAlongRoute.__PropertyOffset_MaxExecuteTime) = value;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x06003BA1 RID: 15265 RVA: 0x0004E51A File Offset: 0x0004C71A
	// (set) Token: 0x06003BA2 RID: 15266 RVA: 0x0004E52A File Offset: 0x0004C72A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskVehicleMoveAlongRoute.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskVehicleMoveAlongRoute.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x06003BA3 RID: 15267 RVA: 0x0004E53B File Offset: 0x0004C73B
	private void OnMoveEnd(ELevelEventState result)
	{
		this.ConcludeAtEndpoint();
	}

	// Token: 0x06003BA4 RID: 15268 RVA: 0x0004E543 File Offset: 0x0004C743
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMaxExecuteTime = this.MaxExecuteTime;
			this.TsTurnSpeed = this.TurnSpeed;
		}
	}

	// Token: 0x06003BA5 RID: 15269 RVA: 0x0004E574 File Offset: 0x0004C774
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecuteAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003BA6 RID: 15270 RVA: 0x0004E610 File Offset: 0x0004C810
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		this.ResetRuntimeState();
		if (!(ownerController is TsAiController))
		{
			this.FailExecute(false);
			return;
		}
		AiController aiController = ((TsAiController)ownerController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.FailExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			this.FailExecute(false);
			return;
		}
		this.VehicleEntityId = charActorComp.Entity.Id;
		int? availableRouteNpc = ControllerBase<NpcVehicleRiderController>.Instance.GetAvailableRouteNpc(this.VehicleEntityId);
		if (availableRouteNpc == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskVehicleMoveAlongRoute] 失败:无可用移动目标乘客";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.FailExecute(false);
			return;
		}
		int? npcTargetSplinePbDataId = ControllerBase<NpcVehicleRiderController>.Instance.GetNpcTargetSplinePbDataId(availableRouteNpc.Value);
		if (npcTargetSplinePbDataId != null)
		{
			int? num = npcTargetSplinePbDataId;
			int num2 = 0;
			if (!(num.GetValueOrDefault() <= num2 & num != null))
			{
				int? num3 = ControllerBase<NpcVehicleRiderController>.Instance.ActivateNpcRouteBySpline(this.VehicleEntityId, npcTargetSplinePbDataId.Value);
				if (num3 == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Vehicle;
					ELogAuthor author3 = ELogAuthor.ZJL;
					string message3 = "[TsTaskVehicleMoveAlongRoute] 失败:激活样条路线失败";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplinePbDataId", npcTargetSplinePbDataId);
					instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.FailExecute(false);
					return;
				}
				this.ServedNpcEntityId = num3.Value;
				this.MoveComp = charActorComp.Entity.GetComponent<BaseMoveComponent>();
				if (this.MoveComp == null)
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Vehicle;
					ELogAuthor author4 = ELogAuthor.ZJL;
					string message4 = "[TsTaskVehicleMoveAlongRoute] 失败:载具缺少移动组件";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
					instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					this.FailExecute(true);
					return;
				}
				this.ExecuteTimeStamp = Singleton<Time>.Instance.WorldTime;
				if (!this.StartMoveAlongRoute(npcTargetSplinePbDataId.Value, charActorComp.CreatureData.GetPbDataId()))
				{
					this.FailExecute(true);
				}
				return;
			}
		}
		Log instance5 = Singleton<Log>.Instance;
		ELogModule module5 = ELogModule.Vehicle;
		ELogAuthor author5 = ELogAuthor.ZJL;
		string message5 = "[TsTaskVehicleMoveAlongRoute] 失败:乘客未登记有效样条";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("NpcEntityId", availableRouteNpc);
		instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
		this.FailExecute(false);
	}

	// Token: 0x06003BA7 RID: 15271 RVA: 0x0004E8C8 File Offset: 0x0004CAC8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06003BA8 RID: 15272 RVA: 0x0004E968 File Offset: 0x0004CB68
	[NullableContext(2)]
	protected unsafe virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.Finished)
		{
			return;
		}
		if (!(ownerController is TsAiController))
		{
			this.FailExecute(false);
			return;
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.ServedNpcEntityId);
		if (entity == null || !entity.Active)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsTaskVehicleMoveAlongRoute] 失败:被服务NPC实体失效";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ServedNpcEntityId", this.ServedNpcEntityId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.ServedNpcEntityId);
			this.FailExecute(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.ExecuteTimeStamp + (double)this.TsMaxExecuteTime)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskVehicleMoveAlongRoute] 样条移动超时, 按到达终点收尾";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("ServedNpcEntityId", this.ServedNpcEntityId);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			this.ConcludeAtEndpoint();
		}
	}

	// Token: 0x06003BA9 RID: 15273 RVA: 0x0004EABF File Offset: 0x0004CCBF
	private void ConcludeAtEndpoint()
	{
		if (this.Finished)
		{
			return;
		}
		this.Finished = true;
		base.Finish(this.ApplyEndpointState());
	}

	// Token: 0x06003BAA RID: 15274 RVA: 0x0004EADD File Offset: 0x0004CCDD
	private void ResetRuntimeState()
	{
		this.VehicleEntityId = 0;
		this.ServedNpcEntityId = 0;
		this.MoveComp = null;
		this.MoveHandleId = 0;
		this.ExecuteTimeStamp = 0.0;
		this.Finished = false;
	}

	// Token: 0x06003BAB RID: 15275 RVA: 0x0004EB11 File Offset: 0x0004CD11
	private void FailExecute(bool releaseServedNpc = false)
	{
		if (this.Finished)
		{
			return;
		}
		if (releaseServedNpc && this.ServedNpcEntityId != 0)
		{
			ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.ServedNpcEntityId);
		}
		this.Finished = true;
		base.Finish(false);
	}

	// Token: 0x06003BAC RID: 15276 RVA: 0x0004EB48 File Offset: 0x0004CD48
	private bool StartMoveAlongRoute(int splinePbDataId, int vehiclePbDataId)
	{
		if (this.MoveComp == null)
		{
			return false;
		}
		MoveCharacterConfig moveCharacterConfig = this.CreateMoveConfig(splinePbDataId, vehiclePbDataId);
		if (moveCharacterConfig == null)
		{
			return false;
		}
		this.MoveHandleId = this.MoveComp.MoveAlongPath(moveCharacterConfig, "TsTaskVehicleMoveAlongRoute.StartMoveAlongRoute");
		return true;
	}

	// Token: 0x06003BAD RID: 15277 RVA: 0x0004EB88 File Offset: 0x0004CD88
	[NullableContext(2)]
	private unsafe MoveCharacterConfig CreateMoveConfig(int splinePbDataId, int vehiclePbDataId)
	{
		GameSplineComponent gameSplineComponent = new GameSplineComponent(splinePbDataId);
		if (!gameSplineComponent.InitializeWithSubPoints(vehiclePbDataId))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Vehicle;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "[TsTaskVehicleMoveAlongRoute] 失败:NPC移动组件初始化样条失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		if (gameSplineComponent.PathPoint.Count < 2)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Vehicle;
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "[TsTaskVehicleMoveAlongRoute] 失败:NPC移动组件样条点数量不足";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return null;
		}
		List<MoveCharacterPoint> list = new List<MoveCharacterPoint>();
		int num = 0;
		foreach (PatrolPoint patrolPoint in gameSplineComponent.PathPoint)
		{
			MoveCharacterPoint item = new MoveCharacterPoint
			{
				Index = (patrolPoint.IsMain ? num : -1),
				Position = patrolPoint.Point,
				MoveState = new EPatrolMoveState?((EPatrolMoveState)((patrolPoint.MoveState != 0) ? patrolPoint.MoveState : 1)),
				MoveSpeed = new float?((patrolPoint.MoveSpeed != 0f) ? patrolPoint.MoveSpeed : 100f)
			};
			if (patrolPoint.IsMain)
			{
				num++;
			}
			list.Add(item);
		}
		BaseMoveComponent moveComp = this.MoveComp;
		CharacterActorComponent characterActorComponent = (moveComp != null) ? moveComp.ActorComp : null;
		int num2 = (characterActorComponent != null) ? this.FindNearestNextPointIndex(list, characterActorComponent.ActorLocationProxy, characterActorComponent.ActorForwardProxy) : 0;
		Log instance3 = Singleton<Log>.Instance;
		ELogModule module3 = ELogModule.Vehicle;
		ELogAuthor author3 = ELogAuthor.ZJL;
		string message3 = "[TsTaskVehicleMoveAlongRoute] 创建移动配置完成";
		<>y__InlineArray6<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray6<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("VehicleEntityId", this.VehicleEntityId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("SplinePbDataId", splinePbDataId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("移动点数量", list.Count);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("主锚点数量", num);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("起始点Index", num2);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 5) = new ValueTuple<string, object>("载具位置", (characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
		instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray6<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 6));
		return new MoveCharacterConfig
		{
			Points = list,
			Navigation = true,
			StrictNavigation = new bool?(true),
			IsFly = false,
			DebugMode = true,
			Loop = false,
			CircleMove = new bool?(false),
			UsePreviousIndex = new bool?(false),
			UseNearestPoint = new bool?(true),
			StartIndex = new int?(num2),
			TurnSpeed = new float?(this.TsTurnSpeed),
			ReturnFalseWhenNavigationFailed = true,
			ReturnTimeoutFailed = new float?((float)300000),
			Callback = new Action<ELevelEventState>(this.OnMoveEnd)
		};
	}

	// Token: 0x06003BAE RID: 15278 RVA: 0x0004EF0C File Offset: 0x0004D10C
	private int FindNearestNextPointIndex(List<MoveCharacterPoint> movePoints, Vector currentLocation, Vector forward)
	{
		int result = 0;
		double num = double.MaxValue;
		for (int i = 0; i < movePoints.Count - 1; i++)
		{
			Vector position = movePoints[i].Position;
			Vector position2 = movePoints[i + 1].Position;
			position2.Subtraction(position, this.NearestSegmentVector);
			double num2 = this.NearestSegmentVector.Size();
			if (num2 > 0.0)
			{
				currentLocation.Subtraction(position2, this.NearestToPointVector);
				if (this.NearestSegmentVector.DotProduct(this.NearestToPointVector) <= 0.0)
				{
					currentLocation.Subtraction(position, this.NearestToPointVector);
					if (this.NearestSegmentVector.DotProduct(this.NearestToPointVector) >= 0.0 && this.NearestSegmentVector.DotProduct(forward) >= 0.0)
					{
						this.NearestSegmentVector.CrossProduct(this.NearestToPointVector, this.NearestCrossVector);
						double num3 = this.NearestCrossVector.Size() / num2;
						if (num3 < num)
						{
							num = num3;
							result = i + 1;
						}
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06003BAF RID: 15279 RVA: 0x0004F028 File Offset: 0x0004D228
	private bool ApplyEndpointState()
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(this.ServedNpcEntityId);
		if (entity != null && entity.Active)
		{
			ControllerBase<NpcVehicleRiderController>.Instance.SetNpcVehicleRideState(this.ServedNpcEntityId, ENpcVehicleRideState.WaitingToDismount);
			return true;
		}
		ControllerBase<NpcVehicleRiderController>.Instance.ReleaseVehicle(this.ServedNpcEntityId);
		return false;
	}

	// Token: 0x06003BB0 RID: 15280 RVA: 0x0004F079 File Offset: 0x0004D279
	protected override void OnAbort()
	{
		if (this.Finished || this.ServedNpcEntityId == 0)
		{
			return;
		}
		this.Finished = true;
		this.ApplyEndpointState();
	}

	// Token: 0x06003BB1 RID: 15281 RVA: 0x0004F09A File Offset: 0x0004D29A
	protected override void OnClear()
	{
		if (this.MoveComp != null)
		{
			this.MoveComp.StopMoveByHandleId(this.MoveHandleId, "TsTaskVehicleMoveAlongRoute.OnClear");
		}
		this.MoveComp = null;
		this.MoveHandleId = 0;
	}

	// Token: 0x06003BB2 RID: 15282 RVA: 0x0004F0C8 File Offset: 0x0004D2C8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskVehicleMoveAlongRoute._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskVehicleMoveAlongRoute.TsTaskVehicleMoveAlongRoute_C");
		}
		return TsTaskVehicleMoveAlongRoute._ClassPtr;
	}

	// Token: 0x06003BB3 RID: 15283 RVA: 0x0004F0EC File Offset: 0x0004D2EC
	public TsTaskVehicleMoveAlongRoute() : this(BuiltinUtils.AllocNativeUObject(TsTaskVehicleMoveAlongRoute.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BB4 RID: 15284 RVA: 0x0004F114 File Offset: 0x0004D314
	public TsTaskVehicleMoveAlongRoute(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskVehicleMoveAlongRoute.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003BB5 RID: 15285 RVA: 0x0004F147 File Offset: 0x0004D347
	protected TsTaskVehicleMoveAlongRoute(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003BB6 RID: 15286 RVA: 0x0004F174 File Offset: 0x0004D374
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003BB7 RID: 15287 RVA: 0x0004F1A4 File Offset: 0x0004D3A4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000AEC RID: 2796
	private const int DEFAULT_MAX_EXECUTE_TIME = 300000;

	// Token: 0x04000AED RID: 2797
	private const float DEFAULT_MOVE_SPEED = 100f;

	// Token: 0x04000AEE RID: 2798
	private const int DEFAULT_MOVE_STATE = 1;

	// Token: 0x04000AEF RID: 2799
	private const float DEFAULT_TURN_SPEED = 180f;

	// Token: 0x04000AF0 RID: 2800
	private bool IsInitTsVariables;

	// Token: 0x04000AF1 RID: 2801
	private int TsMaxExecuteTime;

	// Token: 0x04000AF2 RID: 2802
	private float TsTurnSpeed;

	// Token: 0x04000AF3 RID: 2803
	private int VehicleEntityId;

	// Token: 0x04000AF4 RID: 2804
	private int ServedNpcEntityId;

	// Token: 0x04000AF5 RID: 2805
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000AF6 RID: 2806
	private int MoveHandleId;

	// Token: 0x04000AF7 RID: 2807
	private double ExecuteTimeStamp;

	// Token: 0x04000AF8 RID: 2808
	private bool Finished;

	// Token: 0x04000AF9 RID: 2809
	private readonly Vector NearestSegmentVector = Vector.Create();

	// Token: 0x04000AFA RID: 2810
	private readonly Vector NearestToPointVector = Vector.Create();

	// Token: 0x04000AFB RID: 2811
	private readonly Vector NearestCrossVector = Vector.Create();

	// Token: 0x04000AFC RID: 2812
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskVehicleMoveAlongRoute.TsTaskVehicleMoveAlongRoute_C";

	// Token: 0x04000AFD RID: 2813
	private static IntPtr _ClassPtr;

	// Token: 0x04000AFE RID: 2814
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000AFF RID: 2815
	private static int __PropertyOffset_MaxExecuteTime;

	// Token: 0x04000B00 RID: 2816
	private static int __PropertyOffset_TurnSpeed;
}
