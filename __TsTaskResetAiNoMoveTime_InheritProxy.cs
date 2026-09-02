using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003653 RID: 13907
public class __TsTaskResetAiNoMoveTime_InheritProxy : TsTaskResetAiNoMoveTime
{
	// Token: 0x0601CE42 RID: 118338 RVA: 0x008B7914 File Offset: 0x008B5B14
	[NullableContext(1)]
	public __TsTaskResetAiNoMoveTime_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskResetAiNoMoveTime.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE43 RID: 118339 RVA: 0x008B7947 File Offset: 0x008B5B47
	protected __TsTaskResetAiNoMoveTime_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CE44 RID: 118340 RVA: 0x008B7950 File Offset: 0x008B5B50
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
