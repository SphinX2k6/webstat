using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003854 RID: 14420
public class __AiWeaponBlueprintFunctionLibrary_SubClassMissingExportProxy : __AiWeaponBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D555 RID: 120149 RVA: 0x008C8BE8 File Offset: 0x008C6DE8
	[NullableContext(1)]
	protected __AiWeaponBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AiWeaponBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D556 RID: 120150 RVA: 0x008C8C1B File Offset: 0x008C6E1B
	protected __AiWeaponBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
