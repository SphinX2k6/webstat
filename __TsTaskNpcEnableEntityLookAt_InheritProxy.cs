using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035BB RID: 13755
public class __TsTaskNpcEnableEntityLookAt_InheritProxy : TsTaskNpcEnableEntityLookAt
{
	// Token: 0x0601CC8A RID: 117898 RVA: 0x008B39AC File Offset: 0x008B1BAC
	[NullableContext(1)]
	public __TsTaskNpcEnableEntityLookAt_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcEnableEntityLookAt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC8B RID: 117899 RVA: 0x008B39DF File Offset: 0x008B1BDF
	protected __TsTaskNpcEnableEntityLookAt_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CC8C RID: 117900 RVA: 0x008B39E8 File Offset: 0x008B1BE8
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
