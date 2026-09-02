using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B3 RID: 14515
public class __LogicDataSuiGuang_InheritProxy : LogicDataSuiGuang
{
	// Token: 0x0601D669 RID: 120425 RVA: 0x008CAF8C File Offset: 0x008C918C
	[NullableContext(1)]
	public __LogicDataSuiGuang_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSuiGuang.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D66A RID: 120426 RVA: 0x008CAFBF File Offset: 0x008C91BF
	protected __LogicDataSuiGuang_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
