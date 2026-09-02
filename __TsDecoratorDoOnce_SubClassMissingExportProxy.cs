using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003530 RID: 13616
public class __TsDecoratorDoOnce_SubClassMissingExportProxy : __TsDecoratorDoOnce_InheritProxy
{
	// Token: 0x0601CB26 RID: 117542 RVA: 0x008B0988 File Offset: 0x008AEB88
	[NullableContext(1)]
	protected __TsDecoratorDoOnce_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDoOnce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB27 RID: 117543 RVA: 0x008B09BB File Offset: 0x008AEBBB
	protected __TsDecoratorDoOnce_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
