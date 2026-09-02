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

// Token: 0x02000C86 RID: 3206
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChairAndLeave.TsTaskNpcSitOnChairAndLeave_C")]
public class TsTaskNpcSitOnChairAndLeave : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06003A5E RID: 14942 RVA: 0x000475B3 File Offset: 0x000457B3
	// (set) Token: 0x06003A5F RID: 14943 RVA: 0x000475C3 File Offset: 0x000457C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int ChairEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_ChairEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_ChairEntityId) = value;
		}
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06003A60 RID: 14944 RVA: 0x000475D4 File Offset: 0x000457D4
	// (set) Token: 0x06003A61 RID: 14945 RVA: 0x000475E8 File Offset: 0x000457E8
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string MontagePath
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_MontagePath)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_MontagePath)), value);
		}
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06003A62 RID: 14946 RVA: 0x000475FD File Offset: 0x000457FD
	// (set) Token: 0x06003A63 RID: 14947 RVA: 0x0004760D File Offset: 0x0004580D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float LoopDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_LoopDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_LoopDuration) = value;
		}
	}

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06003A64 RID: 14948 RVA: 0x0004761E File Offset: 0x0004581E
	// (set) Token: 0x06003A65 RID: 14949 RVA: 0x0004762E File Offset: 0x0004582E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int RepeatTimes
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_RepeatTimes);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_RepeatTimes) = value;
		}
	}

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06003A66 RID: 14950 RVA: 0x0004763F File Offset: 0x0004583F
	// (set) Token: 0x06003A67 RID: 14951 RVA: 0x0004764F File Offset: 0x0004584F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool EndOnBlendOut
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_EndOnBlendOut) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_EndOnBlendOut) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06003A68 RID: 14952 RVA: 0x00047660 File Offset: 0x00045860
	// (set) Token: 0x06003A69 RID: 14953 RVA: 0x00047670 File Offset: 0x00045870
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool SkipLeave
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_SkipLeave) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskNpcSitOnChairAndLeave.__PropertyOffset_SkipLeave) = (value ? 1 : 0);
		}
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06003A6A RID: 14954 RVA: 0x00047681 File Offset: 0x00045881
	// (set) Token: 0x06003A6B RID: 14955 RVA: 0x00047689 File Offset: 0x00045889
	private TsTaskNpcSitOnChairAndLeave.ETaskPhase Phase
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

	// Token: 0x06003A6C RID: 14956 RVA: 0x0004769C File Offset: 0x0004589C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsChairEntityId = this.ChairEntityId;
			this.TsMontagePath = this.MontagePath;
			this.TsLoopDuration = this.LoopDuration;
			this.TsRepeatTimes = this.RepeatTimes;
			this.TsEndOnBlendOut = this.EndOnBlendOut;
			this.TsSkipLeave = this.SkipLeave;
			this.ChairNearbyPos = Vector.Create();
			this.ChairSitPos = Vector.Create();
		}
	}

	// Token: 0x06003A6D RID: 14957 RVA: 0x00047720 File Offset: 0x00045920
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
			string message2 = "[TsTaskNpcSitOnChairAndLeave]MoveComp不合法";
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
			string message3 = "[TsTaskNpcSitOnChairAndLeave]无效的Montage路径";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("PbDataId", this.Character.CreatureData.GetPbDataId());
			instance3.Error(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			base.FinishExecute(true);
			return;
		}
		this.ChairController.Possess(this.Entity, false);
		this.ChairController.IgnoreCollision();
		this.IsPossessed = true;
		Vector actorLocationProxy = this.Character.ActorLocationProxy;
		Vector sitLocation = this.ChairController.GetSitLocation();
		this.ChairSitPos.Set(sitLocation.X, sitLocation.Y, actorLocationProxy.Z);
		this.ChairController.GetForwardDirection().Multiply(70.0, this.ChairNearbyPos);
		this.ChairNearbyPos.AdditionEqual(sitLocation);
		this.Phase = TsTaskNpcSitOnChairAndLeave.ETaskPhase.Execute;
	}

	// Token: 0x06003A6E RID: 14958 RVA: 0x000479FC File Offset: 0x00045BFC
	[UFunction(EFunctionFlags.FUNC_None)]
	public override void ReceiveTickAI(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		switch (this.Phase)
		{
		case TsTaskNpcSitOnChairAndLeave.ETaskPhase.Execute:
			this.Phase = TsTaskNpcSitOnChairAndLeave.ETaskPhase.PlayMontage;
			return;
		case TsTaskNpcSitOnChairAndLeave.ETaskPhase.PlayMontage:
			this.ExecutePlayMontage();
			return;
		case TsTaskNpcSitOnChairAndLeave.ETaskPhase.MoveAway:
			this.ExecuteMoveAway();
			return;
		case TsTaskNpcSitOnChairAndLeave.ETaskPhase.Finish:
			this.ReleaseChair();
			base.Finish(true);
			return;
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.YJX;
			string message = "[TsTaskNpcSitOnChairAndLeave] 阶段切换出错";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("CurPhase", this.Phase);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		}
	}

	// Token: 0x06003A6F RID: 14959 RVA: 0x00047A80 File Offset: 0x00045C80
	protected override void OnAbort()
	{
		if (this.Phase == TsTaskNpcSitOnChairAndLeave.ETaskPhase.MoveAway)
		{
			BaseMoveComponent moveComp = this.MoveComp;
			if (moveComp != null)
			{
				moveComp.StopMoveNew(null);
			}
		}
		else if (this.Phase == TsTaskNpcSitOnChairAndLeave.ETaskPhase.PlayMontage)
		{
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
		this.ReleaseChair();
	}

	// Token: 0x06003A70 RID: 14960 RVA: 0x00047AED File Offset: 0x00045CED
	protected override void OnClear()
	{
		this.Character = null;
		this.IsExecutePlayMontage = false;
		this.IsExecuteMoveAway = false;
	}

	// Token: 0x06003A71 RID: 14961 RVA: 0x00047B04 File Offset: 0x00045D04
	private void ReleaseChair()
	{
		if (this.IsPossessed && this.ChairController != null)
		{
			this.ChairController.ResetCollision();
			this.ChairController.UnPossess(this.Entity);
			this.IsPossessed = false;
		}
	}

	// Token: 0x06003A72 RID: 14962 RVA: 0x00047B3C File Offset: 0x00045D3C
	private void ExecutePlayMontage()
	{
		if (this.IsExecutePlayMontage)
		{
			return;
		}
		this.IsExecutePlayMontage = true;
		CharacterAnimationComponent animComp = this.AnimComp;
		if (animComp != null)
		{
			animComp.SetLocationAndRotatorWithModelBuffer(this.ChairSitPos.ToUeVector(false), this.Character.ActorRotationProxy.ToUeRotator(), 200f, "TsTaskNpcSitOnChairAndLeave.ExecutePlayMontage", ESetRotationPriority.Anim, true);
		}
		BasePerformComponent component = this.Entity.GetComponent<BasePerformComponent>();
		this.PlayingMontage = component.VolatileMontagePlayByLoad(EPerformMode.Ecology, this.TsMontagePath, null, null, delegate(UAnimMontage montage, bool _)
		{
			if (montage != null)
			{
				this.Phase = (this.TsSkipLeave ? TsTaskNpcSitOnChairAndLeave.ETaskPhase.Finish : TsTaskNpcSitOnChairAndLeave.ETaskPhase.MoveAway);
				return;
			}
			base.FinishExecute(true);
		}, new float?(this.TsLoopDuration), new float?((float)this.TsRepeatTimes), new bool?(false), new bool?(false), new bool?(this.TsEndOnBlendOut));
	}

	// Token: 0x06003A73 RID: 14963 RVA: 0x00047BF0 File Offset: 0x00045DF0
	private void ExecuteMoveAway()
	{
		if (this.IsExecuteMoveAway)
		{
			return;
		}
		this.IsExecuteMoveAway = true;
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
				this.Phase = TsTaskNpcSitOnChairAndLeave.ETaskPhase.Finish;
			},
			ReturnFalseWhenNavigationFailed = false
		};
		this.MoveComp.MoveAlongPath(config, null);
	}

	// Token: 0x06003A74 RID: 14964 RVA: 0x00047CAF File Offset: 0x00045EAF
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskNpcSitOnChairAndLeave._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChairAndLeave.TsTaskNpcSitOnChairAndLeave_C");
		}
		return TsTaskNpcSitOnChairAndLeave._ClassPtr;
	}

	// Token: 0x06003A75 RID: 14965 RVA: 0x00047CD4 File Offset: 0x00045ED4
	public TsTaskNpcSitOnChairAndLeave() : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSitOnChairAndLeave.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A76 RID: 14966 RVA: 0x00047CFC File Offset: 0x00045EFC
	[NullableContext(1)]
	public TsTaskNpcSitOnChairAndLeave(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcSitOnChairAndLeave.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A77 RID: 14967 RVA: 0x00047D2F File Offset: 0x00045F2F
	protected TsTaskNpcSitOnChairAndLeave(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A78 RID: 14968 RVA: 0x00047D4C File Offset: 0x00045F4C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003A79 RID: 14969 RVA: 0x00047D7C File Offset: 0x00045F7C
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040009E9 RID: 2537
	private const int NEARBY_CHAIR_OFFSET = 70;

	// Token: 0x040009EA RID: 2538
	private const int MOVE_TO_CHAIR_SPEED = 70;

	// Token: 0x040009EB RID: 2539
	private const int MOVE_TO_CHAIR_DISTANCE_TOLERANCE = 5;

	// Token: 0x040009EC RID: 2540
	private const int MODEL_BUFFER_SMOOTH_TIME = 200;

	// Token: 0x040009ED RID: 2541
	private int PlayingMontage = -1;

	// Token: 0x040009EE RID: 2542
	private TsTaskNpcSitOnChairAndLeave.ETaskPhase PhaseInternal;

	// Token: 0x040009EF RID: 2543
	private bool IsExecutePlayMontage;

	// Token: 0x040009F0 RID: 2544
	private bool IsExecuteMoveAway;

	// Token: 0x040009F1 RID: 2545
	private bool IsPossessed;

	// Token: 0x040009F2 RID: 2546
	private Entity Entity;

	// Token: 0x040009F3 RID: 2547
	private CharacterActorComponent Character;

	// Token: 0x040009F4 RID: 2548
	private BaseMoveComponent MoveComp;

	// Token: 0x040009F5 RID: 2549
	private CharacterAnimationComponent AnimComp;

	// Token: 0x040009F6 RID: 2550
	private PawnChairController ChairController;

	// Token: 0x040009F7 RID: 2551
	private bool IsInitTsVariables;

	// Token: 0x040009F8 RID: 2552
	private int TsChairEntityId;

	// Token: 0x040009F9 RID: 2553
	[Nullable(1)]
	private string TsMontagePath = "";

	// Token: 0x040009FA RID: 2554
	private float TsLoopDuration;

	// Token: 0x040009FB RID: 2555
	private int TsRepeatTimes;

	// Token: 0x040009FC RID: 2556
	private bool TsEndOnBlendOut;

	// Token: 0x040009FD RID: 2557
	private bool TsSkipLeave;

	// Token: 0x040009FE RID: 2558
	private Vector ChairNearbyPos;

	// Token: 0x040009FF RID: 2559
	private Vector ChairSitPos;

	// Token: 0x04000A00 RID: 2560
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskNpcSitOnChairAndLeave.TsTaskNpcSitOnChairAndLeave_C";

	// Token: 0x04000A01 RID: 2561
	private static IntPtr _ClassPtr;

	// Token: 0x04000A02 RID: 2562
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000A03 RID: 2563
	private static int __PropertyOffset_ChairEntityId;

	// Token: 0x04000A04 RID: 2564
	private static int __PropertyOffset_MontagePath;

	// Token: 0x04000A05 RID: 2565
	private static int __PropertyOffset_LoopDuration;

	// Token: 0x04000A06 RID: 2566
	private static int __PropertyOffset_RepeatTimes;

	// Token: 0x04000A07 RID: 2567
	private static int __PropertyOffset_EndOnBlendOut;

	// Token: 0x04000A08 RID: 2568
	private static int __PropertyOffset_SkipLeave;

	// Token: 0x020071CD RID: 29133
	[NullableContext(0)]
	private enum ETaskPhase
	{
		// Token: 0x040279B3 RID: 162227
		None,
		// Token: 0x040279B4 RID: 162228
		Execute,
		// Token: 0x040279B5 RID: 162229
		PlayMontage,
		// Token: 0x040279B6 RID: 162230
		MoveAway,
		// Token: 0x040279B7 RID: 162231
		Finish
	}
}
