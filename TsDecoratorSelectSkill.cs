using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C67 RID: 3175
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSelectSkill.TsDecoratorSelectSkill_C")]
public class TsDecoratorSelectSkill : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700014E RID: 334
	// (get) Token: 0x0600388A RID: 14474 RVA: 0x0003DE57 File Offset: 0x0003C057
	// (set) Token: 0x0600388B RID: 14475 RVA: 0x0003DE67 File Offset: 0x0003C067
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorSelectSkill.__PropertyOffset_SkillType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorSelectSkill.__PropertyOffset_SkillType) = value;
		}
	}

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x0600388C RID: 14476 RVA: 0x0003DE78 File Offset: 0x0003C078
	// (set) Token: 0x0600388D RID: 14477 RVA: 0x0003DE88 File Offset: 0x0003C088
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugLog
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorSelectSkill.__PropertyOffset_DebugLog) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorSelectSkill.__PropertyOffset_DebugLog) = (value ? 1 : 0);
		}
	}

	// Token: 0x0600388E RID: 14478 RVA: 0x0003DE99 File Offset: 0x0003C099
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSkillType = this.SkillType;
			this.TsDebugLog = this.DebugLog;
		}
	}

	// Token: 0x0600388F RID: 14479 RVA: 0x0003DECC File Offset: 0x0003C0CC
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

	// Token: 0x06003890 RID: 14480 RVA: 0x0003DF6C File Offset: 0x0003C16C
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
		if (aiController.AiSkill == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "没有配置技能";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return false;
		}
		CharacterSkillComponent component = aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		if (!component.Valid)
		{
			return false;
		}
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget != null && currentTarget.Valid)
		{
			return AiLibrary.SelectSkillWithTarget(aiController, component, currentTarget.Entity.GetComponent<CharacterActorComponent>(), this.TsSkillType, this.TsDebugLog);
		}
		return AiLibrary.SelectSkillWithoutTarget(aiController, component, this.TsSkillType);
	}

	// Token: 0x06003891 RID: 14481 RVA: 0x0003E06A File Offset: 0x0003C26A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorSelectSkill._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSelectSkill.TsDecoratorSelectSkill_C");
		}
		return TsDecoratorSelectSkill._ClassPtr;
	}

	// Token: 0x06003892 RID: 14482 RVA: 0x0003E090 File Offset: 0x0003C290
	public TsDecoratorSelectSkill() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSelectSkill.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003893 RID: 14483 RVA: 0x0003E0B8 File Offset: 0x0003C2B8
	[NullableContext(1)]
	public TsDecoratorSelectSkill(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSelectSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003894 RID: 14484 RVA: 0x0003E0EB File Offset: 0x0003C2EB
	protected TsDecoratorSelectSkill(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003895 RID: 14485 RVA: 0x0003E0F4 File Offset: 0x0003C2F4
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000876 RID: 2166
	private bool IsInitTsVariables;

	// Token: 0x04000877 RID: 2167
	private int TsSkillType;

	// Token: 0x04000878 RID: 2168
	private bool TsDebugLog;

	// Token: 0x04000879 RID: 2169
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorSelectSkill.TsDecoratorSelectSkill_C";

	// Token: 0x0400087A RID: 2170
	private static IntPtr _ClassPtr;

	// Token: 0x0400087B RID: 2171
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400087C RID: 2172
	private static int __PropertyOffset_SkillType;

	// Token: 0x0400087D RID: 2173
	private static int __PropertyOffset_DebugLog;
}
