using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003660 RID: 13920
public class __TsTaskSetSightToTarget_SubClassMissingExportProxy : __TsTaskSetSightToTarget_InheritProxy
{
	// Token: 0x0601CE63 RID: 118371 RVA: 0x008B7D78 File Offset: 0x008B5F78
	[NullableContext(1)]
	protected __TsTaskSetSightToTarget_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetSightToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE64 RID: 118372 RVA: 0x008B7DAB File Offset: 0x008B5FAB
	protected __TsTaskSetSightToTarget_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
