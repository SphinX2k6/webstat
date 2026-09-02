using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037A8 RID: 14248
public class __TsAnimNotifyClientEvent_SubClassMissingExportProxy : __TsAnimNotifyClientEvent_InheritProxy
{
	// Token: 0x0601D315 RID: 119573 RVA: 0x008C3678 File Offset: 0x008C1878
	[NullableContext(1)]
	protected __TsAnimNotifyClientEvent_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyClientEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D316 RID: 119574 RVA: 0x008C36AB File Offset: 0x008C18AB
	protected __TsAnimNotifyClientEvent_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
