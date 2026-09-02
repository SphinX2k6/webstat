using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A9 RID: 14505
public class __LogicDataShield_InheritProxy : LogicDataShield
{
	// Token: 0x0601D655 RID: 120405 RVA: 0x008CAD34 File Offset: 0x008C8F34
	[NullableContext(1)]
	public __LogicDataShield_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShield.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D656 RID: 120406 RVA: 0x008CAD67 File Offset: 0x008C8F67
	protected __LogicDataShield_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
