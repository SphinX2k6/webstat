using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200364C RID: 13900
public class __TsTaskPortal_SubClassMissingExportProxy : __TsTaskPortal_InheritProxy
{
	// Token: 0x0601CE30 RID: 118320 RVA: 0x008B76A8 File Offset: 0x008B58A8
	[NullableContext(1)]
	protected __TsTaskPortal_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPortal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE31 RID: 118321 RVA: 0x008B76DB File Offset: 0x008B58DB
	protected __TsTaskPortal_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
