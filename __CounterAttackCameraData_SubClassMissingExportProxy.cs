using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003836 RID: 14390
public class __CounterAttackCameraData_SubClassMissingExportProxy : __CounterAttackCameraData_InheritProxy
{
	// Token: 0x0601D4F3 RID: 120051 RVA: 0x008C7A30 File Offset: 0x008C5C30
	[NullableContext(1)]
	protected __CounterAttackCameraData_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackCameraData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4F4 RID: 120052 RVA: 0x008C7A63 File Offset: 0x008C5C63
	protected __CounterAttackCameraData_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
