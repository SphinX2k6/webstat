using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C3 RID: 14531
public class __TsControlBlueprintFunctionLibrary_InheritProxy : TsControlBlueprintFunctionLibrary
{
	// Token: 0x0601D6A1 RID: 120481 RVA: 0x008CB8B4 File Offset: 0x008C9AB4
	[NullableContext(1)]
	public __TsControlBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsControlBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6A2 RID: 120482 RVA: 0x008CB8E7 File Offset: 0x008C9AE7
	protected __TsControlBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
