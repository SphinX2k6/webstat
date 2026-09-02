using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A0 RID: 14496
public class __LogicDataFreeze_SubClassMissingExportProxy : __LogicDataFreeze_InheritProxy
{
	// Token: 0x0601D643 RID: 120387 RVA: 0x008CAB18 File Offset: 0x008C8D18
	[NullableContext(1)]
	protected __LogicDataFreeze_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataFreeze.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D644 RID: 120388 RVA: 0x008CAB4B File Offset: 0x008C8D4B
	protected __LogicDataFreeze_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
