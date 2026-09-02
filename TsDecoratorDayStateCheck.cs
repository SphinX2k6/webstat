using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C59 RID: 3161
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDayStateCheck.TsDecoratorDayStateCheck_C")]
public class TsDecoratorDayStateCheck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700013B RID: 315
	// (get) Token: 0x060037F7 RID: 14327 RVA: 0x0003BABF File Offset: 0x00039CBF
	// (set) Token: 0x060037F8 RID: 14328 RVA: 0x0003BAD3 File Offset: 0x00039CD3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorDayStateCheck.__PropertyOffset_BlackboardKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsDecoratorDayStateCheck.__PropertyOffset_BlackboardKey)), value);
		}
	}

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x060037F9 RID: 14329 RVA: 0x0003BAE8 File Offset: 0x00039CE8
	// (set) Token: 0x060037FA RID: 14330 RVA: 0x0003BAF0 File Offset: 0x00039CF0
	public EDayState CheckValue { get; set; }

	// Token: 0x060037FB RID: 14331 RVA: 0x0003BAF9 File Offset: 0x00039CF9
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsBlackboardKey = this.BlackboardKey;
			this.TsCheckValue = this.CheckValue;
		}
	}

	// Token: 0x060037FC RID: 14332 RVA: 0x0003BB2C File Offset: 0x00039D2C
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

	// Token: 0x060037FD RID: 14333 RVA: 0x0003BBCC File Offset: 0x00039DCC
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
		if (!this.IsCollected)
		{
			NpcDecisionController npcDecision = aiController.NpcDecision;
			if (npcDecision != null)
			{
				this.IsCollected = true;
				npcDecision.CheckDayState = true;
			}
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			return false;
		}
		int id = charActorComp.Entity.Id;
		int? intValueByEntity = ControllerBase<BlackboardController>.Instance.GetIntValueByEntity(id, this.TsBlackboardKey);
		int tsCheckValue = (int)this.TsCheckValue;
		return intValueByEntity.GetValueOrDefault() == tsCheckValue & intValueByEntity != null;
	}

	// Token: 0x060037FE RID: 14334 RVA: 0x0003BC8D File Offset: 0x00039E8D
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorDayStateCheck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDayStateCheck.TsDecoratorDayStateCheck_C");
		}
		return TsDecoratorDayStateCheck._ClassPtr;
	}

	// Token: 0x060037FF RID: 14335 RVA: 0x0003BCB4 File Offset: 0x00039EB4
	public TsDecoratorDayStateCheck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDayStateCheck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003800 RID: 14336 RVA: 0x0003BCDC File Offset: 0x00039EDC
	public TsDecoratorDayStateCheck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDayStateCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003801 RID: 14337 RVA: 0x0003BD0F File Offset: 0x00039F0F
	protected TsDecoratorDayStateCheck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003802 RID: 14338 RVA: 0x0003BD24 File Offset: 0x00039F24
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0400081A RID: 2074
	private bool IsCollected;

	// Token: 0x0400081B RID: 2075
	private bool IsInitTsVariables;

	// Token: 0x0400081C RID: 2076
	private string TsBlackboardKey = "";

	// Token: 0x0400081D RID: 2077
	private EDayState TsCheckValue;

	// Token: 0x0400081E RID: 2078
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorDayStateCheck.TsDecoratorDayStateCheck_C";

	// Token: 0x0400081F RID: 2079
	private static IntPtr _ClassPtr;

	// Token: 0x04000820 RID: 2080
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000821 RID: 2081
	private static int __PropertyOffset_BlackboardKey;
}
