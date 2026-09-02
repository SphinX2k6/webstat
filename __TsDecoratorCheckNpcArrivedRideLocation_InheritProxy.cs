using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200351D RID: 13597
public class __TsDecoratorCheckNpcArrivedRideLocation_InheritProxy : TsDecoratorCheckNpcArrivedRideLocation
{
	// Token: 0x0601CAF6 RID: 117494 RVA: 0x008B030C File Offset: 0x008AE50C
	[NullableContext(1)]
	public __TsDecoratorCheckNpcArrivedRideLocation_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckNpcArrivedRideLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CAF7 RID: 117495 RVA: 0x008B033F File Offset: 0x008AE53F
	protected __TsDecoratorCheckNpcArrivedRideLocation_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CAF8 RID: 117496 RVA: 0x008B0348 File Offset: 0x008AE548
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
