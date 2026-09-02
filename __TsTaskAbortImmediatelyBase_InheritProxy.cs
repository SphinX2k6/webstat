using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035E5 RID: 13797
public class __TsTaskAbortImmediatelyBase_InheritProxy : TsTaskAbortImmediatelyBase
{
	// Token: 0x0601CCFF RID: 118015 RVA: 0x008B49E4 File Offset: 0x008B2BE4
	[NullableContext(1)]
	public __TsTaskAbortImmediatelyBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAbortImmediatelyBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD00 RID: 118016 RVA: 0x008B4A17 File Offset: 0x008B2C17
	protected __TsTaskAbortImmediatelyBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CD01 RID: 118017 RVA: 0x008B4A20 File Offset: 0x008B2C20
	protected unsafe override void __CPPCALL_ReceiveAbortAI_Implementation(UBTTask_BlueprintBase.__ReceiveAbortAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveAbortAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
