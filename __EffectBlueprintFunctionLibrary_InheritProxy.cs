using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394F RID: 14671
public class __EffectBlueprintFunctionLibrary_InheritProxy : EffectBlueprintFunctionLibrary
{
	// Token: 0x0601D90E RID: 121102 RVA: 0x008D2F5C File Offset: 0x008D115C
	[NullableContext(1)]
	public __EffectBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D90F RID: 121103 RVA: 0x008D2F8F File Offset: 0x008D118F
	protected __EffectBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
