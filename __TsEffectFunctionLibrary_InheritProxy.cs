using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200383B RID: 14395
public class __TsEffectFunctionLibrary_InheritProxy : TsEffectFunctionLibrary
{
	// Token: 0x0601D504 RID: 120068 RVA: 0x008C7D00 File Offset: 0x008C5F00
	[NullableContext(1)]
	public __TsEffectFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEffectFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D505 RID: 120069 RVA: 0x008C7D33 File Offset: 0x008C5F33
	protected __TsEffectFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
