using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003582 RID: 13698
public class __TsDecoratorPlayerIdle_SubClassMissingExportProxy : __TsDecoratorPlayerIdle_InheritProxy
{
	// Token: 0x0601CBF5 RID: 117749 RVA: 0x008B2580 File Offset: 0x008B0780
	[NullableContext(1)]
	protected __TsDecoratorPlayerIdle_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorPlayerIdle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBF6 RID: 117750 RVA: 0x008B25B3 File Offset: 0x008B07B3
	protected __TsDecoratorPlayerIdle_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
