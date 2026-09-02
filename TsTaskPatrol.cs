using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC2 RID: 3266
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrol.TsTaskPatrol_C")]
public class TsTaskPatrol : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000277 RID: 631
	// (get) Token: 0x06003ED6 RID: 16086 RVA: 0x0005F5A8 File Offset: 0x0005D7A8
	// (set) Token: 0x06003ED7 RID: 16087 RVA: 0x0005F5B8 File Offset: 0x0005D7B8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x06003ED8 RID: 16088 RVA: 0x0005F5C9 File Offset: 0x0005D7C9
	// (set) Token: 0x06003ED9 RID: 16089 RVA: 0x0005F5D9 File Offset: 0x0005D7D9
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MoveOnePath
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_MoveOnePath) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_MoveOnePath) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000279 RID: 633
	// (get) Token: 0x06003EDA RID: 16090 RVA: 0x0005F5EA File Offset: 0x0005D7EA
	// (set) Token: 0x06003EDB RID: 16091 RVA: 0x0005F5FA File Offset: 0x0005D7FA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseSimpleMove
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseSimpleMove) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseSimpleMove) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700027A RID: 634
	// (get) Token: 0x06003EDC RID: 16092 RVA: 0x0005F60B File Offset: 0x0005D80B
	// (set) Token: 0x06003EDD RID: 16093 RVA: 0x0005F61B File Offset: 0x0005D81B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseActorForward
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseActorForward) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseActorForward) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06003EDE RID: 16094 RVA: 0x0005F62C File Offset: 0x0005D82C
	// (set) Token: 0x06003EDF RID: 16095 RVA: 0x0005F63C File Offset: 0x0005D83C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseLastMoveIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseLastMoveIndex) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_UseLastMoveIndex) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06003EE0 RID: 16096 RVA: 0x0005F64D File Offset: 0x0005D84D
	// (set) Token: 0x06003EE1 RID: 16097 RVA: 0x0005F65D File Offset: 0x0005D85D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OpenDebugNode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_OpenDebugNode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrol.__PropertyOffset_OpenDebugNode) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003EE2 RID: 16098 RVA: 0x0005F670 File Offset: 0x0005D870
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsMoveOnePath = this.MoveOnePath;
			this.TsUseLastMoveIndex = this.UseLastMoveIndex;
			this.TsOpenDebugNode = this.OpenDebugNode;
		}
	}

	// Token: 0x06003EE3 RID: 16099 RVA: 0x0005F6C4 File Offset: 0x0005D8C4
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

	// Token: 0x06003EE4 RID: 16100 RVA: 0x0005F760 File Offset: 0x0005D960
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
		this.PatrolLogic = aiController.AiPatrol;
		this.PatrolConfig = this.PatrolLogic.GetConfig();
		if (this.PatrolConfig == null)
		{
			base.Finish(false);
			return;
		}
		this.Entity = aiController.CharAiDesignComp.Entity;
		this.MoveComp = this.Entity.GetComponent<BaseMoveComponent>();
		this.StateComp = this.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.ActorComp = aiController.CharActorComp;
		if (this.PatrolConfig.ContainZ)
		{
			CharacterActorComponent charActorComp = aiController.CharActorComp;
			if (charActorComp != null)
			{
				charActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Flying,
					Context = "[TsTaskPatrol.ReceiveExecuteAI]"
				});
			}
		}
		if (this.HandleMoveEnd == null)
		{
			this.HandleMoveEnd = new Action<ELevelEventState>(this.ExecuteMoveEnd);
		}
		this.InitPatrolInfo();
		AiPatrolController patrolLogic = this.PatrolLogic;
		if (((patrolLogic != null) ? patrolLogic.PatrolPoint : null) == null)
		{
			base.Finish(false);
			return;
		}
		EntityPatrolStartRequest entityPatrolStartRequest = EntityPatrolStartRequest.Create();
		entityPatrolStartRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(aiController.CharActorComp.CreatureData.GetCreatureDataId());
		entityPatrolStartRequest.Dir = !this.PatrolLogic.StartWithInversePath.GetValueOrDefault();
		Singleton<Net>.Instance.Call<EntityPatrolStartResponse>(ERequestMessageId.EntityPatrolStartRequest, entityPatrolStartRequest, delegate(EntityPatrolStartResponse _, Net.CallbackStatus _)
		{
		}, 0);
		this.MoveToPatrolPoint();
		if (aiController.AiPatrol.StartWithInversePath != null)
		{
			aiController.AiPatrol.StartWithInversePath = null;
		}
	}

	// Token: 0x06003EE5 RID: 16101 RVA: 0x0005F940 File Offset: 0x0005DB40
	private void CallOutside()
	{
		if (GlobalData.BpEventManager == null)
		{
			return;
		}
		AiPatrolController patrolLogic = this.PatrolLogic;
		PatrolPoint patrolPoint = (patrolLogic != null) ? patrolLogic.PatrolPoint : null;
		if (patrolPoint == null)
		{
			return;
		}
		if (!patrolPoint.IsMain)
		{
			return;
		}
		GlobalData.BpEventManager.AI巡逻达到样条点.Broadcast(this.ActorComp.Actor, this.PatrolLogic.PatrolIndex);
	}

	// Token: 0x06003EE6 RID: 16102 RVA: 0x0005F99C File Offset: 0x0005DB9C
	private void InitPatrolInfo()
	{
		this.PatrolLogic.GeneratePatrol(true);
		this.PatrolLogic.StartPatrol(this.TsUseLastMoveIndex, new Action(this.CallOutside));
		this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
	}

	// Token: 0x06003EE7 RID: 16103 RVA: 0x0005F9F0 File Offset: 0x0005DBF0
	private void MoveToPatrolPoint()
	{
		TsTaskPatrol.<>c__DisplayClass36_0 CS$<>8__locals1 = new TsTaskPatrol.<>c__DisplayClass36_0();
		CS$<>8__locals1.<>4__this = this;
		TsTaskPatrol.<>c__DisplayClass36_0 CS$<>8__locals2 = CS$<>8__locals1;
		AiPatrolController patrolLogic = this.PatrolLogic;
		CS$<>8__locals2.curPoint = ((patrolLogic != null) ? patrolLogic.PatrolPoint : null);
		if (CS$<>8__locals1.curPoint == null)
		{
			return;
		}
		List<MoveCharacterPoint> list = new List<MoveCharacterPoint>();
		int num = 0;
		for (int i = 0; i < this.PatrolLogic.AllPatrolPoints.Count; i++)
		{
			PatrolPoint patrolPoint = this.PatrolLogic.AllPatrolPoints[i];
			int currentIndex = i;
			MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
			{
				Index = (patrolPoint.IsMain ? num : -1),
				Position = patrolPoint.Point,
				MoveState = new EPatrolMoveState?((EPatrolMoveState)patrolPoint.MoveState),
				MoveSpeed = new float?(patrolPoint.MoveSpeed),
				Actions = patrolPoint.Actions,
				Callback = delegate()
				{
					CS$<>8__locals1.<>4__this.PatrolLogic.SetPatrolIndex(currentIndex);
					if (CS$<>8__locals1.curPoint.IsMain)
					{
						CS$<>8__locals1.<>4__this.CallOutside();
					}
				}
			};
			if (patrolPoint.IsMain)
			{
				num++;
			}
			if (moveCharacterPoint.Actions == null)
			{
				moveCharacterPoint.Actions = new List<ActionInfo>();
			}
			list.Add(moveCharacterPoint);
		}
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = list,
			Navigation = this.PatrolConfig.IsNavigation,
			IsFly = this.PatrolConfig.ContainZ,
			DebugMode = this.TsOpenDebugNode,
			Loop = this.PatrolConfig.Loop,
			CircleMove = new bool?(this.PatrolConfig.CirclePatrol),
			StartWithInversePath = this.PatrolLogic.StartWithInversePath,
			Distance = new float?(this.PatrolConfig.EndDistance),
			TurnSpeed = new float?(this.PatrolConfig.TurnSpeed),
			Callback = delegate(ELevelEventState result)
			{
				if (result == ELevelEventState.Success)
				{
					CS$<>8__locals1.<>4__this.PatrolFinish();
				}
				CS$<>8__locals1.<>4__this.Finish(true);
			},
			UsePreviousIndex = new bool?(this.UseLastMoveIndex),
			UseNearestPoint = new bool?(this.UseLastMoveIndex),
			ReturnFalseWhenNavigationFailed = false
		};
		this.TsMoveHandleId = this.MoveComp.MoveAlongPath(config, "TsTaskPatrol.MoveToPatrolPoint");
	}

	// Token: 0x06003EE8 RID: 16104 RVA: 0x0005FC10 File Offset: 0x0005DE10
	private void ExecuteMoveEnd(ELevelEventState result)
	{
		if (result == ELevelEventState.Success)
		{
			AiPatrolController patrolLogic = this.PatrolLogic;
			if (((patrolLogic != null) ? patrolLogic.PatrolPoint : null) == null)
			{
				return;
			}
			PatrolPoint patrolPoint = this.PatrolLogic.PatrolPoint;
			if (this.CheckMoveEnd(patrolPoint))
			{
				this.PatrolFinish();
				base.Finish(true);
				return;
			}
			if (patrolPoint != this.PatrolLogic.PatrolPoint)
			{
				patrolPoint = this.PatrolLogic.PatrolPoint;
				if (patrolPoint == null)
				{
					base.Finish(true);
					return;
				}
				if (patrolPoint.IsMain)
				{
					this.CallOutside();
					this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
				}
				this.MoveToPatrolPoint();
				return;
			}
		}
		else
		{
			base.Finish(false);
		}
	}

	// Token: 0x06003EE9 RID: 16105 RVA: 0x0005FCBC File Offset: 0x0005DEBC
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

	// Token: 0x06003EEA RID: 16106 RVA: 0x0005FD5C File Offset: 0x0005DF5C
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
	}

	// Token: 0x06003EEB RID: 16107 RVA: 0x0005FD60 File Offset: 0x0005DF60
	[NullableContext(1)]
	private bool CheckMoveEnd(PatrolPoint curPoint)
	{
		bool result = this.PatrolLogic.CheckPatrolEnd();
		if (curPoint.IsMain)
		{
			if (this.TsMoveOnePath && !curPoint.IsIgnorePoint)
			{
				result = true;
			}
			if (curPoint.Actions != null)
			{
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(curPoint.Actions, EntityContext.Create(this.Entity.Id, null), null);
			}
		}
		return result;
	}

	// Token: 0x06003EEC RID: 16108 RVA: 0x0005FDC6 File Offset: 0x0005DFC6
	private void PatrolFinish()
	{
		this.CallOutside();
		AiPatrolController patrolLogic = this.PatrolLogic;
		if (patrolLogic == null)
		{
			return;
		}
		patrolLogic.PatrolFinish();
	}

	// Token: 0x06003EED RID: 16109 RVA: 0x0005FDDE File Offset: 0x0005DFDE
	protected override void OnAbort()
	{
		this.PatrolFinish();
		BaseMoveComponent moveComp = this.MoveComp;
		if (moveComp == null)
		{
			return;
		}
		moveComp.StopMoveByHandleId(this.TsMoveHandleId, "TsTaskPatrol.OnAbort");
	}

	// Token: 0x06003EEE RID: 16110 RVA: 0x0005FE04 File Offset: 0x0005E004
	protected override void OnClear()
	{
		if (!(base.AIOwner is TsAiController))
		{
			return;
		}
		if (Singleton<EntitySystem>.Instance.Get(this.Entity.Id) != null)
		{
			EntityPatrolStopRequest entityPatrolStopRequest = EntityPatrolStopRequest.Create();
			entityPatrolStopRequest.EntityId = Singleton<MathUtils>.Instance.NumberToLong(this.ActorComp.CreatureData.GetCreatureDataId());
			Singleton<Net>.Instance.Call<EntityPatrolStopResponse>(ERequestMessageId.EntityPatrolStopRequest, entityPatrolStopRequest, delegate(EntityPatrolStopResponse _, Net.CallbackStatus _)
			{
			}, 0);
		}
		if (this.MoveComp != null)
		{
			if (this.TsMoveOnePath)
			{
				this.MoveComp.SetForceSpeed(global::Vector.ZeroVectorProxy);
			}
			this.MoveComp.IsSpecialMove = false;
		}
		this.Entity = null;
		this.ActorComp = null;
		this.MoveComp = null;
		this.StateComp = null;
		this.PatrolLogic = null;
		this.PatrolConfig = null;
	}

	// Token: 0x06003EEF RID: 16111 RVA: 0x0005FEE2 File Offset: 0x0005E0E2
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPatrol._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrol.TsTaskPatrol_C");
		}
		return TsTaskPatrol._ClassPtr;
	}

	// Token: 0x06003EF0 RID: 16112 RVA: 0x0005FF08 File Offset: 0x0005E108
	public TsTaskPatrol() : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrol.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003EF1 RID: 16113 RVA: 0x0005FF30 File Offset: 0x0005E130
	[NullableContext(1)]
	public TsTaskPatrol(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003EF2 RID: 16114 RVA: 0x0005FF63 File Offset: 0x0005E163
	protected TsTaskPatrol(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003EF3 RID: 16115 RVA: 0x0005FF6C File Offset: 0x0005E16C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003EF4 RID: 16116 RVA: 0x0005FF9C File Offset: 0x0005E19C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000DB0 RID: 3504
	private Entity Entity;

	// Token: 0x04000DB1 RID: 3505
	private CharacterActorComponent ActorComp;

	// Token: 0x04000DB2 RID: 3506
	private BaseMoveComponent MoveComp;

	// Token: 0x04000DB3 RID: 3507
	private BaseUnifiedStateComponent StateComp;

	// Token: 0x04000DB4 RID: 3508
	private AiPatrolController PatrolLogic;

	// Token: 0x04000DB5 RID: 3509
	private AiPatrolConfig PatrolConfig;

	// Token: 0x04000DB6 RID: 3510
	private bool IsInitTsVariables;

	// Token: 0x04000DB7 RID: 3511
	private int TsMoveState;

	// Token: 0x04000DB8 RID: 3512
	private bool TsMoveOnePath;

	// Token: 0x04000DB9 RID: 3513
	private bool TsUseLastMoveIndex;

	// Token: 0x04000DBA RID: 3514
	private bool TsOpenDebugNode;

	// Token: 0x04000DBB RID: 3515
	private int TsMoveHandleId;

	// Token: 0x04000DBC RID: 3516
	private Action<ELevelEventState> HandleMoveEnd;

	// Token: 0x04000DBD RID: 3517
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrol.TsTaskPatrol_C";

	// Token: 0x04000DBE RID: 3518
	private static IntPtr _ClassPtr;

	// Token: 0x04000DBF RID: 3519
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000DC0 RID: 3520
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000DC1 RID: 3521
	private static int __PropertyOffset_MoveOnePath;

	// Token: 0x04000DC2 RID: 3522
	private static int __PropertyOffset_UseSimpleMove;

	// Token: 0x04000DC3 RID: 3523
	private static int __PropertyOffset_UseActorForward;

	// Token: 0x04000DC4 RID: 3524
	private static int __PropertyOffset_UseLastMoveIndex;

	// Token: 0x04000DC5 RID: 3525
	private static int __PropertyOffset_OpenDebugNode;
}
