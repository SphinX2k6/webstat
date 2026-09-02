using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003877 RID: 14455
public class __TsUiHomeHelper_InheritProxy : TsUiHomeHelper
{
	// Token: 0x0601D5D3 RID: 120275 RVA: 0x008CA000 File Offset: 0x008C8200
	[NullableContext(1)]
	public __TsUiHomeHelper_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHomeHelper.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5D4 RID: 120276 RVA: 0x008CA033 File Offset: 0x008C8233
	protected __TsUiHomeHelper_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
