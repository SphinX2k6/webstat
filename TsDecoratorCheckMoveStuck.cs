using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C54 RID: 3156
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckMoveStuck.TsDecoratorCheckMoveStuck_C")]
public class TsDecoratorCheckMoveStuck : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000133 RID: 307
	// (get) Token: 0x060037B9 RID: 14265 RVA: 0x0003AB47 File Offset: 0x00038D47
	// (set) Token: 0x060037BA RID: 14266 RVA: 0x0003AB57 File Offset: 0x00038D57
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float MinMoveSpeedRate
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckMoveStuck.__PropertyOffset_MinMoveSpeedRate);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckMoveStuck.__PropertyOffset_MinMoveSpeedRate) = value;
		}
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x060037BB RID: 14267 RVA: 0x0003AB68 File Offset: 0x00038D68
	// (set) Token: 0x060037BC RID: 14268 RVA: 0x0003AB78 File Offset: 0x00038D78
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float StuckDuration
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorCheckMoveStuck.__PropertyOffset_StuckDuration);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorCheckMoveStuck.__PropertyOffset_StuckDuration) = value;
		}
	}

	// Token: 0x060037BD RID: 14269 RVA: 0x0003AB89 File Offset: 0x00038D89
	private void ResetSampleState()
	{
		this.HasSample = false;
		this.LastSampleTime = 0.0;
		this.LowSpeedDuration = 0.0;
	}

	// Token: 0x060037BE RID: 14270 RVA: 0x0003ABB0 File Offset: 0x00038DB0
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsMinMoveSpeedRate = this.MinMoveSpeedRate;
			this.TsStuckDuration = this.StuckDuration;
		}
	}

	// Token: 0x060037BF RID: 14271 RVA: 0x0003ABE0 File Offset: 0x00038DE0
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override bool PerformConditionCheckAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("PerformConditionCheckAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		bool _Result = ptr2->__Result;
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
		return _Result;
	}

	// Token: 0x060037C0 RID: 14272 RVA: 0x0003AC80 File Offset: 0x00038E80
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		CharacterActorComponent characterActorComponent = (aiController != null) ? aiController.CharActorComp : null;
		if (characterActorComponent == null || !characterActorComponent.Valid)
		{
			return false;
		}
		this.InitTsVariables();
		if (this.TsStuckDuration <= 0f || this.TsMinMoveSpeedRate <= 0f)
		{
			return true;
		}
		double worldTime = Singleton<Time>.Instance.WorldTime;
		if (!this.HasSample)
		{
			this.LastSampleTime = worldTime;
			this.LastSampleLocation.DeepCopy(characterActorComponent.ActorLocationProxy);
			this.HasSample = true;
			return true;
		}
		double num = worldTime - this.LastSampleTime;
		if (num <= 0.0)
		{
			return true;
		}
		Vector safeActorVelocityProxy = characterActorComponent.SafeActorVelocityProxy;
		if (safeActorVelocityProxy == null)
		{
			return false;
		}
		BaseUnifiedStateComponent component = characterActorComponent.Entity.GetComponent<BaseUnifiedStateComponent>();
		ECharMoveState? echarMoveState = (component != null) ? new ECharMoveState?(component.MoveState) : null;
		object obj = echarMoveState != null && this.RealGroundStates.Contains(echarMoveState.Value);
		double num2 = num * 0.0010000000474974513;
		object obj2 = obj;
		double num3 = (obj2 != null) ? Singleton<GravityUtils>.Instance.GetPlanarSizeSquared2dForActor(characterActorComponent, safeActorVelocityProxy) : safeActorVelocityProxy.SizeSquared();
		double num4 = ((obj2 != null) ? Singleton<GravityUtils>.Instance.GetDistSquared2dForActor(characterActorComponent, characterActorComponent.ActorLocationProxy, this.LastSampleLocation) : Vector.DistSquared(characterActorComponent.ActorLocationProxy, this.LastSampleLocation)) / (num2 * num2);
		this.LastSampleLocation.DeepCopy(characterActorComponent.ActorLocationProxy);
		this.LastSampleTime = worldTime;
		double num5 = num3 * (double)this.TsMinMoveSpeedRate * (double)this.TsMinMoveSpeedRate;
		if (num4 < num5)
		{
			this.LowSpeedDuration += num;
			if (this.LowSpeedDuration >= (double)this.TsStuckDuration)
			{
				return false;
			}
		}
		else
		{
			this.LowSpeedDuration = 0.0;
		}
		return true;
	}

	// Token: 0x060037C1 RID: 14273 RVA: 0x0003AE34 File Offset: 0x00039034
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveExecutionFinishAI(AAIController ownerController, APawn controlledPawn, EBTNodeResult nodeResult)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveExecutionFinishAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__ReceiveExecutionFinishAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__ReceiveExecutionFinishAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__ReceiveExecutionFinishAI_FunctionParams) & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
			*(&ptr2->OwnerController) = ((ownerController != null) ? ownerController.NativePtr : ((IntPtr)0));
			*(&ptr2->ControlledPawn) = ((controlledPawn != null) ? controlledPawn.NativePtr : ((IntPtr)0));
			*(byte*)(&ptr2->NodeResult) = (byte)nodeResult;
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, (void*)ptr2);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)ptr2, 1);
		}
	}

	// Token: 0x060037C2 RID: 14274 RVA: 0x0003AED8 File Offset: 0x000390D8
	[NullableContext(2)]
	protected unsafe virtual void ReceiveExecutionFinishAI_Implementation(AAIController ownerController, APawn controlledPawn, EBTNodeResult nodeResult)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.YY;
		string message = "[CheckMoveStuck] ReceiveExecutionFinishAI";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Controller", ((ownerController != null) ? ownerController.GetName() : null) ?? "Unknown");
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Result", nodeResult);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		this.ResetSampleState();
	}

	// Token: 0x060037C3 RID: 14275 RVA: 0x0003AF58 File Offset: 0x00039158
	[NullableContext(2)]
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void ReceiveObserverDeactivatedAI(AAIController ownerController, APawn controlledPawn)
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("ReceiveObserverDeactivatedAI"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		UBTDecorator_BlueprintBase.__ReceiveObserverDeactivatedAI_FunctionParams* ptr2 = null;
		if (num != 0)
		{
			ptr2 = ((UBTDecorator_BlueprintBase.__ReceiveObserverDeactivatedAI_FunctionParams*)ptr + 15L / (long)sizeof(UBTDecorator_BlueprintBase.__ReceiveObserverDeactivatedAI_FunctionParams) & -16L);
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

	// Token: 0x060037C4 RID: 14276 RVA: 0x0003AFF4 File Offset: 0x000391F4
	[NullableContext(2)]
	protected virtual void ReceiveObserverDeactivatedAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.BehaviorTree;
		ELogAuthor author = ELogAuthor.YY;
		string message = "[CheckMoveStuck] ReceiveObserverDeactivatedAI";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Controller", ((ownerController != null) ? ownerController.GetName() : null) ?? "Unknown");
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.ResetSampleState();
	}

	// Token: 0x060037C5 RID: 14277 RVA: 0x0003B042 File Offset: 0x00039242
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckMoveStuck._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckMoveStuck.TsDecoratorCheckMoveStuck_C");
		}
		return TsDecoratorCheckMoveStuck._ClassPtr;
	}

	// Token: 0x060037C6 RID: 14278 RVA: 0x0003B068 File Offset: 0x00039268
	public TsDecoratorCheckMoveStuck() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckMoveStuck.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x060037C7 RID: 14279 RVA: 0x0003B090 File Offset: 0x00039290
	[NullableContext(1)]
	public TsDecoratorCheckMoveStuck(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckMoveStuck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x060037C8 RID: 14280 RVA: 0x0003B0C4 File Offset: 0x000392C4
	protected TsDecoratorCheckMoveStuck(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x060037C9 RID: 14281 RVA: 0x0003B128 File Offset: 0x00039328
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x060037CA RID: 14282 RVA: 0x0003B15C File Offset: 0x0003935C
	protected unsafe virtual void __CPPCALL_ReceiveExecutionFinishAI_Implementation(UBTDecorator_BlueprintBase.__ReceiveExecutionFinishAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		EBTNodeResult nodeResult = __Params->NodeResult;
		this.ReceiveExecutionFinishAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, nodeResult);
	}

	// Token: 0x060037CB RID: 14283 RVA: 0x0003B198 File Offset: 0x00039398
	protected unsafe virtual void __CPPCALL_ReceiveObserverDeactivatedAI_Implementation(UBTDecorator_BlueprintBase.__ReceiveObserverDeactivatedAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		this.ReceiveObserverDeactivatedAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007F3 RID: 2035
	private bool IsInitTsVariables;

	// Token: 0x040007F4 RID: 2036
	private float TsMinMoveSpeedRate;

	// Token: 0x040007F5 RID: 2037
	private float TsStuckDuration;

	// Token: 0x040007F6 RID: 2038
	private double LastSampleTime;

	// Token: 0x040007F7 RID: 2039
	[Nullable(1)]
	private readonly Vector LastSampleLocation = Vector.Create();

	// Token: 0x040007F8 RID: 2040
	private double LowSpeedDuration;

	// Token: 0x040007F9 RID: 2041
	private bool HasSample;

	// Token: 0x040007FA RID: 2042
	[Nullable(1)]
	private readonly HashSet<ECharMoveState> RealGroundStates = new HashSet<ECharMoveState>
	{
		ECharMoveState.Walk,
		ECharMoveState.WalkStop,
		ECharMoveState.Run,
		ECharMoveState.RunStop,
		ECharMoveState.Sprint,
		ECharMoveState.SprintStop,
		ECharMoveState.Dodge
	};

	// Token: 0x040007FB RID: 2043
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckMoveStuck.TsDecoratorCheckMoveStuck_C";

	// Token: 0x040007FC RID: 2044
	private static IntPtr _ClassPtr;

	// Token: 0x040007FD RID: 2045
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x040007FE RID: 2046
	private static int __PropertyOffset_MinMoveSpeedRate;

	// Token: 0x040007FF RID: 2047
	private static int __PropertyOffset_StuckDuration;
}
