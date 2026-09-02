using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003527 RID: 13607
public class __TsDecoratorCheckVehicleHasRouteSpline_InheritProxy : TsDecoratorCheckVehicleHasRouteSpline
{
	// Token: 0x0601CB0F RID: 117519 RVA: 0x008B0668 File Offset: 0x008AE868
	[NullableContext(1)]
	public __TsDecoratorCheckVehicleHasRouteSpline_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckVehicleHasRouteSpline.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB10 RID: 117520 RVA: 0x008B069B File Offset: 0x008AE89B
	protected __TsDecoratorCheckVehicleHasRouteSpline_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CB11 RID: 117521 RVA: 0x008B06A4 File Offset: 0x008AE8A4
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
