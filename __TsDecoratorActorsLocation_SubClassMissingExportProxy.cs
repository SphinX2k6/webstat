using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003542 RID: 13634
public class __TsDecoratorActorsLocation_SubClassMissingExportProxy : __TsDecoratorActorsLocation_InheritProxy
{
	// Token: 0x0601CB53 RID: 117587 RVA: 0x008B0F94 File Offset: 0x008AF194
	[NullableContext(1)]
	protected __TsDecoratorActorsLocation_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorActorsLocation.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB54 RID: 117588 RVA: 0x008B0FC7 File Offset: 0x008AF1C7
	protected __TsDecoratorActorsLocation_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
