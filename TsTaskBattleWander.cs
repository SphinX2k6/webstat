using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA2 RID: 3234
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleWander.TsTaskBattleWander_C")]
public class TsTaskBattleWander : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06003C55 RID: 15445 RVA: 0x00051971 File Offset: 0x0004FB71
	// (set) Token: 0x06003C56 RID: 15446 RVA: 0x00051981 File Offset: 0x0004FB81
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x06003C57 RID: 15447 RVA: 0x00051992 File Offset: 0x0004FB92
	// (set) Token: 0x06003C58 RID: 15448 RVA: 0x000519A2 File Offset: 0x0004FBA2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AllyDetect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_AllyDetect);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_AllyDetect) = value;
		}
	}

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x06003C59 RID: 15449 RVA: 0x000519B3 File Offset: 0x0004FBB3
	// (set) Token: 0x06003C5A RID: 15450 RVA: 0x000519C3 File Offset: 0x0004FBC3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool WalkOff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_WalkOff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskBattleWander.__PropertyOffset_WalkOff) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003C5B RID: 15451 RVA: 0x000519D4 File Offset: 0x0004FBD4
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

	// Token: 0x06003C5C RID: 15452 RVA: 0x00051A44 File Offset: 0x0004FC44
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsAllyDetect = this.AllyDetect;
			this.TsWalkOff = this.WalkOff;
		}
		if (this.TmpVector == null)
		{
			this.TmpVector = global::Vector.Create();
			this.TmpOffset = global::Vector.Create();
			this.TmpVector2 = global::Vector.Create();
			this.TmpDirection = global::Vector.Create();
			this.TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
			this.LastDestination = global::Vector.Create();
		}
	}

	// Token: 0x06003C5D RID: 15453 RVA: 0x00051AEC File Offset: 0x0004FCEC
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

	// Token: 0x06003C5E RID: 15454 RVA: 0x00051B88 File Offset: 0x0004FD88
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		this.DistanceIndex = 4;
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			return;
		}
		AiController aiController = tsAiController.AiController;
		if (!this.TsWalkOff)
		{
			CharacterMoveComponent component = aiController.CharActorComp.Entity.GetComponent<CharacterMoveComponent>();
			if (component != null)
			{
				component.SetWalkOffLedgeRecord(false);
			}
		}
		AiWanderInfos aiWanderInfos = aiController.AiWanderInfos;
		if (((aiWanderInfos != null) ? aiWanderInfos.AiBattleWanderGroups : null) == null || aiController.AiWanderInfos.AiBattleWanderGroups.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "没有配置战斗游荡";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.EndTime = Singleton<Time>.Instance.WorldTime + aiController.AiWanderInfos.RandomBattleWanderEndTime();
		aiController.AiWanderInfos.BattleWanderAddTime = 0f;
		this.NextPickDirectTime = 0.0;
		this.NextTriggerTime = 0.0;
		this.NavigationInterval = 3f;
		this.DistanceIndex = -1;
		this.DirectIndex = global::EMoveDirection.None;
	}

	// Token: 0x06003C5F RID: 15455 RVA: 0x00051CA0 File Offset: 0x0004FEA0
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

	// Token: 0x06003C60 RID: 15456 RVA: 0x00051D40 File Offset: 0x0004FF40
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		this.NavigationInterval += deltaSeconds;
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.Finish(false);
			return;
		}
		AiController aiController = tsAiController.AiController;
		AiWanderInfos aiWanderInfos = aiController.AiWanderInfos;
		if (((aiWanderInfos != null) ? aiWanderInfos.AiBattleWanderGroups : null) == null || aiController.AiWanderInfos.AiBattleWanderGroups.Count == 0)
		{
			base.Finish(false);
			return;
		}
		if (this.EndTime + (double)aiController.AiWanderInfos.BattleWanderAddTime < Singleton<Time>.Instance.WorldTime)
		{
			base.Finish(true);
			return;
		}
		AiBattleWanderGroup wanderData = this.GetWanderData(aiController);
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget == null || !currentTarget.Valid)
		{
			base.Finish(false);
			return;
		}
		CharacterActorComponent component = currentTarget.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			base.Finish(false);
			return;
		}
		if (Singleton<Time>.Instance.Now < this.NextTriggerTime)
		{
			this.SetInputParams(tsAiController.AiController.CharActorComp, component, wanderData);
			return;
		}
		this.NextTriggerTime = Singleton<Time>.Instance.Now + 500.0;
		component.ActorLocationProxy.Subtraction(charActorComp.ActorLocationProxy, this.TmpOffset);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpOffset);
		double num = this.TmpOffset.Size();
		if (num < 1E-08)
		{
			charActorComp.ActorForwardProxy.Multiply(-1.0, this.TmpVector);
			charActorComp.SetInputDirect(this.TmpVector, false);
			return;
		}
		if (num <= (double)wanderData.DistanceRange(0))
		{
			this.DistanceIndex = 0;
			this.DirectIndex = global::EMoveDirection.Backward;
		}
		else if (num > (double)wanderData.DistanceRange(3))
		{
			this.DistanceIndex = 4;
			this.DirectIndex = global::EMoveDirection.Forward;
		}
		else if (this.NextPickDirectTime < Singleton<Time>.Instance.WorldTime)
		{
			this.PickDirect(aiController, wanderData);
			this.NextPickDirectTime = Singleton<Time>.Instance.WorldTime + Singleton<MathUtils>.Instance.GetRandomRange((double)wanderData.WanderTime.Value.Min, (double)wanderData.WanderTime.Value.Max);
		}
		this.SetInputParams(tsAiController.AiController.CharActorComp, component, wanderData);
	}

	// Token: 0x06003C61 RID: 15457 RVA: 0x00051FC0 File Offset: 0x000501C0
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			BaseMoveComponent component = tsAiController.AiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.MoveController.StopMoveToLocation("TsTaskBattleWander.OnClear");
			}
			this.LastDestination.Reset();
			AiControllerLibrary.ClearInput(tsAiController);
			if (!this.TsWalkOff && component != null)
			{
				component.SetWalkOffLedgeRecord(true);
			}
		}
	}

	// Token: 0x06003C62 RID: 15458 RVA: 0x00052028 File Offset: 0x00050228
	private AiBattleWanderGroup GetWanderData(AiController aiController)
	{
		return aiController.AiWanderInfos.GetCurrentBattleWander();
	}

	// Token: 0x06003C63 RID: 15459 RVA: 0x00052038 File Offset: 0x00050238
	private bool PickDirect(AiController aiController, AiBattleWanderGroup wanderData)
	{
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (currentTarget == null || !currentTarget.Valid)
		{
			return false;
		}
		CharacterActorComponent component = currentTarget.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return false;
		}
		component.ActorLocationProxy.Subtraction(charActorComp.ActorLocationProxy, this.TmpOffset);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpOffset);
		double distance = this.TmpOffset.Size() - (double)charActorComp.ScaledRadius - (double)component.ScaledRadius;
		this.DistanceIndex = this.FindDistanceIndexByDistance(wanderData, distance);
		this.FindDirectByWeights(wanderData);
		this.CheckNavigationAndAllyBlock(aiController, this.TmpOffset, distance);
		CharacterUnifiedStateComponent component2 = aiController.CharAiDesignComp.Entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component2.Valid)
		{
			switch (this.TsMoveState)
			{
			case 1:
				component2.SetMoveState(ECharMoveState.Walk);
				break;
			case 2:
				component2.SetMoveState(ECharMoveState.Run);
				break;
			case 3:
				component2.SetMoveState(ECharMoveState.Sprint);
				break;
			}
		}
		return true;
	}

	// Token: 0x06003C64 RID: 15460 RVA: 0x0005213C File Offset: 0x0005033C
	private int FindDistanceIndexByDistance(AiBattleWanderGroup wanderData, double distance)
	{
		int num = 0;
		while (num < 4 && distance > (double)wanderData.DistanceRange(num))
		{
			num++;
		}
		return num;
	}

	// Token: 0x06003C65 RID: 15461 RVA: 0x00052164 File Offset: 0x00050364
	private void FindDirectByWeights(AiBattleWanderGroup wanderData)
	{
		if (this.DistanceIndex == 0)
		{
			this.DirectIndex = global::EMoveDirection.Backward;
			return;
		}
		if (this.DistanceIndex == 4)
		{
			this.DirectIndex = global::EMoveDirection.Forward;
			return;
		}
		int distanceIndex = this.DistanceIndex;
		float[] array;
		if (distanceIndex != 1)
		{
			if (distanceIndex != 2)
			{
				array = wanderData.FarActionRates();
			}
			else
			{
				array = wanderData.MiddleActionRates();
			}
		}
		else
		{
			array = wanderData.NearActionRates();
		}
		double num = Singleton<MathUtils>.Instance.GetRandomRange(0.0, 100.0);
		int num2 = 0;
		while (num2 < array.Length && num >= (double)array[num2])
		{
			num -= (double)array[num2];
			num2++;
		}
		this.DirectIndex = (global::EMoveDirection)num2;
	}

	// Token: 0x06003C66 RID: 15462 RVA: 0x00052200 File Offset: 0x00050400
	private void CheckNavigationAndAllyBlock(AiController aiController, global::Vector offset, double distance)
	{
		if (this.DirectIndex == global::EMoveDirection.None)
		{
			return;
		}
		if (distance <= 1E-08)
		{
			return;
		}
		this.TmpVector.DeepCopy(offset);
		this.TmpVector.DivisionEqual(distance);
		if (AiControllerLibrary.AllyOnPath(aiController, this.TmpVector, this.TsAllyDetect, this.DirectIndex))
		{
			this.DirectIndex = global::EMoveDirection.None;
			return;
		}
		Singleton<GravityUtils>.Instance.TurnVectorByDirectionInGravityForActor(aiController.CharActorComp, this.TmpVector, this.DirectIndex);
	}

	// Token: 0x06003C67 RID: 15463 RVA: 0x0005227C File Offset: 0x0005047C
	private void SetInputParams(CharacterActorComponent character, CharacterActorComponent targetCharacter, AiBattleWanderGroup wanderData)
	{
		targetCharacter.ActorLocationProxy.Subtraction(character.ActorLocationProxy, this.TmpOffset);
		this.TmpDirection.DeepCopy(this.TmpOffset);
		Singleton<GravityUtils>.Instance.TurnVectorByDirectionInGravityForActor(character, this.TmpOffset, this.DirectIndex);
		float turnSpeed = (this.TsMoveState == 2) ? wanderData.RunTurnSpeed : wanderData.TurnSpeeds((int)this.DirectIndex);
		if (this.NavigationInterval > 3f)
		{
			this.NavigationInterval = 0f;
			if (this.SetMoveToLocation(this.TmpOffset, character, turnSpeed, targetCharacter.ActorLocationProxy))
			{
				return;
			}
			this.StopMoveToLocation(character);
		}
		if (this.DirectIndex != global::EMoveDirection.None && AiControllerLibrary.NavigationBlockDirectionE(base.AIOwner, character.ActorLocationProxy, character.ActorForwardProxy, this.DirectIndex, 100f, true))
		{
			this.DirectIndex = global::EMoveDirection.None;
			character.ClearInput(false, true);
			return;
		}
		BaseMoveComponent component = character.Entity.GetComponent<BaseMoveComponent>();
		if (component == null || !component.MoveController.IsMovingToLocation())
		{
			BaseUnifiedStateComponent component2 = character.Entity.GetComponent<BaseUnifiedStateComponent>();
			if (component2 == null || component2.MoveState != ECharMoveState.Walk)
			{
				AiControllerLibrary.TurnToDirect(character, this.TmpOffset, turnSpeed, false, 0f);
				character.SetInputDirect(character.ActorForwardProxy, false);
				return;
			}
			AiControllerLibrary.InputNearestDirection(character, this.TmpOffset, this.TmpQuat, this.TmpVector2, turnSpeed, true, this.TmpDirection);
		}
	}

	// Token: 0x06003C68 RID: 15464 RVA: 0x000523E0 File Offset: 0x000505E0
	private void StopMoveToLocation(CharacterActorComponent character)
	{
		BaseMoveComponent component = character.Entity.GetComponent<BaseMoveComponent>();
		if (component != null && component.MoveController.IsMovingToLocation() && component != null)
		{
			component.MoveController.StopMoveToLocation("TsTaskBattleWander.StopMoveToLocation");
		}
		this.LastDestination.Reset();
	}

	// Token: 0x06003C69 RID: 15465 RVA: 0x00052428 File Offset: 0x00050628
	private bool SetMoveToLocation(global::Vector target, CharacterActorComponent actorComp, float turnSpeed, global::Vector facingDirection)
	{
		this.TmpVector2.DeepCopy(target);
		this.TmpVector2.AdditionEqual(actorComp.ActorLocationProxy);
		BaseMoveComponent component = actorComp.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return false;
		}
		if ((!this.LastDestination.IsNearlyZero(9.999999747378752E-05) || global::Vector.Dist(this.LastDestination, this.TmpVector2) < 100.0) && component.MoveController.IsMovingToLocation())
		{
			this.LastDestination.DeepCopy(this.TmpVector2);
			return true;
		}
		this.LastDestination.DeepCopy(this.TmpVector2);
		bool flag = (this.DirectIndex == global::EMoveDirection.Left || this.DirectIndex == global::EMoveDirection.Right) && actorComp.WanderDirectionType == EWanderDirectionType.FB;
		MoveToLocationController moveController = component.MoveController;
		MoveToPointConfigImpl moveToPointConfigImpl = new MoveToPointConfigImpl();
		moveToPointConfigImpl.Position = this.TmpVector2;
		moveToPointConfigImpl.TurnSpeed = new float?(turnSpeed);
		moveToPointConfigImpl.UseNearestDirection = new bool?(!flag);
		moveToPointConfigImpl.FaceToPosition = (flag ? null : facingDirection);
		moveToPointConfigImpl.ResetCondition = (() => false);
		return moveController.NavigateMoveToLocation(moveToPointConfigImpl, new bool?(true), false, "TsTaskBattleWander.SetMoveToLocation");
	}

	// Token: 0x06003C6A RID: 15466 RVA: 0x0005255C File Offset: 0x0005075C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskBattleWander._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleWander.TsTaskBattleWander_C");
		}
		return TsTaskBattleWander._ClassPtr;
	}

	// Token: 0x06003C6B RID: 15467 RVA: 0x00052580 File Offset: 0x00050780
	public TsTaskBattleWander() : this(BuiltinUtils.AllocNativeUObject(TsTaskBattleWander.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C6C RID: 15468 RVA: 0x000525A8 File Offset: 0x000507A8
	public TsTaskBattleWander(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBattleWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C6D RID: 15469 RVA: 0x000525DC File Offset: 0x000507DC
	protected TsTaskBattleWander(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C6E RID: 15470 RVA: 0x0005264D File Offset: 0x0005084D
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003C6F RID: 15471 RVA: 0x00052658 File Offset: 0x00050858
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003C70 RID: 15472 RVA: 0x00052688 File Offset: 0x00050888
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000B6A RID: 2922
	private const int MAX_DISTANCE_INDEX = 4;

	// Token: 0x04000B6B RID: 2923
	private const int SUM_WEIGHT = 100;

	// Token: 0x04000B6C RID: 2924
	private const int TRIGGER_PERIOD = 500;

	// Token: 0x04000B6D RID: 2925
	private const int NAV_INTERVAL_TIME = 3;

	// Token: 0x04000B6E RID: 2926
	private bool IsInitTsVariables;

	// Token: 0x04000B6F RID: 2927
	private int TsMoveState;

	// Token: 0x04000B70 RID: 2928
	private float TsAllyDetect;

	// Token: 0x04000B71 RID: 2929
	private bool TsWalkOff;

	// Token: 0x04000B72 RID: 2930
	private int DistanceIndex;

	// Token: 0x04000B73 RID: 2931
	private global::EMoveDirection DirectIndex = global::EMoveDirection.None;

	// Token: 0x04000B74 RID: 2932
	private double EndTime;

	// Token: 0x04000B75 RID: 2933
	private double NextPickDirectTime;

	// Token: 0x04000B76 RID: 2934
	private global::Vector TmpVector = global::Vector.Create();

	// Token: 0x04000B77 RID: 2935
	private global::Vector TmpOffset = global::Vector.Create();

	// Token: 0x04000B78 RID: 2936
	private global::Vector TmpDirection = global::Vector.Create();

	// Token: 0x04000B79 RID: 2937
	private global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x04000B7A RID: 2938
	private global::Vector LastDestination = global::Vector.Create();

	// Token: 0x04000B7B RID: 2939
	private Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000B7C RID: 2940
	private double NextTriggerTime;

	// Token: 0x04000B7D RID: 2941
	private float NavigationInterval;

	// Token: 0x04000B7E RID: 2942
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBattleWander.TsTaskBattleWander_C";

	// Token: 0x04000B7F RID: 2943
	private static IntPtr _ClassPtr;

	// Token: 0x04000B80 RID: 2944
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000B81 RID: 2945
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000B82 RID: 2946
	private static int __PropertyOffset_AllyDetect;

	// Token: 0x04000B83 RID: 2947
	private static int __PropertyOffset_WalkOff;
}
