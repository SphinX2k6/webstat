using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CDC RID: 3292
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchFsmState.TsTaskSwitchFsmState_C")]
public class TsTaskSwitchFsmState : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x060040C2 RID: 16578 RVA: 0x00068484 File Offset: 0x00066684
	// (set) Token: 0x060040C3 RID: 16579 RVA: 0x000684BD File Offset: 0x000666BD
	[UProperty(EPropertyFlags.CPF_None)]
	public TArray<string> States
	{
		get
		{
			base.FastCheckIsValid();
			TArray<string> result;
			if ((result = this._States) == null)
			{
				result = (this._States = new TArray<string>(base.NativePtr + (IntPtr)TsTaskSwitchFsmState.__PropertyOffset_States, this));
			}
			return result;
		}
		set
		{
			this.States.CopyAssign(value);
		}
	}

	// Token: 0x060040C4 RID: 16580 RVA: 0x000684CC File Offset: 0x000666CC
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

	// Token: 0x060040C5 RID: 16581 RVA: 0x0006856C File Offset: 0x0006676C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
		}
		base.FinishExecute(true);
	}

	// Token: 0x060040C6 RID: 16582 RVA: 0x000685CE File Offset: 0x000667CE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSwitchFsmState._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchFsmState.TsTaskSwitchFsmState_C");
		}
		return TsTaskSwitchFsmState._ClassPtr;
	}

	// Token: 0x060040C7 RID: 16583 RVA: 0x000685F4 File Offset: 0x000667F4
	public TsTaskSwitchFsmState() : this(BuiltinUtils.AllocNativeUObject(TsTaskSwitchFsmState.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060040C8 RID: 16584 RVA: 0x0006861C File Offset: 0x0006681C
	public TsTaskSwitchFsmState(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSwitchFsmState.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060040C9 RID: 16585 RVA: 0x0006864F File Offset: 0x0006684F
	protected TsTaskSwitchFsmState(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040CA RID: 16586 RVA: 0x00068658 File Offset: 0x00066858
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000F44 RID: 3908
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSwitchFsmState.TsTaskSwitchFsmState_C";

	// Token: 0x04000F45 RID: 3909
	private static IntPtr _ClassPtr;

	// Token: 0x04000F46 RID: 3910
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F47 RID: 3911
	private static int __PropertyOffset_States;

	// Token: 0x04000F48 RID: 3912
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TArray<string> _States;
}
