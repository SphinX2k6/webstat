using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003834 RID: 14388
public class __TsStartupPlayerController_SubClassMissingExportProxy : __TsStartupPlayerController_InheritProxy
{
	// Token: 0x0601D4EF RID: 120047 RVA: 0x008C79B8 File Offset: 0x008C5BB8
	[NullableContext(1)]
	protected __TsStartupPlayerController_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsStartupPlayerController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4F0 RID: 120048 RVA: 0x008C79EB File Offset: 0x008C5BEB
	protected __TsStartupPlayerController_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
