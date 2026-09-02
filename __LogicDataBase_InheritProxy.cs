using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200388F RID: 14479
public class __LogicDataBase_InheritProxy : LogicDataBase
{
	// Token: 0x0601D621 RID: 120353 RVA: 0x008CA71C File Offset: 0x008C891C
	[NullableContext(1)]
	public __LogicDataBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D622 RID: 120354 RVA: 0x008CA74F File Offset: 0x008C894F
	protected __LogicDataBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
