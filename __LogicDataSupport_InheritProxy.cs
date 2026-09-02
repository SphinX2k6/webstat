using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B7 RID: 14519
public class __LogicDataSupport_InheritProxy : LogicDataSupport
{
	// Token: 0x0601D671 RID: 120433 RVA: 0x008CB07C File Offset: 0x008C927C
	[NullableContext(1)]
	public __LogicDataSupport_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSupport.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D672 RID: 120434 RVA: 0x008CB0AF File Offset: 0x008C92AF
	protected __LogicDataSupport_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
