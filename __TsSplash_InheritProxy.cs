using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003973 RID: 14707
public class __TsSplash_InheritProxy : TsSplash
{
	// Token: 0x0601DA07 RID: 121351 RVA: 0x008D6610 File Offset: 0x008D4810
	[NullableContext(1)]
	public __TsSplash_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSplash.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA08 RID: 121352 RVA: 0x008D6643 File Offset: 0x008D4843
	protected __TsSplash_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
