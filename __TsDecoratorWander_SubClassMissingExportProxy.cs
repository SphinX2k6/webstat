using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003590 RID: 13712
public class __TsDecoratorWander_SubClassMissingExportProxy : __TsDecoratorWander_InheritProxy
{
	// Token: 0x0601CC18 RID: 117784 RVA: 0x008B2A34 File Offset: 0x008B0C34
	[NullableContext(1)]
	protected __TsDecoratorWander_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC19 RID: 117785 RVA: 0x008B2A67 File Offset: 0x008B0C67
	protected __TsDecoratorWander_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
