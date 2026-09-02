using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200388B RID: 14475
public class __LogicDataAddBuff_InheritProxy : LogicDataAddBuff
{
	// Token: 0x0601D619 RID: 120345 RVA: 0x008CA62C File Offset: 0x008C882C
	[NullableContext(1)]
	public __LogicDataAddBuff_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataAddBuff.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D61A RID: 120346 RVA: 0x008CA65F File Offset: 0x008C885F
	protected __LogicDataAddBuff_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
