using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C65 RID: 3173
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorPlayerIdle.TsDecoratorPlayerIdle_C")]
public class TsDecoratorPlayerIdle : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700014A RID: 330
	// (get) Token: 0x06003872 RID: 14450 RVA: 0x0003D9EB File Offset: 0x0003BBEB
	// (set) Token: 0x06003873 RID: 14451 RVA: 0x0003D9FB File Offset: 0x0003BBFB
	[UProperty(EPropertyFlags.CPF_None)]
	public unsafe float IdleTimeThreshold
	{
		get
		{
			return *(base.NativePtr + (IntPtr)TsDecoratorPlayerIdle.__PropertyOffset_IdleTimeThreshold);
		}
		set
		{
			*(base.NativePtr + (IntPtr)TsDecoratorPlayerIdle.__PropertyOffset_IdleTimeThreshold) = value;
		}
	}

	// Token: 0x06003874 RID: 14452 RVA: 0x0003DA0C File Offset: 0x0003BC0C
	private void InitTsVariables()
	{
		if (this.TsIdleTimeThreshold == 0f || GlobalData.IsPlayInEditor)
		{
			this.TsIdleTimeThreshold = this.IdleTimeThreshold * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
		}
	}

	// Token: 0x06003875 RID: 14453 RVA: 0x0003DA3C File Offset: 0x0003BC3C
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

	// Token: 0x06003876 RID: 14454 RVA: 0x0003DADB File Offset: 0x0003BCDB
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		this.InitTsVariables();
		return ModelBase<IdlePerformModel>.Instance.GetIdleTime() >= this.TsIdleTimeThreshold;
	}

	// Token: 0x06003877 RID: 14455 RVA: 0x0003DAF8 File Offset: 0x0003BCF8
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorPlayerIdle._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorPlayerIdle.TsDecoratorPlayerIdle_C");
		}
		return TsDecoratorPlayerIdle._ClassPtr;
	}

	// Token: 0x06003878 RID: 14456 RVA: 0x0003DB1C File Offset: 0x0003BD1C
	public TsDecoratorPlayerIdle() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerIdle.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003879 RID: 14457 RVA: 0x0003DB44 File Offset: 0x0003BD44
	[NullableContext(1)]
	public TsDecoratorPlayerIdle(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerIdle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0600387A RID: 14458 RVA: 0x0003DB77 File Offset: 0x0003BD77
	protected TsDecoratorPlayerIdle(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0600387B RID: 14459 RVA: 0x0003DB80 File Offset: 0x0003BD80
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x04000867 RID: 2151
	private float TsIdleTimeThreshold;

	// Token: 0x04000868 RID: 2152
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorPlayerIdle.TsDecoratorPlayerIdle_C";

	// Token: 0x04000869 RID: 2153
	private static IntPtr _ClassPtr;

	// Token: 0x0400086A RID: 2154
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400086B RID: 2155
	private static int __PropertyOffset_IdleTimeThreshold;
}
