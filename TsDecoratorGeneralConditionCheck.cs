using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C5D RID: 3165
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeneralConditionCheck.TsDecoratorGeneralConditionCheck_C")]
public class TsDecoratorGeneralConditionCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000142 RID: 322
	// (get) Token: 0x06003824 RID: 14372 RVA: 0x0003C6DF File Offset: 0x0003A8DF
	// (set) Token: 0x06003825 RID: 14373 RVA: 0x0003C6F3 File Offset: 0x0003A8F3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string ConditionGroupId
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorGeneralConditionCheck.__PropertyOffset_ConditionGroupId)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorGeneralConditionCheck.__PropertyOffset_ConditionGroupId)), value);
		}
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x06003826 RID: 14374 RVA: 0x0003C708 File Offset: 0x0003A908
	// (set) Token: 0x06003827 RID: 14375 RVA: 0x0003C718 File Offset: 0x0003A918
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorGeneralConditionCheck.__PropertyOffset_CompareValue) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorGeneralConditionCheck.__PropertyOffset_CompareValue) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003828 RID: 14376 RVA: 0x0003C729 File Offset: 0x0003A929
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsConditionGroupId = this.ConditionGroupId;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x06003829 RID: 14377 RVA: 0x0003C75C File Offset: 0x0003A95C
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x0600382A RID: 14378 RVA: 0x0003C7FB File Offset: 0x0003A9FB
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		return this.TsConditionGroupId != "" && ControllerBase<LevelGeneralController>.Instance.CheckCondition(this.TsConditionGroupId, null, true, Array.Empty<object>()) == this.TsCompareValue;
	}

	// Token: 0x0600382B RID: 14379 RVA: 0x0003C836 File Offset: 0x0003AA36
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorGeneralConditionCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeneralConditionCheck.TsDecoratorGeneralConditionCheck_C");
		}
		return TsDecoratorGeneralConditionCheck._ClassPtr;
	}

	// Token: 0x0600382C RID: 14380 RVA: 0x0003C85C File Offset: 0x0003AA5C
	public TsDecoratorGeneralConditionCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeneralConditionCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600382D RID: 14381 RVA: 0x0003C884 File Offset: 0x0003AA84
	public TsDecoratorGeneralConditionCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeneralConditionCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600382E RID: 14382 RVA: 0x0003C8B7 File Offset: 0x0003AAB7
	protected TsDecoratorGeneralConditionCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600382F RID: 14383 RVA: 0x0003C8CC File Offset: 0x0003AACC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000838 RID: 2104
	private bool IsInitTsVariables;

	// Token: 0x04000839 RID: 2105
	private string TsConditionGroupId = "";

	// Token: 0x0400083A RID: 2106
	private bool TsCompareValue;

	// Token: 0x0400083B RID: 2107
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorGeneralConditionCheck.TsDecoratorGeneralConditionCheck_C";

	// Token: 0x0400083C RID: 2108
	private static IntPtr _ClassPtr;

	// Token: 0x0400083D RID: 2109
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400083E RID: 2110
	private static int __PropertyOffset_ConditionGroupId;

	// Token: 0x0400083F RID: 2111
	private static int __PropertyOffset_CompareValue;
}
