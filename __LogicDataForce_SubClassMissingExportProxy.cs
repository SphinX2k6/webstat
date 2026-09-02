using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389E RID: 14494
public class __LogicDataForce_SubClassMissingExportProxy : __LogicDataForce_InheritProxy
{
	// Token: 0x0601D63F RID: 120383 RVA: 0x008CAAA0 File Offset: 0x008C8CA0
	[NullableContext(1)]
	protected __LogicDataForce_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataForce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D640 RID: 120384 RVA: 0x008CAAD3 File Offset: 0x008C8CD3
	protected __LogicDataForce_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
