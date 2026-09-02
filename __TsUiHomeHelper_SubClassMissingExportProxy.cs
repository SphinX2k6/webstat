using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003878 RID: 14456
public class __TsUiHomeHelper_SubClassMissingExportProxy : __TsUiHomeHelper_InheritProxy
{
	// Token: 0x0601D5D5 RID: 120277 RVA: 0x008CA03C File Offset: 0x008C823C
	[NullableContext(1)]
	protected __TsUiHomeHelper_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsUiHomeHelper.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5D6 RID: 120278 RVA: 0x008CA06F File Offset: 0x008C826F
	protected __TsUiHomeHelper_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
