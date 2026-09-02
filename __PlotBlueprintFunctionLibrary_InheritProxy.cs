using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003869 RID: 14441
public class __PlotBlueprintFunctionLibrary_InheritProxy : PlotBlueprintFunctionLibrary
{
	// Token: 0x0601D5AB RID: 120235 RVA: 0x008C9B48 File Offset: 0x008C7D48
	[NullableContext(1)]
	public __PlotBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PlotBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5AC RID: 120236 RVA: 0x008C9B7B File Offset: 0x008C7D7B
	protected __PlotBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
