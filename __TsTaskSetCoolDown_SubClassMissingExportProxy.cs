using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200365C RID: 13916
public class __TsTaskSetCoolDown_SubClassMissingExportProxy : __TsTaskSetCoolDown_InheritProxy
{
	// Token: 0x0601CE59 RID: 118361 RVA: 0x008B7C24 File Offset: 0x008B5E24
	[NullableContext(1)]
	protected __TsTaskSetCoolDown_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetCoolDown.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE5A RID: 118362 RVA: 0x008B7C57 File Offset: 0x008B5E57
	protected __TsTaskSetCoolDown_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
