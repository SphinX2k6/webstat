using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396B RID: 14699
public class __WorldFunctionLibrary_InheritProxy : WorldFunctionLibrary
{
	// Token: 0x0601D9E0 RID: 121312 RVA: 0x008D5DE0 File Offset: 0x008D3FE0
	[NullableContext(1)]
	public __WorldFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WorldFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9E1 RID: 121313 RVA: 0x008D5E13 File Offset: 0x008D4013
	protected __WorldFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
