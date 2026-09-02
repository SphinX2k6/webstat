using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C44 RID: 3140
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerImpactCheck.TsDecoratorPlayerImpactCheck_C")]
public class TsDecoratorPlayerImpactCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000112 RID: 274
	// (get) Token: 0x060036F9 RID: 14073 RVA: 0x0003799B File Offset: 0x00035B9B
	// (set) Token: 0x060036FA RID: 14074 RVA: 0x000379AF File Offset: 0x00035BAF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorPlayerImpactCheck.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorPlayerImpactCheck.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x060036FB RID: 14075 RVA: 0x000379C4 File Offset: 0x00035BC4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
		}
	}

	// Token: 0x060036FC RID: 14076 RVA: 0x000379E8 File Offset: 0x00035BE8
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

	// Token: 0x060036FD RID: 14077 RVA: 0x00037A88 File Offset: 0x00035C88
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!(ownerController is TsAiController))
		{
			return false;
		}
		this.InitTsVariables();
		if (!this.IsCollected)
		{
			NpcDecisionController npcDecision = (ownerController as TsAiController).AiController.NpcDecision;
			if (npcDecision != null)
			{
				this.IsCollected = true;
				npcDecision.CheckPlayerImpact = true;
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

	// Token: 0x060036FE RID: 14078 RVA: 0x00037B0D File Offset: 0x00035D0D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorPlayerImpactCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerImpactCheck.TsDecoratorPlayerImpactCheck_C");
		}
		return TsDecoratorPlayerImpactCheck._ClassPtr;
	}

	// Token: 0x060036FF RID: 14079 RVA: 0x00037B34 File Offset: 0x00035D34
	public TsDecoratorPlayerImpactCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerImpactCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003700 RID: 14080 RVA: 0x00037B5C File Offset: 0x00035D5C
	public TsDecoratorPlayerImpactCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerImpactCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003701 RID: 14081 RVA: 0x00037B8F File Offset: 0x00035D8F
	protected TsDecoratorPlayerImpactCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003702 RID: 14082 RVA: 0x00037BA4 File Offset: 0x00035DA4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400076D RID: 1901
	private bool IsCollected;

	// Token: 0x0400076E RID: 1902
	private bool IsInitTsVariables;

	// Token: 0x0400076F RID: 1903
	private string TsBlackboardKey = "";

	// Token: 0x04000770 RID: 1904
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/Npc/TsDecoratorPlayerImpactCheck.TsDecoratorPlayerImpactCheck_C";

	// Token: 0x04000771 RID: 1905
	private static IntPtr _ClassPtr;

	// Token: 0x04000772 RID: 1906
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000773 RID: 1907
	private static int __PropertyOffset_BlackboardKey;
}
