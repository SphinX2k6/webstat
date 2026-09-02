using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C47 RID: 3143
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardBooleanCompare.TsDecoratorBlackboardBooleanCompare_C")]
public class TsDecoratorBlackboardBooleanCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700011A RID: 282
	// (get) Token: 0x06003721 RID: 14113 RVA: 0x000383F7 File Offset: 0x000365F7
	// (set) Token: 0x06003722 RID: 14114 RVA: 0x0003840B File Offset: 0x0003660B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardBooleanCompare.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardBooleanCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x06003723 RID: 14115 RVA: 0x00038420 File Offset: 0x00036620
	// (set) Token: 0x06003724 RID: 14116 RVA: 0x00038430 File Offset: 0x00036630
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardBooleanCompare.__PropertyOffset_CompareValue) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardBooleanCompare.__PropertyOffset_CompareValue) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003725 RID: 14117 RVA: 0x00038441 File Offset: 0x00036641
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x06003726 RID: 14118 RVA: 0x00038474 File Offset: 0x00036674
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

	// Token: 0x06003727 RID: 14119 RVA: 0x00038514 File Offset: 0x00036714
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		AiController aiController = (ownerController as TsAiController).AiController;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
		if (charAiDesignComp == null)
		{
			return false;
		}
		this.InitTsVariables();
		if (ControllerBase<BlackboardController>.Instance.GetBooleanValueByEntity(charAiDesignComp.Entity.Id, this.TsBlackboardKey).GetValueOrDefault())
		{
			return this.TsCompareValue;
		}
		return !this.TsCompareValue;
	}

	// Token: 0x06003728 RID: 14120 RVA: 0x000385AD File Offset: 0x000367AD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardBooleanCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardBooleanCompare.TsDecoratorBlackboardBooleanCompare_C");
		}
		return TsDecoratorBlackboardBooleanCompare._ClassPtr;
	}

	// Token: 0x06003729 RID: 14121 RVA: 0x000385D4 File Offset: 0x000367D4
	public TsDecoratorBlackboardBooleanCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardBooleanCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600372A RID: 14122 RVA: 0x000385FC File Offset: 0x000367FC
	public TsDecoratorBlackboardBooleanCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardBooleanCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600372B RID: 14123 RVA: 0x0003862F File Offset: 0x0003682F
	protected TsDecoratorBlackboardBooleanCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600372C RID: 14124 RVA: 0x00038644 File Offset: 0x00036844
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400078B RID: 1931
	private bool IsInitTsVariables;

	// Token: 0x0400078C RID: 1932
	private string TsBlackboardKey = "";

	// Token: 0x0400078D RID: 1933
	private bool TsCompareValue;

	// Token: 0x0400078E RID: 1934
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardBooleanCompare.TsDecoratorBlackboardBooleanCompare_C";

	// Token: 0x0400078F RID: 1935
	private static IntPtr _ClassPtr;

	// Token: 0x04000790 RID: 1936
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000791 RID: 1937
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x04000792 RID: 1938
	private static int __PropertyOffset_CompareValue;
}
