using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389D RID: 14493
public class __LogicDataForce_InheritProxy : LogicDataForce
{
	// Token: 0x0601D63D RID: 120381 RVA: 0x008CAA64 File Offset: 0x008C8C64
	[NullableContext(1)]
	public __LogicDataForce_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataForce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D63E RID: 120382 RVA: 0x008CAA97 File Offset: 0x008C8C97
	protected __LogicDataForce_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
