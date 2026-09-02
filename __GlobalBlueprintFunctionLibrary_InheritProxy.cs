using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003967 RID: 14695
public class __GlobalBlueprintFunctionLibrary_InheritProxy : GlobalBlueprintFunctionLibrary
{
	// Token: 0x0601D9D8 RID: 121304 RVA: 0x008D5CF0 File Offset: 0x008D3EF0
	[NullableContext(1)]
	public __GlobalBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GlobalBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9D9 RID: 121305 RVA: 0x008D5D23 File Offset: 0x008D3F23
	protected __GlobalBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
