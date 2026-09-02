using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C46 RID: 3142
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboard.TsDecoratorBlackboard_C")]
public class TsDecoratorBlackboard : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000118 RID: 280
	// (get) Token: 0x06003715 RID: 14101 RVA: 0x0003818F File Offset: 0x0003638F
	// (set) Token: 0x06003716 RID: 14102 RVA: 0x000381A3 File Offset: 0x000363A3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyName
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboard.__PropertyOffset_BlackboardKeyName)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboard.__PropertyOffset_BlackboardKeyName)), value);
		}
	}

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x06003717 RID: 14103 RVA: 0x000381B8 File Offset: 0x000363B8
	// (set) Token: 0x06003718 RID: 14104 RVA: 0x000381C8 File Offset: 0x000363C8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsSet
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboard.__PropertyOffset_IsSet) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboard.__PropertyOffset_IsSet) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003719 RID: 14105 RVA: 0x000381D9 File Offset: 0x000363D9
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKeyName = this.BlackboardKeyName;
			this.TsIsSet = this.IsSet;
		}
	}

	// Token: 0x0600371A RID: 14106 RVA: 0x0003820C File Offset: 0x0003640C
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

	// Token: 0x0600371B RID: 14107 RVA: 0x000382AC File Offset: 0x000364AC
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
		this.InitTsVariables();
		bool flag = ControllerBase<BlackboardController>.Instance.HasValueByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyName);
		return this.TsIsSet == flag;
	}

	// Token: 0x0600371C RID: 14108 RVA: 0x0003832D File Offset: 0x0003652D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboard._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboard.TsDecoratorBlackboard_C");
		}
		return TsDecoratorBlackboard._ClassPtr;
	}

	// Token: 0x0600371D RID: 14109 RVA: 0x00038354 File Offset: 0x00036554
	public TsDecoratorBlackboard() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboard.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600371E RID: 14110 RVA: 0x0003837C File Offset: 0x0003657C
	public TsDecoratorBlackboard(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600371F RID: 14111 RVA: 0x000383AF File Offset: 0x000365AF
	protected TsDecoratorBlackboard(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003720 RID: 14112 RVA: 0x000383C4 File Offset: 0x000365C4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000783 RID: 1923
	private bool IsInitTsVariables;

	// Token: 0x04000784 RID: 1924
	private string TsBlackboardKeyName = "";

	// Token: 0x04000785 RID: 1925
	private bool TsIsSet;

	// Token: 0x04000786 RID: 1926
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboard.TsDecoratorBlackboard_C";

	// Token: 0x04000787 RID: 1927
	private static IntPtr _ClassPtr;

	// Token: 0x04000788 RID: 1928
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000789 RID: 1929
	private static int __PropertyOffset_BlackboardKeyName;

	// Token: 0x0400078A RID: 1930
	private static int __PropertyOffset_IsSet;
}
