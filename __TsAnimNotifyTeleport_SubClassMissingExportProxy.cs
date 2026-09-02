using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003810 RID: 14352
public class __TsAnimNotifyTeleport_SubClassMissingExportProxy : __TsAnimNotifyTeleport_InheritProxy
{
	// Token: 0x0601D44B RID: 119883 RVA: 0x008C5D30 File Offset: 0x008C3F30
	[NullableContext(1)]
	protected __TsAnimNotifyTeleport_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyTeleport.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D44C RID: 119884 RVA: 0x008C5D63 File Offset: 0x008C3F63
	protected __TsAnimNotifyTeleport_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
