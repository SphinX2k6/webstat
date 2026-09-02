using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200378A RID: 14218
public class __TsAnimNotifyBreakPoint_SubClassMissingExportProxy : __TsAnimNotifyBreakPoint_InheritProxy
{
	// Token: 0x0601D2BB RID: 119483 RVA: 0x008C2B38 File Offset: 0x008C0D38
	[NullableContext(1)]
	protected __TsAnimNotifyBreakPoint_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBreakPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D2BC RID: 119484 RVA: 0x008C2B6B File Offset: 0x008C0D6B
	protected __TsAnimNotifyBreakPoint_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
