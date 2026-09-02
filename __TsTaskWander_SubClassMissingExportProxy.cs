using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003684 RID: 13956
public class __TsTaskWander_SubClassMissingExportProxy : __TsTaskWander_InheritProxy
{
	// Token: 0x0601CECA RID: 118474 RVA: 0x008B8C30 File Offset: 0x008B6E30
	[NullableContext(1)]
	protected __TsTaskWander_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CECB RID: 118475 RVA: 0x008B8C63 File Offset: 0x008B6E63
	protected __TsTaskWander_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
