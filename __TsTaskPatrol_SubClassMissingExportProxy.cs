using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200363A RID: 13882
public class __TsTaskPatrol_SubClassMissingExportProxy : __TsTaskPatrol_InheritProxy
{
	// Token: 0x0601CDFF RID: 118271 RVA: 0x008B6FF0 File Offset: 0x008B51F0
	[NullableContext(1)]
	protected __TsTaskPatrol_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE00 RID: 118272 RVA: 0x008B7023 File Offset: 0x008B5223
	protected __TsTaskPatrol_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
