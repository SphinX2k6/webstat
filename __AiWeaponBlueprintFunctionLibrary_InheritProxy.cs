using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003853 RID: 14419
public class __AiWeaponBlueprintFunctionLibrary_InheritProxy : AiWeaponBlueprintFunctionLibrary
{
	// Token: 0x0601D553 RID: 120147 RVA: 0x008C8BAC File Offset: 0x008C6DAC
	[NullableContext(1)]
	public __AiWeaponBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AiWeaponBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D554 RID: 120148 RVA: 0x008C8BDF File Offset: 0x008C6DDF
	protected __AiWeaponBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
