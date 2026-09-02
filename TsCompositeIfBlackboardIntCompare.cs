using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.AI.StateMachine;
using CSharpScript.Game.NewWorld.Character.Common.Component;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C2D RID: 3117
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Composite/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Composite/TsCompositeIfBlackboardIntCompare.TsCompositeIfBlackboardIntCompare_C")]
public class TsCompositeIfBlackboardIntCompare : UBTComposite_If, IUnrealUObject, IUnrealObject
{
	// Token: 0x170000EB RID: 235
	// (get) Token: 0x060035EA RID: 13802 RVA: 0x00033398 File Offset: 0x00031598
	// (set) Token: 0x060035EB RID: 13803 RVA: 0x000333AC File Offset: 0x000315AC
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_BlackboardKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x060035EC RID: 13804 RVA: 0x000333C1 File Offset: 0x000315C1
	// (set) Token: 0x060035ED RID: 13805 RVA: 0x000333D5 File Offset: 0x000315D5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EArithmeticKeyOperation> Operation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_Operation);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_Operation) = value;
		}
	}

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x060035EE RID: 13806 RVA: 0x000333EA File Offset: 0x000315EA
	// (set) Token: 0x060035EF RID: 13807 RVA: 0x000333FA File Offset: 0x000315FA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int CompareValue
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_CompareValue);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsCompositeIfBlackboardIntCompare.__PropertyOffset_CompareValue) = value;
		}
	}

	// Token: 0x060035F0 RID: 13808 RVA: 0x0003340C File Offset: 0x0003160C
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

	// Token: 0x060035F1 RID: 13809 RVA: 0x00033458 File Offset: 0x00031658
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_None)]
	public override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
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

	// Token: 0x060035F2 RID: 13810 RVA: 0x00033622 File Offset: 0x00031822
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsCompositeIfBlackboardIntCompare._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Composite/TsCompositeIfBlackboardIntCompare.TsCompositeIfBlackboardIntCompare_C");
		}
		return TsCompositeIfBlackboardIntCompare._ClassPtr;
	}

	// Token: 0x060035F3 RID: 13811 RVA: 0x00033648 File Offset: 0x00031848
	public TsCompositeIfBlackboardIntCompare() : this(BuiltinUtils.AllocNativeUObject(TsCompositeIfBlackboardIntCompare.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060035F4 RID: 13812 RVA: 0x00033670 File Offset: 0x00031870
	[NullableContext(1)]
	public TsCompositeIfBlackboardIntCompare(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCompositeIfBlackboardIntCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060035F5 RID: 13813 RVA: 0x000336A3 File Offset: 0x000318A3
	protected TsCompositeIfBlackboardIntCompare(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060035F6 RID: 13814 RVA: 0x000336B8 File Offset: 0x000318B8
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTComposite_If.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040006BD RID: 1725
	private bool IsInitTsVariables;

	// Token: 0x040006BE RID: 1726
	[Nullable(1)]
	private string TsBlackboardKey = "";

	// Token: 0x040006BF RID: 1727
	private EArithmeticKeyOperation TsOperation;

	// Token: 0x040006C0 RID: 1728
	private int TsCompareValue;

	// Token: 0x040006C1 RID: 1729
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Composite/TsCompositeIfBlackboardIntCompare.TsCompositeIfBlackboardIntCompare_C";

	// Token: 0x040006C2 RID: 1730
	private static IntPtr _ClassPtr;

	// Token: 0x040006C3 RID: 1731
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040006C4 RID: 1732
	private static int __PropertyOffset_BlackboardKey;

	// Token: 0x040006C5 RID: 1733
	private static int __PropertyOffset_Operation;

	// Token: 0x040006C6 RID: 1734
	private static int __PropertyOffset_CompareValue;
}
