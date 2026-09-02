using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CAF RID: 3247
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskExecuteEvent.TsTaskExecuteEvent_C")]
public class TsTaskExecuteEvent : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06003D3F RID: 15679 RVA: 0x000565B3 File Offset: 0x000547B3
	// (set) Token: 0x06003D40 RID: 15680 RVA: 0x000565C3 File Offset: 0x000547C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int EventGroupId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskExecuteEvent.__PropertyOffset_EventGroupId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskExecuteEvent.__PropertyOffset_EventGroupId) = value;
		}
	}

	// Token: 0x06003D41 RID: 15681 RVA: 0x000565D4 File Offset: 0x000547D4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
		}
	}

	// Token: 0x06003D42 RID: 15682 RVA: 0x000565EC File Offset: 0x000547EC
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

	// Token: 0x06003D43 RID: 15683 RVA: 0x00056688 File Offset: 0x00054888
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
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
			return;
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003D44 RID: 15684 RVA: 0x000566F1 File Offset: 0x000548F1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskExecuteEvent._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskExecuteEvent.TsTaskExecuteEvent_C");
		}
		return TsTaskExecuteEvent._ClassPtr;
	}

	// Token: 0x06003D45 RID: 15685 RVA: 0x00056718 File Offset: 0x00054918
	public TsTaskExecuteEvent() : this(BuiltinUtils.AllocNativeUObject(TsTaskExecuteEvent.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003D46 RID: 15686 RVA: 0x00056740 File Offset: 0x00054940
	[NullableContext(1)]
	public TsTaskExecuteEvent(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskExecuteEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003D47 RID: 15687 RVA: 0x00056773 File Offset: 0x00054973
	protected TsTaskExecuteEvent(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003D48 RID: 15688 RVA: 0x0005677C File Offset: 0x0005497C
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000C24 RID: 3108
	private bool IsInitTsVariables;

	// Token: 0x04000C25 RID: 3109
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskExecuteEvent.TsTaskExecuteEvent_C";

	// Token: 0x04000C26 RID: 3110
	private static IntPtr _ClassPtr;

	// Token: 0x04000C27 RID: 3111
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000C28 RID: 3112
	private static int __PropertyOffset_EventGroupId;
}
