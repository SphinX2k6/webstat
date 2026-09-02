using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038DD RID: 14557
public class __TsBaseItem_InheritProxy : TsBaseItem
{
	// Token: 0x0601D6EC RID: 120556 RVA: 0x008CC420 File Offset: 0x008CA620
	[NullableContext(1)]
	public __TsBaseItem_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBaseItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6ED RID: 120557 RVA: 0x008CC453 File Offset: 0x008CA653
	protected __TsBaseItem_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D6EE RID: 120558 RVA: 0x008CC45C File Offset: 0x008CA65C
	protected override void __CPPCALL_ReceiveBeginPlay_Implementation()
	{
		base.ReceiveBeginPlay_Implementation();
	}

	// Token: 0x0601D6EF RID: 120559 RVA: 0x008CC464 File Offset: 0x008CA664
	protected unsafe override void __CPPCALL_GetTagDebugStrings_Implementation(TsBaseItem.__GetTagDebugStrings_FunctionParams* __Params)
	{
		FString.CopyFrom((void*)(&__Params->__Result), base.GetTagDebugStrings_Implementation());
	}
}
