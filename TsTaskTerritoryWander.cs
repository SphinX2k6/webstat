using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Utils;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000CE0 RID: 3296
[NullableContext(2)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTerritoryWander.TsTaskTerritoryWander_C")]
public class TsTaskTerritoryWander : TsTaskAbortImmediatelyBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x170002EE RID: 750
	// (get) Token: 0x06004105 RID: 16645 RVA: 0x00069A65 File Offset: 0x00067C65
	// (set) Token: 0x06004106 RID: 16646 RVA: 0x00069A79 File Offset: 0x00067C79
	[Nullable(1)]
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe string RangeCenterKey
	{
		[NullableContext(1)]
		get
		{
			return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTerritoryWander.__PropertyOffset_RangeCenterKey)));
		}
		[NullableContext(1)]
		set
		{
			FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)TsTaskTerritoryWander.__PropertyOffset_RangeCenterKey)), value);
		}
	}

	// Token: 0x170002EF RID: 751
	// (get) Token: 0x06004107 RID: 16647 RVA: 0x00069A8E File Offset: 0x00067C8E
	// (set) Token: 0x06004108 RID: 16648 RVA: 0x00069A9E File Offset: 0x00067C9E
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float RangeRadius
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_RangeRadius);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_RangeRadius) = value;
		}
	}

	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x06004109 RID: 16649 RVA: 0x00069AAF File Offset: 0x00067CAF
	// (set) Token: 0x0600410A RID: 16650 RVA: 0x00069ABF File Offset: 0x00067CBF
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float Angle
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_Angle);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_Angle) = value;
		}
	}

	// Token: 0x170002F1 RID: 753
	// (get) Token: 0x0600410B RID: 16651 RVA: 0x00069AD0 File Offset: 0x00067CD0
	// (set) Token: 0x0600410C RID: 16652 RVA: 0x00069AE0 File Offset: 0x00067CE0
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float InnerDiameter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_InnerDiameter);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_InnerDiameter) = value;
		}
	}

	// Token: 0x170002F2 RID: 754
	// (get) Token: 0x0600410D RID: 16653 RVA: 0x00069AF1 File Offset: 0x00067CF1
	// (set) Token: 0x0600410E RID: 16654 RVA: 0x00069B01 File Offset: 0x00067D01
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float OuterDiameter
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_OuterDiameter);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_OuterDiameter) = value;
		}
	}

	// Token: 0x170002F3 RID: 755
	// (get) Token: 0x0600410F RID: 16655 RVA: 0x00069B12 File Offset: 0x00067D12
	// (set) Token: 0x06004110 RID: 16656 RVA: 0x00069B22 File Offset: 0x00067D22
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool ForceNavigation
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_ForceNavigation) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_ForceNavigation) = (value ? 1 : 0);
		}
	}

	// Token: 0x170002F4 RID: 756
	// (get) Token: 0x06004111 RID: 16657 RVA: 0x00069B33 File Offset: 0x00067D33
	// (set) Token: 0x06004112 RID: 16658 RVA: 0x00069B43 File Offset: 0x00067D43
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float TurnSpeed
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_TurnSpeed);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_TurnSpeed) = value;
		}
	}

	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06004113 RID: 16659 RVA: 0x00069B54 File Offset: 0x00067D54
	// (set) Token: 0x06004114 RID: 16660 RVA: 0x00069B64 File Offset: 0x00067D64
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe bool DebugMode
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_DebugMode) != 0;
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsTaskTerritoryWander.__PropertyOffset_DebugMode) = (value ? 1 : 0);
		}
	}

	// Token: 0x06004115 RID: 16661 RVA: 0x00069B78 File Offset: 0x00067D78
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsRangeCenterKey = this.RangeCenterKey;
			this.TsRangeRadius = this.RangeRadius;
			this.TsAngle = this.Angle;
			this.TsInnerDiameter = this.InnerDiameter;
			this.TsOuterDiameter = this.OuterDiameter;
			this.TsForceNavigation = this.ForceNavigation;
			this.TsTurnSpeed = this.TurnSpeed;
			this.TsDebugMode = this.DebugMode;
		}
	}

	// Token: 0x06004116 RID: 16662 RVA: 0x00069BFC File Offset: 0x00067DFC
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

	// Token: 0x06004117 RID: 16663 RVA: 0x00069C98 File Offset: 0x00067E98
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
			base.FinishExecute(false);
			return;
		}
		this.ActorComp = aiController.CharActorComp;
		CharacterActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid)
		{
			base.Finish(false);
			return;
		}
		Entity entity = this.ActorComp.Entity;
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		this.MoveComp = entity.GetComponent<CharacterMoveComponent>();
		this.UnifiedStateComp = entity.GetComponent<BaseUnifiedStateComponent>();
		if (this.RangeCenter == null)
		{
			if (this.TsRangeCenterKey != "")
			{
				int id = entity.Id;
				Aki.Protocol.Vector vectorValueByEntity = ControllerBase<BlackboardController>.Instance.GetVectorValueByEntity(id, this.TsRangeCenterKey);
				if (vectorValueByEntity == null)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.BehaviorTree;
					ELogAuthor author2 = ELogAuthor.CJH;
					string message2 = "不存在Blackboard Value";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Key", this.TsRangeCenterKey);
					instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					base.Finish(false);
					return;
				}
				this.RangeCenter = global::Vector.Create(vectorValueByEntity);
			}
			else
			{
				Aki.Protocol.Vector initLocation = component.GetInitLocation();
				this.RangeCenter = global::Vector.Create((double)initLocation.X, (double)initLocation.Y, (double)initLocation.Z);
			}
		}
		if (this.CacheVector == null)
		{
			this.CacheVector = global::Vector.Create();
		}
		this.FindWanderLocation();
		this.FindWanderPath();
		this.NavigationEndTime = Singleton<Time>.Instance.WorldTime + 5000.0;
		this.CurrentNavigationIndex = 1;
	}

	// Token: 0x06004118 RID: 16664 RVA: 0x00069E44 File Offset: 0x00068044
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

	// Token: 0x06004119 RID: 16665 RVA: 0x00069EE4 File Offset: 0x000680E4
	protected virtual void ReceiveTickAI_Implementation(AAIController ownerController, APawn controlledPawn, float deltaSeconds)
	{
		if (!(ownerController is TsAiController))
		{
			base.Finish(false);
			return;
		}
		if (this.TsForceNavigation && !this.FoundPath)
		{
			base.Finish(false);
			return;
		}
		CharacterMoveComponent moveComp = this.MoveComp;
		if (moveComp == null || !moveComp.CanMove())
		{
			base.Finish(false);
			return;
		}
		if (Singleton<Time>.Instance.WorldTime > this.NavigationEndTime)
		{
			base.Finish(true);
			return;
		}
		BaseUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
		if (unifiedStateComp != null && unifiedStateComp.Valid)
		{
			this.UnifiedStateComp.SetMoveState(global::ECharMoveState.Walk);
		}
		global::Vector inV = this.NavigationPath[this.CurrentNavigationIndex];
		this.CacheVector.FromUeVector(inV);
		this.CacheVector.Subtraction(this.ActorComp.ActorLocationProxy, this.CacheVector);
		Singleton<GravityUtils>.Instance.ConvertToPlanarVectorForActor(this.ActorComp, this.CacheVector);
		double num = this.CacheVector.Size();
		this.CacheVector.Normalize(9.99999993922529E-09);
		if (this.CurrentNavigationIndex == this.NavigationPath.Count - 1 && num < 20.0)
		{
			base.Finish(true);
			return;
		}
		if (num < 20.0)
		{
			this.CurrentNavigationIndex++;
		}
		this.ActorComp.SetInputDirect(this.CacheVector, false);
		AiControllerLibrary.TurnToDirect(this.ActorComp, this.CacheVector, this.TsTurnSpeed, false, 0f);
	}

	// Token: 0x0600411A RID: 16666 RVA: 0x0006A05C File Offset: 0x0006825C
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"X",
		"Y"
	})]
	private ValueTuple<double, double> RandomPointInFanRing(double inner, double outer, double minAngle, double maxAngle)
	{
		if (minAngle > maxAngle || inner > outer || inner < 0.0)
		{
			return new ValueTuple<double, double>(0.0, 0.0);
		}
		double randomRange = Singleton<MathUtils>.Instance.GetRandomRange(inner * inner, outer * outer);
		double randomRange2 = Singleton<MathUtils>.Instance.GetRandomRange(minAngle, maxAngle);
		double num = Math.Sqrt(randomRange);
		return new ValueTuple<double, double>(num * Math.Cos(randomRange2), num * Math.Sin(randomRange2));
	}

	// Token: 0x0600411B RID: 16667 RVA: 0x0006A0D0 File Offset: 0x000682D0
	protected override void OnClear()
	{
		TsAiController tsAiController = base.AIOwner as TsAiController;
		if (tsAiController != null)
		{
			AiControllerLibrary.ClearInput(tsAiController);
		}
		BaseUnifiedStateComponent unifiedStateComp = this.UnifiedStateComp;
		if (unifiedStateComp != null)
		{
			unifiedStateComp.SetMoveState(global::ECharMoveState.Stand);
		}
		this.ActorComp = null;
		this.MoveComp = null;
		this.UnifiedStateComp = null;
	}

	// Token: 0x0600411C RID: 16668 RVA: 0x0006A11C File Offset: 0x0006831C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void FindWanderLocation()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("FindWanderLocation"), out num);
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

	// Token: 0x0600411D RID: 16669 RVA: 0x0006A18C File Offset: 0x0006838C
	protected void FindWanderLocation_Implementation()
	{
		if (this.TargetLocation == null)
		{
			this.TargetLocation = global::Vector.Create();
		}
		global::Vector actorLocationProxy = this.ActorComp.ActorLocationProxy;
		ValueTuple<double, double> valueTuple = this.RandomPointInFanRing((double)this.TsInnerDiameter, (double)this.TsOuterDiameter, (double)((this.ActorComp.ActorRotationProxy.Yaw - this.TsAngle / 2f) / 180f) * 3.14, (double)((this.ActorComp.ActorRotationProxy.Yaw + this.TsAngle / 2f) / 180f) * 3.14);
		this.TargetLocation.X = actorLocationProxy.X + valueTuple.Item1;
		this.TargetLocation.Y = actorLocationProxy.Y + valueTuple.Item2;
		this.TargetLocation.Z = actorLocationProxy.Z;
		if (global::Vector.DistSquared2D(this.TargetLocation, this.RangeCenter) >= (double)(this.TsRangeRadius * this.TsRangeRadius))
		{
			this.TargetLocation.X = actorLocationProxy.X - valueTuple.Item1;
			this.TargetLocation.Y = actorLocationProxy.Y - valueTuple.Item2;
			if (global::Vector.DistSquared2D(this.TargetLocation, this.RangeCenter) >= (double)(this.TsRangeRadius * this.TsRangeRadius))
			{
				this.TargetLocation.X = this.RangeCenter.X;
				this.TargetLocation.Y = this.RangeCenter.Y;
			}
			this.TargetLocation.Z = actorLocationProxy.Z;
		}
		this.DebugDraw();
	}

	// Token: 0x0600411E RID: 16670 RVA: 0x0006A324 File Offset: 0x00068524
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void FindWanderPath()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("FindWanderPath"), out num);
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

	// Token: 0x0600411F RID: 16671 RVA: 0x0006A394 File Offset: 0x00068594
	protected void FindWanderPath_Implementation()
	{
		if (this.NavigationPath == null)
		{
			this.NavigationPath = new List<global::Vector>();
		}
		this.FoundPath = AiControllerLibrary.NavigationFindPath(this, this.ActorComp.ActorLocation, this.TargetLocation.ToUeVector(false), this.NavigationPath, null, null);
		if (!this.FoundPath)
		{
			this.NavigationPath.Clear();
			this.NavigationPath.Add(this.ActorComp.ActorLocationProxy);
			this.NavigationPath.Add(this.TargetLocation);
		}
	}

	// Token: 0x06004120 RID: 16672 RVA: 0x0006A42C File Offset: 0x0006862C
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	protected unsafe virtual void DebugDraw()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("DebugDraw"), out num);
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

	// Token: 0x06004121 RID: 16673 RVA: 0x0006A49C File Offset: 0x0006869C
	protected void DebugDraw_Implementation()
	{
		if (this.TsDebugMode && GlobalData.IsPlayInEditor)
		{
			UKismetSystemLibrary.D_DrawDebugCone(this, this.ActorComp.ActorLocation, this.ActorComp.ActorForward, this.TsOuterDiameter, (float)((double)(this.TsAngle / 360f) * 3.14), 0f, 12, ColorUtils.LinearGreen, 3f, 0f);
			UKismetSystemLibrary.D_DrawDebugCone(this, this.ActorComp.ActorLocation, this.ActorComp.ActorForward, this.TsInnerDiameter, (float)((double)(this.TsAngle / 360f) * 3.14), 0f, 12, ColorUtils.LinearRed, 3f, 0f);
			UKismetSystemLibrary.D_DrawDebugCircle(this, this.RangeCenter.ToUeVector(false), this.TsRangeRadius, 24, new FLinearColor?(ColorUtils.LinearYellow), 3f, 0f, new FVectorDouble?(global::Vector.Create(1.0, 0.0, 0.0).ToUeVector(false)), new FVectorDouble?(global::Vector.Create(0.0, 1.0, 0.0).ToUeVector(false)), true);
			UKismetSystemLibrary.D_DrawDebugSphere(this, this.TargetLocation.ToUeVector(false), 30f, 10, new FLinearColor?(ColorUtils.LinearRed), 3f, 0f);
		}
	}

	// Token: 0x06004122 RID: 16674 RVA: 0x0006A610 File Offset: 0x00068810
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsTaskTerritoryWander._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTerritoryWander.TsTaskTerritoryWander_C");
		}
		return TsTaskTerritoryWander._ClassPtr;
	}

	// Token: 0x06004123 RID: 16675 RVA: 0x0006A634 File Offset: 0x00068834
	public TsTaskTerritoryWander() : this(BuiltinUtils.AllocNativeUObject(TsTaskTerritoryWander.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06004124 RID: 16676 RVA: 0x0006A65C File Offset: 0x0006885C
	[NullableContext(1)]
	public TsTaskTerritoryWander(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTerritoryWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06004125 RID: 16677 RVA: 0x0006A68F File Offset: 0x0006888F
	protected TsTaskTerritoryWander(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06004126 RID: 16678 RVA: 0x0006A6A4 File Offset: 0x000688A4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x06004127 RID: 16679 RVA: 0x0006A6D4 File Offset: 0x000688D4
	[NullableContext(0)]
	protected unsafe virtual void __CPPCALL_ReceiveTickAI_Implementation(UBTTask_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}

	// Token: 0x06004128 RID: 16680 RVA: 0x0006A707 File Offset: 0x00068907
	protected virtual void __CPPCALL_FindWanderLocation_Implementation()
	{
		this.FindWanderLocation_Implementation();
	}

	// Token: 0x06004129 RID: 16681 RVA: 0x0006A70F File Offset: 0x0006890F
	protected virtual void __CPPCALL_FindWanderPath_Implementation()
	{
		this.FindWanderPath_Implementation();
	}

	// Token: 0x0600412A RID: 16682 RVA: 0x0006A717 File Offset: 0x00068917
	protected virtual void __CPPCALL_DebugDraw_Implementation()
	{
		this.DebugDraw_Implementation();
	}

	// Token: 0x04000F81 RID: 3969
	private const double PI = 3.14;

	// Token: 0x04000F82 RID: 3970
	private const int NAVIGATION_END_TIME = 5000;

	// Token: 0x04000F83 RID: 3971
	private const int NAVIGATION_COMPLETE_DISTANCE = 20;

	// Token: 0x04000F84 RID: 3972
	private global::Vector RangeCenter;

	// Token: 0x04000F85 RID: 3973
	private global::Vector TargetLocation;

	// Token: 0x04000F86 RID: 3974
	private bool FoundPath;

	// Token: 0x04000F87 RID: 3975
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<global::Vector> NavigationPath;

	// Token: 0x04000F88 RID: 3976
	private int CurrentNavigationIndex;

	// Token: 0x04000F89 RID: 3977
	private CharacterActorComponent ActorComp;

	// Token: 0x04000F8A RID: 3978
	private CharacterMoveComponent MoveComp;

	// Token: 0x04000F8B RID: 3979
	private BaseUnifiedStateComponent UnifiedStateComp;

	// Token: 0x04000F8C RID: 3980
	private global::Vector CacheVector;

	// Token: 0x04000F8D RID: 3981
	private double NavigationEndTime;

	// Token: 0x04000F8E RID: 3982
	private bool IsInitTsVariables;

	// Token: 0x04000F8F RID: 3983
	[Nullable(1)]
	private string TsRangeCenterKey = "";

	// Token: 0x04000F90 RID: 3984
	private float TsRangeRadius;

	// Token: 0x04000F91 RID: 3985
	private float TsAngle;

	// Token: 0x04000F92 RID: 3986
	private float TsInnerDiameter;

	// Token: 0x04000F93 RID: 3987
	private float TsOuterDiameter;

	// Token: 0x04000F94 RID: 3988
	private bool TsForceNavigation;

	// Token: 0x04000F95 RID: 3989
	private float TsTurnSpeed;

	// Token: 0x04000F96 RID: 3990
	private bool TsDebugMode;

	// Token: 0x04000F97 RID: 3991
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Task/TsTaskTerritoryWander.TsTaskTerritoryWander_C";

	// Token: 0x04000F98 RID: 3992
	private static IntPtr _ClassPtr;

	// Token: 0x04000F99 RID: 3993
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000F9A RID: 3994
	private static int __PropertyOffset_RangeCenterKey;

	// Token: 0x04000F9B RID: 3995
	private static int __PropertyOffset_RangeRadius;

	// Token: 0x04000F9C RID: 3996
	private static int __PropertyOffset_Angle;

	// Token: 0x04000F9D RID: 3997
	private static int __PropertyOffset_InnerDiameter;

	// Token: 0x04000F9E RID: 3998
	private static int __PropertyOffset_OuterDiameter;

	// Token: 0x04000F9F RID: 3999
	private static int __PropertyOffset_ForceNavigation;

	// Token: 0x04000FA0 RID: 4000
	private static int __PropertyOffset_TurnSpeed;

	// Token: 0x04000FA1 RID: 4001
	private static int __PropertyOffset_DebugMode;
}
