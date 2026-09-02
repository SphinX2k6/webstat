using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA8 RID: 3240
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMovementMode.TsTaskChangeMovementMode_C")]
public class TsTaskChangeMovementMode : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001FB RID: 507
	// (get) Token: 0x06003CC9 RID: 15561 RVA: 0x000545F9 File Offset: 0x000527F9
	// (set) Token: 0x06003CCA RID: 15562 RVA: 0x0005460D File Offset: 0x0005280D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe TEnumAsByte<EMovementMode> MovementMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeMovementMode.__PropertyOffset_MovementMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeMovementMode.__PropertyOffset_MovementMode) = value;
		}
	}

	// Token: 0x06003CCB RID: 15563 RVA: 0x00054624 File Offset: 0x00052824
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitTsVariables()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitTsVariables"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003CCC RID: 15564 RVA: 0x00054694 File Offset: 0x00052894
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMovementMode = this.MovementMode;
		}
	}

	// Token: 0x06003CCD RID: 15565 RVA: 0x000546C0 File Offset: 0x000528C0
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

	// Token: 0x06003CCE RID: 15566 RVA: 0x0005475C File Offset: 0x0005295C
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null)
		{
			base.FinishExecute(true);
			return;
		}
		EntityHandle entityByActor = ActorUtils.GetEntityByActor(charActorComp.Actor, true);
		if (entityByActor == null)
		{
			base.FinishExecute(true);
			return;
		}
		if (entityByActor.Entity.GetComponent<BaseMoveComponent>() == null)
		{
			base.FinishExecute(true);
			return;
		}
		charActorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
		{
			Mode = this.TsMovementMode,
			Context = "[TsTaskChangeMovementMode.ReceiveExecuteAI]"
		});
		base.FinishExecute(true);
	}

	// Token: 0x06003CCF RID: 15567 RVA: 0x0005482E File Offset: 0x00052A2E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskChangeMovementMode._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMovementMode.TsTaskChangeMovementMode_C");
		}
		return TsTaskChangeMovementMode._ClassPtr;
	}

	// Token: 0x06003CD0 RID: 15568 RVA: 0x00054854 File Offset: 0x00052A54
	public TsTaskChangeMovementMode() : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeMovementMode.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CD1 RID: 15569 RVA: 0x0005487C File Offset: 0x00052A7C
	[NullableContext(1)]
	public TsTaskChangeMovementMode(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeMovementMode.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CD2 RID: 15570 RVA: 0x000548AF File Offset: 0x00052AAF
	protected TsTaskChangeMovementMode(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CD3 RID: 15571 RVA: 0x000548B8 File Offset: 0x00052AB8
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003CD4 RID: 15572 RVA: 0x000548C0 File Offset: 0x00052AC0
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BCE RID: 3022
	private bool IsInitTsVariables;

	// Token: 0x04000BCF RID: 3023
	private EMovementMode TsMovementMode;

	// Token: 0x04000BD0 RID: 3024
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMovementMode.TsTaskChangeMovementMode_C";

	// Token: 0x04000BD1 RID: 3025
	private static IntPtr _ClassPtr;

	// Token: 0x04000BD2 RID: 3026
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BD3 RID: 3027
	private static int __PropertyOffset_MovementMode;
}
