using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003523 RID: 13603
public class __TsDecoratorCheckNpcOnVehicleWaiting_InheritProxy : TsDecoratorCheckNpcOnVehicleWaiting
{
	// Token: 0x0601CB05 RID: 117509 RVA: 0x008B0510 File Offset: 0x008AE710
	[NullableContext(1)]
	public __TsDecoratorCheckNpcOnVehicleWaiting_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckNpcOnVehicleWaiting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB06 RID: 117510 RVA: 0x008B0543 File Offset: 0x008AE743
	protected __TsDecoratorCheckNpcOnVehicleWaiting_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CB07 RID: 117511 RVA: 0x008B054C File Offset: 0x008AE74C
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
