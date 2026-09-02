using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A6 RID: 14502
public class __LogicDataRebound_SubClassMissingExportProxy : __LogicDataRebound_InheritProxy
{
	// Token: 0x0601D64F RID: 120399 RVA: 0x008CAC80 File Offset: 0x008C8E80
	[NullableContext(1)]
	protected __LogicDataRebound_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataRebound.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D650 RID: 120400 RVA: 0x008CACB3 File Offset: 0x008C8EB3
	protected __LogicDataRebound_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
