using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C43 RID: 3139
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerAttackCheck.TsDecoratorPlayerAttackCheck_C")]
public class TsDecoratorPlayerAttackCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000111 RID: 273
	// (get) Token: 0x060036EF RID: 14063 RVA: 0x0003775F File Offset: 0x0003595F
	// (set) Token: 0x060036F0 RID: 14064 RVA: 0x00037773 File Offset: 0x00035973
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorPlayerAttackCheck.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorPlayerAttackCheck.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x060036F1 RID: 14065 RVA: 0x00037788 File Offset: 0x00035988
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x060036F2 RID: 14066 RVA: 0x000377AC File Offset: 0x000359AC
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

	// Token: 0x060036F3 RID: 14067 RVA: 0x0003784C File Offset: 0x00035A4C
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
		{
			return false;
		}
		if (!this.IsCollected)
		{
			NpcDecisionController npcDecision = (ownerController as TsAiController).AiController.NpcDecision;
			if (npcDecision != null)
			{
				this.IsCollected = true;
				npcDecision.CheckPlayerAttack = true;
			}
		}
		CharacterActorComponent charActorComp = (ownerController as TsAiController).AiController.CharActorComp;
		if (charActorComp == null)
		{
			return false;
		}
		int id = charActorComp.Entity.Id;
		return ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.TsBlackboardKey).GetValueOrDefault() == 1;
	}

	// Token: 0x060036F4 RID: 14068 RVA: 0x000378D1 File Offset: 0x00035AD1
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorPlayerAttackCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerAttackCheck.TsDecoratorPlayerAttackCheck_C");
		}
		return TsDecoratorPlayerAttackCheck._ClassPtr;
	}

	// Token: 0x060036F5 RID: 14069 RVA: 0x000378F8 File Offset: 0x00035AF8
	public TsDecoratorPlayerAttackCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerAttackCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060036F6 RID: 14070 RVA: 0x00037920 File Offset: 0x00035B20
	public TsDecoratorPlayerAttackCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerAttackCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060036F7 RID: 14071 RVA: 0x00037953 File Offset: 0x00035B53
	protected TsDecoratorPlayerAttackCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060036F8 RID: 14072 RVA: 0x00037968 File Offset: 0x00035B68
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000766 RID: 1894
	private bool IsCollected;

	// Token: 0x04000767 RID: 1895
	private bool IsInitTsVariables;

	// Token: 0x04000768 RID: 1896
	private string TsBlackboardKey = "";

	// Token: 0x04000769 RID: 1897
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerAttackCheck.TsDecoratorPlayerAttackCheck_C";

	// Token: 0x0400076A RID: 1898
	private static IntPtr _ClassPtr;

	// Token: 0x0400076B RID: 1899
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400076C RID: 1900
	private static int __PropertyOffset_BlackboardKey;
}
