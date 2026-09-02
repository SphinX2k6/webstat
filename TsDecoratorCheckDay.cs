using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Common.Enum;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x02000C4E RID: 3150
[UClass("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDay.TsDecoratorCheckDay_C")]
public class TsDecoratorCheckDay : UBTDecorator_BlueprintBase, IUnrealUObject, IUnrealObject
{
	// Token: 0x1700012C RID: 300
	// (get) Token: 0x0600377D RID: 14205 RVA: 0x00039CB3 File Offset: 0x00037EB3
	// (set) Token: 0x0600377E RID: 14206 RVA: 0x00039CBB File Offset: 0x00037EBB
	public EDayState CheckDayState { get; set; }

	// Token: 0x0600377F RID: 14207 RVA: 0x00039CC4 File Offset: 0x00037EC4
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

	// Token: 0x06003780 RID: 14208 RVA: 0x00039D64 File Offset: 0x00037F64
	[NullableContext(2)]
	protected virtual bool PerformConditionCheckAI_Implementation(AAIController ownerController, APawn controlledPawn)
	{
		bool result;
		if (this.CheckDayState == EDayState.白天)
		{
			result = ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(360, 1080);
		}
		else
		{
			result = !ControllerBase<TimeOfDayController>.Instance.CheckInMinuteSpan(360, 1080);
		}
		return result;
	}

	// Token: 0x06003781 RID: 14209 RVA: 0x00039DAB File Offset: 0x00037FAB
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsDecoratorCheckDay._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDay.TsDecoratorCheckDay_C");
		}
		return TsDecoratorCheckDay._ClassPtr;
	}

	// Token: 0x06003782 RID: 14210 RVA: 0x00039DD0 File Offset: 0x00037FD0
	public TsDecoratorCheckDay() : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckDay.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x06003783 RID: 14211 RVA: 0x00039DF8 File Offset: 0x00037FF8
	[NullableContext(1)]
	public TsDecoratorCheckDay(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckDay.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x06003784 RID: 14212 RVA: 0x00039E2B File Offset: 0x0003802B
	protected TsDecoratorCheckDay(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x06003785 RID: 14213 RVA: 0x00039E34 File Offset: 0x00038034
	protected unsafe virtual void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = this.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}

	// Token: 0x040007CE RID: 1998
	private const int DAY_MINITE_START = 360;

	// Token: 0x040007CF RID: 1999
	private const int DAY_MINITE_END = 1080;

	// Token: 0x040007D1 RID: 2001
	[Nullable(1)]
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/AI/BehaviorTree/Decorator/TsDecoratorCheckDay.TsDecoratorCheckDay_C";

	// Token: 0x040007D2 RID: 2002
	private static IntPtr _ClassPtr;

	// Token: 0x040007D3 RID: 2003
	private static IntPtr _ClassDefaultObjectPtr;
}
