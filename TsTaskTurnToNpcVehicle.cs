using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C8B RID: 3211
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToNpcVehicle.TsTaskTurnToNpcVehicle_C")]
public class TsTaskTurnToNpcVehicle : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001AF RID: 431
	// (get) Token: 0x06003AC2 RID: 15042 RVA: 0x0004904B File Offset: 0x0004724B
	// (set) Token: 0x06003AC3 RID: 15043 RVA: 0x0004905B File Offset: 0x0004725B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x06003AC4 RID: 15044 RVA: 0x0004906C File Offset: 0x0004726C
	// (set) Token: 0x06003AC5 RID: 15045 RVA: 0x0004907C File Offset: 0x0004727C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MovementMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_MovementMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_MovementMode) = value;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x06003AC6 RID: 15046 RVA: 0x0004908D File Offset: 0x0004728D
	// (set) Token: 0x06003AC7 RID: 15047 RVA: 0x0004909D File Offset: 0x0004729D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EnableDebugDraw
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_EnableDebugDraw) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToNpcVehicle.__PropertyOffset_EnableDebugDraw) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003AC8 RID: 15048 RVA: 0x000490AE File Offset: 0x000472AE
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsMovementMode = (EMovementMode)this.MovementMode;
		}
	}

	// Token: 0x06003AC9 RID: 15049 RVA: 0x000490E0 File Offset: 0x000472E0
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

	// Token: 0x06003ACA RID: 15050 RVA: 0x0004917C File Offset: 0x0004737C
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
			ELogAuthor author = ELogAuthor.ZJL;
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
			ELogAuthor author2 = ELogAuthor.ZJL;
			string message2 = "执行转向骑乘载具时实体不存在:";
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
			ELogAuthor author3 = ELogAuthor.ZJL;
			string message3 = "[TsTaskTurnToNpcVehicle]无效的CharacterMovement";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(true);
			return;
		}
		this.OriginalMovementMode = ucharacterMovementComponent.MovementMode;
		ucharacterMovementComponent.MovementMode = this.TsMovementMode;
		int id = entity.Id;
		int? ridingVehicle = ControllerBase<NpcVehicleRiderController>.Instance.GetRidingVehicle(id);
		if (ridingVehicle == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.LevelAi;
			ELogAuthor author4 = ELogAuthor.ZJL;
			string message4 = "[TsTaskTurnToNpcVehicle]NPC没有骑乘载具";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("NpcEntityId", id);
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			ucharacterMovementComponent.MovementMode = this.OriginalMovementMode;
			base.FinishExecute(true);
			return;
		}
		Singleton<MathUtils>.Instance.CommonTempVector.Reset();
		if (!ControllerBase<NpcVehicleRiderController>.Instance.GetNpcRideFacingDirection(id, ridingVehicle.Value, Singleton<MathUtils>.Instance.CommonTempVector))
		{
			ucharacterMovementComponent.MovementMode = this.OriginalMovementMode;
			base.FinishExecute(true);
			return;
		}
		AiControllerLibrary.TurnToDirect(this.Character, Singleton<MathUtils>.Instance.CommonTempVector, this.TsTurnSpeed, false, 0f);
		this.TmpTargetDirection.DeepCopy(Singleton<MathUtils>.Instance.CommonTempVector);
	}

	// Token: 0x06003ACB RID: 15051 RVA: 0x000493AC File Offset: 0x000475AC
	[NullableContext(2)]
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

	// Token: 0x06003ACC RID: 15052 RVA: 0x0004944C File Offset: 0x0004764C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.EnableDebugDraw)
		{
			this.DrawDebugRotation();
		}
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 3f)
		{
			this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.OriginalMovementMode;
			base.Finish(true);
		}
	}

	// Token: 0x06003ACD RID: 15053 RVA: 0x000494AC File Offset: 0x000476AC
	private void DrawDebugRotation()
	{
		CharacterActorComponent character = this.Character;
		if (character == null || !character.Valid)
		{
			return;
		}
		Vector actorLocationProxy = character.ActorLocationProxy;
		this.TmpArrowEnd.DeepCopy(character.ActorForwardProxy);
		this.TmpArrowEnd.MultiplyEqual(200.0);
		this.TmpArrowEnd.AdditionEqual(actorLocationProxy);
		UKismetSystemLibrary.D_DrawDebugArrow(this, actorLocationProxy.ToUeVector(false), this.TmpArrowEnd.ToUeVector(false), 60f, TsTaskTurnToNpcVehicle.CurrentRotationColor, 0f, 2f);
		this.TmpArrowEnd.DeepCopy(this.TmpTargetDirection);
		this.TmpArrowEnd.MultiplyEqual(200.0);
		this.TmpArrowEnd.AdditionEqual(actorLocationProxy);
		UKismetSystemLibrary.D_DrawDebugArrow(this, actorLocationProxy.ToUeVector(false), this.TmpArrowEnd.ToUeVector(false), 60f, TsTaskTurnToNpcVehicle.TargetRotationColor, 0f, 2f);
	}

	// Token: 0x06003ACE RID: 15054 RVA: 0x00049599 File Offset: 0x00047799
	protected override void OnClear()
	{
		this.Character = null;
		this.OriginalMovementMode = EMovementMode.MOVE_None;
	}

	// Token: 0x06003ACF RID: 15055 RVA: 0x000495A9 File Offset: 0x000477A9
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToNpcVehicle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToNpcVehicle.TsTaskTurnToNpcVehicle_C");
		}
		return TsTaskTurnToNpcVehicle._ClassPtr;
	}

	// Token: 0x06003AD0 RID: 15056 RVA: 0x000495D0 File Offset: 0x000477D0
	public TsTaskTurnToNpcVehicle() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToNpcVehicle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003AD1 RID: 15057 RVA: 0x000495F8 File Offset: 0x000477F8
	[NullableContext(1)]
	public TsTaskTurnToNpcVehicle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToNpcVehicle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003AD2 RID: 15058 RVA: 0x0004962B File Offset: 0x0004782B
	protected TsTaskTurnToNpcVehicle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003AD3 RID: 15059 RVA: 0x0004965C File Offset: 0x0004785C
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003AD4 RID: 15060 RVA: 0x0004968C File Offset: 0x0004788C
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000A35 RID: 2613
	private const float TOLERANCE = 3f;

	// Token: 0x04000A36 RID: 2614
	private const float DEBUG_ARROW_LENGTH = 200f;

	// Token: 0x04000A37 RID: 2615
	private const float DEBUG_ARROW_SIZE = 60f;

	// Token: 0x04000A38 RID: 2616
	private const float DEBUG_DRAW_DURATION = 0f;

	// Token: 0x04000A39 RID: 2617
	private const float DEBUG_DRAW_THICKNESS = 2f;

	// Token: 0x04000A3A RID: 2618
	private static readonly FLinearColor CurrentRotationColor = new FLinearColor(1f, 0f, 0f, 1f);

	// Token: 0x04000A3B RID: 2619
	private static readonly FLinearColor TargetRotationColor = new FLinearColor(0f, 1f, 0f, 1f);

	// Token: 0x04000A3C RID: 2620
	private float TsTurnSpeed = 180f;

	// Token: 0x04000A3D RID: 2621
	private EMovementMode TsMovementMode = EMovementMode.MOVE_Walking;

	// Token: 0x04000A3E RID: 2622
	[Nullable(2)]
	private CharacterActorComponent Character;

	// Token: 0x04000A3F RID: 2623
	[Nullable(1)]
	private readonly Vector TmpTargetDirection = Vector.Create();

	// Token: 0x04000A40 RID: 2624
	[Nullable(1)]
	private readonly Vector TmpArrowEnd = Vector.Create();

	// Token: 0x04000A41 RID: 2625
	private EMovementMode OriginalMovementMode;

	// Token: 0x04000A42 RID: 2626
	private bool IsInitTsVariables;

	// Token: 0x04000A43 RID: 2627
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToNpcVehicle.TsTaskTurnToNpcVehicle_C";

	// Token: 0x04000A44 RID: 2628
	private static IntPtr _ClassPtr;

	// Token: 0x04000A45 RID: 2629
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A46 RID: 2630
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000A47 RID: 2631
	private static int __PropertyOffset_MovementMode;

	// Token: 0x04000A48 RID: 2632
	private static int __PropertyOffset_EnableDebugDraw;
}
