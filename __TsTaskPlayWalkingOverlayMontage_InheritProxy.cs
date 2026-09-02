using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003649 RID: 13897
public class __TsTaskPlayWalkingOverlayMontage_InheritProxy : TsTaskPlayWalkingOverlayMontage
{
	// Token: 0x0601CE27 RID: 118311 RVA: 0x008B7560 File Offset: 0x008B5760
	[NullableContext(1)]
	public __TsTaskPlayWalkingOverlayMontage_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayWalkingOverlayMontage.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE28 RID: 118312 RVA: 0x008B7593 File Offset: 0x008B5793
	protected __TsTaskPlayWalkingOverlayMontage_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CE29 RID: 118313 RVA: 0x008B759C File Offset: 0x008B579C
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
