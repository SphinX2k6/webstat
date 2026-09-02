using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D5 RID: 14549
public class __TsVehicleBlueprintFunctionLibrary_InheritProxy : TsVehicleBlueprintFunctionLibrary
{
	// Token: 0x0601D6C5 RID: 120517 RVA: 0x008CBCEC File Offset: 0x008C9EEC
	[NullableContext(1)]
	public __TsVehicleBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsVehicleBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6C6 RID: 120518 RVA: 0x008CBD1F File Offset: 0x008C9F1F
	protected __TsVehicleBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
