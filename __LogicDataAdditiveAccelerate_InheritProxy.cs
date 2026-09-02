using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200388D RID: 14477
public class __LogicDataAdditiveAccelerate_InheritProxy : LogicDataAdditiveAccelerate
{
	// Token: 0x0601D61D RID: 120349 RVA: 0x008CA6A4 File Offset: 0x008C88A4
	[NullableContext(1)]
	public __LogicDataAdditiveAccelerate_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataAdditiveAccelerate.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D61E RID: 120350 RVA: 0x008CA6D7 File Offset: 0x008C88D7
	protected __LogicDataAdditiveAccelerate_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
