using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C8A RID: 3210
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToEntity.TsTaskTurnToEntity_C")]
public class TsTaskTurnToEntity : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06003AAD RID: 15021 RVA: 0x00048A71 File Offset: 0x00046C71
	// (set) Token: 0x06003AAE RID: 15022 RVA: 0x00048A81 File Offset: 0x00046C81
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TurnMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TurnMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TurnMode) = value;
		}
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06003AAF RID: 15023 RVA: 0x00048A92 File Offset: 0x00046C92
	// (set) Token: 0x06003AB0 RID: 15024 RVA: 0x00048AA2 File Offset: 0x00046CA2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TargetEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TargetEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TargetEntityId) = value;
		}
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06003AB1 RID: 15025 RVA: 0x00048AB3 File Offset: 0x00046CB3
	// (set) Token: 0x06003AB2 RID: 15026 RVA: 0x00048AC7 File Offset: 0x00046CC7
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector TargetPos
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TargetPos);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TargetPos) = value;
		}
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06003AB3 RID: 15027 RVA: 0x00048ADC File Offset: 0x00046CDC
	// (set) Token: 0x06003AB4 RID: 15028 RVA: 0x00048AEC File Offset: 0x00046CEC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTurnToEntity.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x06003AB5 RID: 15029 RVA: 0x00048B00 File Offset: 0x00046D00
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsTurnMode = this.TurnMode;
			this.TsTargetEntityId = this.TargetEntityId;
			this.TsTargetPos = Vector.Create((double)this.TargetPos.X, (double)this.TargetPos.Y, (double)this.TargetPos.Z);
			this.TsTurnSpeed = this.TurnSpeed;
		}
	}

	// Token: 0x06003AB6 RID: 15030 RVA: 0x00048B78 File Offset: 0x00046D78
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

	// Token: 0x06003AB7 RID: 15031 RVA: 0x00048C14 File Offset: 0x00046E14
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
			string message3 = "[TsTaskTurnToEntity]无效的CharacterMovement";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("PbDataId", component.GetPbDataId());
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			base.FinishExecute(true);
			return;
		}
		this.MovementMode = ucharacterMovementComponent.MovementMode;
		ucharacterMovementComponent.MovementMode = EMovementMode.MOVE_Walking;
		Singleton<MathUtils>.Instance.CommonTempVector.Reset();
		if (!this.GetTurnToPosition(Singleton<MathUtils>.Instance.CommonTempVector))
		{
			base.FinishExecute(true);
			return;
		}
		AiControllerLibrary.TurnToTarget(this.Character, Singleton<MathUtils>.Instance.CommonTempVector, this.TsTurnSpeed, false, 0f);
	}

	// Token: 0x06003AB8 RID: 15032 RVA: 0x00048DA8 File Offset: 0x00046FA8
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

	// Token: 0x06003AB9 RID: 15033 RVA: 0x00048E48 File Offset: 0x00047048
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 3f)
		{
			this.Character.Entity.GetComponent<BaseMoveComponent>().CharacterMovement.MovementMode = this.MovementMode;
			base.Finish(true);
		}
	}

	// Token: 0x06003ABA RID: 15034 RVA: 0x00048E98 File Offset: 0x00047098
	protected override void OnClear()
	{
		this.Character = null;
		this.MovementMode = EMovementMode.MOVE_None;
	}

	// Token: 0x06003ABB RID: 15035 RVA: 0x00048EA8 File Offset: 0x000470A8
	[NullableContext(1)]
	private bool GetTurnToPosition(Vector outPosition)
	{
		switch (this.TsTurnMode)
		{
		case 2:
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.TsTargetEntityId) : null;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return false;
			}
			BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
			outPosition.DeepCopy(component.ActorLocationProxy);
			break;
		}
		case 3:
			outPosition.DeepCopy(this.TsTargetPos);
			break;
		case 4:
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return false;
			}
			outPosition.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
			break;
		}
		default:
			return false;
		}
		return true;
	}

	// Token: 0x06003ABC RID: 15036 RVA: 0x00048F54 File Offset: 0x00047154
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTurnToEntity._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToEntity.TsTaskTurnToEntity_C");
		}
		return TsTaskTurnToEntity._ClassPtr;
	}

	// Token: 0x06003ABD RID: 15037 RVA: 0x00048F78 File Offset: 0x00047178
	public TsTaskTurnToEntity() : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToEntity.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003ABE RID: 15038 RVA: 0x00048FA0 File Offset: 0x000471A0
	[NullableContext(1)]
	public TsTaskTurnToEntity(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003ABF RID: 15039 RVA: 0x00048FD3 File Offset: 0x000471D3
	protected TsTaskTurnToEntity(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003AC0 RID: 15040 RVA: 0x00048FE8 File Offset: 0x000471E8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003AC1 RID: 15041 RVA: 0x00049018 File Offset: 0x00047218
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000A26 RID: 2598
	private const float TOLERANCE = 3f;

	// Token: 0x04000A27 RID: 2599
	private int TsTurnMode;

	// Token: 0x04000A28 RID: 2600
	private int TsTargetEntityId;

	// Token: 0x04000A29 RID: 2601
	private Vector TsTargetPos;

	// Token: 0x04000A2A RID: 2602
	private float TsTurnSpeed = 180f;

	// Token: 0x04000A2B RID: 2603
	private CharacterActorComponent Character;

	// Token: 0x04000A2C RID: 2604
	private EMovementMode MovementMode;

	// Token: 0x04000A2D RID: 2605
	private bool IsInitTsVariables;

	// Token: 0x04000A2E RID: 2606
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskTurnToEntity.TsTaskTurnToEntity_C";

	// Token: 0x04000A2F RID: 2607
	private static IntPtr _ClassPtr;

	// Token: 0x04000A30 RID: 2608
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A31 RID: 2609
	private static int __PropertyOffset_TurnMode;

	// Token: 0x04000A32 RID: 2610
	private static int __PropertyOffset_TargetEntityId;

	// Token: 0x04000A33 RID: 2611
	private static int __PropertyOffset_TargetPos;

	// Token: 0x04000A34 RID: 2612
	private static int __PropertyOffset_TurnSpeed;
}
