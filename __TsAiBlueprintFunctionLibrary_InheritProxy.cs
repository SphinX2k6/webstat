using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038BF RID: 14527
public class __TsAiBlueprintFunctionLibrary_InheritProxy : TsAiBlueprintFunctionLibrary
{
	// Token: 0x0601D699 RID: 120473 RVA: 0x008CB7C4 File Offset: 0x008C99C4
	[NullableContext(1)]
	public __TsAiBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D69A RID: 120474 RVA: 0x008CB7F7 File Offset: 0x008C99F7
	protected __TsAiBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
