using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003638 RID: 13880
public class __TsTaskMoveToLocation_SubClassMissingExportProxy : __TsTaskMoveToLocation_InheritProxy
{
	// Token: 0x0601CDF9 RID: 118265 RVA: 0x008B6F14 File Offset: 0x008B5114
	[NullableContext(1)]
	protected __TsTaskMoveToLocation_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDFA RID: 118266 RVA: 0x008B6F47 File Offset: 0x008B5147
	protected __TsTaskMoveToLocation_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
