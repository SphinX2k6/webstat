using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC3 RID: 3267
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolLogic.TsTaskPatrolLogic_C")]
public class TsTaskPatrolLogic : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700027D RID: 637
	// (get) Token: 0x06003EF5 RID: 16117 RVA: 0x0005FFCF File Offset: 0x0005E1CF
	// (set) Token: 0x06003EF6 RID: 16118 RVA: 0x0005FFDF File Offset: 0x0005E1DF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x1700027E RID: 638
	// (get) Token: 0x06003EF7 RID: 16119 RVA: 0x0005FFF0 File Offset: 0x0005E1F0
	// (set) Token: 0x06003EF8 RID: 16120 RVA: 0x00060000 File Offset: 0x0005E200
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MoveOnePath
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveOnePath) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveOnePath) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700027F RID: 639
	// (get) Token: 0x06003EF9 RID: 16121 RVA: 0x00060011 File Offset: 0x0005E211
	// (set) Token: 0x06003EFA RID: 16122 RVA: 0x00060021 File Offset: 0x0005E221
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseLastMoveIndex
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_UseLastMoveIndex) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_UseLastMoveIndex) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06003EFB RID: 16123 RVA: 0x00060032 File Offset: 0x0005E232
	// (set) Token: 0x06003EFC RID: 16124 RVA: 0x00060042 File Offset: 0x0005E242
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MoveSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_MoveSpeed) = value;
		}
	}

	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06003EFD RID: 16125 RVA: 0x00060053 File Offset: 0x0005E253
	// (set) Token: 0x06003EFE RID: 16126 RVA: 0x00060063 File Offset: 0x0005E263
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool CheckObstacles
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacles) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacles) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000282 RID: 642
	// (get) Token: 0x06003EFF RID: 16127 RVA: 0x00060074 File Offset: 0x0005E274
	// (set) Token: 0x06003F00 RID: 16128 RVA: 0x00060084 File Offset: 0x0005E284
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckObstacleTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacleTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacleTime) = value;
		}
	}

	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06003F01 RID: 16129 RVA: 0x00060095 File Offset: 0x0005E295
	// (set) Token: 0x06003F02 RID: 16130 RVA: 0x000600A5 File Offset: 0x0005E2A5
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float CheckObstacleLength
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacleLength);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskPatrolLogic.__PropertyOffset_CheckObstacleLength) = value;
		}
	}

	// Token: 0x06003F03 RID: 16131 RVA: 0x000600B8 File Offset: 0x0005E2B8
	private void InitTsVariables()
	{
		this.TsMoveState = this.MoveState;
		this.TsMoveOnePath = this.MoveOnePath;
		this.TsCheckObstacleLength = this.CheckObstacleLength;
		this.TsCheckObstacleTime = this.CheckObstacleTime;
		this.TsCheckObstacles = this.CheckObstacles;
		this.TsUseLastMoveIndex = this.UseLastMoveIndex;
		this.TsMoveSpeed = this.MoveSpeed;
		this.IsInitTsVariables = true;
	}

	// Token: 0x06003F04 RID: 16132 RVA: 0x00060120 File Offset: 0x0005E320
	[NullableContext(1)]
	private void InitComp(AiController aiController)
	{
		this.FrameRate = (float)Singleton<GameSettingsDeviceRender>.Instance.FrameRate;
		this.FrameSeconds = Singleton<GameSettingsDeviceRender>.Instance.FrameSeconds;
		this.PatrolLogic = aiController.AiPatrol;
		this.PatrolConfig = this.PatrolLogic.GetConfig();
		if (this.PatrolConfig == null)
		{
			base.Finish(false);
			return;
		}
		this.IsMoveFlyingState = this.PatrolConfig.ContainZ;
		this.Entity = aiController.CharAiDesignComp.Entity;
		this.ActorComp = aiController.CharActorComp;
		this.MoveComp = this.Entity.GetComponent<BaseMoveComponent>();
		if (this.IsMoveFlyingState && this.MoveComp != null)
		{
			CharacterActorComponent actorComp = this.ActorComp;
			if (actorComp != null)
			{
				actorComp.Actor.KuroSetMovementMode(new SetMovementModeInfo
				{
					Mode = EMovementMode.MOVE_Flying,
					Context = "[TsTaskPatrolLogic.InitComp]"
				});
			}
		}
		this.StateComp = this.Entity.GetComponent<BaseUnifiedStateComponent>();
		this.AnimComp = this.Entity.GetComponent<CharacterAnimationComponent>();
		if (!this.PatrolLogic.IsInitialized)
		{
			this.PatrolLogic.GeneratePatrol(false);
		}
		this.IsSplineLoading = true;
		this.IsInitComp = true;
	}

	// Token: 0x06003F05 RID: 16133 RVA: 0x00060240 File Offset: 0x0005E440
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

	// Token: 0x06003F06 RID: 16134 RVA: 0x000602DC File Offset: 0x0005E4DC
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.InitTsVariables();
		}
		if (!this.IsInitComp)
		{
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
			this.InitComp(aiController);
		}
		this.InitBaseInfo();
		if (this.TraceElement == null)
		{
			this.InitTraceElement();
		}
	}

	// Token: 0x06003F07 RID: 16135 RVA: 0x00060372 File Offset: 0x0005E572
	private void InitBaseInfo()
	{
		if (this.CacheVector == null)
		{
			this.CacheVector = Vector.Create();
		}
		this.CurTime = 0f;
		this.IsPause = false;
		this.ForceExit = false;
		this.IsAvoidObstacles = false;
	}

	// Token: 0x06003F08 RID: 16136 RVA: 0x000603A8 File Offset: 0x0005E5A8
	private void InitTraceElement()
	{
		this.TraceElement = new UTraceCapsuleElement();
		this.TraceElement.bIsSingle = true;
		this.TraceElement.bIgnoreSelf = true;
		this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
		this.TraceElement.HalfHeight = this.ActorComp.DefaultHalfHeight;
		this.TraceElement.Radius = this.ActorComp.DefaultRadius;
		this.TraceElement.WorldContextObject = this.ActorComp.Owner;
	}

	// Token: 0x06003F09 RID: 16137 RVA: 0x0006042A File Offset: 0x0005E62A
	[NullableContext(1)]
	private bool SetTraceElement(Vector startLocation, Vector endLocation)
	{
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, startLocation);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, endLocation);
		return Singleton<TraceElementCommon>.Instance.CapsuleTrace(this.TraceElement, "TsTaskNpcPatrol_GetObstacleLocation");
	}

	// Token: 0x06003F0A RID: 16138 RVA: 0x00060464 File Offset: 0x0005E664
	private void CallOutside()
	{
		if (GlobalData.BpEventManager == null)
		{
			return;
		}
		AiPatrolController patrolLogic = this.PatrolLogic;
		PatrolPoint patrolPoint = (patrolLogic != null) ? patrolLogic.PatrolPoint : null;
		if (patrolPoint == null || !patrolPoint.IsMain)
		{
			return;
		}
		GlobalData.BpEventManager.AI巡逻达到样条点.Broadcast(this.ActorComp.Actor, this.PatrolLogic.PatrolIndex);
	}

	// Token: 0x06003F0B RID: 16139 RVA: 0x000604C0 File Offset: 0x0005E6C0
	private void InitPatrolInfo()
	{
		CreatureDataComponent creatureData = this.ActorComp.CreatureData;
		this.PatrolLogic.StartPatrol(this.TsUseLastMoveIndex, new Action(this.CallOutside));
		creatureData.SetPosAbnormal(false);
		this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
	}

	// Token: 0x06003F0C RID: 16140 RVA: 0x00060518 File Offset: 0x0005E718
	private bool CheckSplineLoading()
	{
		if (this.IsSplineLoading)
		{
			AiPatrolController patrolLogic = this.PatrolLogic;
			if (patrolLogic != null && patrolLogic.IsInitialized)
			{
				this.IsSplineLoading = false;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06003F0D RID: 16141 RVA: 0x00060540 File Offset: 0x0005E740
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

	// Token: 0x06003F0E RID: 16142 RVA: 0x000605E0 File Offset: 0x0005E7E0
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.ForceExit)
		{
			base.Finish(false);
			return;
		}
		if (this.IsPause)
		{
			return;
		}
		if (this.CheckSplineLoading())
		{
			this.InitPatrolInfo();
			this.PatrolLogic.CheckPatrolEnd();
			return;
		}
		this.CurTime += deltaSeconds;
		if (this.TsCheckObstacles && this.CurTime > this.TsCheckObstacleTime)
		{
			this.CurTime = 0f;
			this.ExecuteObstacle();
			if (this.IsAvoidObstacles)
			{
				return;
			}
		}
		if (this.PatrolLogic == null || this.CheckMoveEnd(this.PatrolLogic.PatrolPoint))
		{
			this.PatrolFinish();
			base.Finish(true);
			return;
		}
		if (!this.CheckCanMove())
		{
			return;
		}
		this.MoveToPatrolPoint(deltaSeconds);
	}

	// Token: 0x06003F0F RID: 16143 RVA: 0x00060698 File Offset: 0x0005E898
	private bool CheckCanMove()
	{
		return !this.ForceExit && !this.IsPause && this.MoveComp != null && this.MoveComp.CanMove() && this.MoveComp.CanUpdateMovingRotation();
	}

	// Token: 0x06003F10 RID: 16144 RVA: 0x000606D0 File Offset: 0x0005E8D0
	private void MoveToPatrolPoint(float deltaSeconds)
	{
		this.CacheVector.FromUeVector(this.PatrolLogic.PatrolPoint.Point);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		if (!this.IsMoveFlyingState)
		{
			this.CacheVector.Z -= (double)this.ActorComp.HalfHeight;
		}
		double x = this.CacheVector.X;
		double y = this.CacheVector.Y;
		double z = this.CacheVector.Z;
		this.CacheVector.Z = 0.0;
		double distance = this.CacheVector.Size();
		this.CacheVector.Z = z;
		this.TurnToDirect(this.CacheVector, distance, deltaSeconds);
		this.CacheVector.Set(x, y, z);
		this.MoveCharacter(this.CacheVector, distance, deltaSeconds);
	}

	// Token: 0x06003F11 RID: 16145 RVA: 0x000607B0 File Offset: 0x0005E9B0
	private bool TurnToNextPoint()
	{
		AiPatrolController patrolLogic = this.PatrolLogic;
		if (((patrolLogic != null) ? patrolLogic.PatrolPoint : null) == null)
		{
			return false;
		}
		this.CacheVector.FromUeVector(this.PatrolLogic.PatrolPoint.Point);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		return this.CacheVector.Size() < 100.0 && this.PatrolLogic.CheckPatrolEnd();
	}

	// Token: 0x06003F12 RID: 16146 RVA: 0x00060828 File Offset: 0x0005EA28
	[NullableContext(1)]
	private bool CheckMoveEnd(PatrolPoint curPoint)
	{
		if (this.TurnToNextPoint())
		{
			return true;
		}
		if (curPoint != this.PatrolLogic.PatrolPoint)
		{
			if (this.TsMoveOnePath && curPoint.IsMain && !curPoint.IsIgnorePoint && curPoint.Actions != null)
			{
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(curPoint.Actions, EntityContext.Create(this.Entity.Id, null), null);
			}
			if (this.PatrolLogic.PatrolPoint.IsMain)
			{
				this.CallOutside();
				this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
			}
		}
		return false;
	}

	// Token: 0x06003F13 RID: 16147 RVA: 0x000608D0 File Offset: 0x0005EAD0
	[NullableContext(1)]
	private void TurnToDirect(Vector moveDirect, double distance, float deltaSeconds)
	{
		this.CacheVector.FromUeVector(moveDirect);
		this.CacheVector.Normalize(9.99999993922529E-09);
		float speed = 540f;
		if (distance < 100.0)
		{
			speed = 10000f;
		}
		this.MoveComp.SmoothCharacterRotation(Rotator.Create(0f, (float)Singleton<MathUtils>.Instance.GetAngleByVector2D(this.CacheVector), 0f), speed, deltaSeconds, false, "Movement.SmoothCharacterRotation", true);
	}

	// Token: 0x06003F14 RID: 16148 RVA: 0x0006094C File Offset: 0x0005EB4C
	[NullableContext(1)]
	private void MoveCharacter(Vector moveDirect, double distance, float deltaSeconds)
	{
		this.CacheVector.FromUeVector(moveDirect);
		this.CacheVector.Normalize(9.99999993922529E-09);
		if (!this.CacheVector.IsNearlyZero(9.999999747378752E-05))
		{
			float num = this.TsMoveSpeed / this.FrameRate * (deltaSeconds / this.FrameSeconds);
			float num2 = deltaSeconds;
			this.CacheVector.Addition(this.ActorComp.ActorForwardProxy, this.CacheVector);
			this.CacheVector.Normalize(9.99999993922529E-09);
			this.CacheVector.MultiplyEqual((double)num);
			CharacterAnimationComponent animComp = this.AnimComp;
			FTransformDouble? ftransformDouble = (animComp != null) ? new FTransformDouble?(animComp.GetMeshTransform()) : null;
			if ((double)num > distance)
			{
				num2 = (float)(distance / (double)this.TsMoveSpeed);
				this.SetPatrolPointLocation();
			}
			else
			{
				this.MoveComp.MoveCharacter(this.CacheVector, num2, "");
			}
			CharacterAnimationComponent animComp2 = this.AnimComp;
			if (animComp2 != null && animComp2.Valid && this.Entity.GetTickInterval() > 1)
			{
				AActor owner = this.ActorComp.Owner;
				if (owner != null && owner.WasRecentlyRenderedOnScreen(0.2f) && ftransformDouble != null)
				{
					this.AnimComp.SetModelBuffer(ftransformDouble.Value, num2 * 1000f * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
				}
			}
		}
		else if (this.Entity.GetTickInterval() <= 1)
		{
			this.AnimComp.StopModelBuffer();
		}
		this.MoveComp.IsSpecialMove = true;
		this.MoveComp.HasMoveInput = true;
		this.MoveComp.Speed = this.TsMoveSpeed;
	}

	// Token: 0x06003F15 RID: 16149 RVA: 0x00060AF0 File Offset: 0x0005ECF0
	private void SetPatrolPointLocation()
	{
		this.CacheVector.FromUeVector(this.PatrolLogic.PatrolPoint.Point);
		if (!this.IsMoveFlyingState)
		{
			this.CacheVector.Z += (double)this.ActorComp.HalfHeight;
		}
		this.ActorComp.SetActorLocation(this.CacheVector.ToUeVector(false), "角色移动到位置.MoveCharacter", false);
	}

	// Token: 0x06003F16 RID: 16150 RVA: 0x00060B5C File Offset: 0x0005ED5C
	private void ExecuteObstacle()
	{
		AiPatrolController patrolLogic = this.PatrolLogic;
		bool flag;
		if (patrolLogic == null)
		{
			flag = (null != null);
		}
		else
		{
			PatrolPoint patrolPoint = patrolLogic.PatrolPoint;
			flag = (((patrolPoint != null) ? patrolPoint.Point : null) != null);
		}
		if (!flag)
		{
			this.IsAvoidObstacles = false;
			return;
		}
		this.CacheVector.FromUeVector(this.PatrolLogic.PatrolPoint.Point);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.CacheVector.Z = 0.0;
		this.CacheVector.Normalize(9.99999993922529E-09);
		this.CacheVector.MultiplyEqual((double)this.TsCheckObstacleLength);
		this.CacheVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
		bool flag2 = this.SetTraceElement(this.ActorComp.ActorLocationProxy, this.CacheVector);
		UKuroHitResult hitResult = this.TraceElement.HitResult;
		if (!flag2 || (hitResult == null || !hitResult.bBlockingHit))
		{
			this.IsAvoidObstacles = false;
			return;
		}
		if (!this.IsAvoidObstacles)
		{
			this.StopMove();
		}
		this.IsAvoidObstacles = true;
	}

	// Token: 0x06003F17 RID: 16151 RVA: 0x00060C6C File Offset: 0x0005EE6C
	private void StopMove()
	{
		if (this.AnimComp != null)
		{
			this.AnimComp.StopModelBuffer();
		}
		if (this.MoveComp != null)
		{
			this.MoveComp.Speed = 0f;
			this.MoveComp.HasMoveInput = false;
			this.MoveComp.IsSpecialMove = false;
			this.MoveComp.StopMove(true, "TsTaskPatrolLogic.OnClear");
		}
		if (this.ActorComp != null)
		{
			this.ActorComp.ClearInput(false, true);
		}
	}

	// Token: 0x06003F18 RID: 16152 RVA: 0x00060CE2 File Offset: 0x0005EEE2
	private void PatrolFinish()
	{
		this.ForceExit = true;
		this.StopMove();
		this.CallOutside();
		AiPatrolController patrolLogic = this.PatrolLogic;
		if (patrolLogic == null)
		{
			return;
		}
		patrolLogic.PatrolFinish();
	}

	// Token: 0x06003F19 RID: 16153 RVA: 0x00060D07 File Offset: 0x0005EF07
	protected override void OnAbort()
	{
		this.PatrolFinish();
	}

	// Token: 0x06003F1A RID: 16154 RVA: 0x00060D0F File Offset: 0x0005EF0F
	protected override void OnClear()
	{
		if (!(base.AIOwner is TsAiController))
		{
			return;
		}
		this.StopMove();
		this.CurTime = 0f;
		this.ForceExit = false;
		this.IsPause = false;
	}

	// Token: 0x06003F1B RID: 16155 RVA: 0x00060D3E File Offset: 0x0005EF3E
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskPatrolLogic._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolLogic.TsTaskPatrolLogic_C");
		}
		return TsTaskPatrolLogic._ClassPtr;
	}

	// Token: 0x06003F1C RID: 16156 RVA: 0x00060D64 File Offset: 0x0005EF64
	public TsTaskPatrolLogic() : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolLogic.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003F1D RID: 16157 RVA: 0x00060D8C File Offset: 0x0005EF8C
	[NullableContext(1)]
	public TsTaskPatrolLogic(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolLogic.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003F1E RID: 16158 RVA: 0x00060DBF File Offset: 0x0005EFBF
	protected TsTaskPatrolLogic(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003F1F RID: 16159 RVA: 0x00060DD4 File Offset: 0x0005EFD4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003F20 RID: 16160 RVA: 0x00060E04 File Offset: 0x0005F004
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000DC6 RID: 3526
	[Nullable(1)]
	private const string PROFILE_KEY = "TsTaskNpcPatrol_GetObstacleLocation";

	// Token: 0x04000DC7 RID: 3527
	private const float PATROL_TURN_SPEED = 540f;

	// Token: 0x04000DC8 RID: 3528
	private const float NO_FORWARD_DISTANCE = 100f;

	// Token: 0x04000DC9 RID: 3529
	private const float NO_FORWARD_TURN_SPEED = 10000f;

	// Token: 0x04000DCA RID: 3530
	private int TsMoveState;

	// Token: 0x04000DCB RID: 3531
	private bool TsMoveOnePath;

	// Token: 0x04000DCC RID: 3532
	private bool TsUseLastMoveIndex;

	// Token: 0x04000DCD RID: 3533
	private float TsMoveSpeed;

	// Token: 0x04000DCE RID: 3534
	private bool TsCheckObstacles;

	// Token: 0x04000DCF RID: 3535
	private float TsCheckObstacleTime;

	// Token: 0x04000DD0 RID: 3536
	private float TsCheckObstacleLength;

	// Token: 0x04000DD1 RID: 3537
	private Entity Entity;

	// Token: 0x04000DD2 RID: 3538
	private CharacterActorComponent ActorComp;

	// Token: 0x04000DD3 RID: 3539
	private BaseMoveComponent MoveComp;

	// Token: 0x04000DD4 RID: 3540
	private BaseUnifiedStateComponent StateComp;

	// Token: 0x04000DD5 RID: 3541
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000DD6 RID: 3542
	private AiPatrolController PatrolLogic;

	// Token: 0x04000DD7 RID: 3543
	private AiPatrolConfig PatrolConfig;

	// Token: 0x04000DD8 RID: 3544
	private UTraceCapsuleElement TraceElement;

	// Token: 0x04000DD9 RID: 3545
	private bool IsSplineLoading;

	// Token: 0x04000DDA RID: 3546
	private bool IsInitTsVariables;

	// Token: 0x04000DDB RID: 3547
	private bool IsInitComp;

	// Token: 0x04000DDC RID: 3548
	private bool IsAvoidObstacles;

	// Token: 0x04000DDD RID: 3549
	[Nullable(1)]
	private Vector CacheVector = Vector.Create();

	// Token: 0x04000DDE RID: 3550
	private float CurTime;

	// Token: 0x04000DDF RID: 3551
	private bool IsMoveFlyingState;

	// Token: 0x04000DE0 RID: 3552
	private float FrameSeconds;

	// Token: 0x04000DE1 RID: 3553
	private float FrameRate;

	// Token: 0x04000DE2 RID: 3554
	private bool IsPause;

	// Token: 0x04000DE3 RID: 3555
	private bool ForceExit;

	// Token: 0x04000DE4 RID: 3556
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskPatrolLogic.TsTaskPatrolLogic_C";

	// Token: 0x04000DE5 RID: 3557
	private static IntPtr _ClassPtr;

	// Token: 0x04000DE6 RID: 3558
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000DE7 RID: 3559
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000DE8 RID: 3560
	private static int __PropertyOffset_MoveOnePath;

	// Token: 0x04000DE9 RID: 3561
	private static int __PropertyOffset_UseLastMoveIndex;

	// Token: 0x04000DEA RID: 3562
	private static int __PropertyOffset_MoveSpeed;

	// Token: 0x04000DEB RID: 3563
	private static int __PropertyOffset_CheckObstacles;

	// Token: 0x04000DEC RID: 3564
	private static int __PropertyOffset_CheckObstacleTime;

	// Token: 0x04000DED RID: 3565
	private static int __PropertyOffset_CheckObstacleLength;
}
