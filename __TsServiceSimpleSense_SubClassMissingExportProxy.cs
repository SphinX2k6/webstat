using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003598 RID: 13720
public class __TsServiceSimpleSense_SubClassMissingExportProxy : __TsServiceSimpleSense_InheritProxy
{
	// Token: 0x0601CC2D RID: 117805 RVA: 0x008B2D14 File Offset: 0x008B0F14
	[NullableContext(1)]
	protected __TsServiceSimpleSense_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceSimpleSense.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC2E RID: 117806 RVA: 0x008B2D47 File Offset: 0x008B0F47
	protected __TsServiceSimpleSense_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
