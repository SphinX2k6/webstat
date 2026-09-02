using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B9 RID: 14521
public class __LogicDataWhirlpool_InheritProxy : LogicDataWhirlpool
{
	// Token: 0x0601D675 RID: 120437 RVA: 0x008CB0F4 File Offset: 0x008C92F4
	[NullableContext(1)]
	public __LogicDataWhirlpool_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataWhirlpool.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D676 RID: 120438 RVA: 0x008CB127 File Offset: 0x008C9327
	protected __LogicDataWhirlpool_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
