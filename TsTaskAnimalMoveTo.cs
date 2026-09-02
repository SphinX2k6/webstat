using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C72 RID: 3186
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalMoveTo.TsTaskAnimalMoveTo_C")]
public class TsTaskAnimalMoveTo : TsTaskAbortImmediatelyBase, IStaticVariableResetter, IUnrealUObject, IUnrealObject
{
	// Token: 0x060038FD RID: 14589 RVA: 0x00040239 File Offset: 0x0003E439
	static TsTaskAnimalMoveTo()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TsTaskAnimalMoveTo.CreateStaticDefaultValue), new Action(TsTaskAnimalMoveTo.ResetStaticDefaultValue));
	}

	// Token: 0x060038FE RID: 14590 RVA: 0x00040258 File Offset: 0x0003E458
	public static void CreateStaticDefaultValue()
	{
		TsTaskAnimalMoveTo.AnimalValidMoveState = new HashSet<global::ECharMoveState>();
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.Walk);
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.Run);
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.NormalSwim);
		TsTaskAnimalMoveTo.StaticVariablesInited = true;
	}

	// Token: 0x060038FF RID: 14591 RVA: 0x0004028F File Offset: 0x0003E48F
	public static void ResetStaticDefaultValue()
	{
		TsTaskAnimalMoveTo.StaticVariablesInited = false;
		TsTaskAnimalMoveTo.AnimalValidMoveState = null;
	}

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x06003900 RID: 14592 RVA: 0x0004029D File Offset: 0x0003E49D
	// (set) Token: 0x06003901 RID: 14593 RVA: 0x000402AD File Offset: 0x0003E4AD
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe ECharState MoveState
	{
		get
		{
			return (ECharState)(*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_MoveState));
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_MoveState) = (byte)value;
		}
	}

	// Token: 0x1700015D RID: 349
	// (get) Token: 0x06003902 RID: 14594 RVA: 0x000402BE File Offset: 0x0003E4BE
	// (set) Token: 0x06003903 RID: 14595 RVA: 0x000402CE File Offset: 0x0003E4CE
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool NavigationOn
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_NavigationOn) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_NavigationOn) = (value ? 1 : 0);
		}
	}

	// Token: 0x1700015E RID: 350
	// (get) Token: 0x06003904 RID: 14596 RVA: 0x000402DF File Offset: 0x0003E4DF
	// (set) Token: 0x06003905 RID: 14597 RVA: 0x000402F3 File Offset: 0x0003E4F3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string TargetLocation
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_TargetLocation)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_TargetLocation)), value);
		}
	}

	// Token: 0x1700015F RID: 351
	// (get) Token: 0x06003906 RID: 14598 RVA: 0x00040308 File Offset: 0x0003E508
	// (set) Token: 0x06003907 RID: 14599 RVA: 0x00040318 File Offset: 0x0003E518
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x17000160 RID: 352
	// (get) Token: 0x06003908 RID: 14600 RVA: 0x00040329 File Offset: 0x0003E529
	// (set) Token: 0x06003909 RID: 14601 RVA: 0x00040339 File Offset: 0x0003E539
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int LimitTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_LimitTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_LimitTime) = value;
		}
	}

	// Token: 0x17000161 RID: 353
	// (get) Token: 0x0600390A RID: 14602 RVA: 0x0004034A File Offset: 0x0003E54A
	// (set) Token: 0x0600390B RID: 14603 RVA: 0x0004035A File Offset: 0x0003E55A
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool RootMotion
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_RootMotion) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_RootMotion) = (value ? 1 : 0);
		}
	}

	// Token: 0x17000162 RID: 354
	// (get) Token: 0x0600390C RID: 14604 RVA: 0x0004036B File Offset: 0x0003E56B
	// (set) Token: 0x0600390D RID: 14605 RVA: 0x0004037B File Offset: 0x0003E57B
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe int DistanceErrorThreshold
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_DistanceErrorThreshold);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskAnimalMoveTo.__PropertyOffset_DistanceErrorThreshold) = value;
		}
	}

	// Token: 0x0600390E RID: 14606 RVA: 0x0004038C File Offset: 0x0003E58C
	private static void InitStaticVariables()
	{
		TsTaskAnimalMoveTo.AnimalValidMoveState = new HashSet<global::ECharMoveState>();
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.Walk);
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.Run);
		TsTaskAnimalMoveTo.AnimalValidMoveState.Add(global::ECharMoveState.NormalSwim);
		TsTaskAnimalMoveTo.StaticVariablesInited = true;
	}

	// Token: 0x0600390F RID: 14607 RVA: 0x000403C4 File Offset: 0x0003E5C4
	private void InitTsVariables(Entity entity)
	{
		if (!this.IsInitTsVariables)
		{
			this.TsMoveState = (global::ECharMoveState)this.MoveState;
			this.TsNavigationOn = this.NavigationOn;
			this.TsTargetLocation = this.TargetLocation;
			this.TsLimitTime = (double)(this.LimitTime * Singleton<TimeUtil>.Instance.InverseMillisecond);
			this.TsTurnSpeed = this.TurnSpeed;
			this.TargetCache = global::Vector.Create();
			this.TsRootMotion = this.RootMotion;
			this.TsDistanceErrorThreshold = ((this.TsMoveState == global::ECharMoveState.NormalSwim) ? ((float)this.DistanceErrorThreshold) : ((float)Math.Max(100, this.DistanceErrorThreshold)));
			this.IsInitTsVariables = true;
		}
	}

	// Token: 0x06003910 RID: 14608 RVA: 0x0004046C File Offset: 0x0003E66C
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

	// Token: 0x06003911 RID: 14609 RVA: 0x00040508 File Offset: 0x0003E708
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		if (!TsTaskAnimalMoveTo.StaticVariablesInited)
		{
			TsTaskAnimalMoveTo.InitStaticVariables();
		}
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			base.FinishExecute(false);
			return;
		}
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		Entity entity = (charActorComp != null) ? charActorComp.Entity : null;
		if (entity == null || !entity.Valid)
		{
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables(entity);
		if (!TsTaskAnimalMoveTo.AnimalValidMoveState.Contains(this.TsMoveState))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.CJH;
			string message2 = "错误的移动状态";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.FinishExecute(false);
			return;
		}
		Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(entity.Id, this.TsTargetLocation);
		this.TargetCache.DeepCopy(vectorValueByEntity);
		this.AnimalMoveToController = new AnimalMoveToController(entity);
		this.AnimalMoveToController.Init(this.TsMoveState, this.TsRootMotion);
		this.AnimalMoveToController.Start(this.TargetCache, this.TsNavigationOn, this.TsTurnSpeed, (double)this.TsDistanceErrorThreshold);
		this.EndTime = double.MaxValue;
		if (this.TsLimitTime > 0.0)
		{
			this.EndTime = Singleton<Time>.Instance.WorldTime + this.TsLimitTime;
		}
	}

	// Token: 0x06003912 RID: 14610 RVA: 0x00040698 File Offset: 0x0003E898
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

	// Token: 0x06003913 RID: 14611 RVA: 0x00040738 File Offset: 0x0003E938
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (this.TsLimitTime > 0.0 && this.EndTime < Singleton<Time>.Instance.WorldTime)
		{
			this.AnimalMoveToController.Stop();
			base.Finish(true);
			return;
		}
		EAnimalMoveToState eanimalMoveToState = this.AnimalMoveToController.Update(deltaSeconds);
		if (eanimalMoveToState == EAnimalMoveToState.Success)
		{
			base.Finish(true);
			return;
		}
		if (eanimalMoveToState != EAnimalMoveToState.Failure)
		{
			return;
		}
		base.Finish(false);
	}

	// Token: 0x06003914 RID: 14612 RVA: 0x000407A0 File Offset: 0x0003E9A0
	protected override void OnClear()
	{
		AnimalMoveToController animalMoveToController = this.AnimalMoveToController;
		if (animalMoveToController != null)
		{
			animalMoveToController.Finish();
		}
		this.AnimalMoveToController = null;
	}

	// Token: 0x06003915 RID: 14613 RVA: 0x000407BA File Offset: 0x0003E9BA
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskAnimalMoveTo._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalMoveTo.TsTaskAnimalMoveTo_C");
		}
		return TsTaskAnimalMoveTo._ClassPtr;
	}

	// Token: 0x06003916 RID: 14614 RVA: 0x000407E0 File Offset: 0x0003E9E0
	public TsTaskAnimalMoveTo() : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalMoveTo.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003917 RID: 14615 RVA: 0x00040808 File Offset: 0x0003EA08
	public TsTaskAnimalMoveTo(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAnimalMoveTo.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003918 RID: 14616 RVA: 0x0004083B File Offset: 0x0003EA3B
	protected TsTaskAnimalMoveTo(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003919 RID: 14617 RVA: 0x00040858 File Offset: 0x0003EA58
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x0600391A RID: 14618 RVA: 0x00040888 File Offset: 0x0003EA88
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x040008C2 RID: 2242
	private const int DEFAULT_DISTANCE_ERROR_THRESHOLD = 100;

	// Token: 0x040008C3 RID: 2243
	private bool IsInitTsVariables;

	// Token: 0x040008C4 RID: 2244
	private double TsLimitTime;

	// Token: 0x040008C5 RID: 2245
	private float TsTurnSpeed;

	// Token: 0x040008C6 RID: 2246
	private global::ECharMoveState TsMoveState = global::ECharMoveState.Walk;

	// Token: 0x040008C7 RID: 2247
	private bool TsNavigationOn;

	// Token: 0x040008C8 RID: 2248
	private string TsTargetLocation = "";

	// Token: 0x040008C9 RID: 2249
	private bool TsRootMotion;

	// Token: 0x040008CA RID: 2250
	private float TsDistanceErrorThreshold;

	// Token: 0x040008CB RID: 2251
	[Nullable(2)]
	private AnimalMoveToController AnimalMoveToController;

	// Token: 0x040008CC RID: 2252
	[Nullable(2)]
	private global::Vector TargetCache;

	// Token: 0x040008CD RID: 2253
	private double EndTime;

	// Token: 0x040008CE RID: 2254
	private static bool StaticVariablesInited;

	// Token: 0x040008CF RID: 2255
	[Nullable(2)]
	private static HashSet<global::ECharMoveState> AnimalValidMoveState;

	// Token: 0x040008D0 RID: 2256
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/Animal/TsTaskAnimalMoveTo.TsTaskAnimalMoveTo_C";

	// Token: 0x040008D1 RID: 2257
	private static IntPtr _ClassPtr;

	// Token: 0x040008D2 RID: 2258
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040008D3 RID: 2259
	private static int __PropertyOffset_MoveState;

	// Token: 0x040008D4 RID: 2260
	private static int __PropertyOffset_NavigationOn;

	// Token: 0x040008D5 RID: 2261
	private static int __PropertyOffset_TargetLocation;

	// Token: 0x040008D6 RID: 2262
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x040008D7 RID: 2263
	private static int __PropertyOffset_LimitTime;

	// Token: 0x040008D8 RID: 2264
	private static int __PropertyOffset_RootMotion;

	// Token: 0x040008D9 RID: 2265
	private static int __PropertyOffset_DistanceErrorThreshold;
}
