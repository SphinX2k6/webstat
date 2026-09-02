using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003975 RID: 14709
public class __TsCharacterEntityBase_InheritProxy : TsCharacterEntityBase
{
	// Token: 0x0601DA0B RID: 121355 RVA: 0x008D6688 File Offset: 0x008D4888
	[NullableContext(1)]
	public __TsCharacterEntityBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA0C RID: 121356 RVA: 0x008D66BB File Offset: 0x008D48BB
	protected __TsCharacterEntityBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
