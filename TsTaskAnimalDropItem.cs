using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA0 RID: 3232
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAnimalDropItem.TsTaskAnimalDropItem_C")]
public class TsTaskAnimalDropItem : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001EA RID: 490
	// (get) Token: 0x06003C42 RID: 15426 RVA: 0x00051525 File Offset: 0x0004F725
	// (set) Token: 0x06003C43 RID: 15427 RVA: 0x00051535 File Offset: 0x0004F735
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DoOnce
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalDropItem.__PropertyOffset_DoOnce) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalDropItem.__PropertyOffset_DoOnce) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003C44 RID: 15428 RVA: 0x00051546 File Offset: 0x0004F746
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsDoOnce = this.DoOnce;
		}
	}

	// Token: 0x06003C45 RID: 15429 RVA: 0x0005156C File Offset: 0x0004F76C
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

	// Token: 0x06003C46 RID: 15430 RVA: 0x00051608 File Offset: 0x0004F808
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
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
		Entity entity = aiController.CharActorComp.Entity;
		if (entity.GetComponent<CharacterAiComponent>() == null)
		{
			base.FinishExecute(false);
			return;
		}
		if (this.TsDoOnce && this.HasDone)
		{
			base.FinishExecute(true);
			return;
		}
		long creatureDataId = entity.GetComponent<CreatureDataComponent>().GetCreatureDataId();
		ControllerBase<CreatureController>.Instance.AnimalDropItemRequest(creatureDataId);
		this.HasDone = true;
		base.FinishExecute(true);
	}

	// Token: 0x06003C47 RID: 15431 RVA: 0x000516C6 File Offset: 0x0004F8C6
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAnimalDropItem._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAnimalDropItem.TsTaskAnimalDropItem_C");
		}
		return TsTaskAnimalDropItem._ClassPtr;
	}

	// Token: 0x06003C48 RID: 15432 RVA: 0x000516EC File Offset: 0x0004F8EC
	public TsTaskAnimalDropItem() : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalDropItem.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C49 RID: 15433 RVA: 0x00051714 File Offset: 0x0004F914
	[NullableContext(1)]
	public TsTaskAnimalDropItem(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalDropItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C4A RID: 15434 RVA: 0x00051747 File Offset: 0x0004F947
	protected TsTaskAnimalDropItem(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C4B RID: 15435 RVA: 0x00051758 File Offset: 0x0004F958
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000B5F RID: 2911
	private bool IsInitTsVariables;

	// Token: 0x04000B60 RID: 2912
	private bool TsDoOnce = true;

	// Token: 0x04000B61 RID: 2913
	private bool HasDone;

	// Token: 0x04000B62 RID: 2914
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskAnimalDropItem.TsTaskAnimalDropItem_C";

	// Token: 0x04000B63 RID: 2915
	private static IntPtr _ClassPtr;

	// Token: 0x04000B64 RID: 2916
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B65 RID: 2917
	private static int __PropertyOffset_DoOnce;
}
