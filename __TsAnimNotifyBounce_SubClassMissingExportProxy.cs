using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003786 RID: 14214
public class __TsAnimNotifyBounce_SubClassMissingExportProxy : __TsAnimNotifyBounce_InheritProxy
{
	// Token: 0x0601D2AF RID: 119471 RVA: 0x008C29B8 File Offset: 0x008C0BB8
	[NullableContext(1)]
	protected __TsAnimNotifyBounce_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBounce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D2B0 RID: 119472 RVA: 0x008C29EB File Offset: 0x008C0BEB
	protected __TsAnimNotifyBounce_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
