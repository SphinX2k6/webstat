using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.LevelGamePlay.LevelAi.BehaviorTree;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C88 RID: 3208
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolWithEvents.TsTaskPatrolWithEvents_C")]
public class TsTaskPatrolWithEvents : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06003A85 RID: 14981 RVA: 0x00048035 File Offset: 0x00046235
	// (set) Token: 0x06003A86 RID: 14982 RVA: 0x00048045 File Offset: 0x00046245
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseLastMoveIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_UseLastMoveIndex) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_UseLastMoveIndex) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06003A87 RID: 14983 RVA: 0x00048056 File Offset: 0x00046256
	// (set) Token: 0x06003A88 RID: 14984 RVA: 0x00048066 File Offset: 0x00046266
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool StartWithNearestPoint
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_StartWithNearestPoint) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_StartWithNearestPoint) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06003A89 RID: 14985 RVA: 0x00048077 File Offset: 0x00046277
	// (set) Token: 0x06003A8A RID: 14986 RVA: 0x00048087 File Offset: 0x00046287
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SplineId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_SplineId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_SplineId) = value;
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06003A8B RID: 14987 RVA: 0x00048098 File Offset: 0x00046298
	// (set) Token: 0x06003A8C RID: 14988 RVA: 0x000480A8 File Offset: 0x000462A8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Version
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_Version);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_Version) = value;
		}
	}

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06003A8D RID: 14989 RVA: 0x000480B9 File Offset: 0x000462B9
	// (set) Token: 0x06003A8E RID: 14990 RVA: 0x000480C9 File Offset: 0x000462C9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RandomDistanceMin
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_RandomDistanceMin);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_RandomDistanceMin) = value;
		}
	}

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06003A8F RID: 14991 RVA: 0x000480DA File Offset: 0x000462DA
	// (set) Token: 0x06003A90 RID: 14992 RVA: 0x000480EA File Offset: 0x000462EA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RandomDistanceMax
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_RandomDistanceMax);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolWithEvents.__PropertyOffset_RandomDistanceMax) = value;
		}
	}

	// Token: 0x06003A91 RID: 14993 RVA: 0x000480FC File Offset: 0x000462FC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsStartWithNearestPoint = this.StartWithNearestPoint;
			this.TsSplineId = this.SplineId;
			this.TsRandomDistanceMin = this.RandomDistanceMin;
			this.TsRandomDistanceMax = this.RandomDistanceMax;
		}
	}

	// Token: 0x06003A92 RID: 14994 RVA: 0x00048150 File Offset: 0x00046350
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

	// Token: 0x06003A93 RID: 14995 RVA: 0x000481EC File Offset: 0x000463EC
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		Entity entity = aiController.CharAiDesignComp.Entity;
		this.PerformComp = entity.GetComponent<BasePerformComponent>();
		if (this.PerformComp == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (entity.GetComponent<CharacterPatrolComponent>() == null)
		{
			base.FinishExecute(false);
			return;
		}
		int version = this.Version;
		if (version == 0)
		{
			this.ExecuteWithVersion0(entity);
			return;
		}
		if (version != 1)
		{
			base.FinishExecute(false);
			return;
		}
		this.ExecuteWithVersion1(entity);
	}

	// Token: 0x06003A94 RID: 14996 RVA: 0x000482B2 File Offset: 0x000464B2
	protected override void OnAbort()
	{
		BasePerformComponent performComp = this.PerformComp;
		if (performComp == null)
		{
			return;
		}
		performComp.PerformStopMove(EPerformMode.Ecology, new IStopMoveParams
		{
			SplineId = this.TsSplineId,
			Context = "PatrolWithEvents",
			Method = new EStopMoveMethod?(EStopMoveMethod.Pause)
		}, null, null);
	}

	// Token: 0x06003A95 RID: 14997 RVA: 0x000482F0 File Offset: 0x000464F0
	protected override void OnClear()
	{
		if (!(base.AIOwner is TsAiController))
		{
			return;
		}
		this.PerformComp = null;
	}

	// Token: 0x06003A96 RID: 14998 RVA: 0x00048308 File Offset: 0x00046508
	protected void ExecuteWithVersion0(Entity entity)
	{
		CharacterPatrolComponent patrolComp = entity.GetComponent<CharacterPatrolComponent>();
		Action<int> onArrivePointHandle = delegate(int pIndex)
		{
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_POINT_INDEX", pIndex);
		};
		Action<ELevelEventState> onPatrolEndHandle = delegate(ELevelEventState result)
		{
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(entity.Id, "PATROL_STATE", "PATROL_COMPLETE");
			this.Finish(result == ELevelEventState.Success);
		};
		Action<IList<ActionInfo>> onTriggerActionsHandle = delegate(IList<ActionInfo> _)
		{
			int lastPointRawIndex = patrolComp.GetLastPointRawIndex();
			string patrolActionStateName = BehaviorTreeDefines.GetPatrolActionStateName(this.TsSplineId, lastPointRawIndex, false);
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(entity.Id, "PATROL_STATE", patrolActionStateName);
		};
		IStartMoveParams startMoveParams = new IStartMoveParams();
		startMoveParams.SplineId = this.TsSplineId;
		startMoveParams.Context = "PatrolWithEvents";
		startMoveParams.DebugMode = new bool?(false);
		startMoveParams.StartMode = new EPatrolStartMode?(this.TsStartWithNearestPoint ? EPatrolStartMode.NearestPoint : EPatrolStartMode.Default);
		List<double> randomDistanceRange;
		if (this.TsRandomDistanceMin == 0 && this.TsRandomDistanceMax == 0)
		{
			randomDistanceRange = null;
		}
		else
		{
			List<double> list = new List<double>();
			list.Add((double)this.TsRandomDistanceMin);
			randomDistanceRange = list;
			list.Add((double)this.TsRandomDistanceMax);
		}
		startMoveParams.RandomDistanceRange = randomDistanceRange;
		startMoveParams.ReturnFalseWhenNavigationFailed = new bool?(false);
		startMoveParams.OnArrivePointHandle = onArrivePointHandle;
		startMoveParams.OnTriggerActionsHandle = onTriggerActionsHandle;
		startMoveParams.OnPatrolEndHandle = onPatrolEndHandle;
		IStartMoveParams param = startMoveParams;
		this.PerformComp.PerformStartMove(EPerformMode.Ecology, param, null, null);
	}

	// Token: 0x06003A97 RID: 14999 RVA: 0x00048408 File Offset: 0x00046608
	protected void ExecuteWithVersion1(Entity entity)
	{
		if (this.TryResumeSplineActions(entity))
		{
			return;
		}
		CharacterPatrolComponent patrolComp = entity.GetComponent<CharacterPatrolComponent>();
		Action<int> onArrivePointHandle = delegate(int pIndex)
		{
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_POINT_INDEX", pIndex);
		};
		Action<ELevelEventState> onPatrolEndHandle = delegate(ELevelEventState result)
		{
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(entity.Id, "PATROL_STATE", "PATROL_COMPLETE");
			this.Finish(result == ELevelEventState.Success);
		};
		Action<IList<ActionInfo>> onTriggerActionsHandle = delegate(IList<ActionInfo> _)
		{
			int lastPointRawIndex = patrolComp.GetLastPointRawIndex();
			IList<ActionInfo> pointActions = patrolComp.GetPointActions(lastPointRawIndex);
			ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(entity.Id, "PATROL_STATE", BehaviorTreeDefines.GetPatrolActionStateName(this.TsSplineId, lastPointRawIndex, true));
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_ACTION_INDEX", 1);
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_ACTION_TYPE", Singleton<CommonBtRuntimeHelper>.Instance.GetCommonActionNodeId(pointActions[0].Name, true).GetValueOrDefault(-1));
		};
		Action<int> onBeforeExecute = delegate(int _)
		{
			ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_ACTION_INDEX", 0);
		};
		IStartMoveParams param = new IStartMoveParams
		{
			SplineId = this.TsSplineId,
			Context = "PatrolWithEvents",
			DebugMode = new bool?(false),
			StartMode = new EPatrolStartMode?(this.TsStartWithNearestPoint ? EPatrolStartMode.NearestPoint : EPatrolStartMode.Default),
			ReturnFalseWhenNavigationFailed = new bool?(false),
			OnArrivePointHandle = onArrivePointHandle,
			OnTriggerActionsHandle = onTriggerActionsHandle,
			OnPatrolEndHandle = onPatrolEndHandle
		};
		this.PerformComp.PerformStartMove(EPerformMode.Ecology, param, onBeforeExecute, null);
	}

	// Token: 0x06003A98 RID: 15000 RVA: 0x000484F4 File Offset: 0x000466F4
	protected bool TryResumeSplineActions(Entity entity)
	{
		CharacterPatrolComponent component = entity.GetComponent<CharacterPatrolComponent>();
		if (!component.HasPatrolRecord(new long?((long)this.TsSplineId)))
		{
			return false;
		}
		int lastPointRawIndex = component.GetLastPointRawIndex();
		int valueOrDefault = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(entity.Id, "PATROL_ACTION_INDEX").GetValueOrDefault();
		if (valueOrDefault == 0)
		{
			return false;
		}
		IList<ActionInfo> pointActions = component.GetPointActions(lastPointRawIndex);
		int num = (pointActions != null) ? pointActions.Count : 0;
		if (valueOrDefault >= num)
		{
			return false;
		}
		ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(entity.Id, "PATROL_STATE", BehaviorTreeDefines.GetPatrolActionStateName(this.TsSplineId, lastPointRawIndex, true));
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_ACTION_INDEX", valueOrDefault + 1);
		ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "PATROL_ACTION_TYPE", Singleton<CommonBtRuntimeHelper>.Instance.GetCommonActionNodeId(pointActions[valueOrDefault].Name, true).GetValueOrDefault(-1));
		return true;
	}

	// Token: 0x06003A99 RID: 15001 RVA: 0x000485D9 File Offset: 0x000467D9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPatrolWithEvents._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolWithEvents.TsTaskPatrolWithEvents_C");
		}
		return TsTaskPatrolWithEvents._ClassPtr;
	}

	// Token: 0x06003A9A RID: 15002 RVA: 0x00048600 File Offset: 0x00046800
	public TsTaskPatrolWithEvents() : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolWithEvents.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A9B RID: 15003 RVA: 0x00048628 File Offset: 0x00046828
	public TsTaskPatrolWithEvents(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolWithEvents.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A9C RID: 15004 RVA: 0x0004865B File Offset: 0x0004685B
	protected TsTaskPatrolWithEvents(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A9D RID: 15005 RVA: 0x00048664 File Offset: 0x00046864
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000A0D RID: 2573
	[Nullable(2)]
	private BasePerformComponent PerformComp;

	// Token: 0x04000A0E RID: 2574
	private bool IsInitTsVariables;

	// Token: 0x04000A0F RID: 2575
	private bool TsStartWithNearestPoint;

	// Token: 0x04000A10 RID: 2576
	private int TsSplineId;

	// Token: 0x04000A11 RID: 2577
	private int TsRandomDistanceMin;

	// Token: 0x04000A12 RID: 2578
	private int TsRandomDistanceMax;

	// Token: 0x04000A13 RID: 2579
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskPatrolWithEvents.TsTaskPatrolWithEvents_C";

	// Token: 0x04000A14 RID: 2580
	private static IntPtr _ClassPtr;

	// Token: 0x04000A15 RID: 2581
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A16 RID: 2582
	private static int __PropertyOffset_UseLastMoveIndex;

	// Token: 0x04000A17 RID: 2583
	private static int __PropertyOffset_StartWithNearestPoint;

	// Token: 0x04000A18 RID: 2584
	private static int __PropertyOffset_SplineId;

	// Token: 0x04000A19 RID: 2585
	private static int __PropertyOffset_Version;

	// Token: 0x04000A1A RID: 2586
	private static int __PropertyOffset_RandomDistanceMin;

	// Token: 0x04000A1B RID: 2587
	private static int __PropertyOffset_RandomDistanceMax;
}
