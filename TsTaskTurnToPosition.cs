using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C8C RID: 3212
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToPosition.TsTaskTurnToPosition_C")]
public class TsTaskTurnToPosition : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06003AD6 RID: 15062 RVA: 0x000496FD File Offset: 0x000478FD
	// (set) Token: 0x06003AD7 RID: 15063 RVA: 0x00049711 File Offset: 0x00047911
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector TargetPos
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_TargetPos);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_TargetPos) = value;
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06003AD8 RID: 15064 RVA: 0x00049726 File Offset: 0x00047926
	// (set) Token: 0x06003AD9 RID: 15065 RVA: 0x00049736 File Offset: 0x00047936
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06003ADA RID: 15066 RVA: 0x00049747 File Offset: 0x00047947
	// (set) Token: 0x06003ADB RID: 15067 RVA: 0x00049757 File Offset: 0x00047957
	[UProperty(EPropertyFlags.CPF_None)]
	private unsafe bool IsInitTsVariables
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_IsInitTsVariables) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToPosition.__PropertyOffset_IsInitTsVariables) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003ADC RID: 15068 RVA: 0x00049768 File Offset: 0x00047968
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTargetPos = Vector.Create((double)this.TargetPos.X, (double)this.TargetPos.Y, (double)this.TargetPos.Z);
			this.TsTurnSpeed = this.TurnSpeed;
		}
	}

	// Token: 0x06003ADD RID: 15069 RVA: 0x000497C8 File Offset: 0x000479C8
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

	// Token: 0x06003ADE RID: 15070 RVA: 0x00049864 File Offset: 0x00047A64
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
			base.FinishExecute(true);
			return;
		}
		Entity entity = aiController.CharAiDesignComp.Entity;
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (entity == null || !entity.Valid)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.LevelAi;
			ELogAuthor author2 = ELogAuthor.CJH;
			string message2 = "执行转向动作时实体不存在:";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(true);
			return;
		}
		this.Character = entity.GetComponent<CharacterActorComponent>();
		BaseMoveComponent component2 = entity.GetComponent<BaseMoveComponent>();
		UCharacterMovementComponent ucharacterMovementComponent = (component2 != null) ? component2.CharacterMovement : null;
		if (ucharacterMovementComponent == null || !ucharacterMovementComponent.IsValid())
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.LevelAi;
			ELogAuthor author3 = ELogAuthor.YJX;
			string message3 = "[TsTaskTurnToPosition]无效的CharacterMovement";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(true);
			return;
		}
		this.MovementMode = ucharacterMovementComponent.MovementMode;
		ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
		AiControllerLibrary.TurnToTarget(this.Character, this.TsTargetPos, this.TsTurnSpeed, false, 0f);
	}

	// Token: 0x06003ADF RID: 15071 RVA: 0x000499CC File Offset: 0x00047BCC
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

	// Token: 0x06003AE0 RID: 15072 RVA: 0x00049A6C File Offset: 0x00047C6C
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 3f)
		{
			this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
			base.Finish(true);
		}
	}

	// Token: 0x06003AE1 RID: 15073 RVA: 0x00049ABC File Offset: 0x00047CBC
	protected override void OnAbort()
	{
		CharacterActorComponent character = this.Character;
		if (character == null)
		{
			return;
		}
		character.ClearInput(false, true);
	}

	// Token: 0x06003AE2 RID: 15074 RVA: 0x00049AD0 File Offset: 0x00047CD0
	protected override void OnClear()
	{
		this.Character = null;
		this.MovementMode = EMovementMode.MOVE_None;
	}

	// Token: 0x06003AE3 RID: 15075 RVA: 0x00049AE0 File Offset: 0x00047CE0
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToPosition._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToPosition.TsTaskTurnToPosition_C");
		}
		return TsTaskTurnToPosition._ClassPtr;
	}

	// Token: 0x06003AE4 RID: 15076 RVA: 0x00049B04 File Offset: 0x00047D04
	public TsTaskTurnToPosition() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToPosition.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003AE5 RID: 15077 RVA: 0x00049B2C File Offset: 0x00047D2C
	[NullableContext(1)]
	public TsTaskTurnToPosition(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToPosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003AE6 RID: 15078 RVA: 0x00049B5F File Offset: 0x00047D5F
	protected TsTaskTurnToPosition(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003AE7 RID: 15079 RVA: 0x00049B74 File Offset: 0x00047D74
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003AE8 RID: 15080 RVA: 0x00049BA4 File Offset: 0x00047DA4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000A49 RID: 2633
	private const float TOLERANCE = 3f;

	// Token: 0x04000A4A RID: 2634
	private Vector TsTargetPos;

	// Token: 0x04000A4B RID: 2635
	private float TsTurnSpeed = 180f;

	// Token: 0x04000A4C RID: 2636
	private CharacterActorComponent Character;

	// Token: 0x04000A4D RID: 2637
	private EMovementMode MovementMode;

	// Token: 0x04000A4E RID: 2638
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToPosition.TsTaskTurnToPosition_C";

	// Token: 0x04000A4F RID: 2639
	private static IntPtr _ClassPtr;

	// Token: 0x04000A50 RID: 2640
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A51 RID: 2641
	private static int __PropertyOffset_TargetPos;

	// Token: 0x04000A52 RID: 2642
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000A53 RID: 2643
	private static int __PropertyOffset_IsInitTsVariables;
}
