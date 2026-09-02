using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA4 RID: 3236
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetString.TsTaskBlackBoardSetString_C")]
public class TsTaskBlackBoardSetString : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001F1 RID: 497
	// (get) Token: 0x06003C8F RID: 15503 RVA: 0x000534B3 File Offset: 0x000516B3
	// (set) Token: 0x06003C90 RID: 15504 RVA: 0x000534C7 File Offset: 0x000516C7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StringName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBlackBoardSetString.__PropertyOffset_StringName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBlackBoardSetString.__PropertyOffset_StringName)), value);
		}
	}

	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x06003C91 RID: 15505 RVA: 0x000534DC File Offset: 0x000516DC
	// (set) Token: 0x06003C92 RID: 15506 RVA: 0x000534F0 File Offset: 0x000516F0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string StringValue
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBlackBoardSetString.__PropertyOffset_StringValue)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBlackBoardSetString.__PropertyOffset_StringValue)), value);
		}
	}

	// Token: 0x06003C93 RID: 15507 RVA: 0x00053508 File Offset: 0x00051708
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitTsVariables()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitTsVariables"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003C94 RID: 15508 RVA: 0x00053578 File Offset: 0x00051778
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsStringName = this.StringName;
			this.TsStringValue = this.StringValue;
		}
	}

	// Token: 0x06003C95 RID: 15509 RVA: 0x000535A8 File Offset: 0x000517A8
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

	// Token: 0x06003C96 RID: 15510 RVA: 0x00053644 File Offset: 0x00051844
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
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		int id = aiController.CharActorComp.Entity.Id;
		ControllerBase<BlackboardController>.Instance.SetStringValueByEntity(id, this.TsStringName, this.TsStringValue);
		base.FinishExecute(true);
	}

	// Token: 0x06003C97 RID: 15511 RVA: 0x000536D7 File Offset: 0x000518D7
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskBlackBoardSetString._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetString.TsTaskBlackBoardSetString_C");
		}
		return TsTaskBlackBoardSetString._ClassPtr;
	}

	// Token: 0x06003C98 RID: 15512 RVA: 0x000536FC File Offset: 0x000518FC
	public TsTaskBlackBoardSetString() : this(BuiltinUtils.AllocNativeUObject(TsTaskBlackBoardSetString.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C99 RID: 15513 RVA: 0x00053724 File Offset: 0x00051924
	public TsTaskBlackBoardSetString(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBlackBoardSetString.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C9A RID: 15514 RVA: 0x00053757 File Offset: 0x00051957
	protected TsTaskBlackBoardSetString(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C9B RID: 15515 RVA: 0x00053776 File Offset: 0x00051976
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003C9C RID: 15516 RVA: 0x00053780 File Offset: 0x00051980
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BA5 RID: 2981
	private bool IsInitTsVariables;

	// Token: 0x04000BA6 RID: 2982
	private string TsStringName = "";

	// Token: 0x04000BA7 RID: 2983
	private string TsStringValue = "";

	// Token: 0x04000BA8 RID: 2984
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBlackBoardSetString.TsTaskBlackBoardSetString_C";

	// Token: 0x04000BA9 RID: 2985
	private static IntPtr _ClassPtr;

	// Token: 0x04000BAA RID: 2986
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BAB RID: 2987
	private static int __PropertyOffset_StringName;

	// Token: 0x04000BAC RID: 2988
	private static int __PropertyOffset_StringValue;
}
