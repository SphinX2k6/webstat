using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200362B RID: 13867
public class __TsTaskGamePlayCallFinish_InheritProxy : TsTaskGamePlayCallFinish
{
	// Token: 0x0601CDD5 RID: 118229 RVA: 0x008B6A14 File Offset: 0x008B4C14
	[NullableContext(1)]
	public __TsTaskGamePlayCallFinish_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskGamePlayCallFinish.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDD6 RID: 118230 RVA: 0x008B6A47 File Offset: 0x008B4C47
	protected __TsTaskGamePlayCallFinish_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CDD7 RID: 118231 RVA: 0x008B6A50 File Offset: 0x008B4C50
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
