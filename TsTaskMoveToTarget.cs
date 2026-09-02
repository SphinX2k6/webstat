using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.LevelGamePlay;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C81 RID: 3201
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskMoveToTarget.TsTaskMoveToTarget_C")]
public class TsTaskMoveToTarget : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000184 RID: 388
	// (get) Token: 0x060039EC RID: 14828 RVA: 0x0004512B File Offset: 0x0004332B
	// (set) Token: 0x060039ED RID: 14829 RVA: 0x0004513B File Offset: 0x0004333B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_MoveMode);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_MoveMode) = value;
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x060039EE RID: 14830 RVA: 0x0004514C File Offset: 0x0004334C
	// (set) Token: 0x060039EF RID: 14831 RVA: 0x0004515C File Offset: 0x0004335C
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int MoveState
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_MoveState);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_MoveState) = value;
		}
	}

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x060039F0 RID: 14832 RVA: 0x0004516D File Offset: 0x0004336D
	// (set) Token: 0x060039F1 RID: 14833 RVA: 0x0004517D File Offset: 0x0004337D
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsFollow
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_IsFollow) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_IsFollow) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x060039F2 RID: 14834 RVA: 0x0004518E File Offset: 0x0004338E
	// (set) Token: 0x060039F3 RID: 14835 RVA: 0x0004519E File Offset: 0x0004339E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int TargetEntityId
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_TargetEntityId);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_TargetEntityId) = value;
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x060039F4 RID: 14836 RVA: 0x000451AF File Offset: 0x000433AF
	// (set) Token: 0x060039F5 RID: 14837 RVA: 0x000451C3 File Offset: 0x000433C3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe FVector TargetPos
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_TargetPos);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_TargetPos) = value;
		}
	}

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x060039F6 RID: 14838 RVA: 0x000451D8 File Offset: 0x000433D8
	// (set) Token: 0x060039F7 RID: 14839 RVA: 0x000451E8 File Offset: 0x000433E8
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool IsFly
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_IsFly) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_IsFly) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700018A RID: 394
	// (get) Token: 0x060039F8 RID: 14840 RVA: 0x000451F9 File Offset: 0x000433F9
	// (set) Token: 0x060039F9 RID: 14841 RVA: 0x00045209 File Offset: 0x00043409
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int Distance
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_Distance);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskMoveToTarget.__PropertyOffset_Distance) = value;
		}
	}

	// Token: 0x060039FA RID: 14842 RVA: 0x0004521C File Offset: 0x0004341C
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMoveMode = this.MoveMode;
			this.TsMoveState = this.MoveState;
			this.TsIsFollow = this.IsFollow;
			this.TsIsFly = this.IsFly;
			this.TsDistance = this.Distance;
			this.TsTargetEntityId = this.TargetEntityId;
			this.TsTargetPos = Vector.Create((double)this.TargetPos.X, (double)this.TargetPos.Y, (double)this.TargetPos.Z);
			this.LastLocation = Vector.Create();
			this.TargetLocation = Vector.Create();
			this.TmpVector = Vector.Create();
		}
	}

	// Token: 0x060039FB RID: 14843 RVA: 0x000452DC File Offset: 0x000434DC
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

	// Token: 0x060039FC RID: 14844 RVA: 0x00045378 File Offset: 0x00043578
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
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
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Entity entity = charActorComp.Entity;
		this.MoveComp = entity.GetComponent<BaseMoveComponent>();
		if (!this.GetMoveToTargetPosition(this.TargetLocation))
		{
			base.FinishExecute(true);
			return;
		}
		if (!this.TryFindPathToTarget(this.TargetLocation))
		{
			base.Finish(true);
			return;
		}
		this.LastTime = Singleton<Time>.Instance.WorldTime;
		Vector lastLocation = this.LastLocation;
		if (lastLocation != null)
		{
			lastLocation.Reset();
		}
		Vector lastLocation2 = this.LastLocation;
		if (lastLocation2 == null)
		{
			return;
		}
		lastLocation2.DeepCopy(charActorComp.ActorLocationProxy);
	}

	// Token: 0x060039FD RID: 14845 RVA: 0x0004545C File Offset: 0x0004365C
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

	// Token: 0x060039FE RID: 14846 RVA: 0x000454FC File Offset: 0x000436FC
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			base.Finish(true);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (this.CheckMoveFailed(charActorComp, deltaSeconds))
		{
			base.Finish(true);
			return;
		}
		if (this.TsIsFollow)
		{
			if (!this.GetMoveToTargetPosition(this.TmpVector))
			{
				base.Finish(true);
				return;
			}
			if (Vector.DistSquared(this.TmpVector, this.TargetLocation) > (double)(this.TsDistance * this.TsDistance))
			{
				if (!this.TryFindPathToTarget(this.TmpVector))
				{
					base.Finish(true);
					return;
				}
				this.TargetLocation.DeepCopy(this.TmpVector);
			}
		}
	}

	// Token: 0x060039FF RID: 14847 RVA: 0x000455A8 File Offset: 0x000437A8
	protected override void OnClear()
	{
		if (this.MoveComp != null)
		{
			this.MoveComp.StopMoveNew("TsTaskMoveToTarget.OnClear");
			this.MoveComp = null;
		}
		this.LastTime = 0.0;
		this.MoveFailedCountDown = 0.0;
		Vector lastLocation = this.LastLocation;
		if (lastLocation != null)
		{
			lastLocation.Reset();
		}
		Vector targetLocation = this.TargetLocation;
		if (targetLocation == null)
		{
			return;
		}
		targetLocation.Reset();
	}

	// Token: 0x06003A00 RID: 14848 RVA: 0x00045614 File Offset: 0x00043814
	[NullableContext(1)]
	private bool CheckMoveFailed(CharacterActorComponent character, float deltaTime)
	{
		double num = Vector.Dist(character.ActorLocationProxy, this.LastLocation);
		if ((Singleton<Time>.Instance.WorldTime - this.LastTime) * 0.0010000000474974513 * 20.0 >= num)
		{
			this.MoveFailedCountDown += (double)deltaTime;
			if (this.MoveFailedCountDown >= 5.0)
			{
				character.SetActorLocation(this.TargetLocation.ToUeVector(false), "[TsTaskMoveToLocation]长时间处于某点", false);
				return true;
			}
		}
		else
		{
			this.MoveFailedCountDown = 0.0;
		}
		this.LastTime = Singleton<Time>.Instance.WorldTime;
		this.LastLocation.DeepCopy(character.ActorLocationProxy);
		return false;
	}

	// Token: 0x06003A01 RID: 14849 RVA: 0x000456C8 File Offset: 0x000438C8
	[NullableContext(1)]
	private bool TryFindPathToTarget(Vector target)
	{
		if (this.MoveComp == null)
		{
			return false;
		}
		Action<ELevelEventState> item = delegate(ELevelEventState _)
		{
			base.Finish(true);
		};
		MoveToLocationController moveController = this.MoveComp.MoveController;
		MoveToPointConfigImpl moveToPointConfigImpl = new MoveToPointConfigImpl();
		moveToPointConfigImpl.Position = target;
		moveToPointConfigImpl.MoveState = new ECharMoveState?(this.ConvertToCharMoveState(this.TsMoveState));
		moveToPointConfigImpl.IsFly = new bool?(this.TsIsFly);
		moveToPointConfigImpl.Distance = new double?((double)this.TsDistance);
		moveToPointConfigImpl.UseNearestDirection = new bool?(false);
		moveToPointConfigImpl.CallbackList = new List<Action<ELevelEventState>>
		{
			item
		};
		moveToPointConfigImpl.ResetCondition = (() => false);
		return moveController.NavigateMoveToLocation(moveToPointConfigImpl, new bool?(true), false, "TsTaskMoveToTarget.TryFindPathToTarget");
	}

	// Token: 0x06003A02 RID: 14850 RVA: 0x00045791 File Offset: 0x00043991
	private ECharMoveState ConvertToCharMoveState(int state)
	{
		if (state == 1)
		{
			return ECharMoveState.Walk;
		}
		if (state != 2)
		{
			return ECharMoveState.Walk;
		}
		return ECharMoveState.Run;
	}

	// Token: 0x06003A03 RID: 14851 RVA: 0x000457A4 File Offset: 0x000439A4
	[NullableContext(1)]
	private bool GetMoveToTargetPosition(Vector outPosition)
	{
		switch (this.TsMoveMode)
		{
		case 1:
			outPosition.DeepCopy(this.TsTargetPos);
			break;
		case 2:
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null || !baseCharacter.IsValid())
			{
				return false;
			}
			outPosition.DeepCopy(baseCharacter.CharacterActorComponent.ActorLocationProxy);
			break;
		}
		case 3:
		{
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntityByPbDataId(this.TsTargetEntityId) : null;
			if (entityHandle == null || !entityHandle.Valid)
			{
				return false;
			}
			BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
			outPosition.DeepCopy(component.ActorLocationProxy);
			break;
		}
		default:
			return false;
		}
		return true;
	}

	// Token: 0x06003A04 RID: 14852 RVA: 0x00045850 File Offset: 0x00043A50
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskMoveToTarget._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskMoveToTarget.TsTaskMoveToTarget_C");
		}
		return TsTaskMoveToTarget._ClassPtr;
	}

	// Token: 0x06003A05 RID: 14853 RVA: 0x00045874 File Offset: 0x00043A74
	public TsTaskMoveToTarget() : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToTarget.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003A06 RID: 14854 RVA: 0x0004589C File Offset: 0x00043A9C
	[NullableContext(1)]
	public TsTaskMoveToTarget(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003A07 RID: 14855 RVA: 0x000458CF File Offset: 0x00043ACF
	protected TsTaskMoveToTarget(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003A08 RID: 14856 RVA: 0x000458D8 File Offset: 0x00043AD8
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003A09 RID: 14857 RVA: 0x00045908 File Offset: 0x00043B08
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x0400097C RID: 2428
	private const int MIN_MOVE_SPEED = 20;

	// Token: 0x0400097D RID: 2429
	private const int MOVE_FAILED_TIME = 5;

	// Token: 0x0400097E RID: 2430
	private const int MIN_ARRIVE_DISTANCE_TOLERANCE = 30;

	// Token: 0x0400097F RID: 2431
	private bool IsInitTsVariables;

	// Token: 0x04000980 RID: 2432
	private int TsMoveMode;

	// Token: 0x04000981 RID: 2433
	private int TsMoveState;

	// Token: 0x04000982 RID: 2434
	private bool TsIsFollow;

	// Token: 0x04000983 RID: 2435
	private bool TsIsFly;

	// Token: 0x04000984 RID: 2436
	private int TsTargetEntityId;

	// Token: 0x04000985 RID: 2437
	private Vector TsTargetPos;

	// Token: 0x04000986 RID: 2438
	private int TsDistance;

	// Token: 0x04000987 RID: 2439
	private BaseMoveComponent MoveComp;

	// Token: 0x04000988 RID: 2440
	private Vector LastLocation;

	// Token: 0x04000989 RID: 2441
	private Vector TargetLocation;

	// Token: 0x0400098A RID: 2442
	private Vector TmpVector;

	// Token: 0x0400098B RID: 2443
	private double LastTime;

	// Token: 0x0400098C RID: 2444
	private double MoveFailedCountDown;

	// Token: 0x0400098D RID: 2445
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/NPC/LevelAiTask/TsTaskMoveToTarget.TsTaskMoveToTarget_C";

	// Token: 0x0400098E RID: 2446
	private static IntPtr _ClassPtr;

	// Token: 0x0400098F RID: 2447
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000990 RID: 2448
	private static int __PropertyOffset_MoveMode;

	// Token: 0x04000991 RID: 2449
	private static int __PropertyOffset_MoveState;

	// Token: 0x04000992 RID: 2450
	private static int __PropertyOffset_IsFollow;

	// Token: 0x04000993 RID: 2451
	private static int __PropertyOffset_TargetEntityId;

	// Token: 0x04000994 RID: 2452
	private static int __PropertyOffset_TargetPos;

	// Token: 0x04000995 RID: 2453
	private static int __PropertyOffset_IsFly;

	// Token: 0x04000996 RID: 2454
	private static int __PropertyOffset_Distance;
}
