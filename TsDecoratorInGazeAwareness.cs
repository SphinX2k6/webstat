using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C5F RID: 3167
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInGazeAwareness.TsDecoratorInGazeAwareness_C")]
public class TsDecoratorInGazeAwareness : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x17000144 RID: 324
	// (get) Token: 0x06003837 RID: 14391 RVA: 0x0003CAC3 File Offset: 0x0003ACC3
	// (set) Token: 0x06003838 RID: 14392 RVA: 0x0003CAD3 File Offset: 0x0003ACD3
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float GazeTime
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorInGazeAwareness.__PropertyOffset_GazeTime);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorInGazeAwareness.__PropertyOffset_GazeTime) = value;
		}
	}

	// Token: 0x06003839 RID: 14393 RVA: 0x0003CAE4 File Offset: 0x0003ACE4
	private void InitTsVariables()
	{
		if (!this.IsInitTsVariables || GlobalData.IsPlayInEditor)
		{
			this.IsInitTsVariables = true;
			this.TsGazeTime = this.GazeTime * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x0600383A RID: 14394 RVA: 0x0003CB18 File Offset: 0x0003AD18
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

	// Token: 0x0600383B RID: 14395 RVA: 0x0003CBB8 File Offset: 0x0003ADB8
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		TsAiController tsAiController = ownerController as TsAiController;
		AiController aiController = (tsAiController != null) ? tsAiController.AiController : null;
		if (aiController == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.BehaviorTree;
			ELogAuthor author = ELogAuthor.ZJL;
			string message = "错误的Controller类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", ownerController.GetClass().GetName());
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		this.InitTsVariables();
		CharacterActorComponent charActorComp = aiController.CharActorComp;
		if (charActorComp == null || !charActorComp.Valid)
		{
			return false;
		}
		IdlePerformModel instance2 = ModelBase<IdlePerformModel>.Instance;
		return instance2 != null && instance2.CheckGazeAwarenessByEntityId(charActorComp.Entity.Id, this.TsGazeTime);
	}

	// Token: 0x0600383C RID: 14396 RVA: 0x0003CC54 File Offset: 0x0003AE54
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorInGazeAwareness._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInGazeAwareness.TsDecoratorInGazeAwareness_C");
		}
		return TsDecoratorInGazeAwareness._ClassPtr;
	}

	// Token: 0x0600383D RID: 14397 RVA: 0x0003CC78 File Offset: 0x0003AE78
	public TsDecoratorInGazeAwareness() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorInGazeAwareness.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0600383E RID: 14398 RVA: 0x0003CCA0 File Offset: 0x0003AEA0
	[NullableContext(1)]
	public TsDecoratorInGazeAwareness(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorInGazeAwareness.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600383F RID: 14399 RVA: 0x0003CCD3 File Offset: 0x0003AED3
	protected TsDecoratorInGazeAwareness(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003840 RID: 14400 RVA: 0x0003CCDC File Offset: 0x0003AEDC
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000843 RID: 2115
	private bool IsInitTsVariables;

	// Token: 0x04000844 RID: 2116
	private float TsGazeTime;

	// Token: 0x04000845 RID: 2117
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorInGazeAwareness.TsDecoratorInGazeAwareness_C";

	// Token: 0x04000846 RID: 2118
	private static IntPtr _ClassPtr;

	// Token: 0x04000847 RID: 2119
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x04000848 RID: 2120
	private static int __PropertyOffset_GazeTime;
}
