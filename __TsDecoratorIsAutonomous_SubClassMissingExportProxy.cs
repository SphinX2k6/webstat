using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200357A RID: 13690
public class __TsDecoratorIsAutonomous_SubClassMissingExportProxy : __TsDecoratorIsAutonomous_InheritProxy
{
	// Token: 0x0601CBE1 RID: 117729 RVA: 0x008B22D0 File Offset: 0x008B04D0
	[NullableContext(1)]
	protected __TsDecoratorIsAutonomous_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorIsAutonomous.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBE2 RID: 117730 RVA: 0x008B2303 File Offset: 0x008B0503
	protected __TsDecoratorIsAutonomous_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
