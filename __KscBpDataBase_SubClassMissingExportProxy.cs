using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003840 RID: 14400
public class __KscBpDataBase_SubClassMissingExportProxy : __KscBpDataBase_InheritProxy
{
	// Token: 0x0601D50E RID: 120078 RVA: 0x008C7E2C File Offset: 0x008C602C
	[NullableContext(1)]
	protected __KscBpDataBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBpDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D50F RID: 120079 RVA: 0x008C7E5F File Offset: 0x008C605F
	protected __KscBpDataBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
