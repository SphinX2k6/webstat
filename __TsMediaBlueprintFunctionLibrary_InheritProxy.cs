using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038CB RID: 14539
public class __TsMediaBlueprintFunctionLibrary_InheritProxy : TsMediaBlueprintFunctionLibrary
{
	// Token: 0x0601D6B1 RID: 120497 RVA: 0x008CBA94 File Offset: 0x008C9C94
	[NullableContext(1)]
	public __TsMediaBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMediaBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6B2 RID: 120498 RVA: 0x008CBAC7 File Offset: 0x008C9CC7
	protected __TsMediaBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
