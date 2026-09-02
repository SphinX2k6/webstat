using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003607 RID: 13831
public class __TsTaskChangeMoveSpeed_InheritProxy : TsTaskChangeMoveSpeed
{
	// Token: 0x0601CD71 RID: 118129 RVA: 0x008B5BC4 File Offset: 0x008B3DC4
	[NullableContext(1)]
	public __TsTaskChangeMoveSpeed_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangeMoveSpeed.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD72 RID: 118130 RVA: 0x008B5BF7 File Offset: 0x008B3DF7
	protected __TsTaskChangeMoveSpeed_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601CD73 RID: 118131 RVA: 0x008B5C00 File Offset: 0x008B3E00
	protected unsafe override void __CPPCALL_ReceiveExecuteAI_Implementation(UBTTask_BlueprintBase.__ReceiveExecuteAI_FunctionParams* __Params)
	{
		AAIController orCreateUObjectByNativePointer = BuiltinUtils.GetOrCreateUObjectByNativePointer<AAIController>(__Params->OwnerController);
		APawn orCreateUObjectByNativePointer2 = BuiltinUtils.GetOrCreateUObjectByNativePointer<APawn>(__Params->ControlledPawn);
		base.ReceiveExecuteAI_Implementation(orCreateUObjectByNativePointer, orCreateUObjectByNativePointer2);
	}
}
