using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003682 RID: 13954
public class __TsTaskWait_SubClassMissingExportProxy : __TsTaskWait_InheritProxy
{
	// Token: 0x0601CEC4 RID: 118468 RVA: 0x008B8B54 File Offset: 0x008B6D54
	[NullableContext(1)]
	protected __TsTaskWait_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWait.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CEC5 RID: 118469 RVA: 0x008B8B87 File Offset: 0x008B6D87
	protected __TsTaskWait_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
