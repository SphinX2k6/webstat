using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035B6 RID: 13750
public class __TsTaskLog_SubClassMissingExportProxy : __TsTaskLog_InheritProxy
{
	// Token: 0x0601CC7D RID: 117885 RVA: 0x008B37EC File Offset: 0x008B19EC
	[NullableContext(1)]
	protected __TsTaskLog_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskLog.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC7E RID: 117886 RVA: 0x008B381F File Offset: 0x008B1A1F
	protected __TsTaskLog_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
