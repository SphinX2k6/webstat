using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C7D RID: 3197
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskChangeNpcAbpState.TsTaskChangeNpcAbpState_C")]
public class TsTaskChangeNpcAbpState : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700017E RID: 382
	// (get) Token: 0x060039BD RID: 14781 RVA: 0x00044611 File Offset: 0x00042811
	// (set) Token: 0x060039BE RID: 14782 RVA: 0x00044621 File Offset: 0x00042821
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeNpcAbpState.__PropertyOffset_EntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeNpcAbpState.__PropertyOffset_EntityId) = value;
		}
	}

	// Token: 0x1700017F RID: 383
	// (get) Token: 0x060039BF RID: 14783 RVA: 0x00044632 File Offset: 0x00042832
	// (set) Token: 0x060039C0 RID: 14784 RVA: 0x00044646 File Offset: 0x00042846
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetState
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskChangeNpcAbpState.__PropertyOffset_TargetState)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskChangeNpcAbpState.__PropertyOffset_TargetState)), value);
		}
	}

	// Token: 0x060039C1 RID: 14785 RVA: 0x0004465C File Offset: 0x0004285C
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

	// Token: 0x060039C2 RID: 14786 RVA: 0x000446F8 File Offset: 0x000428F8
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
		Entity entity = (charActorComp != null) ? charActorComp.Entity : null;
		NpcPerformComponent performComp = (entity != null) ? entity.GetComponent<NpcPerformComponent>() : null;
		if (performComp == null)
		{
			base.FinishExecute(true);
			return;
		}
		Action<int> <>9__1;
		this.Handle = TimerSystem.Instance.Delay(delegate(float _)
		{
			this.Handle = null;
			BasePerformComponent performComp = performComp;
			EPerformMode mode = EPerformMode.Ecology;
			SwitchState switchState = new SwitchState();
			switchState.TargetStateName = this.TargetState;
			switchState.IsNoTransition = new bool?(false);
			switchState.Context = "TsTaskChangeNpcApbState";
			Action<int> onBeforeExecute = null;
			Action<int> onAfterExecute;
			if ((onAfterExecute = <>9__1) == null)
			{
				onAfterExecute = (<>9__1 = delegate(int _)
				{
					this.FinishExecute(true);
				});
			}
			performComp.PerformSwitchState(mode, switchState, onBeforeExecute, onAfterExecute);
		}, 100f, null, null, true, 1f);
	}

	// Token: 0x060039C3 RID: 14787 RVA: 0x000447C2 File Offset: 0x000429C2
	protected override void OnAbort()
	{
		if (this.Handle != null)
		{
			TimerSystem.Instance.Remove(this.Handle);
		}
		this.Handle = null;
	}

	// Token: 0x060039C4 RID: 14788 RVA: 0x000447E4 File Offset: 0x000429E4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskChangeNpcAbpState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskChangeNpcAbpState.TsTaskChangeNpcAbpState_C");
		}
		return TsTaskChangeNpcAbpState._ClassPtr;
	}

	// Token: 0x060039C5 RID: 14789 RVA: 0x00044808 File Offset: 0x00042A08
	public TsTaskChangeNpcAbpState() : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeNpcAbpState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060039C6 RID: 14790 RVA: 0x00044830 File Offset: 0x00042A30
	public TsTaskChangeNpcAbpState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeNpcAbpState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060039C7 RID: 14791 RVA: 0x00044863 File Offset: 0x00042A63
	protected TsTaskChangeNpcAbpState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060039C8 RID: 14792 RVA: 0x0004486C File Offset: 0x00042A6C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000966 RID: 2406
	private const float DEFAULT_BLEND_TIME = 100f;

	// Token: 0x04000967 RID: 2407
	[Nullable(2)]
	private TimerHandle Handle;

	// Token: 0x04000968 RID: 2408
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskChangeNpcAbpState.TsTaskChangeNpcAbpState_C";

	// Token: 0x04000969 RID: 2409
	private static IntPtr _ClassPtr;

	// Token: 0x0400096A RID: 2410
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400096B RID: 2411
	private static int __PropertyOffset_EntityId;

	// Token: 0x0400096C RID: 2412
	private static int __PropertyOffset_TargetState;
}
