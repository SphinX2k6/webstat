using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003868 RID: 14440
public class __PlotActorBlueprintFunctionLibrary_SubClassMissingExportProxy : __PlotActorBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D5A9 RID: 120233 RVA: 0x008C9B0C File Offset: 0x008C7D0C
	[NullableContext(1)]
	protected __PlotActorBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5AA RID: 120234 RVA: 0x008C9B3F File Offset: 0x008C7D3F
	protected __PlotActorBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
