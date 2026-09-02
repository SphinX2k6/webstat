using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4C RID: 3148
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardStringCompare.TsDecoratorBlackboardStringCompare_C")]
public class TsDecoratorBlackboardStringCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000127 RID: 295
	// (get) Token: 0x06003763 RID: 14179 RVA: 0x00039767 File Offset: 0x00037967
	// (set) Token: 0x06003764 RID: 14180 RVA: 0x0003977B File Offset: 0x0003797B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x06003765 RID: 14181 RVA: 0x00039790 File Offset: 0x00037990
	// (set) Token: 0x06003766 RID: 14182 RVA: 0x000397A0 File Offset: 0x000379A0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Positive
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_Positive) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_Positive) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x06003767 RID: 14183 RVA: 0x000397B1 File Offset: 0x000379B1
	// (set) Token: 0x06003768 RID: 14184 RVA: 0x000397C1 File Offset: 0x000379C1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool Exactly
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_Exactly) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_Exactly) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x06003769 RID: 14185 RVA: 0x000397D2 File Offset: 0x000379D2
	// (set) Token: 0x0600376A RID: 14186 RVA: 0x000397E6 File Offset: 0x000379E6
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string CompareValue
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_CompareValue)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardStringCompare.__PropertyOffset_CompareValue)), value);
		}
	}

	// Token: 0x0600376B RID: 14187 RVA: 0x000397FC File Offset: 0x000379FC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsPositive = this.Positive;
			this.TsExactly = this.Exactly;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x0600376C RID: 14188 RVA: 0x00039850 File Offset: 0x00037A50
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

	// Token: 0x0600376D RID: 14189 RVA: 0x000398F0 File Offset: 0x00037AF0
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
		string stringValueByEntity = ControllerBase<BlackboardController>.Instance.GetStringValueByEntity(charAiDesignComp.Entity.Id, this.TsBlackboardKey);
		return (this.TsExactly ? (stringValueByEntity == this.TsCompareValue) : stringValueByEntity.Contains(this.TsCompareValue)) == this.TsPositive;
	}

	// Token: 0x0600376E RID: 14190 RVA: 0x0003999A File Offset: 0x00037B9A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardStringCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardStringCompare.TsDecoratorBlackboardStringCompare_C");
		}
		return TsDecoratorBlackboardStringCompare._ClassPtr;
	}

	// Token: 0x0600376F RID: 14191 RVA: 0x000399C0 File Offset: 0x00037BC0
	public TsDecoratorBlackboardStringCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardStringCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003770 RID: 14192 RVA: 0x000399E8 File Offset: 0x00037BE8
	public TsDecoratorBlackboardStringCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardStringCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003771 RID: 14193 RVA: 0x00039A1B File Offset: 0x00037C1B
	protected TsDecoratorBlackboardStringCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003772 RID: 14194 RVA: 0x00039A3C File Offset: 0x00037C3C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007BC RID: 1980
	private bool IsInitTsVariables;

	// Token: 0x040007BD RID: 1981
	private string TsBlackboardKey = "";

	// Token: 0x040007BE RID: 1982
	private bool TsPositive;

	// Token: 0x040007BF RID: 1983
	private bool TsExactly;

	// Token: 0x040007C0 RID: 1984
	private string TsCompareValue = "";

	// Token: 0x040007C1 RID: 1985
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardStringCompare.TsDecoratorBlackboardStringCompare_C";

	// Token: 0x040007C2 RID: 1986
	private static IntPtr _ClassPtr;

	// Token: 0x040007C3 RID: 1987
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007C4 RID: 1988
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x040007C5 RID: 1989
	private static int __PropertyOffset_Positive;

	// Token: 0x040007C6 RID: 1990
	private static int __PropertyOffset_Exactly;

	// Token: 0x040007C7 RID: 1991
	private static int __PropertyOffset_CompareValue;
}
