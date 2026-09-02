using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C56 RID: 3158
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckSkillUsable.TsDecoratorCheckSkillUsable_C")]
public class TsDecoratorCheckSkillUsable : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000135 RID: 309
	// (get) Token: 0x060037D3 RID: 14291 RVA: 0x0003B397 File Offset: 0x00039597
	// (set) Token: 0x060037D4 RID: 14292 RVA: 0x0003B3A7 File Offset: 0x000395A7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckSkillUsable.__PropertyOffset_SkillId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckSkillUsable.__PropertyOffset_SkillId) = value;
		}
	}

	// Token: 0x060037D5 RID: 14293 RVA: 0x0003B3B8 File Offset: 0x000395B8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsSkillId = this.SkillId;
		}
	}

	// Token: 0x060037D6 RID: 14294 RVA: 0x0003B3DC File Offset: 0x000395DC
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

	// Token: 0x060037D7 RID: 14295 RVA: 0x0003B47C File Offset: 0x0003967C
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		this.InitTsVariables();
		CharacterSkillComponent component = aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		return component != null && component.Valid && component.IsCanUseSkill(this.TsSkillId);
	}

	// Token: 0x060037D8 RID: 14296 RVA: 0x0003B50A File Offset: 0x0003970A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckSkillUsable._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckSkillUsable.TsDecoratorCheckSkillUsable_C");
		}
		return TsDecoratorCheckSkillUsable._ClassPtr;
	}

	// Token: 0x060037D9 RID: 14297 RVA: 0x0003B530 File Offset: 0x00039730
	public TsDecoratorCheckSkillUsable() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckSkillUsable.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037DA RID: 14298 RVA: 0x0003B558 File Offset: 0x00039758
	[NullableContext(1)]
	public TsDecoratorCheckSkillUsable(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckSkillUsable.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037DB RID: 14299 RVA: 0x0003B58B File Offset: 0x0003978B
	protected TsDecoratorCheckSkillUsable(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037DC RID: 14300 RVA: 0x0003B594 File Offset: 0x00039794
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000803 RID: 2051
	private bool IsInitTsVariables;

	// Token: 0x04000804 RID: 2052
	private int TsSkillId;

	// Token: 0x04000805 RID: 2053
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckSkillUsable.TsDecoratorCheckSkillUsable_C";

	// Token: 0x04000806 RID: 2054
	private static IntPtr _ClassPtr;

	// Token: 0x04000807 RID: 2055
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000808 RID: 2056
	private static int __PropertyOffset_SkillId;
}
