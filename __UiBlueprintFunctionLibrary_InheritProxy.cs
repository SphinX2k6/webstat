using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003855 RID: 14421
public class __UiBlueprintFunctionLibrary_InheritProxy : UiBlueprintFunctionLibrary
{
	// Token: 0x0601D557 RID: 120151 RVA: 0x008C8C24 File Offset: 0x008C6E24
	[NullableContext(1)]
	public __UiBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(UiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D558 RID: 120152 RVA: 0x008C8C57 File Offset: 0x008C6E57
	protected __UiBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
