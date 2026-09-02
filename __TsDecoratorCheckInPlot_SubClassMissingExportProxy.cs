using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200355E RID: 13662
public class __TsDecoratorCheckInPlot_SubClassMissingExportProxy : __TsDecoratorCheckInPlot_InheritProxy
{
	// Token: 0x0601CB99 RID: 117657 RVA: 0x008B18FC File Offset: 0x008AFAFC
	[NullableContext(1)]
	protected __TsDecoratorCheckInPlot_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckInPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB9A RID: 117658 RVA: 0x008B192F File Offset: 0x008AFB2F
	protected __TsDecoratorCheckInPlot_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
