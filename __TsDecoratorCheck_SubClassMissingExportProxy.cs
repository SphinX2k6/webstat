using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200351A RID: 13594
public class __TsDecoratorCheck_SubClassMissingExportProxy : __TsDecoratorCheck_InheritProxy
{
	// Token: 0x0601CAEF RID: 117487 RVA: 0x008B0224 File Offset: 0x008AE424
	[NullableContext(1)]
	protected __TsDecoratorCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CAF0 RID: 117488 RVA: 0x008B0257 File Offset: 0x008AE457
	protected __TsDecoratorCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
