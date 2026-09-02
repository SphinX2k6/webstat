using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE4 RID: 3300
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkill.TsTaskUseSkill_C")]
public class TsTaskUseSkill : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x06004155 RID: 16725 RVA: 0x0006B2F4 File Offset: 0x000694F4
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

	// Token: 0x06004156 RID: 16726 RVA: 0x0006B38D File Offset: 0x0006958D
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.WaitingSkill = false;
	}

	// Token: 0x06004157 RID: 16727 RVA: 0x0006B398 File Offset: 0x00069598
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveTickAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			ptr2->DeltaSeconds = deltaSeconds;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x06004158 RID: 16728 RVA: 0x0006B438 File Offset: 0x00069638
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsTaskUseSkill.<>c__DisplayClass4_0 CS$<>8__locals1 = new TsTaskUseSkill.<>c__DisplayClass4_0();
		CS$<>8__locals1.<>4__this = this;
		TsTaskUseSkill.<>c__DisplayClass4_0 CS$<>8__locals2 = CS$<>8__locals1;
		TsAiController tsAiController = ownerController as TsAiController;
		CS$<>8__locals2.aiController = ((tsAiController != null) ? tsAiController.AiController : null);
		if (CS$<>8__locals1.aiController == null)
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
		CS$<>8__locals1.entityId = CS$<>8__locals1.aiController.CharAiDesignComp.Entity.Id;
		CharacterSkillComponent component = CS$<>8__locals1.aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		string text = ControllerBase<BlackboardController>.Instance.GetStringValueByEntity(CS$<>8__locals1.entityId, "SkillId");
		if (string.IsNullOrEmpty(text))
		{
			text = "0";
		}
		if (this.WaitingSkill)
		{
			return;
		}
		this.WaitingSkill = true;
		BaseSkillComponent baseSkillComponent = component;
		int skillId = int.Parse(text);
		SkillParam skillParam = new SkillParam();
		EntityHandle currentTarget = CS$<>8__locals1.aiController.AiHateList.GetCurrentTarget();
		skillParam.Target = ((currentTarget != null) ? currentTarget.Entity : null);
		skillParam.Reason = "TsTaskUseSkill.ReceiveTickAI";
		baseSkillComponent.BeginSkillAsync(skillId, skillParam).ContinueWith(delegate(bool result)
		{
			CS$<>8__locals1.<>4__this.FinishExecute(result);
			if (result && CS$<>8__locals1.aiController.AiSkill != null)
			{
				CS$<>8__locals1.aiController.AiSkill.SetSkillCdFromNow(ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(CS$<>8__locals1.entityId, "SkillInfoId"));
			}
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(CS$<>8__locals1.entityId, "SkillId");
			ControllerBase<BlackboardController>.Instance.RemoveValueByEntity(CS$<>8__locals1.entityId, "SkillInfoId");
		});
	}

	// Token: 0x06004159 RID: 16729 RVA: 0x0006B573 File Offset: 0x00069773
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskUseSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkill.TsTaskUseSkill_C");
		}
		return TsTaskUseSkill._ClassPtr;
	}

	// Token: 0x0600415A RID: 16730 RVA: 0x0006B598 File Offset: 0x00069798
	public TsTaskUseSkill() : this(BuiltinUtils.AllocNativeUObject(TsTaskUseSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600415B RID: 16731 RVA: 0x0006B5C0 File Offset: 0x000697C0
	[NullableContext(1)]
	public TsTaskUseSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskUseSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600415C RID: 16732 RVA: 0x0006B5F3 File Offset: 0x000697F3
	protected TsTaskUseSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600415D RID: 16733 RVA: 0x0006B5FC File Offset: 0x000697FC
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600415E RID: 16734 RVA: 0x0006B62C File Offset: 0x0006982C
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000FC9 RID: 4041
	private bool WaitingSkill;

	// Token: 0x04000FCA RID: 4042
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskUseSkill.TsTaskUseSkill_C";

	// Token: 0x04000FCB RID: 4043
	private static IntPtr _ClassPtr;

	// Token: 0x04000FCC RID: 4044
	private static IntPtr _ClassDefaultObjectPtr;
}
