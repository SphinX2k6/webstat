using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037D0 RID: 14288
public class __TsAnimNotifyHideBone_SubClassMissingExportProxy : __TsAnimNotifyHideBone_InheritProxy
{
	// Token: 0x0601D38D RID: 119693 RVA: 0x008C4578 File Offset: 0x008C2778
	[NullableContext(1)]
	protected __TsAnimNotifyHideBone_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyHideBone.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D38E RID: 119694 RVA: 0x008C45AB File Offset: 0x008C27AB
	protected __TsAnimNotifyHideBone_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
