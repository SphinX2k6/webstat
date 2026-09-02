using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C49 RID: 3145
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardFloatCompare.TsDecoratorBlackboardFloatCompare_C")]
public class TsDecoratorBlackboardFloatCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700011F RID: 287
	// (get) Token: 0x0600373B RID: 14139 RVA: 0x00038AFB File Offset: 0x00036CFB
	// (set) Token: 0x0600373C RID: 14140 RVA: 0x00038B0F File Offset: 0x00036D0F
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_BlackboardKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x0600373D RID: 14141 RVA: 0x00038B24 File Offset: 0x00036D24
	// (set) Token: 0x0600373E RID: 14142 RVA: 0x00038B38 File Offset: 0x00036D38
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> Operation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_Operation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_Operation) = value;
		}
	}

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x0600373F RID: 14143 RVA: 0x00038B4D File Offset: 0x00036D4D
	// (set) Token: 0x06003740 RID: 14144 RVA: 0x00038B5D File Offset: 0x00036D5D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_CompareValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardFloatCompare.__PropertyOffset_CompareValue) = value;
		}
	}

	// Token: 0x06003741 RID: 14145 RVA: 0x00038B70 File Offset: 0x00036D70
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsOperation = this.Operation;
			this.TsCompareValue = this.CompareValue;
		}
	}

	// Token: 0x06003742 RID: 14146 RVA: 0x00038BBC File Offset: 0x00036DBC
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

	// Token: 0x06003743 RID: 14147 RVA: 0x00038C5C File Offset: 0x00036E5C
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
		float? floatValueByEntity = ControllerBase<BlackboardController>.Instance.GetFloatValueByEntity(charAiDesignComp.Entity.Id, this.TsBlackboardKey);
		if (floatValueByEntity == null)
		{
			floatValueByEntity = new float?(0f);
		}
		switch (this.TsOperation)
		{
		case EArithmeticKeyOperation.Equal:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return num.GetValueOrDefault() == tsCompareValue & num != null;
		}
		case EArithmeticKeyOperation.NotEqual:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return !(num.GetValueOrDefault() == tsCompareValue & num != null);
		}
		case EArithmeticKeyOperation.Less:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return num.GetValueOrDefault() < tsCompareValue & num != null;
		}
		case EArithmeticKeyOperation.LessOrEqual:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return num.GetValueOrDefault() <= tsCompareValue & num != null;
		}
		case EArithmeticKeyOperation.Greater:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return num.GetValueOrDefault() > tsCompareValue & num != null;
		}
		case EArithmeticKeyOperation.GreaterOrEqual:
		{
			float? num = floatValueByEntity;
			float tsCompareValue = this.TsCompareValue;
			return num.GetValueOrDefault() >= tsCompareValue & num != null;
		}
		default:
			return false;
		}
	}

	// Token: 0x06003744 RID: 14148 RVA: 0x00038DE1 File Offset: 0x00036FE1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardFloatCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardFloatCompare.TsDecoratorBlackboardFloatCompare_C");
		}
		return TsDecoratorBlackboardFloatCompare._ClassPtr;
	}

	// Token: 0x06003745 RID: 14149 RVA: 0x00038E08 File Offset: 0x00037008
	public TsDecoratorBlackboardFloatCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardFloatCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003746 RID: 14150 RVA: 0x00038E30 File Offset: 0x00037030
	[NullableContext(1)]
	public TsDecoratorBlackboardFloatCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardFloatCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003747 RID: 14151 RVA: 0x00038E63 File Offset: 0x00037063
	protected TsDecoratorBlackboardFloatCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003748 RID: 14152 RVA: 0x00038E78 File Offset: 0x00037078
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007A0 RID: 1952
	private bool IsInitTsVariables;

	// Token: 0x040007A1 RID: 1953
	[Nullable(1)]
	private string TsBlackboardKey = "";

	// Token: 0x040007A2 RID: 1954
	private EArithmeticKeyOperation TsOperation;

	// Token: 0x040007A3 RID: 1955
	private float TsCompareValue;

	// Token: 0x040007A4 RID: 1956
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardFloatCompare.TsDecoratorBlackboardFloatCompare_C";

	// Token: 0x040007A5 RID: 1957
	private static IntPtr _ClassPtr;

	// Token: 0x040007A6 RID: 1958
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007A7 RID: 1959
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x040007A8 RID: 1960
	private static int __PropertyOffset_Operation;

	// Token: 0x040007A9 RID: 1961
	private static int __PropertyOffset_CompareValue;
}
