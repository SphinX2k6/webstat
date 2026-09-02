using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MonsterGroup;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C7F RID: 3199
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskEnterPatrolState.TsTaskEnterPatrolState_C")]
public class TsTaskEnterPatrolState : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000180 RID: 384
	// (get) Token: 0x060039D0 RID: 14800 RVA: 0x00044ABD File Offset: 0x00042CBD
	// (set) Token: 0x060039D1 RID: 14801 RVA: 0x00044ACD File Offset: 0x00042CCD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskEnterPatrolState.__PropertyOffset_EntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskEnterPatrolState.__PropertyOffset_EntityId) = value;
		}
	}

	// Token: 0x060039D2 RID: 14802 RVA: 0x00044AE0 File Offset: 0x00042CE0
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

	// Token: 0x060039D3 RID: 14803 RVA: 0x00044B7C File Offset: 0x00042D7C
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(true);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		this.EntityId = charActorComp.Entity.Id;
		this.CheckGroupPatrolAction(0f);
	}

	// Token: 0x060039D4 RID: 14804 RVA: 0x00044C00 File Offset: 0x00042E00
	private void CheckGroupPatrolAction(float delta)
	{
		if (this.TimeHandle != null)
		{
			TimerSystem.FlowTimeInstance.Remove(this.TimeHandle);
			this.TimeHandle = null;
		}
		MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.EntityId);
		if (monsterInfoByEntityId != null)
		{
			monsterInfoByEntityId.GroupPatrolState = EGroupPatrolState.Ready;
			return;
		}
		this.TimeHandle = TimerSystem.FlowTimeInstance.Delay(new TTimerAction(this.CheckGroupPatrolAction), 1000f, null, null, true, 1f);
	}

	// Token: 0x060039D5 RID: 14805 RVA: 0x00044C74 File Offset: 0x00042E74
	protected override void OnAbort()
	{
		MonsterPatrolInfo monsterInfoByEntityId = ModelBase<MonsterGroupPatrolModel>.Instance.GetMonsterInfoByEntityId(this.EntityId);
		if (monsterInfoByEntityId != null)
		{
			MonsterGroupInfo group = monsterInfoByEntityId.Group;
			if (group != null)
			{
				group.PausePatrol();
			}
			monsterInfoByEntityId.GroupPatrolState = EGroupPatrolState.None;
		}
		if (this.TimeHandle != null)
		{
			TimerSystem.FlowTimeInstance.Remove(this.TimeHandle);
		}
	}

	// Token: 0x060039D6 RID: 14806 RVA: 0x00044CC6 File Offset: 0x00042EC6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskEnterPatrolState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskEnterPatrolState.TsTaskEnterPatrolState_C");
		}
		return TsTaskEnterPatrolState._ClassPtr;
	}

	// Token: 0x060039D7 RID: 14807 RVA: 0x00044CEC File Offset: 0x00042EEC
	public TsTaskEnterPatrolState() : this(BuiltinUtils.AllocNativeUObject(TsTaskEnterPatrolState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060039D8 RID: 14808 RVA: 0x00044D14 File Offset: 0x00042F14
	[NullableContext(1)]
	public TsTaskEnterPatrolState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskEnterPatrolState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060039D9 RID: 14809 RVA: 0x00044D47 File Offset: 0x00042F47
	protected TsTaskEnterPatrolState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060039DA RID: 14810 RVA: 0x00044D50 File Offset: 0x00042F50
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000970 RID: 2416
	private const int TRY_CHECK_TIME_INTERVAL = 1000;

	// Token: 0x04000971 RID: 2417
	[Nullable(2)]
	private TimerHandle TimeHandle;

	// Token: 0x04000972 RID: 2418
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskEnterPatrolState.TsTaskEnterPatrolState_C";

	// Token: 0x04000973 RID: 2419
	private static IntPtr _ClassPtr;

	// Token: 0x04000974 RID: 2420
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000975 RID: 2421
	private static int __PropertyOffset_EntityId;
}
