using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4B RID: 3147
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardIntCompare.TsDecoratorBlackboardIntCompare_C")]
public class TsDecoratorBlackboardIntCompare : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000124 RID: 292
	// (get) Token: 0x06003755 RID: 14165 RVA: 0x0003937B File Offset: 0x0003757B
	// (set) Token: 0x06003756 RID: 14166 RVA: 0x0003938F File Offset: 0x0003758F
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_BlackboardKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x06003757 RID: 14167 RVA: 0x000393A4 File Offset: 0x000375A4
	// (set) Token: 0x06003758 RID: 14168 RVA: 0x000393B8 File Offset: 0x000375B8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> Operation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_Operation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_Operation) = value;
		}
	}

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x06003759 RID: 14169 RVA: 0x000393CD File Offset: 0x000375CD
	// (set) Token: 0x0600375A RID: 14170 RVA: 0x000393DD File Offset: 0x000375DD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_CompareValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorBlackboardIntCompare.__PropertyOffset_CompareValue) = value;
		}
	}

	// Token: 0x0600375B RID: 14171 RVA: 0x000393F0 File Offset: 0x000375F0
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

	// Token: 0x0600375C RID: 14172 RVA: 0x0003943C File Offset: 0x0003763C
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

	// Token: 0x0600375D RID: 14173 RVA: 0x000394DC File Offset: 0x000376DC
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
		int? num = null;
		CharacterStateMachineNewComponent component = charAiDesignComp.Entity.GetComponent<CharacterStateMachineNewComponent>();
		if (component != null)
		{
			AiStateMachineGroup stateMachineGroup = component.StateMachineGroup;
			num = ((stateMachineGroup != null) ? stateMachineGroup.GetCustomBlackboard(this.TsBlackboardKey) : null);
		}
		if (num == null)
		{
			num = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(charAiDesignComp.Entity.Id, this.TsBlackboardKey);
		}
		if (num == null)
		{
			num = new int?(0);
		}
		switch (this.TsOperation)
		{
		case EArithmeticKeyOperation.Equal:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return num2.GetValueOrDefault() == tsCompareValue & num2 != null;
		}
		case EArithmeticKeyOperation.NotEqual:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return !(num2.GetValueOrDefault() == tsCompareValue & num2 != null);
		}
		case EArithmeticKeyOperation.Less:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return num2.GetValueOrDefault() < tsCompareValue & num2 != null;
		}
		case EArithmeticKeyOperation.LessOrEqual:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return num2.GetValueOrDefault() <= tsCompareValue & num2 != null;
		}
		case EArithmeticKeyOperation.Greater:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return num2.GetValueOrDefault() > tsCompareValue & num2 != null;
		}
		case EArithmeticKeyOperation.GreaterOrEqual:
		{
			int? num2 = num;
			int tsCompareValue = this.TsCompareValue;
			return num2.GetValueOrDefault() >= tsCompareValue & num2 != null;
		}
		default:
			return false;
		}
	}

	// Token: 0x0600375E RID: 14174 RVA: 0x0003969F File Offset: 0x0003789F
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorBlackboardIntCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardIntCompare.TsDecoratorBlackboardIntCompare_C");
		}
		return TsDecoratorBlackboardIntCompare._ClassPtr;
	}

	// Token: 0x0600375F RID: 14175 RVA: 0x000396C4 File Offset: 0x000378C4
	public TsDecoratorBlackboardIntCompare() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardIntCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003760 RID: 14176 RVA: 0x000396EC File Offset: 0x000378EC
	[NullableContext(1)]
	public TsDecoratorBlackboardIntCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardIntCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003761 RID: 14177 RVA: 0x0003971F File Offset: 0x0003791F
	protected TsDecoratorBlackboardIntCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003762 RID: 14178 RVA: 0x00039734 File Offset: 0x00037934
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007B2 RID: 1970
	private bool IsInitTsVariables;

	// Token: 0x040007B3 RID: 1971
	[Nullable(1)]
	private string TsBlackboardKey = "";

	// Token: 0x040007B4 RID: 1972
	private EArithmeticKeyOperation TsOperation;

	// Token: 0x040007B5 RID: 1973
	private int TsCompareValue;

	// Token: 0x040007B6 RID: 1974
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorBlackboardIntCompare.TsDecoratorBlackboardIntCompare_C";

	// Token: 0x040007B7 RID: 1975
	private static IntPtr _ClassPtr;

	// Token: 0x040007B8 RID: 1976
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007B9 RID: 1977
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x040007BA RID: 1978
	private static int __PropertyOffset_Operation;

	// Token: 0x040007BB RID: 1979
	private static int __PropertyOffset_CompareValue;
}
