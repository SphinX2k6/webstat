using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using CSharpScript.Game.NewWorld.SceneItem;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C85 RID: 3205
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChair.TsTaskNpcSitOnChair_C")]
public class TsTaskNpcSitOnChair : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000195 RID: 405
	// (get) Token: 0x06003A3E RID: 14910 RVA: 0x00046821 File Offset: 0x00044A21
	// (set) Token: 0x06003A3F RID: 14911 RVA: 0x00046831 File Offset: 0x00044A31
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ChairEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_ChairEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_ChairEntityId) = value;
		}
	}

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x06003A40 RID: 14912 RVA: 0x00046842 File Offset: 0x00044A42
	// (set) Token: 0x06003A41 RID: 14913 RVA: 0x00046856 File Offset: 0x00044A56
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MontagePath
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_MontagePath)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_MontagePath)), value);
		}
	}

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x06003A42 RID: 14914 RVA: 0x0004686B File Offset: 0x00044A6B
	// (set) Token: 0x06003A43 RID: 14915 RVA: 0x0004687B File Offset: 0x00044A7B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_LoopDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_LoopDuration) = value;
		}
	}

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x06003A44 RID: 14916 RVA: 0x0004688C File Offset: 0x00044A8C
	// (set) Token: 0x06003A45 RID: 14917 RVA: 0x0004689C File Offset: 0x00044A9C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RepeatTimes
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_RepeatTimes);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChair.__PropertyOffset_RepeatTimes) = value;
		}
	}

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x06003A46 RID: 14918 RVA: 0x000468AD File Offset: 0x00044AAD
	// (set) Token: 0x06003A47 RID: 14919 RVA: 0x000468B5 File Offset: 0x00044AB5
	private TsTaskNpcSitOnChair.ETaskPhase Phase
	{
		get
		{
			return this.PhaseInternal;
		}
		set
		{
			if (this.PhaseInternal == value)
			{
				return;
			}
			this.PhaseInternal = value;
		}
	}

	// Token: 0x06003A48 RID: 14920 RVA: 0x000468C8 File Offset: 0x00044AC8
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsChairEntityId = this.ChairEntityId;
			this.TsMontagePath = this.MontagePath;
			this.TsLoopDuration = this.LoopDuration;
			this.TsRepeatTimes = this.RepeatTimes;
			this.ChairNearbyPos = Vector.Create();
			this.ChairSitPos = Vector.Create();
			this.TempVec = Vector.Create();
		}
	}

	// Token: 0x06003A49 RID: 14921 RVA: 0x0004693C File Offset: 0x00044B3C
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

	// Token: 0x06003A4A RID: 14922 RVA: 0x000469D8 File Offset: 0x00044BD8
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
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(true);
			return;
		}
		this.Entity = aiController.CharAiDesignComp.Entity;
		this.Character = this.Entity.GetComponent<CharacterActorComponent>();
		this.MoveComp = this.Entity.GetComponent<BaseMoveComponent>();
		this.AnimComp = this.Entity.GetComponent<CharacterAnimationComponent>();
		BaseMoveComponent moveComp = this.MoveComp;
		bool flag;
		if (moveComp == null)
		{
			flag = true;
		}
		else
		{
			UCharacterMovementComponent characterMovement = moveComp.CharacterMovement;
			flag = !((characterMovement != null) ? new bool?(characterMovement.IsValid()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.YJX;
			string message2 = "[TsTaskSitOnChair]MoveComp不合法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("PbDataId", this.Character.CreatureData.GetPbDataId());
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.FinishExecute(true);
			return;
		}
		EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.TsChairEntityId);
		object obj;
		if (entityByPbDataId == null)
		{
			obj = null;
		}
		else
		{
			WorldEntity entity = entityByPbDataId.Entity;
			if (entity == null)
			{
				obj = null;
			}
			else
			{
				PawnInteractNewComponent component = entity.GetComponent<PawnInteractNewComponent>();
				obj = ((component != null) ? component.GetSubEntityInteractLogicController() : null);
			}
		}
		this.ChairController = (obj as PawnChairController);
		if (this.ChairController == null || !this.ChairController.IsSceneInteractionLoadCompleted())
		{
			base.FinishExecute(true);
			return;
		}
		if (this.TsMontagePath == "")
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.BehaviorTree;
			ELogAuthor author3 = ELogAuthor.YJX;
			string message3 = "[TsTaskSitOnChair]无效的Montage路径";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.Character.CreatureData.GetPbDataId());
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			base.FinishExecute(true);
			return;
		}
		this.Phase = TsTaskNpcSitOnChair.ETaskPhase.Execute;
	}

	// Token: 0x06003A4B RID: 14923 RVA: 0x00046C2C File Offset: 0x00044E2C
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

	// Token: 0x06003A4C RID: 14924 RVA: 0x00046CCC File Offset: 0x00044ECC
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		switch (this.Phase)
		{
		case TsTaskNpcSitOnChair.ETaskPhase.Execute:
			this.Phase = TsTaskNpcSitOnChair.ETaskPhase.MoveNearby;
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.MoveNearby:
			this.ExecuteMoveNearby();
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.MoveClose:
			this.ExecuteMoveClose();
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.TurnTo:
			this.ExecuteTurnTo();
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.PlayMontage:
			this.ExecutePlayMontage();
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.MoveAway:
			this.ExecuteMoveAway();
			return;
		case TsTaskNpcSitOnChair.ETaskPhase.Finish:
			base.Finish(true);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[TsTaskTurnAndSit] 阶段切换出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurPhase", this.Phase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		}
	}

	// Token: 0x06003A4D RID: 14925 RVA: 0x00046D6C File Offset: 0x00044F6C
	protected override void OnAbort()
	{
		if (this.Phase == TsTaskNpcSitOnChair.ETaskPhase.MoveNearby || this.Phase == TsTaskNpcSitOnChair.ETaskPhase.MoveClose || this.Phase == TsTaskNpcSitOnChair.ETaskPhase.MoveAway)
		{
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp == null)
			{
				return;
			}
			moveComp.StopMoveNew(null);
			return;
		}
		else
		{
			if (this.Phase != TsTaskNpcSitOnChair.ETaskPhase.TurnTo)
			{
				if (this.Phase == TsTaskNpcSitOnChair.ETaskPhase.PlayMontage)
				{
					if (this.NeedSetSeatMorph)
					{
						this.NeedSetSeatMorph = false;
						if (this.AnimComp != null)
						{
							PawnChairController chairController = this.ChairController;
							if (((chairController != null) ? chairController.Entity : null) != null)
							{
								ControllerBase<AnimController>.Instance.SetSeatMorph(this.ChairController.Entity, this.AnimComp.Entity.Id, 0.0);
							}
						}
					}
					Entity entity = this.Entity;
					BasePerformComponent basePerformComponent = (entity != null) ? entity.GetComponent<BasePerformComponent>() : null;
					if (this.PlayingMontage != -1)
					{
						if (basePerformComponent != null)
						{
							basePerformComponent.VolatileMontageStopByLoad(EPerformMode.Ecology, this.PlayingMontage, EStopMethod.BlendOut);
						}
						this.PlayingMontage = -1;
					}
				}
				return;
			}
			CharacterActorComponent character = this.Character;
			if (character == null)
			{
				return;
			}
			character.ClearInput(false, true);
			return;
		}
	}

	// Token: 0x06003A4E RID: 14926 RVA: 0x00046E5B File Offset: 0x0004505B
	protected override void OnClear()
	{
		this.Character = null;
		this.MovementMode = EMovementMode.MOVE_None;
		this.IsExecuteMoveNearby = false;
		this.IsExecuteMoveClose = false;
		this.IsExecuteTurnTo = false;
		this.IsExecutePlayMontage = false;
		this.IsExecuteMoveAway = false;
	}

	// Token: 0x06003A4F RID: 14927 RVA: 0x00046E90 File Offset: 0x00045090
	private void ExecuteMoveNearby()
	{
		if (this.IsExecuteMoveNearby)
		{
			return;
		}
		this.IsExecuteMoveNearby = true;
		this.ChairController.Possess(this.Entity, false);
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.ChairController.GetForwardDirection().Multiply(70.0, this.ChairNearbyPos);
		this.ChairNearbyPos.AdditionEqual(sitLocation);
		MoveCharacterPoint item = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.ChairNearbyPos,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)100)
		};
		List<MoveCharacterPoint> value = new List<MoveCharacterPoint>
		{
			item
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				BaseMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					moveComp.StopMoveNew(null);
				}
				this.Phase = TsTaskNpcSitOnChair.ETaskPhase.MoveClose;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A50 RID: 14928 RVA: 0x00046F9C File Offset: 0x0004519C
	private void ExecuteMoveClose()
	{
		if (this.IsExecuteMoveClose)
		{
			return;
		}
		this.IsExecuteMoveClose = true;
		this.ChairController.Possess(this.Entity, false);
		this.ChairController.IgnoreCollision();
		Vector actorLocationProxy = this.Character.ActorLocationProxy;
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.ChairSitPos.Set(sitLocation.X, sitLocation.Y, actorLocationProxy.Z);
		MoveCharacterPoint item = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.ChairSitPos,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)70)
		};
		List<MoveCharacterPoint> value = new List<MoveCharacterPoint>
		{
			item
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				BaseMoveComponent moveComp = this.MoveComp;
				if (moveComp != null)
				{
					moveComp.StopMoveNew(null);
				}
				this.Phase = TsTaskNpcSitOnChair.ETaskPhase.TurnTo;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A51 RID: 14929 RVA: 0x000470B0 File Offset: 0x000452B0
	private void ExecuteTurnTo()
	{
		if (!this.IsExecuteTurnTo)
		{
			this.IsExecuteTurnTo = true;
			this.ChairController.GetForwardDirection().Multiply(200.0, this.TempVec);
			this.TempVec.AdditionEqual(this.ChairNearbyPos);
			this.MovementMode = this.MoveComp.CharacterMovement.MovementMode;
			this.MoveComp.CharacterMovement.MovementMode = EMovementMode.MOVE_Walking;
			AiControllerLibrary.TurnToTarget(this.Character, this.TempVec, 200f, false, 0f);
			return;
		}
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 10f)
		{
			this.MoveComp.CharacterMovement.MovementMode = this.MovementMode;
			this.Phase = TsTaskNpcSitOnChair.ETaskPhase.PlayMontage;
			return;
		}
	}

	// Token: 0x06003A52 RID: 14930 RVA: 0x00047188 File Offset: 0x00045388
	private void ExecutePlayMontage()
	{
		if (this.IsExecutePlayMontage)
		{
			if (this.NeedSetSeatMorph && this.AnimComp != null)
			{
				PawnChairController chairController = this.ChairController;
				if (((chairController != null) ? chairController.Entity : null) != null)
				{
					UAnimInstance animInstance = this.AnimComp.GetAnimInstance();
					float num = (animInstance != null) ? animInstance.GetCurveValue(Singleton<CharacterNameDefines>.Instance.SEAT_MORPH) : 0f;
					ControllerBase<AnimController>.Instance.SetSeatMorph(this.ChairController.Entity, this.AnimComp.Entity.Id, (double)num);
				}
			}
			return;
		}
		this.IsExecutePlayMontage = true;
		PawnChairController chairController2 = this.ChairController;
		bool? flag;
		if (chairController2 == null)
		{
			flag = null;
		}
		else
		{
			Entity entity = chairController2.Entity;
			if (entity == null)
			{
				flag = null;
			}
			else
			{
				SceneItemProceduralMaterialComponent component = entity.GetComponent<SceneItemProceduralMaterialComponent>();
				flag = ((component != null) ? new bool?(component.HasCustomType(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair)) : null);
			}
		}
		bool? flag2 = flag;
		this.NeedSetSeatMorph = (flag2.GetValueOrDefault() && this.AnimComp != null);
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			animComp.SetLocationAndRotatorWithModelBuffer(this.ChairSitPos.ToUeVector(false), this.Character.ActorRotationProxy.ToUeRotator(), 200f, "TsTaskNpcSitOnChair.ExecuteTurnToFinish", ESetRotationPriority.Anim, true);
		}
		BasePerformComponent component2 = this.Entity.GetComponent<BasePerformComponent>();
		this.PlayingMontage = component2.VolatileMontagePlayByLoad(EPerformMode.Ecology, this.TsMontagePath, null, null, delegate(UAnimMontage montage, bool _)
		{
			if (montage != null)
			{
				this.Phase = TsTaskNpcSitOnChair.ETaskPhase.MoveAway;
				return;
			}
			base.FinishExecute(true);
		}, new float?(this.TsLoopDuration), new float?((float)this.TsRepeatTimes), new bool?(false), new bool?(false), new bool?(false));
	}

	// Token: 0x06003A53 RID: 14931 RVA: 0x0004730C File Offset: 0x0004550C
	private void ExecuteMoveAway()
	{
		if (this.IsExecuteMoveAway)
		{
			return;
		}
		if (this.NeedSetSeatMorph)
		{
			this.NeedSetSeatMorph = false;
			if (this.AnimComp != null)
			{
				PawnChairController chairController = this.ChairController;
				if (((chairController != null) ? chairController.Entity : null) != null)
				{
					ControllerBase<AnimController>.Instance.SetSeatMorph(this.ChairController.Entity, this.AnimComp.Entity.Id, 0.0);
				}
			}
		}
		this.IsExecuteMoveAway = true;
		this.ChairController.UnPossess(this.Entity);
		MoveCharacterPoint item = new MoveCharacterPoint
		{
			Index = 0,
			Position = this.ChairNearbyPos,
			MoveState = new EPatrolMoveState?(EPatrolMoveState.Walk),
			MoveSpeed = new float?((float)70)
		};
		List<MoveCharacterPoint> value = new List<MoveCharacterPoint>
		{
			item
		};
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = value,
			Navigation = true,
			IsFly = false,
			DebugMode = true,
			Loop = false,
			Distance = new float?((float)5),
			Callback = delegate(ELevelEventState result)
			{
				this.MoveComp.StopMoveNew(null);
				this.ChairController.ResetCollision();
				this.ChairController.UnPossess(this.Entity);
				this.Phase = TsTaskNpcSitOnChair.ETaskPhase.Finish;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A54 RID: 14932 RVA: 0x00047436 File Offset: 0x00045636
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcSitOnChair._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChair.TsTaskNpcSitOnChair_C");
		}
		return TsTaskNpcSitOnChair._ClassPtr;
	}

	// Token: 0x06003A55 RID: 14933 RVA: 0x0004745C File Offset: 0x0004565C
	public TsTaskNpcSitOnChair() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSitOnChair.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A56 RID: 14934 RVA: 0x00047484 File Offset: 0x00045684
	[NullableContext(1)]
	public TsTaskNpcSitOnChair(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSitOnChair.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A57 RID: 14935 RVA: 0x000474B7 File Offset: 0x000456B7
	protected TsTaskNpcSitOnChair(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A58 RID: 14936 RVA: 0x000474D4 File Offset: 0x000456D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003A59 RID: 14937 RVA: 0x00047504 File Offset: 0x00045704
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040009C5 RID: 2501
	private const int TOLERANCE = 10;

	// Token: 0x040009C6 RID: 2502
	private const int TURN_SPEED = 200;

	// Token: 0x040009C7 RID: 2503
	private const int NEARBY_CHAIR_OFFSET = 70;

	// Token: 0x040009C8 RID: 2504
	private const int MOVE_TO_CHAIR_SPEED = 70;

	// Token: 0x040009C9 RID: 2505
	private const int MOVE_TO_NEARBY_CHAIR_SPEED = 100;

	// Token: 0x040009CA RID: 2506
	private const int MOVE_TO_CHAIR_DISTANCE_TOLERANCE = 5;

	// Token: 0x040009CB RID: 2507
	private const int MODEL_BUFFER_SMOOTH_TIME = 200;

	// Token: 0x040009CC RID: 2508
	private EMovementMode MovementMode;

	// Token: 0x040009CD RID: 2509
	private int PlayingMontage = -1;

	// Token: 0x040009CE RID: 2510
	private TsTaskNpcSitOnChair.ETaskPhase PhaseInternal;

	// Token: 0x040009CF RID: 2511
	private bool IsExecuteMoveNearby;

	// Token: 0x040009D0 RID: 2512
	private bool IsExecuteMoveClose;

	// Token: 0x040009D1 RID: 2513
	private bool IsExecuteTurnTo;

	// Token: 0x040009D2 RID: 2514
	private bool IsExecutePlayMontage;

	// Token: 0x040009D3 RID: 2515
	private bool NeedSetSeatMorph;

	// Token: 0x040009D4 RID: 2516
	private bool IsExecuteMoveAway;

	// Token: 0x040009D5 RID: 2517
	private Entity Entity;

	// Token: 0x040009D6 RID: 2518
	private CharacterActorComponent Character;

	// Token: 0x040009D7 RID: 2519
	private BaseMoveComponent MoveComp;

	// Token: 0x040009D8 RID: 2520
	private CharacterAnimationComponent AnimComp;

	// Token: 0x040009D9 RID: 2521
	private PawnChairController ChairController;

	// Token: 0x040009DA RID: 2522
	private bool IsInitTsVariables;

	// Token: 0x040009DB RID: 2523
	private int TsChairEntityId;

	// Token: 0x040009DC RID: 2524
	[Nullable(1)]
	private string TsMontagePath = "";

	// Token: 0x040009DD RID: 2525
	private float TsLoopDuration;

	// Token: 0x040009DE RID: 2526
	private int TsRepeatTimes;

	// Token: 0x040009DF RID: 2527
	private Vector ChairNearbyPos;

	// Token: 0x040009E0 RID: 2528
	private Vector ChairSitPos;

	// Token: 0x040009E1 RID: 2529
	private Vector TempVec;

	// Token: 0x040009E2 RID: 2530
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChair.TsTaskNpcSitOnChair_C";

	// Token: 0x040009E3 RID: 2531
	private static IntPtr _ClassPtr;

	// Token: 0x040009E4 RID: 2532
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040009E5 RID: 2533
	private static int __PropertyOffset_ChairEntityId;

	// Token: 0x040009E6 RID: 2534
	private static int __PropertyOffset_MontagePath;

	// Token: 0x040009E7 RID: 2535
	private static int __PropertyOffset_LoopDuration;

	// Token: 0x040009E8 RID: 2536
	private static int __PropertyOffset_RepeatTimes;

	// Token: 0x020071CC RID: 29132
	[NullableContext(0)]
	private enum ETaskPhase
	{
		// Token: 0x040279AA RID: 162218
		None,
		// Token: 0x040279AB RID: 162219
		Execute,
		// Token: 0x040279AC RID: 162220
		MoveNearby,
		// Token: 0x040279AD RID: 162221
		MoveClose,
		// Token: 0x040279AE RID: 162222
		TurnTo,
		// Token: 0x040279AF RID: 162223
		PlayMontage,
		// Token: 0x040279B0 RID: 162224
		MoveAway,
		// Token: 0x040279B1 RID: 162225
		Finish
	}
}
