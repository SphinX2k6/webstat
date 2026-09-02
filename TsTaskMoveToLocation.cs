using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CC1 RID: 3265
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToLocation.TsTaskMoveToLocation_C")]
public class TsTaskMoveToLocation : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06003EB9 RID: 16057 RVA: 0x0005EF0F File Offset: 0x0005D10F
	// (set) Token: 0x06003EBA RID: 16058 RVA: 0x0005EF1F File Offset: 0x0005D11F
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06003EBB RID: 16059 RVA: 0x0005EF30 File Offset: 0x0005D130
	// (set) Token: 0x06003EBC RID: 16060 RVA: 0x0005EF40 File Offset: 0x0005D140
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NavigationOn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_NavigationOn) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_NavigationOn) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06003EBD RID: 16061 RVA: 0x0005EF51 File Offset: 0x0005D151
	// (set) Token: 0x06003EBE RID: 16062 RVA: 0x0005EF65 File Offset: 0x0005D165
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string BlackboardLocation
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskMoveToLocation.__PropertyOffset_BlackboardLocation)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskMoveToLocation.__PropertyOffset_BlackboardLocation)), value);
		}
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06003EBF RID: 16063 RVA: 0x0005EF7A File Offset: 0x0005D17A
	// (set) Token: 0x06003EC0 RID: 16064 RVA: 0x0005EF8A File Offset: 0x0005D18A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float EndDistance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_EndDistance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_EndDistance) = value;
		}
	}

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x06003EC1 RID: 16065 RVA: 0x0005EF9B File Offset: 0x0005D19B
	// (set) Token: 0x06003EC2 RID: 16066 RVA: 0x0005EFAB File Offset: 0x0005D1AB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06003EC3 RID: 16067 RVA: 0x0005EFBC File Offset: 0x0005D1BC
	// (set) Token: 0x06003EC4 RID: 16068 RVA: 0x0005EFCC File Offset: 0x0005D1CC
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool OpenDebugNode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_OpenDebugNode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_OpenDebugNode) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06003EC5 RID: 16069 RVA: 0x0005EFDD File Offset: 0x0005D1DD
	// (set) Token: 0x06003EC6 RID: 16070 RVA: 0x0005EFED File Offset: 0x0005D1ED
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LimitTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_LimitTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_LimitTime) = value;
		}
	}

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x06003EC7 RID: 16071 RVA: 0x0005EFFE File Offset: 0x0005D1FE
	// (set) Token: 0x06003EC8 RID: 16072 RVA: 0x0005F00E File Offset: 0x0005D20E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsFly
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_IsFly) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToLocation.__PropertyOffset_IsFly) = (value ? 1 : 0);
		}
	}

	// Token: 0x06003EC9 RID: 16073 RVA: 0x0005F020 File Offset: 0x0005D220
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveState = this.MoveState;
			this.TsNavigationOn = this.NavigationOn;
			this.TsBlackboardLocation = this.BlackboardLocation;
			this.TsOpenDebugNode = this.OpenDebugNode;
			this.TsLimitTime = (double)this.LimitTime;
			this.TsIsFly = this.IsFly;
		}
	}

	// Token: 0x06003ECA RID: 16074 RVA: 0x0005F08C File Offset: 0x0005D28C
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

	// Token: 0x06003ECB RID: 16075 RVA: 0x0005F128 File Offset: 0x0005D328
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
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Entity entity = charActorComp.Entity;
		global::Vector vector = global::Vector.Create();
		if (this.TsBlackboardLocation == "_currentPlayer")
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			global::Vector vector2;
			if (baseCharacter == null)
			{
				vector2 = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				vector2 = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
			}
			global::Vector vector3 = vector2;
			if (vector3 != null)
			{
				vector.DeepCopy(vector3);
			}
		}
		else
		{
			Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entity.Id, this.TsBlackboardLocation);
			if (vectorValueByEntity != null)
			{
				vector.DeepCopy(vectorValueByEntity);
			}
		}
		if (vector.IsNearlyZero(9.999999747378752E-05))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.LCZ;
			string message2 = "TsTaskMoveToLocation没有获取到目标坐标";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BehaviorTree", base.TreeAsset);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BlackboardLocation", this.TsBlackboardLocation);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			base.Finish(false);
			return;
		}
		if (this.HandleMoveEnd == null)
		{
			this.HandleMoveEnd = delegate(ELevelEventState result)
			{
				if (result == ELevelEventState.Success)
				{
					base.Finish(true);
					return;
				}
				base.Finish(false);
			};
		}
		this.MoveComp = entity.GetComponent<BaseMoveComponent>();
		MoveCharacterPoint moveCharacterPoint = new MoveCharacterPoint
		{
			Index = 0,
			Position = vector,
			MoveState = new EPatrolMoveState?((EPatrolMoveState)this.TsMoveState)
		};
		float scaledRadius = charActorComp.ScaledRadius;
		MoveCharacterConfig config = new MoveCharacterConfig
		{
			Points = new MoveCharacterPoint[]
			{
				moveCharacterPoint
			},
			Navigation = this.TsNavigationOn,
			IsFly = this.TsIsFly,
			DebugMode = this.TsOpenDebugNode,
			Loop = false,
			Callback = this.HandleMoveEnd,
			ReturnFalseWhenNavigationFailed = true,
			Distance = new float?(this.EndDistance + scaledRadius)
		};
		this.TsMoveHandleId = this.MoveComp.MoveAlongPath(config, "TsTaskMoveToLocation.ReceiveExecuteAI");
		if (this.TsLimitTime > -1.0)
		{
			this.EndTime = Singleton<Time>.Instance.WorldTime + this.TsLimitTime;
		}
	}

	// Token: 0x06003ECC RID: 16076 RVA: 0x0005F388 File Offset: 0x0005D588
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

	// Token: 0x06003ECD RID: 16077 RVA: 0x0005F428 File Offset: 0x0005D628
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			base.Finish(false);
			return;
		}
		if (this.TsLimitTime > -1.0 && this.EndTime < Singleton<Time>.Instance.WorldTime)
		{
			base.Finish(true);
		}
	}

	// Token: 0x06003ECE RID: 16078 RVA: 0x0005F464 File Offset: 0x0005D664
	protected override void OnClear()
	{
		if (this.MoveComp != null)
		{
			this.MoveComp.StopMoveByHandleId(this.TsMoveHandleId, "TsTaskMoveToLocation.OnClear");
			this.MoveComp = null;
		}
		this.EndTime = 0.0;
	}

	// Token: 0x06003ECF RID: 16079 RVA: 0x0005F49A File Offset: 0x0005D69A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskMoveToLocation._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToLocation.TsTaskMoveToLocation_C");
		}
		return TsTaskMoveToLocation._ClassPtr;
	}

	// Token: 0x06003ED0 RID: 16080 RVA: 0x0005F4C0 File Offset: 0x0005D6C0
	public TsTaskMoveToLocation() : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToLocation.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003ED1 RID: 16081 RVA: 0x0005F4E8 File Offset: 0x0005D6E8
	public TsTaskMoveToLocation(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003ED2 RID: 16082 RVA: 0x0005F51B File Offset: 0x0005D71B
	protected TsTaskMoveToLocation(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003ED3 RID: 16083 RVA: 0x0005F530 File Offset: 0x0005D730
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003ED4 RID: 16084 RVA: 0x0005F560 File Offset: 0x0005D760
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000D99 RID: 3481
	private const string CURRENT_PLAYER = "_currentPlayer";

	// Token: 0x04000D9A RID: 3482
	private bool IsInitTsVariables;

	// Token: 0x04000D9B RID: 3483
	private int TsMoveState;

	// Token: 0x04000D9C RID: 3484
	private bool TsNavigationOn;

	// Token: 0x04000D9D RID: 3485
	private string TsBlackboardLocation = "";

	// Token: 0x04000D9E RID: 3486
	private bool TsOpenDebugNode;

	// Token: 0x04000D9F RID: 3487
	private double TsLimitTime;

	// Token: 0x04000DA0 RID: 3488
	private bool TsIsFly;

	// Token: 0x04000DA1 RID: 3489
	private double EndTime;

	// Token: 0x04000DA2 RID: 3490
	[Nullable(2)]
	private BaseMoveComponent MoveComp;

	// Token: 0x04000DA3 RID: 3491
	private int TsMoveHandleId;

	// Token: 0x04000DA4 RID: 3492
	[Nullable(2)]
	private Action<ELevelEventState> HandleMoveEnd;

	// Token: 0x04000DA5 RID: 3493
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskMoveToLocation.TsTaskMoveToLocation_C";

	// Token: 0x04000DA6 RID: 3494
	private static IntPtr _ClassPtr;

	// Token: 0x04000DA7 RID: 3495
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000DA8 RID: 3496
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000DA9 RID: 3497
	private static int __PropertyOffset_NavigationOn;

	// Token: 0x04000DAA RID: 3498
	private static int __PropertyOffset_BlackboardLocation;

	// Token: 0x04000DAB RID: 3499
	private static int __PropertyOffset_EndDistance;

	// Token: 0x04000DAC RID: 3500
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000DAD RID: 3501
	private static int __PropertyOffset_OpenDebugNode;

	// Token: 0x04000DAE RID: 3502
	private static int __PropertyOffset_LimitTime;

	// Token: 0x04000DAF RID: 3503
	private static int __PropertyOffset_IsFly;
}
