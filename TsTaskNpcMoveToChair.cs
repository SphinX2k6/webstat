using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.LevelGamePlay;
using CSharpScript.Game.NewWorld.Pawn.Component;
using CSharpScript.Game.NewWorld.Pawn.Controllers;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C84 RID: 3204
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcMoveToChair.TsTaskNpcMoveToChair_C")]
public class TsTaskNpcMoveToChair : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06003A27 RID: 14887 RVA: 0x00045F81 File Offset: 0x00044181
	// (set) Token: 0x06003A28 RID: 14888 RVA: 0x00045F91 File Offset: 0x00044191
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ChairEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToChair.__PropertyOffset_ChairEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToChair.__PropertyOffset_ChairEntityId) = value;
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06003A29 RID: 14889 RVA: 0x00045FA2 File Offset: 0x000441A2
	// (set) Token: 0x06003A2A RID: 14890 RVA: 0x00045FB2 File Offset: 0x000441B2
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool QuickFinish
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcMoveToChair.__PropertyOffset_QuickFinish) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcMoveToChair.__PropertyOffset_QuickFinish) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x06003A2B RID: 14891 RVA: 0x00045FC3 File Offset: 0x000441C3
	// (set) Token: 0x06003A2C RID: 14892 RVA: 0x00045FCB File Offset: 0x000441CB
	private TsTaskNpcMoveToChair.ETaskPhase Phase
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

	// Token: 0x06003A2D RID: 14893 RVA: 0x00045FE0 File Offset: 0x000441E0
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsChairEntityId = this.ChairEntityId;
			this.TsQuickFinish = this.QuickFinish;
			this.ChairNearbyPos = Vector.Create();
			this.ChairSitPos = Vector.Create();
			this.TempVec = Vector.Create();
			this.TempRotator = Rotator.Create();
		}
	}

	// Token: 0x06003A2E RID: 14894 RVA: 0x00046048 File Offset: 0x00044248
	[UFunction(EFunctionFlags.FUNC_None)]
	public unsafe override void ReceiveExecuteAI(AAIController ownerController, APawn controlledPawn)
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
			string message2 = "[TsTaskNpcMoveToChair]MoveComp不合法";
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
		this.ChairController.Possess(this.Entity, false);
		this.ChairController.IgnoreCollision();
		this.IsPossessed = true;
		if (this.TsQuickFinish)
		{
			Vector actorLocationProxy = this.Character.ActorLocationProxy;
			Vector sitLocation = this.ChairController.GetSitLocation();
			this.ChairSitPos.Set(sitLocation.X, sitLocation.Y, actorLocationProxy.Z);
			Vector forwardDirection = this.ChairController.GetForwardDirection();
			Singleton<MathUtils>.Instance.VectorToRotator(forwardDirection, this.TempRotator);
			this.Character.SetActorLocationAndRotation(this.ChairSitPos.ToUeVector(false), this.TempRotator.ToUeRotator(), "TsTaskNpcMoveToChair.QuickFinish", false, null);
			this.Character.ClearInput(true, true);
			this.Character.SetInputFacing(forwardDirection, false);
			this.ReleaseChair();
			base.FinishExecute(true);
			return;
		}
		this.Phase = TsTaskNpcMoveToChair.ETaskPhase.Execute;
	}

	// Token: 0x06003A2F RID: 14895 RVA: 0x000462E8 File Offset: 0x000444E8
	[UFunction(EFunctionFlags.FUNC_None)]
	public override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.TsQuickFinish)
		{
			base.FinishExecute(true);
			return;
		}
		switch (this.Phase)
		{
		case TsTaskNpcMoveToChair.ETaskPhase.Execute:
			this.Phase = TsTaskNpcMoveToChair.ETaskPhase.MoveNearby;
			return;
		case TsTaskNpcMoveToChair.ETaskPhase.MoveNearby:
			this.ExecuteMoveNearby();
			return;
		case TsTaskNpcMoveToChair.ETaskPhase.MoveClose:
			this.ExecuteMoveClose();
			return;
		case TsTaskNpcMoveToChair.ETaskPhase.TurnTo:
			this.ExecuteTurnTo();
			return;
		case TsTaskNpcMoveToChair.ETaskPhase.Finish:
			this.ReleaseChair();
			base.Finish(true);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[TsTaskNpcMoveToChair] 阶段切换出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurPhase", this.Phase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		}
	}

	// Token: 0x06003A30 RID: 14896 RVA: 0x00046388 File Offset: 0x00044588
	protected override void OnAbort()
	{
		if (this.Phase == TsTaskNpcMoveToChair.ETaskPhase.MoveNearby || this.Phase == TsTaskNpcMoveToChair.ETaskPhase.MoveClose)
		{
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.StopMoveNew(null);
			}
		}
		else if (this.Phase == TsTaskNpcMoveToChair.ETaskPhase.TurnTo)
		{
			CharacterActorComponent character = this.Character;
			if (character != null)
			{
				character.ClearInput(false, true);
			}
		}
		this.ReleaseChair();
	}

	// Token: 0x06003A31 RID: 14897 RVA: 0x000463DD File Offset: 0x000445DD
	protected override void OnClear()
	{
		this.Character = null;
		this.MovementMode = EMovementMode.MOVE_None;
		this.IsExecuteMoveNearby = false;
		this.IsExecuteMoveClose = false;
		this.IsExecuteTurnTo = false;
	}

	// Token: 0x06003A32 RID: 14898 RVA: 0x00046402 File Offset: 0x00044602
	private void ReleaseChair()
	{
		if (this.IsPossessed && this.ChairController != null)
		{
			this.ChairController.ResetCollision();
			this.ChairController.UnPossess(this.Entity);
			this.IsPossessed = false;
		}
	}

	// Token: 0x06003A33 RID: 14899 RVA: 0x00046438 File Offset: 0x00044638
	private void ExecuteMoveNearby()
	{
		if (this.IsExecuteMoveNearby)
		{
			return;
		}
		this.IsExecuteMoveNearby = true;
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
				this.Phase = TsTaskNpcMoveToChair.ETaskPhase.MoveClose;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A34 RID: 14900 RVA: 0x00046530 File Offset: 0x00044730
	private void ExecuteMoveClose()
	{
		if (this.IsExecuteMoveClose)
		{
			return;
		}
		this.IsExecuteMoveClose = true;
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
				this.Phase = TsTaskNpcMoveToChair.ETaskPhase.TurnTo;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A35 RID: 14901 RVA: 0x00046628 File Offset: 0x00044828
	private void ExecuteTurnTo()
	{
		if (Singleton<GravityUtils>.Instance.GetAngleOffsetFromCurrentToInputAbs(this.Character) < 10f)
		{
			this.MoveComp.CharacterMovement.MovementMode = this.MovementMode;
			this.Phase = TsTaskNpcMoveToChair.ETaskPhase.Finish;
			return;
		}
		if (this.IsExecuteTurnTo)
		{
			return;
		}
		this.IsExecuteTurnTo = true;
		this.ChairController.GetForwardDirection().Multiply(200.0, this.TempVec);
		this.TempVec.AdditionEqual(this.ChairNearbyPos);
		this.MovementMode = this.MoveComp.CharacterMovement.MovementMode;
		this.MoveComp.CharacterMovement.MovementMode = EMovementMode.MOVE_Walking;
		AiControllerLibrary.TurnToTarget(this.Character, this.TempVec, 200f, false, 0f);
	}

	// Token: 0x06003A36 RID: 14902 RVA: 0x000466FE File Offset: 0x000448FE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcMoveToChair._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcMoveToChair.TsTaskNpcMoveToChair_C");
		}
		return TsTaskNpcMoveToChair._ClassPtr;
	}

	// Token: 0x06003A37 RID: 14903 RVA: 0x00046724 File Offset: 0x00044924
	public TsTaskNpcMoveToChair() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcMoveToChair.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A38 RID: 14904 RVA: 0x0004674C File Offset: 0x0004494C
	[NullableContext(1)]
	public TsTaskNpcMoveToChair(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcMoveToChair.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A39 RID: 14905 RVA: 0x0004677F File Offset: 0x0004497F
	protected TsTaskNpcMoveToChair(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A3A RID: 14906 RVA: 0x00046788 File Offset: 0x00044988
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003A3B RID: 14907 RVA: 0x000467B8 File Offset: 0x000449B8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040009A9 RID: 2473
	private const int TOLERANCE = 10;

	// Token: 0x040009AA RID: 2474
	private const int TURN_SPEED = 200;

	// Token: 0x040009AB RID: 2475
	private const int NEARBY_CHAIR_OFFSET = 70;

	// Token: 0x040009AC RID: 2476
	private const int MOVE_TO_CHAIR_SPEED = 70;

	// Token: 0x040009AD RID: 2477
	private const int MOVE_TO_NEARBY_CHAIR_SPEED = 100;

	// Token: 0x040009AE RID: 2478
	private const int MOVE_TO_CHAIR_DISTANCE_TOLERANCE = 5;

	// Token: 0x040009AF RID: 2479
	private EMovementMode MovementMode;

	// Token: 0x040009B0 RID: 2480
	private TsTaskNpcMoveToChair.ETaskPhase PhaseInternal;

	// Token: 0x040009B1 RID: 2481
	private bool IsExecuteMoveNearby;

	// Token: 0x040009B2 RID: 2482
	private bool IsExecuteMoveClose;

	// Token: 0x040009B3 RID: 2483
	private bool IsExecuteTurnTo;

	// Token: 0x040009B4 RID: 2484
	private bool IsPossessed;

	// Token: 0x040009B5 RID: 2485
	private Entity Entity;

	// Token: 0x040009B6 RID: 2486
	private CharacterActorComponent Character;

	// Token: 0x040009B7 RID: 2487
	private BaseMoveComponent MoveComp;

	// Token: 0x040009B8 RID: 2488
	private PawnChairController ChairController;

	// Token: 0x040009B9 RID: 2489
	private bool IsInitTsVariables;

	// Token: 0x040009BA RID: 2490
	private int TsChairEntityId;

	// Token: 0x040009BB RID: 2491
	private bool TsQuickFinish;

	// Token: 0x040009BC RID: 2492
	private Vector ChairNearbyPos;

	// Token: 0x040009BD RID: 2493
	private Vector ChairSitPos;

	// Token: 0x040009BE RID: 2494
	private Vector TempVec;

	// Token: 0x040009BF RID: 2495
	private Rotator TempRotator;

	// Token: 0x040009C0 RID: 2496
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcMoveToChair.TsTaskNpcMoveToChair_C";

	// Token: 0x040009C1 RID: 2497
	private static IntPtr _ClassPtr;

	// Token: 0x040009C2 RID: 2498
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040009C3 RID: 2499
	private static int __PropertyOffset_ChairEntityId;

	// Token: 0x040009C4 RID: 2500
	private static int __PropertyOffset_QuickFinish;

	// Token: 0x020071CB RID: 29131
	[NullableContext(0)]
	private enum ETaskPhase
	{
		// Token: 0x040279A3 RID: 162211
		None,
		// Token: 0x040279A4 RID: 162212
		Execute,
		// Token: 0x040279A5 RID: 162213
		MoveNearby,
		// Token: 0x040279A6 RID: 162214
		MoveClose,
		// Token: 0x040279A7 RID: 162215
		TurnTo,
		// Token: 0x040279A8 RID: 162216
		Finish
	}
}
