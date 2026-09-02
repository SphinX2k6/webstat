using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200351F RID: 13599
public class __TsDecoratorCheckNpcArrivedSplineEnd_InheritProxy : TsDecoratorCheckNpcArrivedSplineEnd
{
	// Token: 0x0601CAFB RID: 117499 RVA: 0x008B03B8 File Offset: 0x008AE5B8
	[NullableContext(1)]
	public __TsDecoratorCheckNpcArrivedSplineEnd_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckNpcArrivedSplineEnd.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CAFC RID: 117500 RVA: 0x008B03EB File Offset: 0x008AE5EB
	protected __TsDecoratorCheckNpcArrivedSplineEnd_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CAFD RID: 117501 RVA: 0x008B03F4 File Offset: 0x008AE5F4
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
