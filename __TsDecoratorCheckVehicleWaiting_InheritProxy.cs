using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200352B RID: 13611
public class __TsDecoratorCheckVehicleWaiting_InheritProxy : TsDecoratorCheckVehicleWaiting
{
	// Token: 0x0601CB19 RID: 117529 RVA: 0x008B07C0 File Offset: 0x008AE9C0
	[NullableContext(1)]
	public __TsDecoratorCheckVehicleWaiting_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckVehicleWaiting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB1A RID: 117530 RVA: 0x008B07F3 File Offset: 0x008AE9F3
	protected __TsDecoratorCheckVehicleWaiting_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CB1B RID: 117531 RVA: 0x008B07FC File Offset: 0x008AE9FC
	protected unsafe override void __CPPCALL_PerformConditionCheckAI_Implementation(UBTDecorator_BlueprintBase.__PerformConditionCheckAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		__Params->__Result = base.PerformConditionCheckAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
