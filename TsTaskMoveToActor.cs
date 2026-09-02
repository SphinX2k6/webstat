using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC0 RID: 3264
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToActor.TsTaskMoveToActor_C")]
public class TsTaskMoveToActor : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06003E96 RID: 16022 RVA: 0x0005E26F File Offset: 0x0005C46F
	// (set) Token: 0x06003E97 RID: 16023 RVA: 0x0005E27F File Offset: 0x0005C47F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06003E98 RID: 16024 RVA: 0x0005E290 File Offset: 0x0005C490
	// (set) Token: 0x06003E99 RID: 16025 RVA: 0x0005E2A0 File Offset: 0x0005C4A0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NavigationOn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_NavigationOn) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_NavigationOn) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06003E9A RID: 16026 RVA: 0x0005E2B1 File Offset: 0x0005C4B1
	// (set) Token: 0x06003E9B RID: 16027 RVA: 0x0005E2C5 File Offset: 0x0005C4C5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardKeyActor
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskMoveToActor.__PropertyOffset_BlackboardKeyActor)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskMoveToActor.__PropertyOffset_BlackboardKeyActor)), value);
		}
	}

	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06003E9C RID: 16028 RVA: 0x0005E2DA File Offset: 0x0005C4DA
	// (set) Token: 0x06003E9D RID: 16029 RVA: 0x0005E2EA File Offset: 0x0005C4EA
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_EndDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_EndDistance) = value;
		}
	}

	// Token: 0x17000268 RID: 616
	// (get) Token: 0x06003E9E RID: 16030 RVA: 0x0005E2FB File Offset: 0x0005C4FB
	// (set) Token: 0x06003E9F RID: 16031 RVA: 0x0005E30B File Offset: 0x0005C50B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06003EA0 RID: 16032 RVA: 0x0005E31C File Offset: 0x0005C51C
	// (set) Token: 0x06003EA1 RID: 16033 RVA: 0x0005E32C File Offset: 0x0005C52C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float FixPeriod
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_FixPeriod);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_FixPeriod) = value;
		}
	}

	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06003EA2 RID: 16034 RVA: 0x0005E33D File Offset: 0x0005C53D
	// (set) Token: 0x06003EA3 RID: 16035 RVA: 0x0005E34D File Offset: 0x0005C54D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool WalkOff
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_WalkOff) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_WalkOff) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06003EA4 RID: 16036 RVA: 0x0005E35E File Offset: 0x0005C55E
	// (set) Token: 0x06003EA5 RID: 16037 RVA: 0x0005E36E File Offset: 0x0005C56E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseBounds
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_UseBounds) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_UseBounds) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06003EA6 RID: 16038 RVA: 0x0005E37F File Offset: 0x0005C57F
	// (set) Token: 0x06003EA7 RID: 16039 RVA: 0x0005E38F File Offset: 0x0005C58F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EndDistanceAllPoints
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_EndDistanceAllPoints) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_EndDistanceAllPoints) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06003EA8 RID: 16040 RVA: 0x0005E3A0 File Offset: 0x0005C5A0
	// (set) Token: 0x06003EA9 RID: 16041 RVA: 0x0005E3B0 File Offset: 0x0005C5B0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxExecuteTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_MaxExecuteTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_MaxExecuteTime) = value;
		}
	}

	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06003EAA RID: 16042 RVA: 0x0005E3C1 File Offset: 0x0005C5C1
	// (set) Token: 0x06003EAB RID: 16043 RVA: 0x0005E3D1 File Offset: 0x0005C5D1
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool FixFacingWhenEnableRVO
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_FixFacingWhenEnableRVO) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToActor.__PropertyOffset_FixFacingWhenEnableRVO) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003EAC RID: 16044 RVA: 0x0005E3E4 File Offset: 0x0005C5E4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsNavigationOn = this.NavigationOn;
			this.TsBlackboardKeyActor = this.BlackboardKeyActor;
			this.TsEndDistance = this.EndDistance;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsFixPeriod = this.FixPeriod;
			this.TsWalkOff = this.WalkOff;
			this.TsUseBounds = this.UseBounds;
			this.TsFixFacingWhenEnableRVO = this.FixFacingWhenEnableRVO;
			this.SelectedTargetLocation = Vector.Create();
			this.CacheVector = Vector.Create();
			this.CacheVector2 = Vector.Create();
		}
	}

	// Token: 0x06003EAD RID: 16045 RVA: 0x0005E498 File Offset: 0x0005C698
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

	// Token: 0x06003EAE RID: 16046 RVA: 0x0005E534 File Offset: 0x0005C734
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		this.ExecuteTimeStamp = Singleton<Time>.Instance.WorldTime;
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (!this.TsWalkOff)
		{
			BaseMoveComponent component = charActorComp.Entity.GetComponent<BaseMoveComponent>();
			if (component != null)
			{
				component.SetWalkOffLedgeRecord(false);
			}
		}
		long num3;
		if (this.TsBlackboardKeyActor == "_currentPlayer")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			int? num;
			if (baseCharacter == null)
			{
				num = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				num = ((characterActorComponent != null) ? new int?(characterActorComponent.Entity.Id) : null);
			}
			int? num2 = num;
			num3 = (long)num2.GetValueOrDefault();
		}
		else
		{
			num3 = (long)ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyActor).GetValueOrDefault();
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get((int)num3);
		if (num3 == 0L || (entity == null || !entity.Valid))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "TsTaskMoveToEntity没有获取到目标EntityId";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BehaviorTree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TargetKey", this.TsBlackboardKeyActor);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			this.FoundPath = false;
			return;
		}
		this.SelectedTargetLocation.DeepCopy(AiControllerLibrary.GetLocationFromEntity(entity));
		if (this.TsUseBounds)
		{
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			if (component2 != null && component2.Valid)
			{
				AActor owner = component2.Owner;
				if (owner != null && owner.IsValid())
				{
					FVectorDouble fvectorDouble = default(FVectorDouble);
					FVector fvector = default(FVector);
					owner.D_GetActorBounds(true, ref fvectorDouble, ref fvector, true);
					float tsEndDistance = fvector.Size();
					this.TsEndDistance = tsEndDistance;
				}
			}
		}
		else
		{
			this.TsEndDistance = this.EndDistance + charActorComp.ScaledRadius;
		}
		BaseMoveComponent moveComp = charActorComp.MoveComp;
		TEnumAsByte<EMovementMode>? tenumAsByte;
		if (moveComp == null)
		{
			tenumAsByte = null;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			tenumAsByte = ((characterMovement != null) ? new TEnumAsByte<EMovementMode>?(characterMovement.MovementMode) : null);
		}
		TEnumAsByte<EMovementMode>? tenumAsByte2 = tenumAsByte;
		bool flag = tenumAsByte2 == EMovementMode.MOVE_Walking || tenumAsByte2 == EMovementMode.MOVE_NavWalking;
		CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
		CharacterUnifiedStateComponent characterUnifiedStateComponent = (charAiDesignComp != null) ? charAiDesignComp.Entity.GetComponent<CharacterUnifiedStateComponent>() : null;
		if (characterUnifiedStateComponent != null && characterUnifiedStateComponent.Valid && flag)
		{
			switch (this.TsMoveState)
			{
			case 1:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Walk);
				break;
			case 2:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Run);
				break;
			case 3:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Sprint);
				break;
			}
		}
		this.NextCheckTime = Singleton<Time>.Instance.WorldTime + (double)this.TsFixPeriod;
		Vector cacheVector = this.CacheVector;
		FVectorDouble actorLocation = charActorComp.ActorLocation;
		cacheVector.DeepCopy(actorLocation);
		BaseUnifiedStateComponent component3 = charActorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
		if (component3 != null && component3.PositionState == ECharPositionState.Ground)
		{
			this.CacheVector.Z -= (double)charActorComp.HalfHeight;
		}
		this.FindNewPath(ownerController, this.CacheVector.ToUeVector(false));
	}

	// Token: 0x06003EAF RID: 16047 RVA: 0x0005E8C8 File Offset: 0x0005CAC8
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

	// Token: 0x06003EB0 RID: 16048 RVA: 0x0005E968 File Offset: 0x0005CB68
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
		{
			base.Finish(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.ExecuteTimeStamp + (double)this.MaxExecuteTime)
		{
			base.Finish(false);
			return;
		}
		AiController aiController = tsAiController.AiController;
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Vector actorLocationProxy = charActorComp.ActorLocationProxy;
		if (Singleton<Time>.Instance.WorldTime > this.NextCheckTime)
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(aiController.CharAiDesignComp.Entity.Id, this.TsBlackboardKeyActor);
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.GetValueOrDefault());
			if (entityIdByEntity == null || (entity == null || !entity.Valid))
			{
				base.Finish(false);
				return;
			}
			Vector locationFromEntity = AiControllerLibrary.GetLocationFromEntity(entity);
			this.NextCheckTime = Singleton<Time>.Instance.WorldTime + (double)this.TsFixPeriod;
			if (Vector.Dist(locationFromEntity, this.SelectedTargetLocation) > 10.0)
			{
				this.SelectedTargetLocation.DeepCopy(locationFromEntity);
				this.CacheVector.DeepCopy(actorLocationProxy);
				BaseUnifiedStateComponent component = charActorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
				if (component != null && component.PositionState == ECharPositionState.Ground)
				{
					this.CacheVector.Z -= (double)charActorComp.HalfHeight;
				}
				this.FindNewPath(ownerController, this.CacheVector.ToUeVector(false));
			}
		}
		if (!this.FoundPath)
		{
			base.Finish(false);
			return;
		}
		this.CacheVector.DeepCopy(this.SelectedTargetLocation);
		this.CacheVector.Subtraction(actorLocationProxy, this.CacheVector2);
		double num = this.CacheVector2.Size();
		Vector vector = this.SelectedTargetLocation;
		if (this.TsNavigationOn && this.NavigationPath != null && this.CurrentNavigationIndex < this.NavigationPath.Count)
		{
			this.CacheVector.DeepCopy(this.NavigationPath[this.CurrentNavigationIndex]);
			vector = this.CacheVector;
		}
		this.CacheVector2.DeepCopy(vector);
		Vector cacheVector = this.CacheVector2;
		cacheVector.Subtraction(actorLocationProxy, cacheVector);
		cacheVector.Z = 0.0;
		double num2 = cacheVector.Size();
		if ((!this.TsNavigationOn || this.CurrentNavigationIndex == this.NavigationPath.Count - 1 || this.EndDistanceAllPoints) && num < (double)this.TsEndDistance)
		{
			base.Finish(true);
			return;
		}
		if (num2 < (double)(10f + charActorComp.ScaledRadius))
		{
			this.CurrentNavigationIndex++;
		}
		if (this.TsFixFacingWhenEnableRVO)
		{
			BaseMoveComponent moveComp = charActorComp.MoveComp;
			bool flag;
			if (moveComp == null)
			{
				flag = false;
			}
			else
			{
				UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
				flag = ((characterMovement != null) ? new bool?(characterMovement.bUseRVOAvoidance) : null).GetValueOrDefault();
			}
			if (flag)
			{
				UeMovementTickManageComponent component2 = charActorComp.Entity.GetComponent<UeMovementTickManageComponent>();
				if (component2 == null)
				{
					goto IL_2E8;
				}
				component2.EnableFixFacingForVelocityOneFrame(true, new float?(this.TsTurnSpeed));
				goto IL_2E8;
			}
		}
		AiControllerLibrary.TurnToTarget(charActorComp, vector, this.TsTurnSpeed, false, 0f);
		IL_2E8:
		cacheVector.DivisionEqual(num2);
		charActorComp.SetInputDirect(cacheVector, true);
		CharacterAiComponent charAiDesignComp = aiController.CharAiDesignComp;
		CharacterUnifiedStateComponent characterUnifiedStateComponent = (charAiDesignComp != null) ? charAiDesignComp.Entity.GetComponent<CharacterUnifiedStateComponent>() : null;
		BaseMoveComponent moveComp2 = charActorComp.MoveComp;
		TEnumAsByte<EMovementMode>? tenumAsByte;
		if (moveComp2 == null)
		{
			tenumAsByte = null;
		}
		else
		{
			UCharacterMovementComponent characterMovement2 = moveComp2.CharacterMovement;
			tenumAsByte = ((characterMovement2 != null) ? new TEnumAsByte<EMovementMode>?(characterMovement2.MovementMode) : null);
		}
		TEnumAsByte<EMovementMode>? tenumAsByte2 = tenumAsByte;
		bool flag2 = tenumAsByte2 == EMovementMode.MOVE_Walking || tenumAsByte2 == EMovementMode.MOVE_NavWalking;
		if (characterUnifiedStateComponent != null && characterUnifiedStateComponent.Valid && flag2)
		{
			switch (this.TsMoveState)
			{
			case 1:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Walk);
				return;
			case 2:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Run);
				return;
			case 3:
				characterUnifiedStateComponent.SetMoveState(ECharMoveState.Sprint);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x06003EB1 RID: 16049 RVA: 0x0005ED64 File Offset: 0x0005CF64
	private void FindNewPath(AAIController tsAiController, FVectorDouble selfLocation)
	{
		if (this.TsNavigationOn)
		{
			if (this.NavigationPath == null)
			{
				this.NavigationPath = new List<Vector>();
			}
			this.FoundPath = AiControllerLibrary.NavigationFindPath(tsAiController, selfLocation, this.SelectedTargetLocation.ToUeVector(false), this.NavigationPath, null, null);
			this.CurrentNavigationIndex = 1;
			return;
		}
		this.FoundPath = true;
	}

	// Token: 0x06003EB2 RID: 16050 RVA: 0x0005EDCC File Offset: 0x0005CFCC
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
			if (!this.TsWalkOff)
			{
				BaseMoveComponent component = tsAiController.AiController.CharActorComp.Entity.GetComponent<BaseMoveComponent>();
				if (component == null)
				{
					return;
				}
				component.SetWalkOffLedgeRecord(true);
			}
		}
	}

	// Token: 0x06003EB3 RID: 16051 RVA: 0x0005EE16 File Offset: 0x0005D016
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskMoveToActor._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToActor.TsTaskMoveToActor_C");
		}
		return TsTaskMoveToActor._ClassPtr;
	}

	// Token: 0x06003EB4 RID: 16052 RVA: 0x0005EE3C File Offset: 0x0005D03C
	public TsTaskMoveToActor() : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToActor.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003EB5 RID: 16053 RVA: 0x0005EE64 File Offset: 0x0005D064
	public TsTaskMoveToActor(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003EB6 RID: 16054 RVA: 0x0005EE97 File Offset: 0x0005D097
	protected TsTaskMoveToActor(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003EB7 RID: 16055 RVA: 0x0005EEAC File Offset: 0x0005D0AC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003EB8 RID: 16056 RVA: 0x0005EEDC File Offset: 0x0005D0DC
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000D76 RID: 3446
	private const float NAVIGATION_COMPLETE_DISTANCE = 10f;

	// Token: 0x04000D77 RID: 3447
	private const float DEFAULT_MAX_EXECUTION_TIME = 10000f;

	// Token: 0x04000D78 RID: 3448
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000D79 RID: 3449
	private bool IsInitTsVariables;

	// Token: 0x04000D7A RID: 3450
	private int TsMoveState;

	// Token: 0x04000D7B RID: 3451
	private bool TsNavigationOn;

	// Token: 0x04000D7C RID: 3452
	private string TsBlackboardKeyActor = "";

	// Token: 0x04000D7D RID: 3453
	private float TsEndDistance;

	// Token: 0x04000D7E RID: 3454
	private float TsTurnSpeed;

	// Token: 0x04000D7F RID: 3455
	private float TsFixPeriod;

	// Token: 0x04000D80 RID: 3456
	private bool TsWalkOff;

	// Token: 0x04000D81 RID: 3457
	private bool TsUseBounds;

	// Token: 0x04000D82 RID: 3458
	private bool TsFixFacingWhenEnableRVO;

	// Token: 0x04000D83 RID: 3459
	[Nullable(2)]
	private Vector SelectedTargetLocation;

	// Token: 0x04000D84 RID: 3460
	private bool FoundPath;

	// Token: 0x04000D85 RID: 3461
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<Vector> NavigationPath;

	// Token: 0x04000D86 RID: 3462
	private int CurrentNavigationIndex;

	// Token: 0x04000D87 RID: 3463
	private double NextCheckTime;

	// Token: 0x04000D88 RID: 3464
	[Nullable(2)]
	private Vector CacheVector;

	// Token: 0x04000D89 RID: 3465
	[Nullable(2)]
	private Vector CacheVector2;

	// Token: 0x04000D8A RID: 3466
	private double ExecuteTimeStamp;

	// Token: 0x04000D8B RID: 3467
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToActor.TsTaskMoveToActor_C";

	// Token: 0x04000D8C RID: 3468
	private static IntPtr _ClassPtr;

	// Token: 0x04000D8D RID: 3469
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000D8E RID: 3470
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000D8F RID: 3471
	private static int __PropertyOffset_NavigationOn;

	// Token: 0x04000D90 RID: 3472
	private static int __PropertyOffset_BlackboardKeyActor;

	// Token: 0x04000D91 RID: 3473
	private static int __PropertyOffset_EndDistance;

	// Token: 0x04000D92 RID: 3474
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000D93 RID: 3475
	private static int __PropertyOffset_FixPeriod;

	// Token: 0x04000D94 RID: 3476
	private static int __PropertyOffset_WalkOff;

	// Token: 0x04000D95 RID: 3477
	private static int __PropertyOffset_UseBounds;

	// Token: 0x04000D96 RID: 3478
	private static int __PropertyOffset_EndDistanceAllPoints;

	// Token: 0x04000D97 RID: 3479
	private static int __PropertyOffset_MaxExecuteTime;

	// Token: 0x04000D98 RID: 3480
	private static int __PropertyOffset_FixFacingWhenEnableRVO;
}
