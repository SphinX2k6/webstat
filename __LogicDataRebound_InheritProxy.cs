using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A5 RID: 14501
public class __LogicDataRebound_InheritProxy : LogicDataRebound
{
	// Token: 0x0601D64D RID: 120397 RVA: 0x008CAC44 File Offset: 0x008C8E44
	[NullableContext(1)]
	public __LogicDataRebound_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataRebound.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D64E RID: 120398 RVA: 0x008CAC77 File Offset: 0x008C8E77
	protected __LogicDataRebound_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
