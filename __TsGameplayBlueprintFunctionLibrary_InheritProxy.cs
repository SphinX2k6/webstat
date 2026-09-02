using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C7 RID: 14535
public class __TsGameplayBlueprintFunctionLibrary_InheritProxy : TsGameplayBlueprintFunctionLibrary
{
	// Token: 0x0601D6A9 RID: 120489 RVA: 0x008CB9A4 File Offset: 0x008C9BA4
	[NullableContext(1)]
	public __TsGameplayBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameplayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6AA RID: 120490 RVA: 0x008CB9D7 File Offset: 0x008C9BD7
	protected __TsGameplayBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
