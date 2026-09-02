using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C98 RID: 3224
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAbortImmediatelyBase.TsTaskAbortImmediatelyBase_C")]
public class TsTaskAbortImmediatelyBase : UBTTask_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06003BB8 RID: 15288 RVA: 0x0004F1D8 File Offset: 0x0004D3D8
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveAbortAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveAbortAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveAbortAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveAbortAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveAbortAI_FunctionParams) & -16L);
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

	// Token: 0x06003BB9 RID: 15289 RVA: 0x0004F271 File Offset: 0x0004D471
	[NullableContext(2)]
	protected virtual void ReceiveAbortAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		base.FinishAbort();
		this.OnAbort();
		this.OnClear();
	}

	// Token: 0x06003BBA RID: 15290 RVA: 0x0004F285 File Offset: 0x0004D485
	protected void Finish(bool bSuccess)
	{
		base.FinishExecute(bSuccess);
		this.OnClear();
	}

	// Token: 0x06003BBB RID: 15291 RVA: 0x0004F294 File Offset: 0x0004D494
	protected virtual void OnAbort()
	{
	}

	// Token: 0x06003BBC RID: 15292 RVA: 0x0004F296 File Offset: 0x0004D496
	protected virtual void OnClear()
	{
	}

	// Token: 0x06003BBD RID: 15293 RVA: 0x0004F298 File Offset: 0x0004D498
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAbortImmediatelyBase._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAbortImmediatelyBase.TsTaskAbortImmediatelyBase_C");
		}
		return TsTaskAbortImmediatelyBase._ClassPtr;
	}

	// Token: 0x06003BBE RID: 15294 RVA: 0x0004F2BC File Offset: 0x0004D4BC
	public TsTaskAbortImmediatelyBase() : this(BuiltinUtils.AllocNativeUObject(TsTaskAbortImmediatelyBase.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003BBF RID: 15295 RVA: 0x0004F2E4 File Offset: 0x0004D4E4
	[NullableContext(1)]
	public TsTaskAbortImmediatelyBase(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAbortImmediatelyBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003BC0 RID: 15296 RVA: 0x0004F317 File Offset: 0x0004D517
	protected TsTaskAbortImmediatelyBase(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003BC1 RID: 15297 RVA: 0x0004F320 File Offset: 0x0004D520
	protected unsafe virtual void __CPPCALL_ReceiveAbortAI_Implementation(UBTTask_BlueprintBase.__ReceiveAbortAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveAbortAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B01 RID: 2817
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAbortImmediatelyBase.TsTaskAbortImmediatelyBase_C";

	// Token: 0x04000B02 RID: 2818
	private static IntPtr _ClassPtr;

	// Token: 0x04000B03 RID: 2819
	private static IntPtr _ClassDefaultObjectPtr;
}
