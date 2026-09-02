using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CD7 RID: 3287
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSkillWander.TsTaskSkillWander_C")]
public class TsTaskSkillWander : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06004087 RID: 16519 RVA: 0x00066BF3 File Offset: 0x00064DF3
	// (set) Token: 0x06004088 RID: 16520 RVA: 0x00066C03 File Offset: 0x00064E03
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ForwardFirst
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_ForwardFirst) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_ForwardFirst) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06004089 RID: 16521 RVA: 0x00066C14 File Offset: 0x00064E14
	// (set) Token: 0x0600408A RID: 16522 RVA: 0x00066C24 File Offset: 0x00064E24
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckSkillPeriod
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_CheckSkillPeriod);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_CheckSkillPeriod) = value;
		}
	}

	// Token: 0x170002DC RID: 732
	// (get) Token: 0x0600408B RID: 16523 RVA: 0x00066C35 File Offset: 0x00064E35
	// (set) Token: 0x0600408C RID: 16524 RVA: 0x00066C45 File Offset: 0x00064E45
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x170002DD RID: 733
	// (get) Token: 0x0600408D RID: 16525 RVA: 0x00066C56 File Offset: 0x00064E56
	// (set) Token: 0x0600408E RID: 16526 RVA: 0x00066C66 File Offset: 0x00064E66
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int SkillType
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_SkillType);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_SkillType) = value;
		}
	}

	// Token: 0x170002DE RID: 734
	// (get) Token: 0x0600408F RID: 16527 RVA: 0x00066C77 File Offset: 0x00064E77
	// (set) Token: 0x06004090 RID: 16528 RVA: 0x00066C87 File Offset: 0x00064E87
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugLog
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_DebugLog) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_DebugLog) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002DF RID: 735
	// (get) Token: 0x06004091 RID: 16529 RVA: 0x00066C98 File Offset: 0x00064E98
	// (set) Token: 0x06004092 RID: 16530 RVA: 0x00066CA8 File Offset: 0x00064EA8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool WalkOff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_WalkOff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskSkillWander.__PropertyOffset_WalkOff) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004093 RID: 16531 RVA: 0x00066CBC File Offset: 0x00064EBC
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsForwardFirst = this.ForwardFirst;
			this.TsCheckSkillPeriod = this.CheckSkillPeriod;
			this.TsMoveState = ((this.MoveState == 2) ? ECharMoveState.Run : ECharMoveState.Walk);
			this.TsSkillType = this.SkillType;
			this.TsDebugLog = this.DebugLog;
			this.TsWalkOff = this.WalkOff;
			this.TmpVector = global::Vector.Create();
			this.TmpSelfToTarget = global::Vector.Create();
			this.TmpForward = global::Vector.Create();
			this.TmpBackward = global::Vector.Create();
			this.TmpVector2 = global::Vector.Create();
			this.TmpQuat = Quat.Create(0f, 0f, 0f, 1f);
			this.LastDestination = global::Vector.Create();
		}
	}

	// Token: 0x06004094 RID: 16532 RVA: 0x00066D94 File Offset: 0x00064F94
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

	// Token: 0x06004095 RID: 16533 RVA: 0x00066E30 File Offset: 0x00065030
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.NavigationInterval = 3f;
		this.InitTsVariables();
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			return;
		}
		if (!this.TsWalkOff)
		{
			CharacterMoveComponent component = aiController.CharActorComp.Entity.GetComponent<CharacterMoveComponent>();
			if (component != null)
			{
				component.SetWalkOffLedgeRecord(false);
			}
		}
		CharacterUnifiedStateComponent component2 = aiController.CharActorComp.Entity.GetComponent<CharacterUnifiedStateComponent>();
		if (component2 == null)
		{
			return;
		}
		component2.SetMoveState(this.TsMoveState);
	}

	// Token: 0x06004096 RID: 16534 RVA: 0x00066EAC File Offset: 0x000650AC
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

	// Token: 0x06004097 RID: 16535 RVA: 0x00066F4C File Offset: 0x0006514C
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		this.NavigationInterval += deltaSeconds;
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
		EntityHandle currentTarget = aiController.AiHateList.GetCurrentTarget();
		if (currentTarget == null || !currentTarget.Valid)
		{
			base.Finish(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		CharacterActorComponent component = currentTarget.Entity.GetComponent<CharacterActorComponent>();
		Singleton<MathUtils>.Instance.InverseTransformPositionNoScale(component.FloorLocation, component.ActorRotationProxy, charActorComp.FloorLocation, this.TmpVector);
		double angleByVector2D = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.TmpVector);
		component.FloorLocation.Subtraction(charActorComp.FloorLocation, this.TmpSelfToTarget);
		double height = Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpSelfToTarget);
		double num = this.TmpSelfToTarget.Size();
		double num2 = Math.Max(num - (double)charActorComp.ScaledRadius - (double)component.ScaledRadius, 1E-08);
		this.TmpVector.DeepCopy(this.TmpSelfToTarget);
		this.TmpVector.DivisionEqual(num);
		float angleOffsetInGravityForActor = Singleton<GravityUtils>.Instance.GetAngleOffsetInGravityForActor(charActorComp, charActorComp.ActorForwardProxy, this.TmpVector);
		if (this.NextCheckSkillTime == 0.0 || this.NextCheckSkillTime < Singleton<Time>.Instance.WorldTime)
		{
			this.NextCheckSkillTime = Singleton<Time>.Instance.WorldTime + (double)this.TsCheckSkillPeriod;
			if (!this.FindArea(aiController, num2, angleByVector2D, height, this.TmpVector))
			{
				base.Finish(false);
				return;
			}
		}
		else if (this.SelectedSkillPrecondition == null)
		{
			base.Finish(false);
			return;
		}
		bool flag = Singleton<MathUtils>.Instance.InRange(num2, this.SelectedSkillPrecondition.Value.DistanceRange.Value);
		bool flag2 = Singleton<MathUtils>.Instance.InRange((double)angleOffsetInGravityForActor, this.SelectedSkillPrecondition.Value.AngleRange.Value);
		if (flag && flag2)
		{
			base.Finish(true);
			return;
		}
		AiBattleWanderGroup currentBattleWander = aiController.AiWanderInfos.GetCurrentBattleWander();
		FloatRange value = this.SelectedSkillPrecondition.Value.DistanceRange.Value;
		double num3 = this.PreForward ? ((double)value.Min * 0.6666666666666667 + (double)value.Max * 0.3333333333333333) : ((double)value.Min * 0.3333333333333333 + (double)value.Max * 0.6666666666666667);
		BaseUnifiedStateComponent component2 = charActorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
		ECharMoveState echarMoveState = this.TsMoveState;
		if ((flag && !flag2) || num2 < num3)
		{
			echarMoveState = ECharMoveState.Walk;
		}
		if ((component2 == null || component2.MoveState != echarMoveState) && component2 != null)
		{
			component2.SetMoveState(echarMoveState);
		}
		float num4 = currentBattleWander.RunTurnSpeed;
		this.TmpVector.DeepCopy(this.TmpSelfToTarget);
		if (num2 < num3)
		{
			num4 = ((echarMoveState == ECharMoveState.Run) ? num4 : currentBattleWander.TurnSpeeds(1));
			this.TmpVector.UnaryNegation(this.TmpVector);
			this.PreForward = false;
		}
		else
		{
			num4 = ((echarMoveState == ECharMoveState.Run) ? num4 : currentBattleWander.TurnSpeeds(0));
			this.PreForward = true;
		}
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(charActorComp, this.TmpVector);
		if (!flag && this.NavigationInterval > 3f)
		{
			this.NavigationInterval = 0f;
			if (this.SetMoveToLocation(this.TmpVector, charActorComp, num4, component.ActorLocationProxy))
			{
				return;
			}
			this.StopMoveToLocation(charActorComp);
		}
		BaseMoveComponent component3 = charActorComp.Entity.GetComponent<BaseMoveComponent>();
		if (component3 == null || !component3.MoveController.IsMovingToLocation())
		{
			if (component2 == null || component2.MoveState != ECharMoveState.Walk)
			{
				AiControllerLibrary.TurnToDirect(charActorComp, this.TmpVector, num4, false, 0f);
				charActorComp.SetInputDirect(charActorComp.ActorForwardProxy, false);
				return;
			}
			AiControllerLibrary.InputNearestDirection(charActorComp, this.TmpVector, this.TmpQuat, this.TmpVector2, num4, true, this.TmpSelfToTarget);
		}
	}

	// Token: 0x06004098 RID: 16536 RVA: 0x0006738C File Offset: 0x0006558C
	private void StopMoveToLocation(CharacterActorComponent character)
	{
		BaseMoveComponent component = character.Entity.GetComponent<BaseMoveComponent>();
		if (component != null && component.MoveController.IsMovingToLocation())
		{
			component.MoveController.StopMoveToLocation("TsTaskSkillWander.StopMoveToLocation");
		}
		global::Vector lastDestination = this.LastDestination;
		if (lastDestination == null)
		{
			return;
		}
		lastDestination.Reset();
	}

	// Token: 0x06004099 RID: 16537 RVA: 0x000673D8 File Offset: 0x000655D8
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
		MoveToLocationController moveController = component.MoveController;
		MoveToPointConfigImpl moveToPointConfigImpl = new MoveToPointConfigImpl();
		moveToPointConfigImpl.Position = this.TmpVector2;
		moveToPointConfigImpl.TurnSpeed = new float?(turnSpeed);
		moveToPointConfigImpl.UseNearestDirection = new bool?(true);
		moveToPointConfigImpl.FaceToPosition = facingDirection;
		moveToPointConfigImpl.ResetCondition = (() => false);
		return moveController.NavigateMoveToLocation(moveToPointConfigImpl, new bool?(true), false, "TsTaskSkillWander.SetMoveToLocation");
	}

	// Token: 0x0600409A RID: 16538 RVA: 0x000674E4 File Offset: 0x000656E4
	private unsafe bool FindArea(AiController aiController, double distance, double targetAngle, double height, global::Vector selfToTarget)
	{
		CharacterSkillComponent component = aiController.CharAiDesignComp.Entity.GetComponent<CharacterSkillComponent>();
		BaseTagComponent component2 = component.Entity.GetComponent<BaseTagComponent>();
		this.TmpForward.DeepCopy(selfToTarget);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(aiController.CharActorComp, this.TmpForward);
		this.TmpForward.Normalize(9.99999993922529E-09);
		this.TmpForward.UnaryNegation(this.TmpBackward);
		double num = 3.402823466E+38;
		double num2 = 3.402823466E+38;
		this.SelectedSkillPrecondition = null;
		global::EMoveDirection emoveDirection = global::EMoveDirection.None;
		double num3 = 3.402823466E+38;
		if (this.TsDebugLog)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "SkillWander Find Area";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Owner", aiController.CharActorComp.Actor.GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BT", base.TreeAsset);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		foreach (int num4 in aiController.AiSkill.ActiveSkillGroup)
		{
			Span<int> arrayIntBytes = aiController.AiSkill.BaseSkill.Value.RandomSkills()[num4].GetArrayIntBytes();
			for (int i = 0; i < arrayIntBytes.Length; i++)
			{
				int num5 = *arrayIntBytes[i];
				AiSkillInfos aiSkillInfos;
				AiSkillPrecondition value;
				if (!aiController.AiSkill.SkillInfos.TryGetValue(num5, out aiSkillInfos))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.LCZ;
					string message2 = "没有配置技能库";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", num5);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else if (!aiController.AiSkill.SkillPreconditionMap.TryGetValue(aiSkillInfos.SkillPreconditionId, out value))
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.BehaviorTree;
					ELogAuthor author3 = ELogAuthor.LCZ;
					string message3 = "没有配置技能前置条件";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Id", aiSkillInfos.SkillPreconditionId);
					instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				else if (aiSkillInfos.SkillWeight > 0 && AiLibrary.IsSkillAvailable(aiController, num5, component, component2, this.TsSkillType, targetAngle, height, 0.0, 0.0, false, this.TsDebugLog))
				{
					FloatRange value2 = value.DistanceRange.Value;
					if (distance < (double)value2.Min)
					{
						if (this.TsForwardFirst && emoveDirection == global::EMoveDirection.Forward)
						{
							if (this.TsDebugLog)
							{
								Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "    Failed: ForwardFirst", default(ReadOnlySpan<ValueTuple<string, object>>));
							}
						}
						else
						{
							double num6 = (double)value2.Min - distance;
							if (num3 < num6 || num2 < num6)
							{
								if (this.TsDebugLog)
								{
									Log instance4 = Singleton<Log>.Instance;
									ELogModule module4 = ELogModule.AI;
									ELogAuthor author4 = ELogAuthor.LCZ;
									string message4 = "    Failed: BackwardBlock or MinDistance";
									<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("MoveDist", num6);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("MinDistance", num3);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("MinBackwardBlock", num2);
									instance4.Info(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
								}
							}
							else if (AiControllerLibrary.NavigationBlockDirection(base.AIOwner, aiController.CharActorComp.ActorLocationProxy, this.TmpBackward, (float)num6, true))
							{
								num2 = num6;
								if (this.TsDebugLog)
								{
									Log instance5 = Singleton<Log>.Instance;
									ELogModule module5 = ELogModule.AI;
									ELogAuthor author5 = ELogAuthor.LCZ;
									string message5 = "    Failed: BackwardBlock";
									ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("MoveDist", num6);
									instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
								}
							}
							else
							{
								emoveDirection = global::EMoveDirection.Backward;
								num3 = num6;
								this.SelectedSkillPrecondition = new AiSkillPrecondition?(value);
							}
						}
					}
					else
					{
						if (distance <= (double)value2.Max)
						{
							this.SelectedSkillPrecondition = new AiSkillPrecondition?(value);
							break;
						}
						if (!this.TsForwardFirst && emoveDirection == global::EMoveDirection.Backward)
						{
							if (this.TsDebugLog)
							{
								Singleton<Log>.Instance.Info(ELogModule.AI, ELogAuthor.LCZ, "    Failed: BackwardFirst", default(ReadOnlySpan<ValueTuple<string, object>>));
							}
						}
						else
						{
							double num7 = distance - (double)value2.Max;
							if (num3 < num7 || num < num7)
							{
								if (this.TsDebugLog)
								{
									Log instance6 = Singleton<Log>.Instance;
									ELogModule module6 = ELogModule.AI;
									ELogAuthor author6 = ELogAuthor.LCZ;
									string message6 = "    Failed: ForwardBlock or MinDistance";
									<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray3<ValueTuple<string, object>>);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("MoveDist", num7);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("MinDistance", num3);
									*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("MinForwardBlock", num);
									instance6.Info(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 3));
								}
							}
							else if (AiControllerLibrary.NavigationBlockDirection(base.AIOwner, aiController.CharActorComp.ActorLocationProxy, this.TmpForward, (float)num7, true))
							{
								num = num7;
								if (this.TsDebugLog)
								{
									Log instance7 = Singleton<Log>.Instance;
									ELogModule module7 = ELogModule.AI;
									ELogAuthor author7 = ELogAuthor.LCZ;
									string message7 = "    Failed: ForwardBlock";
									ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("MoveDist", num7);
									instance7.Info(module7, author7, message7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
								}
							}
							else
							{
								emoveDirection = global::EMoveDirection.Forward;
								num3 = num7;
								this.SelectedSkillPrecondition = new AiSkillPrecondition?(value);
							}
						}
					}
				}
			}
		}
		return this.SelectedSkillPrecondition != null;
	}

	// Token: 0x0600409B RID: 16539 RVA: 0x00067A60 File Offset: 0x00065C60
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			BaseMoveComponent component = tsAiController.AiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.MoveController.StopMoveToLocation("TsTaskSkillWander.OnClear");
			}
			global::Vector lastDestination = this.LastDestination;
			if (lastDestination != null)
			{
				lastDestination.Reset();
			}
			AiControllerLibrary.ClearInput(tsAiController);
			if (!this.TsWalkOff && component != null)
			{
				component.SetWalkOffLedgeRecord(true);
			}
		}
	}

	// Token: 0x0600409C RID: 16540 RVA: 0x00067ACE File Offset: 0x00065CCE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskSkillWander._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSkillWander.TsTaskSkillWander_C");
		}
		return TsTaskSkillWander._ClassPtr;
	}

	// Token: 0x0600409D RID: 16541 RVA: 0x00067AF4 File Offset: 0x00065CF4
	public TsTaskSkillWander() : this(BuiltinUtils.AllocNativeUObject(TsTaskSkillWander.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600409E RID: 16542 RVA: 0x00067B1C File Offset: 0x00065D1C
	public TsTaskSkillWander(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSkillWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600409F RID: 16543 RVA: 0x00067B50 File Offset: 0x00065D50
	protected TsTaskSkillWander(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060040A0 RID: 16544 RVA: 0x00067BCC File Offset: 0x00065DCC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060040A1 RID: 16545 RVA: 0x00067BFC File Offset: 0x00065DFC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000F17 RID: 3863
	private const double THRESHOLD_RATE = 0.3333333333333333;

	// Token: 0x04000F18 RID: 3864
	private const double OTHER_THRESHOLD_RATE = 0.6666666666666667;

	// Token: 0x04000F19 RID: 3865
	private const int NAV_INTERVAL_TIME = 3;

	// Token: 0x04000F1A RID: 3866
	private bool IsInitTsVariables;

	// Token: 0x04000F1B RID: 3867
	private bool TsForwardFirst;

	// Token: 0x04000F1C RID: 3868
	private float TsCheckSkillPeriod;

	// Token: 0x04000F1D RID: 3869
	private ECharMoveState TsMoveState = ECharMoveState.Walk;

	// Token: 0x04000F1E RID: 3870
	private int TsSkillType;

	// Token: 0x04000F1F RID: 3871
	private global::Vector TmpVector = global::Vector.Create();

	// Token: 0x04000F20 RID: 3872
	private global::Vector TmpSelfToTarget = global::Vector.Create();

	// Token: 0x04000F21 RID: 3873
	private global::Vector TmpForward = global::Vector.Create();

	// Token: 0x04000F22 RID: 3874
	private global::Vector TmpBackward = global::Vector.Create();

	// Token: 0x04000F23 RID: 3875
	private global::Vector TmpVector2 = global::Vector.Create();

	// Token: 0x04000F24 RID: 3876
	private Quat TmpQuat = Quat.Create(0f, 0f, 0f, 1f);

	// Token: 0x04000F25 RID: 3877
	private global::Vector LastDestination = global::Vector.Create();

	// Token: 0x04000F26 RID: 3878
	private bool PreForward;

	// Token: 0x04000F27 RID: 3879
	private bool TsDebugLog;

	// Token: 0x04000F28 RID: 3880
	private bool TsWalkOff;

	// Token: 0x04000F29 RID: 3881
	private float NavigationInterval;

	// Token: 0x04000F2A RID: 3882
	private double NextCheckSkillTime;

	// Token: 0x04000F2B RID: 3883
	private AiSkillPrecondition? SelectedSkillPrecondition;

	// Token: 0x04000F2C RID: 3884
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskSkillWander.TsTaskSkillWander_C";

	// Token: 0x04000F2D RID: 3885
	private static IntPtr _ClassPtr;

	// Token: 0x04000F2E RID: 3886
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F2F RID: 3887
	private static int __PropertyOffset_ForwardFirst;

	// Token: 0x04000F30 RID: 3888
	private static int __PropertyOffset_CheckSkillPeriod;

	// Token: 0x04000F31 RID: 3889
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000F32 RID: 3890
	private static int __PropertyOffset_SkillType;

	// Token: 0x04000F33 RID: 3891
	private static int __PropertyOffset_DebugLog;

	// Token: 0x04000F34 RID: 3892
	private static int __PropertyOffset_WalkOff;
}
