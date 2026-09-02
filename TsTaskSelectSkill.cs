using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD1 RID: 3281
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectSkill.TsTaskSelectSkill_C")]
public class TsTaskSelectSkill : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002C1 RID: 705
	// (get) Token: 0x06004020 RID: 16416 RVA: 0x00064E61 File Offset: 0x00063061
	// (set) Token: 0x06004021 RID: 16417 RVA: 0x00064E71 File Offset: 0x00063071
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectSkill.__PropertyOffset_SkillType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectSkill.__PropertyOffset_SkillType) = value;
		}
	}

	// Token: 0x170002C2 RID: 706
	// (get) Token: 0x06004022 RID: 16418 RVA: 0x00064E82 File Offset: 0x00063082
	// (set) Token: 0x06004023 RID: 16419 RVA: 0x00064E92 File Offset: 0x00063092
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugLog
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSelectSkill.__PropertyOffset_DebugLog) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSelectSkill.__PropertyOffset_DebugLog) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004024 RID: 16420 RVA: 0x00064EA3 File Offset: 0x000630A3
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSkillType = this.SkillType;
			this.TsDebugLog = this.DebugLog;
		}
	}

	// Token: 0x06004025 RID: 16421 RVA: 0x00064ED4 File Offset: 0x000630D4
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

	// Token: 0x06004026 RID: 16422 RVA: 0x00064F74 File Offset: 0x00063174
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
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
		if (aiController.AiSkill == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "没有配置技能";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		CharacterSkillComponent component = aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget != null && currentTarget.Valid)
		{
			if (AiLibrary.SelectSkillWithTarget(aiController, component, currentTarget.Entity.GetComponent<CharacterActorComponent>(), this.TsSkillType, this.TsDebugLog))
			{
				base.FinishExecute(true);
				return;
			}
			base.FinishExecute(false);
			return;
		}
		else
		{
			if (AiLibrary.SelectSkillWithoutTarget(aiController, component, this.TsSkillType))
			{
				base.FinishExecute(true);
				return;
			}
			base.FinishExecute(false);
			return;
		}
	}

	// Token: 0x06004027 RID: 16423 RVA: 0x000650AD File Offset: 0x000632AD
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSelectSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectSkill.TsTaskSelectSkill_C");
		}
		return TsTaskSelectSkill._ClassPtr;
	}

	// Token: 0x06004028 RID: 16424 RVA: 0x000650D4 File Offset: 0x000632D4
	public TsTaskSelectSkill() : this(BuiltinUtils.AllocNativeUObject(TsTaskSelectSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004029 RID: 16425 RVA: 0x000650FC File Offset: 0x000632FC
	[NullableContext(1)]
	public TsTaskSelectSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSelectSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600402A RID: 16426 RVA: 0x0006512F File Offset: 0x0006332F
	protected TsTaskSelectSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600402B RID: 16427 RVA: 0x00065138 File Offset: 0x00063338
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000EB4 RID: 3764
	private bool IsInitTsVariables;

	// Token: 0x04000EB5 RID: 3765
	private int TsSkillType;

	// Token: 0x04000EB6 RID: 3766
	private bool TsDebugLog;

	// Token: 0x04000EB7 RID: 3767
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSelectSkill.TsTaskSelectSkill_C";

	// Token: 0x04000EB8 RID: 3768
	private static IntPtr _ClassPtr;

	// Token: 0x04000EB9 RID: 3769
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000EBA RID: 3770
	private static int __PropertyOffset_SkillType;

	// Token: 0x04000EBB RID: 3771
	private static int __PropertyOffset_DebugLog;
}
