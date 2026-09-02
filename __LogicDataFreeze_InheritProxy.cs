using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389F RID: 14495
public class __LogicDataFreeze_InheritProxy : LogicDataFreeze
{
	// Token: 0x0601D641 RID: 120385 RVA: 0x008CAADC File Offset: 0x008C8CDC
	[NullableContext(1)]
	public __LogicDataFreeze_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataFreeze.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D642 RID: 120386 RVA: 0x008CAB0F File Offset: 0x008C8D0F
	protected __LogicDataFreeze_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
