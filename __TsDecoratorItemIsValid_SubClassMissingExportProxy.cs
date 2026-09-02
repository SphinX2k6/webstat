using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200357C RID: 13692
public class __TsDecoratorItemIsValid_SubClassMissingExportProxy : __TsDecoratorItemIsValid_InheritProxy
{
	// Token: 0x0601CBE6 RID: 117734 RVA: 0x008B237C File Offset: 0x008B057C
	[NullableContext(1)]
	protected __TsDecoratorItemIsValid_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorItemIsValid.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBE7 RID: 117735 RVA: 0x008B23AF File Offset: 0x008B05AF
	protected __TsDecoratorItemIsValid_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
