using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037B0 RID: 14256
public class __TsAnimNotifyDetach_SubClassMissingExportProxy : __TsAnimNotifyDetach_InheritProxy
{
	// Token: 0x0601D32D RID: 119597 RVA: 0x008C3978 File Offset: 0x008C1B78
	[NullableContext(1)]
	protected __TsAnimNotifyDetach_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyDetach.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D32E RID: 119598 RVA: 0x008C39AB File Offset: 0x008C1BAB
	protected __TsAnimNotifyDetach_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
