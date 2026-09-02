using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003538 RID: 13624
public class __TsDecoratorTimePeriodCheck_SubClassMissingExportProxy : __TsDecoratorTimePeriodCheck_InheritProxy
{
	// Token: 0x0601CB3A RID: 117562 RVA: 0x008B0C38 File Offset: 0x008AEE38
	[NullableContext(1)]
	protected __TsDecoratorTimePeriodCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTimePeriodCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB3B RID: 117563 RVA: 0x008B0C6B File Offset: 0x008AEE6B
	protected __TsDecoratorTimePeriodCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
