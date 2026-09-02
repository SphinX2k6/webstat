using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C71 RID: 3185
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalDestroySelf.TsTaskAnimalDestroySelf_C")]
public class TsTaskAnimalDestroySelf : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x060038F6 RID: 14582 RVA: 0x00040038 File Offset: 0x0003E238
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

	// Token: 0x060038F7 RID: 14583 RVA: 0x000400D4 File Offset: 0x0003E2D4
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		Entity entity = aiController.CharActorComp.Entity;
		CharacterAiComponent component = entity.GetComponent<CharacterAiComponent>();
		if (component != null)
		{
			component.DisableAi("动物销毁");
		}
		AnimalPerformComponent component2 = entity.GetComponent<AnimalPerformComponent>();
		if (component2 != null)
		{
			component2.PendingDestroy = false;
		}
		CreatureDataComponent component3 = entity.GetComponent<CreatureDataComponent>();
		ControllerBase<CreatureController>.Instance.AnimalDestroyRequest(component3.GetCreatureDataId());
		base.FinishExecute(true);
	}

	// Token: 0x060038F8 RID: 14584 RVA: 0x00040182 File Offset: 0x0003E382
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAnimalDestroySelf._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalDestroySelf.TsTaskAnimalDestroySelf_C");
		}
		return TsTaskAnimalDestroySelf._ClassPtr;
	}

	// Token: 0x060038F9 RID: 14585 RVA: 0x000401A8 File Offset: 0x0003E3A8
	public TsTaskAnimalDestroySelf() : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalDestroySelf.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060038FA RID: 14586 RVA: 0x000401D0 File Offset: 0x0003E3D0
	[NullableContext(1)]
	public TsTaskAnimalDestroySelf(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalDestroySelf.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060038FB RID: 14587 RVA: 0x00040203 File Offset: 0x0003E403
	protected TsTaskAnimalDestroySelf(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060038FC RID: 14588 RVA: 0x0004020C File Offset: 0x0003E40C
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040008BF RID: 2239
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalDestroySelf.TsTaskAnimalDestroySelf_C";

	// Token: 0x040008C0 RID: 2240
	private static IntPtr _ClassPtr;

	// Token: 0x040008C1 RID: 2241
	private static IntPtr _ClassDefaultObjectPtr;
}
