using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003972 RID: 14706
public class __TsHotPatchPanelConfig_SubClassMissingExportProxy : __TsHotPatchPanelConfig_InheritProxy
{
	// Token: 0x0601DA05 RID: 121349 RVA: 0x008D65D4 File Offset: 0x008D47D4
	[NullableContext(1)]
	protected __TsHotPatchPanelConfig_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHotPatchPanelConfig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA06 RID: 121350 RVA: 0x008D6607 File Offset: 0x008D4807
	protected __TsHotPatchPanelConfig_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
