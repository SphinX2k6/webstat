using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C93 RID: 3219
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPatrol.TsTaskNpcPatrol_C")]
public class TsTaskNpcPatrol : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001C2 RID: 450
	// (get) Token: 0x06003B4D RID: 15181 RVA: 0x0004C32F File Offset: 0x0004A52F
	// (set) Token: 0x06003B4E RID: 15182 RVA: 0x0004C33F File Offset: 0x0004A53F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_DebugMode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_DebugMode) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001C3 RID: 451
	// (get) Token: 0x06003B4F RID: 15183 RVA: 0x0004C350 File Offset: 0x0004A550
	// (set) Token: 0x06003B50 RID: 15184 RVA: 0x0004C360 File Offset: 0x0004A560
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x170001C4 RID: 452
	// (get) Token: 0x06003B51 RID: 15185 RVA: 0x0004C371 File Offset: 0x0004A571
	// (set) Token: 0x06003B52 RID: 15186 RVA: 0x0004C381 File Offset: 0x0004A581
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool MoveOnePath
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MoveOnePath) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MoveOnePath) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001C5 RID: 453
	// (get) Token: 0x06003B53 RID: 15187 RVA: 0x0004C392 File Offset: 0x0004A592
	// (set) Token: 0x06003B54 RID: 15188 RVA: 0x0004C3A2 File Offset: 0x0004A5A2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool UseSimpleMove
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_UseSimpleMove) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_UseSimpleMove) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001C6 RID: 454
	// (get) Token: 0x06003B55 RID: 15189 RVA: 0x0004C3B3 File Offset: 0x0004A5B3
	// (set) Token: 0x06003B56 RID: 15190 RVA: 0x0004C3C3 File Offset: 0x0004A5C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RaycastLength
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_RaycastLength);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_RaycastLength) = value;
		}
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x06003B57 RID: 15191 RVA: 0x0004C3D4 File Offset: 0x0004A5D4
	// (set) Token: 0x06003B58 RID: 15192 RVA: 0x0004C3E4 File Offset: 0x0004A5E4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ChangeMoveTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveTime) = value;
		}
	}

	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06003B59 RID: 15193 RVA: 0x0004C3F5 File Offset: 0x0004A5F5
	// (set) Token: 0x06003B5A RID: 15194 RVA: 0x0004C405 File Offset: 0x0004A605
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ChangeMoveAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveAngle) = value;
		}
	}

	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06003B5B RID: 15195 RVA: 0x0004C416 File Offset: 0x0004A616
	// (set) Token: 0x06003B5C RID: 15196 RVA: 0x0004C426 File Offset: 0x0004A626
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MaxChangeAngle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MaxChangeAngle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_MaxChangeAngle) = value;
		}
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06003B5D RID: 15197 RVA: 0x0004C437 File Offset: 0x0004A637
	// (set) Token: 0x06003B5E RID: 15198 RVA: 0x0004C447 File Offset: 0x0004A647
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float ChangeMoveDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcPatrol.__PropertyOffset_ChangeMoveDistance) = value;
		}
	}

	// Token: 0x06003B5F RID: 15199 RVA: 0x0004C458 File Offset: 0x0004A658
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsDebugMode = this.DebugMode;
			this.TsMoveState = this.MoveState;
			this.TsMoveOnePath = this.MoveOnePath;
			this.TsUseSimpleMove = this.UseSimpleMove;
			this.TsRaycastLength = this.RaycastLength;
			this.TsChangeMoveTime = this.ChangeMoveTime;
			this.TsChangeMoveAngle = this.ChangeMoveAngle;
			this.TsMaxChangeAngle = this.MaxChangeAngle;
			this.TsChangeMoveDistance = this.ChangeMoveDistance;
		}
	}

	// Token: 0x06003B60 RID: 15200 RVA: 0x0004C4E8 File Offset: 0x0004A6E8
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

	// Token: 0x06003B61 RID: 15201 RVA: 0x0004C584 File Offset: 0x0004A784
	protected unsafe virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		if (!(ownerController is TsAiController))
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
		AiController aiController = ((TsAiController)ownerController).AiController;
		this.PatrolLogic = aiController.AiPatrol;
		this.PatrolConfig = this.PatrolLogic.GetConfig();
		if (this.PatrolConfig == null)
		{
			base.Finish(false);
			return;
		}
		this.ActorComp = aiController.CharActorComp;
		if (GlobalData.IsPlayInEditor)
		{
			this.DebugComp = this.ActorComp.Actor.TsCharacterDebugComponent;
		}
		this.Entity = aiController.CharAiDesignComp.Entity;
		this.InitBaseInfo();
		this.InitTraceElement();
		if (AiPatrolController.OpenNpcPatrolDebugMode)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "NPC开始巡逻";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsLogicAutonomousProxy", this.ActorComp.IsAutonomousProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("IsMoveAutonomousProxy", this.ActorComp.IsMoveAutonomousProxy);
			instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
		}
		if (this.HandleMoveEnd == null)
		{
			this.HandleMoveEnd = new Action<ELevelEventState>(this.ExecuteMoveEnd);
		}
		this.PatrolLogic.GeneratePatrol(false);
		this.InitPatrolInfo();
	}

	// Token: 0x06003B62 RID: 15202 RVA: 0x0004C724 File Offset: 0x0004A924
	private void InitBaseInfo()
	{
		if (this.CacheVector == null)
		{
			this.CacheCrossVector = Vector.Create();
			this.CacheVector = Vector.Create();
			this.SingleMoveForward = Vector.Create();
		}
		this.MoveComp = this.Entity.GetComponent<BaseMoveComponent>();
		this.StateComp = this.Entity.GetComponent<CharacterUnifiedStateComponent>();
		this.AnimComp = this.Entity.GetComponent<CharacterAnimationComponent>();
		this.AiComp = this.Entity.GetComponent<CharacterAiComponent>();
		this.CurTime = 0f;
		this.IsInit = false;
		this.IsPause = false;
		this.ForceExit = false;
		this.EntityConfigId = this.ActorComp.CreatureData.GetPbDataId();
		this.IsDebugEntity = false;
		int[] debug_CONFIG_ID = this.DEBUG_CONFIG_ID;
		for (int i = 0; i < debug_CONFIG_ID.Length; i++)
		{
			if (debug_CONFIG_ID[i] == this.EntityConfigId)
			{
				this.IsDebugEntity = true;
				break;
			}
		}
		if (this.DebugComp != null)
		{
			this.DebugComp.ClearDebugPatrolPoints();
		}
		if (this.IsDebugEntity && AiPatrolController.OpenNpcPatrolDebugMode)
		{
			this.ChangeStateHandle = new Action<ECharMoveState, ECharMoveState>(this.HandleChangedState);
			Singleton<EventSystem>.Instance.AddWithTarget<ECharMoveState, ECharMoveState>(this.Entity, EEventName.CharOnUnifiedMoveStateChanged, this.ChangeStateHandle);
		}
	}

	// Token: 0x06003B63 RID: 15203 RVA: 0x0004C854 File Offset: 0x0004AA54
	private void HandleChangedState(ECharMoveState oldState, ECharMoveState newState)
	{
		if (this.IsInit)
		{
			if (newState == ECharMoveState.Other)
			{
				this.ForceExit = true;
				return;
			}
			if (this.AiComp.AiController.AiPatrol.CheckMoveStateChanged(this.StateComp, this.TsMoveState))
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					CharacterAiComponent aiComp = this.AiComp;
					AiPatrolController aiPatrolController;
					if (aiComp == null)
					{
						aiPatrolController = null;
					}
					else
					{
						AiController aiController = aiComp.AiController;
						aiPatrolController = ((aiController != null) ? aiController.AiPatrol : null);
					}
					AiPatrolController aiPatrolController2 = aiPatrolController;
					if (aiPatrolController2 != null)
					{
						aiPatrolController2.ChangeMoveState(this.StateComp, this.TsMoveState);
					}
				}, null, null);
			}
		}
	}

	// Token: 0x06003B64 RID: 15204 RVA: 0x0004C8B0 File Offset: 0x0004AAB0
	private void InitTraceElement()
	{
		if (this.TraceElement == null)
		{
			this.TraceElement = new UTraceBoxElement();
			this.TraceElement.bIsSingle = true;
			this.TraceElement.bIgnoreSelf = true;
			this.TraceElement.SetBoxHalfSize(this.TsRaycastLength / 2f, 20f, this.ActorComp.HalfHeight / 2f);
			this.TraceElement.DrawTime = 0.5f;
			Singleton<TraceElementCommon>.Instance.SetTraceColor(this.TraceElement, ColorUtils.LinearGreen);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(this.TraceElement, ColorUtils.LinearRed);
			this.TraceElement.AddObjectTypeQuery(KuroObjectTypeQuery.Pawn);
			this.TraceElement.SetDrawDebugTrace(this.TsDebugMode ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
		}
		this.TraceElement.WorldContextObject = this.ActorComp.Owner;
	}

	// Token: 0x06003B65 RID: 15205 RVA: 0x0004C990 File Offset: 0x0004AB90
	private void InitPatrolInfo()
	{
		Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		CreatureDataComponent creatureData = this.ActorComp.CreatureData;
		this.PatrolLogic.StartPatrol(false, null);
		creatureData.SetPosAbnormal(false);
		this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
		if (this.TsDebugMode && this.DebugComp != null)
		{
			this.DebugComp.SaveDebugPatrolPoint(actorLocationProxy);
		}
		this.MoveToPatrolPoint();
		this.IsInit = true;
	}

	// Token: 0x06003B66 RID: 15206 RVA: 0x0004CA10 File Offset: 0x0004AC10
	private void MoveToPatrolPoint()
	{
		PatrolPoint patrolPoint = this.PatrolLogic.PatrolPoint;
		if (patrolPoint == null)
		{
			base.Finish(false);
			return;
		}
		this.CacheVector.FromUeVector(patrolPoint.Point);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.CacheVector.Normalize(9.99999993922529E-09);
		this.SingleMoveForward.FromUeVector(this.CacheVector);
		MoveCharacterPoint item = new MoveCharacterPoint
		{
			Index = 0,
			Position = patrolPoint.Point,
			MoveState = new EPatrolMoveState?((EPatrolMoveState)this.TsMoveState)
		};
		List<MoveCharacterPoint> value = new List<MoveCharacterPoint>
		{
			item
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = this.PatrolConfig.ContainZ,
			DebugMode = this.TsDebugMode,
			Loop = false,
			Callback = this.HandleMoveEnd,
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, "TsTaskNpcPatrol.MoveToPatrolPoint");
	}

	// Token: 0x06003B67 RID: 15207 RVA: 0x0004CB1C File Offset: 0x0004AD1C
	private void ExecuteMoveEnd(ELevelEventState result)
	{
		if (result == ELevelEventState.Success)
		{
			PatrolPoint patrolPoint = this.PatrolLogic.PatrolPoint;
			if (this.CheckMoveEnd(patrolPoint))
			{
				this.PatrolLogic.PatrolFinish();
				base.Finish(true);
				return;
			}
			if (patrolPoint != this.PatrolLogic.PatrolPoint)
			{
				patrolPoint = this.PatrolLogic.PatrolPoint;
				if (patrolPoint == null)
				{
					base.Finish(true);
					return;
				}
				if (patrolPoint.IsMain)
				{
					this.PatrolLogic.ResetBaseInfoByMainPoint(this.MoveComp, this.StateComp, this.TsMoveState);
				}
				this.MoveToPatrolPoint();
				return;
			}
		}
		else
		{
			if (result == ELevelEventState.Failure)
			{
				base.Finish(false);
				return;
			}
			if (result == ELevelEventState.Error)
			{
				this.PatrolError();
			}
		}
	}

	// Token: 0x06003B68 RID: 15208 RVA: 0x0004CBBC File Offset: 0x0004ADBC
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

	// Token: 0x06003B69 RID: 15209 RVA: 0x0004CC5C File Offset: 0x0004AE5C
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
		if (this.ChangeMoveTimeInternal > 0f)
		{
			this.ChangeMoveTimeInternal -= deltaSeconds;
			if (this.ChangeMoveTimeInternal < 0f)
			{
				this.MoveToPatrolPoint();
			}
		}
		this.CurTime += deltaSeconds;
		if (this.CurTime > 0.5f)
		{
			this.CurTime = 0f;
			this.ExecuteObstacle();
		}
	}

	// Token: 0x06003B6A RID: 15210 RVA: 0x0004CCDC File Offset: 0x0004AEDC
	private void ExecuteObstacle()
	{
		if (this.IsDebugEntity && AiPatrolController.OpenNpcPatrolDebugMode && this.DebugComp != null)
		{
			this.DebugComp.SaveDebugPatrolPoint(this.ActorComp.ActorLocationProxy);
		}
		if (!this.GetObstacleLocation())
		{
			return;
		}
		Vector currentToLocation = this.MoveComp.MoveController.GetCurrentToLocation();
		Vector vector = this.CalculateAmendForward(currentToLocation);
		if (Math.Abs(Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.SingleMoveForward, vector)) > (double)this.TsMaxChangeAngle)
		{
			return;
		}
		this.CalculateAmendMovePoint(vector);
	}

	// Token: 0x06003B6B RID: 15211 RVA: 0x0004CD60 File Offset: 0x0004AF60
	[NullableContext(1)]
	private Vector CalculateAmendForward(Vector toLocation)
	{
		this.CacheVector.FromUeVector(toLocation);
		this.CacheVector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		this.CacheVector.Z = 0.0;
		this.CacheVector.Normalize(9.99999993922529E-09);
		Vector.CrossProduct(this.ActorComp.ActorForwardProxy, this.CacheVector, this.CacheCrossVector);
		this.CacheVector.FromUeVector(this.ActorComp.ActorForwardProxy);
		if (this.CacheCrossVector.Z > 0.0)
		{
			this.CacheVector.RotateAngleAxis((double)(-(double)this.TsChangeMoveAngle), Vector.UpVectorProxy, this.CacheVector);
		}
		else
		{
			this.CacheVector.RotateAngleAxis((double)this.TsChangeMoveAngle, Vector.UpVectorProxy, this.CacheVector);
		}
		return this.CacheVector;
	}

	// Token: 0x06003B6C RID: 15212 RVA: 0x0004CE44 File Offset: 0x0004B044
	[NullableContext(1)]
	private void CalculateAmendMovePoint(Vector newForward)
	{
		this.CacheVector.FromUeVector(newForward);
		this.CacheVector.MultiplyEqual((double)this.TsChangeMoveDistance);
		this.CacheVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
		MoveCharacterPoint item = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.CacheVector,
			MoveState = new EPatrolMoveState?((EPatrolMoveState)this.TsMoveState)
		};
		List<MoveCharacterPoint> value = new List<MoveCharacterPoint>
		{
			item
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = this.PatrolConfig.ContainZ,
			DebugMode = this.TsDebugMode,
			Loop = false,
			Callback = this.HandleMoveEnd,
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, "TsTaskNpcPatrol.CalculateAmendMovePoint");
		this.ChangeMoveTimeInternal = this.TsChangeMoveTime;
	}

	// Token: 0x06003B6D RID: 15213 RVA: 0x0004CF2C File Offset: 0x0004B12C
	private unsafe bool GetObstacleLocation()
	{
		this.CacheVector.FromUeVector(this.ActorComp.ActorForwardProxy);
		this.CacheVector.MultiplyEqual((double)this.TraceElement.HalfSizeX);
		this.CacheVector.AdditionEqual(this.ActorComp.ActorLocationProxy);
		Singleton<TraceElementCommon>.Instance.SetStartLocation(this.TraceElement, this.CacheVector);
		Singleton<TraceElementCommon>.Instance.SetEndLocation(this.TraceElement, this.CacheVector);
		Singleton<TraceElementCommon>.Instance.SetBoxOrientation(this.TraceElement, this.ActorComp.ActorRotationProxy);
		bool flag = Singleton<TraceElementCommon>.Instance.BoxTrace(this.TraceElement, "TsTaskNpcPatrol_GetObstacleLocation");
		UKuroHitResult hitResult = this.TraceElement.HitResult;
		if (!flag || !hitResult.bBlockingHit)
		{
			return false;
		}
		Singleton<TraceElementCommon>.Instance.GetImpactPoint(hitResult, 0, this.CacheVector);
		if (this.IsDebugEntity && AiPatrolController.OpenNpcPatrolDebugMode)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Level;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "NPC巡逻，碰撞到实体";
			<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", hitResult.Actors.Get(0).GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("NowLocation", this.ActorComp.ActorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("HitLocation", this.CacheVector);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		}
		return true;
	}

	// Token: 0x06003B6E RID: 15214 RVA: 0x0004D0CC File Offset: 0x0004B2CC
	[NullableContext(1)]
	private bool CheckMoveEnd(PatrolPoint curPoint)
	{
		bool result = false;
		if (this.ChangeMoveTimeInternal > 0f)
		{
			this.ChangeMoveTimeInternal = 0f;
			this.MoveToPatrolPoint();
		}
		else
		{
			result = this.PatrolLogic.CheckPatrolEnd();
			if (this.TsMoveOnePath && curPoint.IsMain && !curPoint.IsIgnorePoint && curPoint.Actions != null)
			{
				ControllerBase<LevelGeneralController>.Instance.ExecuteActionsNew(curPoint.Actions, EntityContext.Create(this.Entity.Id, null), null);
			}
		}
		return result;
	}

	// Token: 0x06003B6F RID: 15215 RVA: 0x0004D154 File Offset: 0x0004B354
	private unsafe void PatrolError()
	{
		this.IsPause = true;
		if (AiPatrolController.OpenNpcPatrolDebugMode)
		{
			Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
			Vector actorLocationProxy2 = Global.BaseCharacter.CharacterActorComponent.ActorLocationProxy;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "NPC巡逻，触发异常停止";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.EntityConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("EntityActive", this.Entity.Active);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("HasMove", this.MoveComp.HasMoveInput);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("TickInterval", this.Entity.GetTickInterval());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("HasModelBuffer", this.AnimComp.HasModelBuffer());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("WasRecentlyRenderedOnScreen", this.ActorComp.Owner.WasRecentlyRenderedOnScreen(0.2f));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("CustomTimeDilation", this.ActorComp.Owner.CustomTimeDilation);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
			Vector point = this.PatrolLogic.PatrolPoint.Point;
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.AI;
			ELogAuthor author2 = ELogAuthor.CWZ;
			string message2 = "NPC巡逻，巡逻信息";
			<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray5<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PlayerDist", Math.Ceiling(Vector.Dist2D(actorLocationProxy, actorLocationProxy2)));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PatrolDist", Math.Ceiling(Vector.Dist2D(actorLocationProxy, point)));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("PatrolIndex", this.PatrolLogic.PatrolIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 3) = new ValueTuple<string, object>("NowLocation", actorLocationProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 4) = new ValueTuple<string, object>("ToLocation", point);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 5));
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.AI;
			ELogAuthor author3 = ELogAuthor.CWZ;
			string message3 = "NPC巡逻，角色输入信息";
			<>y__InlineArray10<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray10<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("SimpleMove", this.TsUseSimpleMove);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1);
			string item = "MoveState";
			CharacterUnifiedStateComponent stateComp = this.StateComp;
			ptr = new ValueTuple<string, object>(item, (stateComp != null) ? new ECharMoveState?(stateComp.MoveState) : null);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("MovementMode", this.MoveComp.CharacterMovement.MovementMode);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("MoveSpeed", this.MoveComp.Speed);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 4) = new ValueTuple<string, object>("MaxSpeed", this.MoveComp.CharacterMovement.MaxWalkSpeed);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 5) = new ValueTuple<string, object>("MoveInput", this.ActorComp.Actor.K2_GetMovementInputVector());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 6) = new ValueTuple<string, object>("InputDirect", this.ActorComp.InputDirectProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 7) = new ValueTuple<string, object>("InputFacing", this.ActorComp.InputFacingProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 8) = new ValueTuple<string, object>("ActorForward", this.ActorComp.ActorForwardProxy);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 9) = new ValueTuple<string, object>("Velocity", this.ActorComp.Owner.D_GetVelocity());
			instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray10<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 10));
			UKuroAnimInstance ukuroAnimInstance = this.AnimComp.MainAnimInstance as UKuroAnimInstance;
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.AI;
			ELogAuthor author4 = ELogAuthor.CWZ;
			string message4 = "NPC巡逻，角色ABP动画详细信息";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Anims", ukuroAnimInstance.GetDebugAnimNodeString());
			instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.ActorComp.CreatureData.RequestPosAbnormal();
		this.ActorComp.ClearInput(false, true);
		this.AnimComp.StopModelBuffer();
		this.MoveComp.StopMove(true, "TsTaskNpcPatrol.PatrolError");
		this.MoveComp.IsSpecialMove = false;
		this.MoveComp.HasMoveInput = false;
	}

	// Token: 0x06003B70 RID: 15216 RVA: 0x0004D600 File Offset: 0x0004B800
	protected override void OnAbort()
	{
		AiPatrolController patrolLogic = this.PatrolLogic;
		if (patrolLogic == null)
		{
			return;
		}
		patrolLogic.PatrolFinish();
	}

	// Token: 0x06003B71 RID: 15217 RVA: 0x0004D614 File Offset: 0x0004B814
	protected override void OnClear()
	{
		if (!(base.AIOwner is TsAiController))
		{
			return;
		}
		if (AiPatrolController.OpenNpcPatrolDebugMode)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.AI;
			ELogAuthor author = ELogAuthor.CWZ;
			string message = "NPC退出巡逻";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.EntityConfigId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.MoveComp != null)
		{
			if (this.TsMoveOnePath)
			{
				this.MoveComp.SetForceSpeed(Vector.ZeroVectorProxy);
			}
			this.MoveComp.IsSpecialMove = false;
			this.MoveComp.HasMoveInput = false;
		}
		if (this.IsDebugEntity && AiPatrolController.OpenNpcPatrolDebugMode)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<ECharMoveState, ECharMoveState>(this.Entity, EEventName.CharOnUnifiedMoveStateChanged, this.ChangeStateHandle);
		}
		this.Entity = null;
		this.ActorComp = null;
		this.DebugComp = null;
		this.MoveComp = null;
		this.StateComp = null;
		this.AnimComp = null;
		this.AiComp = null;
		this.PatrolLogic = null;
		this.PatrolConfig = null;
		this.CurTime = 0f;
		this.IsPause = false;
		this.ForceExit = false;
		this.IsInit = false;
	}

	// Token: 0x06003B72 RID: 15218 RVA: 0x0004D729 File Offset: 0x0004B929
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcPatrol._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPatrol.TsTaskNpcPatrol_C");
		}
		return TsTaskNpcPatrol._ClassPtr;
	}

	// Token: 0x06003B73 RID: 15219 RVA: 0x0004D750 File Offset: 0x0004B950
	public TsTaskNpcPatrol() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcPatrol.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003B74 RID: 15220 RVA: 0x0004D778 File Offset: 0x0004B978
	[NullableContext(1)]
	public TsTaskNpcPatrol(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcPatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003B75 RID: 15221 RVA: 0x0004D7AB File Offset: 0x0004B9AB
	protected TsTaskNpcPatrol(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003B76 RID: 15222 RVA: 0x0004D7D0 File Offset: 0x0004B9D0
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003B77 RID: 15223 RVA: 0x0004D800 File Offset: 0x0004BA00
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000AA5 RID: 2725
	[Nullable(1)]
	private const string PROFILE_KEY = "TsTaskNpcPatrol_GetObstacleLocation";

	// Token: 0x04000AA6 RID: 2726
	private const float CHECK_RAYCAST_INTERVAL = 0.5f;

	// Token: 0x04000AA7 RID: 2727
	[Nullable(1)]
	private readonly int[] DEBUG_CONFIG_ID = new int[]
	{
		109002526,
		109002530
	};

	// Token: 0x04000AA8 RID: 2728
	private Entity Entity;

	// Token: 0x04000AA9 RID: 2729
	private CharacterActorComponent ActorComp;

	// Token: 0x04000AAA RID: 2730
	private BaseMoveComponent MoveComp;

	// Token: 0x04000AAB RID: 2731
	private CharacterUnifiedStateComponent StateComp;

	// Token: 0x04000AAC RID: 2732
	private CharacterAnimationComponent AnimComp;

	// Token: 0x04000AAD RID: 2733
	private CharacterAiComponent AiComp;

	// Token: 0x04000AAE RID: 2734
	private Vector CacheCrossVector;

	// Token: 0x04000AAF RID: 2735
	private Vector CacheVector;

	// Token: 0x04000AB0 RID: 2736
	private Vector SingleMoveForward;

	// Token: 0x04000AB1 RID: 2737
	private float CurTime;

	// Token: 0x04000AB2 RID: 2738
	private float ChangeMoveTimeInternal;

	// Token: 0x04000AB3 RID: 2739
	private UTraceBoxElement TraceElement;

	// Token: 0x04000AB4 RID: 2740
	private bool IsInit;

	// Token: 0x04000AB5 RID: 2741
	private bool IsPause;

	// Token: 0x04000AB6 RID: 2742
	private bool ForceExit;

	// Token: 0x04000AB7 RID: 2743
	private int EntityConfigId;

	// Token: 0x04000AB8 RID: 2744
	private bool IsDebugEntity;

	// Token: 0x04000AB9 RID: 2745
	private TsCharacterDebugComponent DebugComp;

	// Token: 0x04000ABA RID: 2746
	private AiPatrolController PatrolLogic;

	// Token: 0x04000ABB RID: 2747
	private AiPatrolConfig PatrolConfig;

	// Token: 0x04000ABC RID: 2748
	private bool IsInitTsVariables;

	// Token: 0x04000ABD RID: 2749
	private bool TsDebugMode;

	// Token: 0x04000ABE RID: 2750
	private int TsMoveState;

	// Token: 0x04000ABF RID: 2751
	private bool TsMoveOnePath;

	// Token: 0x04000AC0 RID: 2752
	private bool TsUseSimpleMove;

	// Token: 0x04000AC1 RID: 2753
	private float TsRaycastLength;

	// Token: 0x04000AC2 RID: 2754
	private float TsChangeMoveTime;

	// Token: 0x04000AC3 RID: 2755
	private float TsChangeMoveAngle;

	// Token: 0x04000AC4 RID: 2756
	private float TsMaxChangeAngle;

	// Token: 0x04000AC5 RID: 2757
	private float TsChangeMoveDistance;

	// Token: 0x04000AC6 RID: 2758
	private Action<ELevelEventState> HandleMoveEnd;

	// Token: 0x04000AC7 RID: 2759
	private Action<ECharMoveState, ECharMoveState> ChangeStateHandle;

	// Token: 0x04000AC8 RID: 2760
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/TsTaskNpcPatrol.TsTaskNpcPatrol_C";

	// Token: 0x04000AC9 RID: 2761
	private static IntPtr _ClassPtr;

	// Token: 0x04000ACA RID: 2762
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000ACB RID: 2763
	private static int __PropertyOffset_DebugMode;

	// Token: 0x04000ACC RID: 2764
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000ACD RID: 2765
	private static int __PropertyOffset_MoveOnePath;

	// Token: 0x04000ACE RID: 2766
	private static int __PropertyOffset_UseSimpleMove;

	// Token: 0x04000ACF RID: 2767
	private static int __PropertyOffset_RaycastLength;

	// Token: 0x04000AD0 RID: 2768
	private static int __PropertyOffset_ChangeMoveTime;

	// Token: 0x04000AD1 RID: 2769
	private static int __PropertyOffset_ChangeMoveAngle;

	// Token: 0x04000AD2 RID: 2770
	private static int __PropertyOffset_MaxChangeAngle;

	// Token: 0x04000AD3 RID: 2771
	private static int __PropertyOffset_ChangeMoveDistance;
}
