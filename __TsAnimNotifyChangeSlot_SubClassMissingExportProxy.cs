using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037A0 RID: 14240
public class __TsAnimNotifyChangeSlot_SubClassMissingExportProxy : __TsAnimNotifyChangeSlot_InheritProxy
{
	// Token: 0x0601D2FD RID: 119549 RVA: 0x008C3378 File Offset: 0x008C1578
	[NullableContext(1)]
	protected __TsAnimNotifyChangeSlot_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyChangeSlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D2FE RID: 119550 RVA: 0x008C33AB File Offset: 0x008C15AB
	protected __TsAnimNotifyChangeSlot_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
