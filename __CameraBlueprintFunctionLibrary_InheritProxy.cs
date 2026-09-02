using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003825 RID: 14373
public class __CameraBlueprintFunctionLibrary_InheritProxy : CameraBlueprintFunctionLibrary
{
	// Token: 0x0601D488 RID: 119944 RVA: 0x008C64D8 File Offset: 0x008C46D8
	[NullableContext(1)]
	public __CameraBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CameraBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D489 RID: 119945 RVA: 0x008C650B File Offset: 0x008C470B
	protected __CameraBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
