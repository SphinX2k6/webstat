using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200385B RID: 14427
public class __TsHideActorBlueprintFunctionLibrary_InheritProxy : TsHideActorBlueprintFunctionLibrary
{
	// Token: 0x0601D565 RID: 120165 RVA: 0x008C8DF4 File Offset: 0x008C6FF4
	[NullableContext(1)]
	public __TsHideActorBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHideActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D566 RID: 120166 RVA: 0x008C8E27 File Offset: 0x008C7027
	protected __TsHideActorBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
