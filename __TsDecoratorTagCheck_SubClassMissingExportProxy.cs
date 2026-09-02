using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200358A RID: 13706
public class __TsDecoratorTagCheck_SubClassMissingExportProxy : __TsDecoratorTagCheck_InheritProxy
{
	// Token: 0x0601CC09 RID: 117769 RVA: 0x008B2830 File Offset: 0x008B0A30
	[NullableContext(1)]
	protected __TsDecoratorTagCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC0A RID: 117770 RVA: 0x008B2863 File Offset: 0x008B0A63
	protected __TsDecoratorTagCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
