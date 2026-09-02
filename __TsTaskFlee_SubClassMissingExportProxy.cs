using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003624 RID: 13860
public class __TsTaskFlee_SubClassMissingExportProxy : __TsTaskFlee_InheritProxy
{
	// Token: 0x0601CDBF RID: 118207 RVA: 0x008B6678 File Offset: 0x008B4878
	[NullableContext(1)]
	protected __TsTaskFlee_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFlee.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDC0 RID: 118208 RVA: 0x008B66AB File Offset: 0x008B48AB
	protected __TsTaskFlee_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
