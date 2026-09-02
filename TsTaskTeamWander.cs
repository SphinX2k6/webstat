using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CDE RID: 3294
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeamWander.TsTaskTeamWander_C")]
public class TsTaskTeamWander : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x060040DF RID: 16607 RVA: 0x000689F9 File Offset: 0x00066BF9
	// (set) Token: 0x060040E0 RID: 16608 RVA: 0x00068A09 File Offset: 0x00066C09
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float AllyDetect
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_AllyDetect);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_AllyDetect) = value;
		}
	}

	// Token: 0x170002EA RID: 746
	// (get) Token: 0x060040E1 RID: 16609 RVA: 0x00068A1A File Offset: 0x00066C1A
	// (set) Token: 0x060040E2 RID: 16610 RVA: 0x00068A2A File Offset: 0x00066C2A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170002EB RID: 747
	// (get) Token: 0x060040E3 RID: 16611 RVA: 0x00068A3B File Offset: 0x00066C3B
	// (set) Token: 0x060040E4 RID: 16612 RVA: 0x00068A4B File Offset: 0x00066C4B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool WalkOff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_WalkOff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTeamWander.__PropertyOffset_WalkOff) = (value ? 1 : 0);
		}
	}

	// Token: 0x060040E5 RID: 16613 RVA: 0x00068A5C File Offset: 0x00066C5C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsAllyDetect = this.AllyDetect;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsWalkOff = this.WalkOff;
		}
	}

	// Token: 0x060040E6 RID: 16614 RVA: 0x00068A98 File Offset: 0x00066C98
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

	// Token: 0x060040E7 RID: 16615 RVA: 0x00068B34 File Offset: 0x00066D34
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		this.CurrentMoveDirect = global::EMoveDirection.None;
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			return;
		}
		AiController aiController = tsAiController.AiController;
		if (!this.TsWalkOff)
		{
			BaseMoveComponent component = aiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.SetWalkOffLedgeRecord(false);
			}
		}
		aiController.CharActorComp.Entity.GetComponent<CharacterUnifiedStateComponent>().SetMoveState(ECharMoveState.Walk);
		if (this.Destination == null)
		{
			this.Destination = Vector.Create();
			this.LastDestination = Vector.Create();
		}
		if (this.TmpDestinationToTarget == null)
		{
			this.TmpDestinationToTarget = Vector.Create();
			this.TmpSelfToTarget = Vector.Create();
			this.TmpVector = Vector.Create();
			this.TmpVector2 = Vector.Create();
			this.TmpDirection = Vector.Create();
			this.TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
		}
		if (this.BlockDirectionsCache == null)
		{
			this.BlockDirectionsCache = new HashSet<global::EMoveDirection>();
		}
		this.NavigationInterval = 3f;
		this.NextDetectAllyTime = 0.0;
		this.NextTriggerTime = Singleton<Time>.Instance.Now;
		this.FirstFrame = true;
	}

	// Token: 0x060040E8 RID: 16616 RVA: 0x00068C5C File Offset: 0x00066E5C
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

	// Token: 0x060040E9 RID: 16617 RVA: 0x00068CFC File Offset: 0x00066EFC
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
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget == null || !currentTarget.Valid)
		{
			base.Finish(true);
			return;
		}
		CharacterActorComponent component = currentTarget.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			base.Finish(true);
			return;
		}
		if (Singleton<Time>.Instance.Now < this.NextTriggerTime)
		{
			component.ActorLocationProxy.Subtraction(aiController.CharActorComp.ActorLocationProxy, this.TmpSelfToTarget);
			this.TmpDirection.DeepCopy(this.TmpSelfToTarget);
			BaseMoveComponent component2 = aiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component2 == null || !component2.MoveController.IsMovingToLocation())
			{
				this.SetInputParams(aiController.CharActorComp, this.TmpSelfToTarget, this.TmpDirection);
			}
			return;
		}
		this.NextTriggerTime = Singleton<Time>.Instance.Now + 500.0;
		AiAreaMemberData aiTeamAreaMemberData = aiController.AiTeam.GetAiTeamAreaMemberData(aiController);
		if (aiTeamAreaMemberData == null || aiTeamAreaMemberData.AreaIndex < 0)
		{
			return;
		}
		if (this.FirstFrame)
		{
			this.FirstFrame = false;
			if (AiControllerLibrary.InTeamArea(aiController, aiTeamAreaMemberData, 1f))
			{
				base.Finish(true);
				return;
			}
		}
		else if (AiControllerLibrary.InTeamArea(aiController, aiTeamAreaMemberData, 0.5f))
		{
			base.Finish(true);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Vector actorLocationProxy = component.ActorLocationProxy;
		float num = (aiTeamAreaMemberData.CachedControllerYaw + aiTeamAreaMemberData.AngleCenter) * 0.017453292f;
		this.TmpVector.Set(Math.Cos((double)num) * (double)aiTeamAreaMemberData.DistanceCenter, Math.Sin((double)num) * (double)aiTeamAreaMemberData.DistanceCenter, 0.0);
		aiTeamAreaMemberData.Group.GravityQuat.RotateVector(this.TmpVector, this.Destination);
		this.Destination.AdditionEqual(aiTeamAreaMemberData.CachedTargetLocation);
		Singleton<GravityUtils>.Instance.SetZnInGravityForActor(charActorComp, this.Destination, Singleton<GravityUtils>.Instance.GetZnInGravityForActor(charActorComp, charActorComp.ActorLocationProxy));
		actorLocationProxy.Subtraction(aiController.CharActorComp.ActorLocationProxy, this.TmpSelfToTarget);
		this.TmpDirection.DeepCopy(this.TmpSelfToTarget);
		actorLocationProxy.Subtraction(this.Destination, this.TmpDestinationToTarget);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpSelfToTarget);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpDestinationToTarget);
		double num2 = this.TmpSelfToTarget.Size();
		double num3 = this.TmpDestinationToTarget.Size();
		if (num2 < 0.0001)
		{
			charActorComp.ActorForwardProxy.Multiply(-1.0, this.TmpSelfToTarget);
		}
		else
		{
			this.TmpSelfToTarget.DivisionEqual(num2);
		}
		if (num3 < 0.0001)
		{
			charActorComp.ActorForwardProxy.Multiply(-1.0, this.TmpDestinationToTarget);
		}
		else
		{
			this.TmpDestinationToTarget.DivisionEqual(num3);
		}
		float num4 = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(charActorComp, this.TmpDestinationToTarget, this.TmpSelfToTarget) * 0.017453292f;
		double forwardBackwardLength = num2 - num3;
		double rightLeftLength = num3 * (double)num4;
		if (Singleton<Time>.Instance.Now > this.NextDetectAllyTime)
		{
			this.NextDetectAllyTime = Singleton<Time>.Instance.Now + 1000.0;
			AiControllerLibrary.AllyBlockDirections(aiController, this.TmpSelfToTarget, this.TsAllyDetect, this.BlockDirectionsCache);
		}
		this.UpdateCurrentMoveDirection(forwardBackwardLength, rightLeftLength, aiTeamAreaMemberData, this.BlockDirectionsCache, charActorComp.ActorLocationProxy, this.TmpSelfToTarget);
		if (this.NavigationInterval > 3f)
		{
			this.NavigationInterval = 0f;
			if (this.SetMoveToLocation(this.Destination, aiController.CharActorComp, component))
			{
				return;
			}
			this.StopMoveToLocation(aiController.CharActorComp);
		}
		BaseMoveComponent component3 = charActorComp.Entity.GetComponent<BaseMoveComponent>();
		if (component3 == null || !component3.MoveController.IsMovingToLocation())
		{
			this.SetInputParams(charActorComp, this.TmpSelfToTarget, this.TmpDirection);
		}
	}

	// Token: 0x060040EA RID: 16618 RVA: 0x00069130 File Offset: 0x00067330
	private void UpdateCurrentMoveDirection(double forwardBackwardLength, double rightLeftLength, AiAreaMemberData areaMemberData, HashSet<global::EMoveDirection> blockDirections, Vector selfLocation, Vector forwardDirect)
	{
		if (forwardBackwardLength > (double)areaMemberData.MaxDistanceOffset)
		{
			this.CurrentMoveDirect = this.GetMoveDirectionForwardBackward(forwardBackwardLength);
			return;
		}
		if (rightLeftLength > (double)(areaMemberData.MaxAngleOffset * 0.017453292f * areaMemberData.DistanceCenter))
		{
			this.CurrentMoveDirect = this.GetMoveDirectionRightLeft(rightLeftLength);
			return;
		}
		ValueTuple<global::EMoveDirection, global::EMoveDirection> moveDirection = this.GetMoveDirection(forwardBackwardLength, rightLeftLength);
		global::EMoveDirection emoveDirection = moveDirection.Item1;
		global::EMoveDirection emoveDirection2 = moveDirection.Item2;
		if (blockDirections.Contains(emoveDirection2) || AiControllerLibrary.NavigationBlockDirectionE(base.AIOwner, selfLocation, forwardDirect, emoveDirection2, 100f, true))
		{
			emoveDirection2 = global::EMoveDirection.None;
		}
		if (blockDirections.Contains(emoveDirection) || AiControllerLibrary.NavigationBlockDirectionE(base.AIOwner, selfLocation, forwardDirect, emoveDirection, 100f, true))
		{
			emoveDirection = emoveDirection2;
			emoveDirection2 = global::EMoveDirection.None;
		}
		if (emoveDirection2 == global::EMoveDirection.None)
		{
			this.CurrentMoveDirect = emoveDirection;
			return;
		}
		if (this.CurrentMoveDirect == emoveDirection2)
		{
			if ((this.CurrentMoveDirect == global::EMoveDirection.Forward || this.CurrentMoveDirect == global::EMoveDirection.Backward) && this.NeedChangeDirect(forwardBackwardLength, rightLeftLength))
			{
				this.CurrentMoveDirect = emoveDirection;
				return;
			}
		}
		else
		{
			this.CurrentMoveDirect = emoveDirection;
		}
	}

	// Token: 0x060040EB RID: 16619 RVA: 0x00069218 File Offset: 0x00067418
	private void StopMoveToLocation(CharacterActorComponent character)
	{
		BaseMoveComponent component = character.Entity.GetComponent<BaseMoveComponent>();
		if (component != null && component.MoveController.IsMovingToLocation())
		{
			component.MoveController.StopMoveToLocation("TsTaskTeamWander.StopMoveToLocation");
		}
		this.LastDestination.Reset();
	}

	// Token: 0x060040EC RID: 16620 RVA: 0x0006925C File Offset: 0x0006745C
	private bool SetMoveToLocation(Vector target, CharacterActorComponent actorComp, CharacterActorComponent targetCharacter)
	{
		this.TmpVector2.DeepCopy(target);
		BaseMoveComponent component = actorComp.Entity.GetComponent<BaseMoveComponent>();
		if (component == null)
		{
			return false;
		}
		if ((!this.LastDestination.IsNearlyZero(9.999999747378752E-05) || Vector.Dist(this.LastDestination, this.TmpVector2) < 100.0) && component.MoveController.IsMovingToLocation())
		{
			this.LastDestination.DeepCopy(this.TmpVector2);
			return true;
		}
		this.LastDestination.DeepCopy(this.TmpVector2);
		bool flag = (this.CurrentMoveDirect == global::EMoveDirection.Left || this.CurrentMoveDirect == global::EMoveDirection.Right) && actorComp.WanderDirectionType == EWanderDirectionType.FB;
		MoveToLocationController moveController = component.MoveController;
		MoveToPointConfigImpl moveToPointConfigImpl = new MoveToPointConfigImpl();
		moveToPointConfigImpl.Position = this.TmpVector2;
		moveToPointConfigImpl.UseNearestDirection = new bool?(!flag);
		moveToPointConfigImpl.FaceToPosition = (flag ? null : targetCharacter.ActorLocationProxy);
		moveToPointConfigImpl.ResetCondition = (() => false);
		return moveController.NavigateMoveToLocation(moveToPointConfigImpl, new bool?(true), false, "TsTaskTeamWander.SetMoveToLocation");
	}

	// Token: 0x060040ED RID: 16621 RVA: 0x00069378 File Offset: 0x00067578
	private void SetInputParams(CharacterActorComponent actorComp, Vector faceToTargetActor, Vector forwardDirect)
	{
		if (this.CurrentMoveDirect == global::EMoveDirection.None)
		{
			AiControllerLibrary.ClearInput((TsAiController)base.AIOwner);
			return;
		}
		this.TmpVector.DeepCopy(forwardDirect);
		Singleton<GravityUtils>.Instance.TurnVectorByDirectionInGravityForActor(actorComp, this.TmpVector, this.CurrentMoveDirect);
		BaseUnifiedStateComponent component = actorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
		if (component == null || component.MoveState != ECharMoveState.Walk)
		{
			AiControllerLibrary.TurnToDirect(actorComp, this.TmpVector, this.TsTurnSpeed, false, 0f);
			actorComp.SetInputDirect(actorComp.ActorForwardProxy, false);
			return;
		}
		AiControllerLibrary.InputNearestDirection(actorComp, this.TmpVector, this.TmpQuat, this.TmpVector2, this.TsTurnSpeed, true, faceToTargetActor);
	}

	// Token: 0x060040EE RID: 16622 RVA: 0x0006942C File Offset: 0x0006762C
	[NullableContext(0)]
	private ValueTuple<global::EMoveDirection, global::EMoveDirection> GetMoveDirection(double forwardBackwardLength, double rightLeftLength)
	{
		if (Math.Abs(forwardBackwardLength) > Math.Abs(rightLeftLength))
		{
			return new ValueTuple<global::EMoveDirection, global::EMoveDirection>(this.GetMoveDirectionForwardBackward(forwardBackwardLength), this.GetMoveDirectionRightLeft(rightLeftLength));
		}
		return new ValueTuple<global::EMoveDirection, global::EMoveDirection>(this.GetMoveDirectionRightLeft(rightLeftLength), this.GetMoveDirectionForwardBackward(forwardBackwardLength));
	}

	// Token: 0x060040EF RID: 16623 RVA: 0x00069463 File Offset: 0x00067663
	private global::EMoveDirection GetMoveDirectionForwardBackward(double length)
	{
		if (Math.Abs(length) < 10.0)
		{
			return global::EMoveDirection.None;
		}
		if (length <= 0.0)
		{
			return global::EMoveDirection.Backward;
		}
		return global::EMoveDirection.Forward;
	}

	// Token: 0x060040F0 RID: 16624 RVA: 0x00069487 File Offset: 0x00067687
	private global::EMoveDirection GetMoveDirectionRightLeft(double length)
	{
		if (Math.Abs(length) < 10.0)
		{
			return global::EMoveDirection.None;
		}
		if (length <= 0.0)
		{
			return global::EMoveDirection.Left;
		}
		return global::EMoveDirection.Right;
	}

	// Token: 0x060040F1 RID: 16625 RVA: 0x000694AC File Offset: 0x000676AC
	private bool NeedChangeDirect(double lengthMain, double lengthSecond)
	{
		double num = Math.Abs(lengthMain);
		if (num < 10.0)
		{
			return true;
		}
		double num2 = Math.Abs(lengthSecond);
		return num * 1.3 < num2 && num + 500.0 < num2;
	}

	// Token: 0x060040F2 RID: 16626 RVA: 0x000694F4 File Offset: 0x000676F4
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			BaseMoveComponent component = tsAiController.AiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.MoveController.StopMoveToLocation("TsTaskTeamWander.OnClear");
			}
			this.LastDestination.Reset();
			AiControllerLibrary.ClearInput(tsAiController);
			if (!this.TsWalkOff && component != null)
			{
				component.SetWalkOffLedgeRecord(true);
			}
		}
	}

	// Token: 0x060040F3 RID: 16627 RVA: 0x0006955C File Offset: 0x0006775C
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTeamWander._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeamWander.TsTaskTeamWander_C");
		}
		return TsTaskTeamWander._ClassPtr;
	}

	// Token: 0x060040F4 RID: 16628 RVA: 0x00069580 File Offset: 0x00067780
	public TsTaskTeamWander() : this(BuiltinUtils.AllocNativeUObject(TsTaskTeamWander.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060040F5 RID: 16629 RVA: 0x000695A8 File Offset: 0x000677A8
	public TsTaskTeamWander(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTeamWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060040F6 RID: 16630 RVA: 0x000695DC File Offset: 0x000677DC
	protected TsTaskTeamWander(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040F7 RID: 16631 RVA: 0x00069670 File Offset: 0x00067870
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060040F8 RID: 16632 RVA: 0x000696A0 File Offset: 0x000678A0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000F59 RID: 3929
	private const int THREADHOLD_ABS = 500;

	// Token: 0x04000F5A RID: 3930
	private const double THREADHOLD_RATIO = 1.3;

	// Token: 0x04000F5B RID: 3931
	private const int THREADHOLD_ARRIVE = 10;

	// Token: 0x04000F5C RID: 3932
	private const int ALLY_DETECT_PERIOD = 1000;

	// Token: 0x04000F5D RID: 3933
	private const int TRIGGER_PERIOD = 500;

	// Token: 0x04000F5E RID: 3934
	private const int NAV_INTERVAL_TIME = 3;

	// Token: 0x04000F5F RID: 3935
	private bool IsInitTsVariables;

	// Token: 0x04000F60 RID: 3936
	private float TsAllyDetect;

	// Token: 0x04000F61 RID: 3937
	private float TsTurnSpeed;

	// Token: 0x04000F62 RID: 3938
	private bool TsWalkOff;

	// Token: 0x04000F63 RID: 3939
	private global::EMoveDirection CurrentMoveDirect = global::EMoveDirection.None;

	// Token: 0x04000F64 RID: 3940
	private double NextDetectAllyTime;

	// Token: 0x04000F65 RID: 3941
	private Vector Destination = Vector.Create();

	// Token: 0x04000F66 RID: 3942
	private Vector LastDestination = Vector.Create();

	// Token: 0x04000F67 RID: 3943
	private Vector TmpDestinationToTarget = Vector.Create();

	// Token: 0x04000F68 RID: 3944
	private Vector TmpSelfToTarget = Vector.Create();

	// Token: 0x04000F69 RID: 3945
	private Vector TmpDirection = Vector.Create();

	// Token: 0x04000F6A RID: 3946
	private Vector TmpVector = Vector.Create();

	// Token: 0x04000F6B RID: 3947
	private Vector TmpVector2 = Vector.Create();

	// Token: 0x04000F6C RID: 3948
	private Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000F6D RID: 3949
	private HashSet<global::EMoveDirection> BlockDirectionsCache = new HashSet<global::EMoveDirection>();

	// Token: 0x04000F6E RID: 3950
	private double NextTriggerTime;

	// Token: 0x04000F6F RID: 3951
	private bool FirstFrame;

	// Token: 0x04000F70 RID: 3952
	private float NavigationInterval;

	// Token: 0x04000F71 RID: 3953
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTeamWander.TsTaskTeamWander_C";

	// Token: 0x04000F72 RID: 3954
	private static IntPtr _ClassPtr;

	// Token: 0x04000F73 RID: 3955
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F74 RID: 3956
	private static int __PropertyOffset_AllyDetect;

	// Token: 0x04000F75 RID: 3957
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000F76 RID: 3958
	private static int __PropertyOffset_WalkOff;
}
