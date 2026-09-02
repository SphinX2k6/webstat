using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200382D RID: 14381
public class __TsAxisHandle_InheritProxy : TsAxisHandle
{
	// Token: 0x0601D4AE RID: 119982 RVA: 0x008C6BE4 File Offset: 0x008C4DE4
	[NullableContext(1)]
	public __TsAxisHandle_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAxisHandle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4AF RID: 119983 RVA: 0x008C6C17 File Offset: 0x008C4E17
	protected __TsAxisHandle_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601D4B0 RID: 119984 RVA: 0x008C6C20 File Offset: 0x008C4E20
	protected unsafe override void __CPPCALL_OnInputAxis_Implementation(TsAxisHandle.__OnInputAxis_FunctionParams* __Params)
	{
		base.OnInputAxis_Implementation(__Params->value);
	}
}
