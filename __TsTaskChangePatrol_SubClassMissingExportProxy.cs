using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200360A RID: 13834
public class __TsTaskChangePatrol_SubClassMissingExportProxy : __TsTaskChangePatrol_InheritProxy
{
	// Token: 0x0601CD79 RID: 118137 RVA: 0x008B5CD8 File Offset: 0x008B3ED8
	[NullableContext(1)]
	protected __TsTaskChangePatrol_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskChangePatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD7A RID: 118138 RVA: 0x008B5D0B File Offset: 0x008B3F0B
	protected __TsTaskChangePatrol_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
