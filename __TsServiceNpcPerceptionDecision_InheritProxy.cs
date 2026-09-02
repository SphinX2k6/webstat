using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003595 RID: 13717
public class __TsServiceNpcPerceptionDecision_InheritProxy : TsServiceNpcPerceptionDecision
{
	// Token: 0x0601CC25 RID: 117797 RVA: 0x008B2BF8 File Offset: 0x008B0DF8
	[NullableContext(1)]
	public __TsServiceNpcPerceptionDecision_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceNpcPerceptionDecision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC26 RID: 117798 RVA: 0x008B2C2B File Offset: 0x008B0E2B
	protected __TsServiceNpcPerceptionDecision_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CC27 RID: 117799 RVA: 0x008B2C34 File Offset: 0x008B0E34
	protected unsafe override void __CPPCALL_ReceiveTickAI_Implementation(UBTService_BlueprintBase.__ReceiveTickAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveTickAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2, __Params->DeltaSeconds);
	}
}
