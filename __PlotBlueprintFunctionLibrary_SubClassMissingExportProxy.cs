using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386A RID: 14442
public class __PlotBlueprintFunctionLibrary_SubClassMissingExportProxy : __PlotBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D5AD RID: 120237 RVA: 0x008C9B84 File Offset: 0x008C7D84
	[NullableContext(1)]
	protected __PlotBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5AE RID: 120238 RVA: 0x008C9BB7 File Offset: 0x008C7DB7
	protected __PlotBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
