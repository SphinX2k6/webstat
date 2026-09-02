using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003974 RID: 14708
public class __TsSplash_SubClassMissingExportProxy : __TsSplash_InheritProxy
{
	// Token: 0x0601DA09 RID: 121353 RVA: 0x008D664C File Offset: 0x008D484C
	[NullableContext(1)]
	protected __TsSplash_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSplash.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA0A RID: 121354 RVA: 0x008D667F File Offset: 0x008D487F
	protected __TsSplash_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
