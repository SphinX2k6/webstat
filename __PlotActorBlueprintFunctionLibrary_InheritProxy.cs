using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003867 RID: 14439
public class __PlotActorBlueprintFunctionLibrary_InheritProxy : PlotActorBlueprintFunctionLibrary
{
	// Token: 0x0601D5A7 RID: 120231 RVA: 0x008C9AD0 File Offset: 0x008C7CD0
	[NullableContext(1)]
	public __PlotActorBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5A8 RID: 120232 RVA: 0x008C9B03 File Offset: 0x008C7D03
	protected __PlotActorBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
