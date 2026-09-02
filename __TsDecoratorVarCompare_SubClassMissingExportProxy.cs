using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200353C RID: 13628
public class __TsDecoratorVarCompare_SubClassMissingExportProxy : __TsDecoratorVarCompare_InheritProxy
{
	// Token: 0x0601CB44 RID: 117572 RVA: 0x008B0D90 File Offset: 0x008AEF90
	[NullableContext(1)]
	protected __TsDecoratorVarCompare_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorVarCompare.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB45 RID: 117573 RVA: 0x008B0DC3 File Offset: 0x008AEFC3
	protected __TsDecoratorVarCompare_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
