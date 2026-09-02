using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA9 RID: 3241
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMoveSpeed.TsTaskChangeMoveSpeed_C")]
public class TsTaskChangeMoveSpeed : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001FC RID: 508
	// (get) Token: 0x06003CD5 RID: 15573 RVA: 0x000548ED File Offset: 0x00052AED
	// (set) Token: 0x06003CD6 RID: 15574 RVA: 0x000548FD File Offset: 0x00052AFD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MoveSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeMoveSpeed.__PropertyOffset_MoveSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeMoveSpeed.__PropertyOffset_MoveSpeed) = value;
		}
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x06003CD7 RID: 15575 RVA: 0x0005490E File Offset: 0x00052B0E
	// (set) Token: 0x06003CD8 RID: 15576 RVA: 0x0005491E File Offset: 0x00052B1E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ResetDefault
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskChangeMoveSpeed.__PropertyOffset_ResetDefault) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskChangeMoveSpeed.__PropertyOffset_ResetDefault) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003CD9 RID: 15577 RVA: 0x0005492F File Offset: 0x00052B2F
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveSpeed = this.MoveSpeed;
			this.TsResetDefault = this.ResetDefault;
		}
	}

	// Token: 0x06003CDA RID: 15578 RVA: 0x00054960 File Offset: 0x00052B60
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

	// Token: 0x06003CDB RID: 15579 RVA: 0x000549FC File Offset: 0x00052BFC
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
		BaseMoveComponent component = entityByActor.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			base.FinishExecute(true);
			return;
		}
		if (this.TsResetDefault)
		{
			ECharMoveState moveState = entityByActor.Entity.GetComponent<CharacterUnifiedStateComponent>().MoveState;
			component.ResetMaxSpeed(new ECharMoveState?(moveState));
		}
		else
		{
			component.SetMaxSpeed(this.TsMoveSpeed);
			component.SetSpeedLock();
		}
		base.FinishExecute(true);
	}

	// Token: 0x06003CDC RID: 15580 RVA: 0x00054AE4 File Offset: 0x00052CE4
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskChangeMoveSpeed._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMoveSpeed.TsTaskChangeMoveSpeed_C");
		}
		return TsTaskChangeMoveSpeed._ClassPtr;
	}

	// Token: 0x06003CDD RID: 15581 RVA: 0x00054B08 File Offset: 0x00052D08
	public TsTaskChangeMoveSpeed() : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeMoveSpeed.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003CDE RID: 15582 RVA: 0x00054B30 File Offset: 0x00052D30
	[NullableContext(1)]
	public TsTaskChangeMoveSpeed(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeMoveSpeed.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003CDF RID: 15583 RVA: 0x00054B63 File Offset: 0x00052D63
	protected TsTaskChangeMoveSpeed(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003CE0 RID: 15584 RVA: 0x00054B6C File Offset: 0x00052D6C
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000BD4 RID: 3028
	private bool IsInitTsVariables;

	// Token: 0x04000BD5 RID: 3029
	private float TsMoveSpeed;

	// Token: 0x04000BD6 RID: 3030
	private bool TsResetDefault;

	// Token: 0x04000BD7 RID: 3031
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskChangeMoveSpeed.TsTaskChangeMoveSpeed_C";

	// Token: 0x04000BD8 RID: 3032
	private static IntPtr _ClassPtr;

	// Token: 0x04000BD9 RID: 3033
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BDA RID: 3034
	private static int __PropertyOffset_MoveSpeed;

	// Token: 0x04000BDB RID: 3035
	private static int __PropertyOffset_ResetDefault;
}
