using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003614 RID: 13844
public class __TsTaskExecuteEvent_SubClassMissingExportProxy : __TsTaskExecuteEvent_InheritProxy
{
	// Token: 0x0601CD96 RID: 118166 RVA: 0x008B6104 File Offset: 0x008B4304
	[NullableContext(1)]
	protected __TsTaskExecuteEvent_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskExecuteEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD97 RID: 118167 RVA: 0x008B6137 File Offset: 0x008B4337
	protected __TsTaskExecuteEvent_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
