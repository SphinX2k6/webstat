using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003950 RID: 14672
public class __EffectBlueprintFunctionLibrary_SubClassMissingExportProxy : __EffectBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D910 RID: 121104 RVA: 0x008D2F98 File Offset: 0x008D1198
	[NullableContext(1)]
	protected __EffectBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D911 RID: 121105 RVA: 0x008D2FCB File Offset: 0x008D11CB
	protected __EffectBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
