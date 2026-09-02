using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CA3 RID: 3235
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBigAnimalEscape.TsTaskBigAnimalEscape_C")]
public class TsTaskBigAnimalEscape : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170001EF RID: 495
	// (get) Token: 0x06003C71 RID: 15473 RVA: 0x000526BB File Offset: 0x000508BB
	// (set) Token: 0x06003C72 RID: 15474 RVA: 0x000526CF File Offset: 0x000508CF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string EnemyKey
	{
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBigAnimalEscape.__PropertyOffset_EnemyKey)));
		}
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskBigAnimalEscape.__PropertyOffset_EnemyKey)), value);
		}
	}

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x06003C73 RID: 15475 RVA: 0x000526E4 File Offset: 0x000508E4
	// (set) Token: 0x06003C74 RID: 15476 RVA: 0x000526F4 File Offset: 0x000508F4
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskBigAnimalEscape.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskBigAnimalEscape.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x06003C75 RID: 15477 RVA: 0x00052708 File Offset: 0x00050908
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitTsVariables()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitTsVariables"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003C76 RID: 15478 RVA: 0x00052778 File Offset: 0x00050978
	protected void InitTsVariables_Implementation()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsEnemyKey = this.EnemyKey;
			this.TsTurnSpeed = this.TurnSpeed;
		}
	}

	// Token: 0x06003C77 RID: 15479 RVA: 0x000527A8 File Offset: 0x000509A8
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

	// Token: 0x06003C78 RID: 15480 RVA: 0x00052844 File Offset: 0x00050A44
	[NullableContext(2)]
	protected virtual void ReceiveExecuteAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (tsAiController == null)
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
		AiController aiController = tsAiController.AiController;
		if (!this.InitConfig(aiController))
		{
			base.FinishExecute(false);
			return;
		}
		this.InitTsVariables();
		this.ActorComp = aiController.CharActorComp;
		if (this.TsEnemyKey != "")
		{
			int? entityIdByEntity = ControllerBase<BlackboardController>.Instance.GetEntityIdByEntity(this.ActorComp.Entity.Id, this.TsEnemyKey);
			if (entityIdByEntity != null && entityIdByEntity.Value != 0)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(entityIdByEntity.Value);
				if (entity != null)
				{
					this.TargetActorComp = entity.GetComponent<CharacterActorComponent>();
				}
			}
		}
		if (this.TargetActorComp == null)
		{
			this.TargetActorComp = Global.BaseCharacter.CharacterActorComponent;
		}
		this.InitData();
		global::Vector vector = global::Vector.Create();
		this.ActorComp.ActorLocationProxy.Subtraction(this.TargetActorComp.ActorLocationProxy, vector);
		vector.Z = 0.0;
		vector.Normalize(9.99999993922529E-09);
		this.FindOptimalDirections(vector);
		if (this.OptimalDirections.Count == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.BehaviorTree;
			ELogAuthor author2 = ELogAuthor.CJH;
			string message2 = "无可行方向，请检查逻辑和配置";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("EntityId: ", this.ActorComp.Entity.Id);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			base.Finish(true);
			return;
		}
		this.FindEscapeLocation();
		this.FindMovePath();
		this.EscapeEndTime = Singleton<Time>.Instance.WorldTime + (double)aiController.AiFlee.Value.TimeMilliseconds;
	}

	// Token: 0x06003C79 RID: 15481 RVA: 0x00052A18 File Offset: 0x00050C18
	private bool InitConfig(AiController aiController)
	{
		if (this.Initialized)
		{
			return true;
		}
		AiFlee? aiFlee = aiController.AiFlee;
		if (aiFlee == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.CJH;
			string message = "没有配置逃跑";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("AiBaseId", aiController.AiBase.Value.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.AngleMin = (double)aiFlee.Value.FleeAngle.Value.Min;
		this.AngleMax = (double)aiFlee.Value.FleeAngle.Value.Max;
		this.InnerDiameter = (double)aiFlee.Value.FleeDistance.Value.Min;
		this.OuterDiameter = (double)aiFlee.Value.FleeDistance.Value.Max;
		this.Initialized = true;
		return true;
	}

	// Token: 0x06003C7A RID: 15482 RVA: 0x00052B28 File Offset: 0x00050D28
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void InitData()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("InitData"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003C7B RID: 15483 RVA: 0x00052B98 File Offset: 0x00050D98
	protected void InitData_Implementation()
	{
		if (this.OptimalDirections == null)
		{
			this.OptimalDirections = new List<global::Vector>();
		}
		if (this.EscapeLocation == null)
		{
			this.EscapeLocation = new FVectorDouble?(new FVectorDouble());
		}
		if (this.MovePath == null)
		{
			this.MovePath = new List<global::Vector>();
		}
		this.CurrentMoveIndex = 1;
	}

	// Token: 0x06003C7C RID: 15484 RVA: 0x00052BF0 File Offset: 0x00050DF0
	private void FindOptimalDirections(global::Vector departure)
	{
		global::Vector actorForwardProxy = this.ActorComp.ActorForwardProxy;
		double num = Math.Max(this.AngleMax - this.AngleMin, 90.0);
		global::Vector vector = global::Vector.Create();
		departure.Multiply(-1.0, vector);
		int num2 = 4;
		List<ValueTuple<global::Vector, double>> list = new List<ValueTuple<global::Vector, double>>();
		for (int i = 0; i < num2; i++)
		{
			int num3 = i * 90;
			global::Vector vector2 = global::Vector.Create();
			actorForwardProxy.RotateAngleAxis((double)num3, this.ActorComp.ActorUpProxy, vector2);
			double angleByVectorDot = Singleton<MathUtils>.Instance.GetAngleByVectorDot(vector, vector2);
			if (angleByVectorDot >= 90.0)
			{
				angleByVectorDot = Singleton<MathUtils>.Instance.GetAngleByVectorDot(departure, vector2);
				if (angleByVectorDot <= num)
				{
					list.Add(new ValueTuple<global::Vector, double>(vector2, angleByVectorDot));
				}
			}
		}
		list.Sort(([Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<global::Vector, double> a, [Nullable(new byte[]
		{
			0,
			1
		})] ValueTuple<global::Vector, double> b) => a.Item2.CompareTo(b.Item2));
		foreach (ValueTuple<global::Vector, double> valueTuple in list)
		{
			this.OptimalDirections.Add(valueTuple.Item1);
		}
	}

	// Token: 0x06003C7D RID: 15485 RVA: 0x00052D30 File Offset: 0x00050F30
	private void FindEscapeLocation()
	{
		global::Vector vector = global::Vector.Create();
		FVectorDouble value = default(FVectorDouble);
		foreach (global::Vector vector2 in this.OptimalDirections)
		{
			for (double num = this.OuterDiameter; num >= this.InnerDiameter; num -= 200.0)
			{
				vector2.Multiply(num, vector);
				vector.AdditionEqual(this.ActorComp.ActorLocationProxy);
				double num2 = num * Math.Sin(0.26);
				UObject world = GlobalData.World;
				FVectorDouble fvectorDouble = vector.ToUeVector(false);
				this.FoundLocation = UNavigationSystemV1.D_K2_GetRandomLocationInNavigableRadius(world, fvectorDouble, ref value, (float)num2, null, default(TSubclassOf<UNavigationQueryFilter>));
				if (this.FoundLocation)
				{
					break;
				}
			}
			if (this.FoundLocation)
			{
				this.EscapeLocation = new FVectorDouble?(value);
				break;
			}
		}
		if (!this.FoundLocation)
		{
			global::Vector vector3 = this.OptimalDirections[0];
			for (double num3 = this.InnerDiameter; num3 > 0.0; num3 -= 200.0)
			{
				vector3.Multiply(num3, vector);
				vector.AdditionEqual(this.ActorComp.ActorLocationProxy);
				UObject world2 = GlobalData.World;
				FVectorDouble fvectorDouble = vector.ToUeVector(false);
				this.FoundLocation = UNavigationSystemV1.D_K2_ProjectPointToNavigation(world2, fvectorDouble, ref value, null, default(TSubclassOf<UNavigationQueryFilter>), default(FVectorDouble), -1.0);
				if (this.FoundLocation)
				{
					this.EscapeLocation = new FVectorDouble?(value);
					return;
				}
			}
		}
	}

	// Token: 0x06003C7E RID: 15486 RVA: 0x00052ED8 File Offset: 0x000510D8
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void FindMovePath()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("FindMovePath"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003C7F RID: 15487 RVA: 0x00052F48 File Offset: 0x00051148
	protected void FindMovePath_Implementation()
	{
		if (!this.FoundLocation)
		{
			this.GenerateFailurePath();
			return;
		}
		this.FoundPath = AiControllerLibrary.NavigationFindPath(GlobalData.World, this.ActorComp.ActorLocation, this.EscapeLocation.Value, this.MovePath, null, null);
		if (GlobalData.IsPlayInEditor && this.FoundPath)
		{
			int i = 0;
			int count = this.MovePath.Count;
			while (i < count)
			{
				UKismetSystemLibrary.D_DrawDebugSphere(this, this.MovePath[i].ToUeVector(false), 30f, 10, new FLinearColor?(ColorUtils.LinearGreen), 2.5f, 0f);
				i++;
			}
		}
		if (!this.FoundPath)
		{
			this.GenerateFailurePath();
		}
	}

	// Token: 0x06003C80 RID: 15488 RVA: 0x0005300C File Offset: 0x0005120C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void GenerateFailurePath()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("GenerateFailurePath"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x06003C81 RID: 15489 RVA: 0x0005307C File Offset: 0x0005127C
	protected void GenerateFailurePath_Implementation()
	{
		global::Vector vector = global::Vector.Create();
		this.OptimalDirections[0].Multiply(200.0, vector);
		vector.AdditionEqual(this.ActorComp.ActorLocationProxy);
		global::Vector item = global::Vector.Create(this.ActorComp.ActorLocationProxy);
		this.MovePath.Clear();
		this.MovePath.Add(item);
		this.MovePath.Add(vector);
		this.FoundPath = true;
		if (GlobalData.IsPlayInEditor)
		{
			UKismetSystemLibrary.D_DrawDebugSphere(this, this.EscapeLocation.Value, 30f, 10, new FLinearColor?(ColorUtils.LinearRed), 2.5f, 0f);
		}
	}

	// Token: 0x06003C82 RID: 15490 RVA: 0x0005312C File Offset: 0x0005132C
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

	// Token: 0x06003C83 RID: 15491 RVA: 0x000531CC File Offset: 0x000513CC
	[NullableContext(2)]
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		if (((tsAiController != null) ? tsAiController.AiController : null) == null)
		{
			base.Finish(false);
			return;
		}
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			base.Finish(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.EscapeEndTime)
		{
			base.Finish(true);
			return;
		}
		BaseUnifiedStateComponent component = this.ActorComp.Entity.GetComponent<BaseUnifiedStateComponent>();
		global::Vector vector = global::Vector.Create(this.MovePath[this.CurrentMoveIndex]);
		vector.SubtractionEqual(this.ActorComp.ActorLocationProxy);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, vector);
		double num = vector.SizeSquared();
		vector.Normalize(9.99999993922529E-09);
		double angleByVectorDot = Singleton<MathUtils>.Instance.GetAngleByVectorDot(this.ActorComp.ActorForwardProxy, vector);
		this.NeedTurn = (angleByVectorDot > 30.0);
		if (this.CurrentMoveIndex == 1 && this.NeedTurn)
		{
			if (component != null && component.Valid)
			{
				component.SetMoveState(ECharMoveState.Stand);
			}
			this.ActorComp.ClearInput(false, true);
			AiControllerLibrary.TurnToDirect(this.ActorComp, vector, this.TsTurnSpeed, false, 0f);
			return;
		}
		if (component != null && component.Valid)
		{
			component.SetMoveState(ECharMoveState.Run);
		}
		if (num < 2500.0)
		{
			this.CurrentMoveIndex++;
			if (this.CurrentMoveIndex == this.MovePath.Count)
			{
				base.Finish(true);
				return;
			}
		}
		this.ActorComp.SetInputDirect(vector, false);
		AiControllerLibrary.TurnToDirect(this.ActorComp, vector, this.TsTurnSpeed, false, 0f);
	}

	// Token: 0x06003C84 RID: 15492 RVA: 0x00053374 File Offset: 0x00051574
	protected override void OnClear()
	{
		this.OptimalDirections.Clear();
		this.FoundLocation = false;
		this.FoundPath = false;
		this.MovePath.Clear();
	}

	// Token: 0x06003C85 RID: 15493 RVA: 0x0005339A File Offset: 0x0005159A
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskBigAnimalEscape._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBigAnimalEscape.TsTaskBigAnimalEscape_C");
		}
		return TsTaskBigAnimalEscape._ClassPtr;
	}

	// Token: 0x06003C86 RID: 15494 RVA: 0x000533C0 File Offset: 0x000515C0
	public TsTaskBigAnimalEscape() : this(BuiltinUtils.AllocNativeUObject(TsTaskBigAnimalEscape.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003C87 RID: 15495 RVA: 0x000533E8 File Offset: 0x000515E8
	public TsTaskBigAnimalEscape(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskBigAnimalEscape.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003C88 RID: 15496 RVA: 0x0005341B File Offset: 0x0005161B
	protected TsTaskBigAnimalEscape(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003C89 RID: 15497 RVA: 0x0005342F File Offset: 0x0005162F
	protected virtual void __CPPCALL_InitTsVariables_Implementation()
	{
		this.InitTsVariables_Implementation();
	}

	// Token: 0x06003C8A RID: 15498 RVA: 0x00053438 File Offset: 0x00051638
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06003C8B RID: 15499 RVA: 0x00053465 File Offset: 0x00051665
	protected virtual void __CPPCALL_InitData_Implementation()
	{
		this.InitData_Implementation();
	}

	// Token: 0x06003C8C RID: 15500 RVA: 0x0005346D File Offset: 0x0005166D
	protected virtual void __CPPCALL_FindMovePath_Implementation()
	{
		this.FindMovePath_Implementation();
	}

	// Token: 0x06003C8D RID: 15501 RVA: 0x00053475 File Offset: 0x00051675
	protected virtual void __CPPCALL_GenerateFailurePath_Implementation()
	{
		this.GenerateFailurePath_Implementation();
	}

	// Token: 0x06003C8E RID: 15502 RVA: 0x00053480 File Offset: 0x00051680
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x04000B84 RID: 2948
	private const double FRONT_RANDOM_RAD = 0.26;

	// Token: 0x04000B85 RID: 2949
	private const int HALF_PI_DEG = 90;

	// Token: 0x04000B86 RID: 2950
	private const int DOUBLE_PI_DEG = 360;

	// Token: 0x04000B87 RID: 2951
	private const int INSPECTION_INTERVAL = 200;

	// Token: 0x04000B88 RID: 2952
	private const int DEBUG_SEGMENTS = 10;

	// Token: 0x04000B89 RID: 2953
	private const int DEBUG_RADIUS = 30;

	// Token: 0x04000B8A RID: 2954
	private const float DEBUG_TIME = 2.5f;

	// Token: 0x04000B8B RID: 2955
	private const int TURN_COMPLETE_DEG = 30;

	// Token: 0x04000B8C RID: 2956
	private const int NAVIGATION_COMPLETE_DISTANCE = 2500;

	// Token: 0x04000B8D RID: 2957
	private const bool DEBUG_MODE = true;

	// Token: 0x04000B8E RID: 2958
	private bool IsInitTsVariables;

	// Token: 0x04000B8F RID: 2959
	private string TsEnemyKey = "";

	// Token: 0x04000B90 RID: 2960
	private float TsTurnSpeed;

	// Token: 0x04000B91 RID: 2961
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x04000B92 RID: 2962
	[Nullable(2)]
	private CharacterActorComponent TargetActorComp;

	// Token: 0x04000B93 RID: 2963
	private bool Initialized;

	// Token: 0x04000B94 RID: 2964
	private double AngleMin;

	// Token: 0x04000B95 RID: 2965
	private double AngleMax;

	// Token: 0x04000B96 RID: 2966
	private double InnerDiameter;

	// Token: 0x04000B97 RID: 2967
	private double OuterDiameter;

	// Token: 0x04000B98 RID: 2968
	private double EscapeEndTime;

	// Token: 0x04000B99 RID: 2969
	private bool FoundLocation;

	// Token: 0x04000B9A RID: 2970
	private FVectorDouble? EscapeLocation;

	// Token: 0x04000B9B RID: 2971
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> OptimalDirections;

	// Token: 0x04000B9C RID: 2972
	protected bool FoundPath;

	// Token: 0x04000B9D RID: 2973
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> MovePath;

	// Token: 0x04000B9E RID: 2974
	private int CurrentMoveIndex;

	// Token: 0x04000B9F RID: 2975
	private bool NeedTurn;

	// Token: 0x04000BA0 RID: 2976
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskBigAnimalEscape.TsTaskBigAnimalEscape_C";

	// Token: 0x04000BA1 RID: 2977
	private static IntPtr _ClassPtr;

	// Token: 0x04000BA2 RID: 2978
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000BA3 RID: 2979
	private static int __PropertyOffset_EnemyKey;

	// Token: 0x04000BA4 RID: 2980
	private static int __PropertyOffset_TurnSpeed;
}
