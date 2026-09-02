using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003648 RID: 13896
public class __TsTaskPlayPlot_SubClassMissingExportProxy : __TsTaskPlayPlot_InheritProxy
{
	// Token: 0x0601CE25 RID: 118309 RVA: 0x008B7524 File Offset: 0x008B5724
	[NullableContext(1)]
	protected __TsTaskPlayPlot_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayPlot.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE26 RID: 118310 RVA: 0x008B7557 File Offset: 0x008B5757
	protected __TsTaskPlayPlot_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
