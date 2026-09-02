using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200353A RID: 13626
public class __TsDecoratorTimeSpanCheck_SubClassMissingExportProxy : __TsDecoratorTimeSpanCheck_InheritProxy
{
	// Token: 0x0601CB3F RID: 117567 RVA: 0x008B0CE4 File Offset: 0x008AEEE4
	[NullableContext(1)]
	protected __TsDecoratorTimeSpanCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTimeSpanCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB40 RID: 117568 RVA: 0x008B0D17 File Offset: 0x008AEF17
	protected __TsDecoratorTimeSpanCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
