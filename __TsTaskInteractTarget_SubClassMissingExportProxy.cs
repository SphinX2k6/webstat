using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003630 RID: 13872
public class __TsTaskInteractTarget_SubClassMissingExportProxy : __TsTaskInteractTarget_InheritProxy
{
	// Token: 0x0601CDE3 RID: 118243 RVA: 0x008B6C04 File Offset: 0x008B4E04
	[NullableContext(1)]
	protected __TsTaskInteractTarget_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskInteractTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDE4 RID: 118244 RVA: 0x008B6C37 File Offset: 0x008B4E37
	protected __TsTaskInteractTarget_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
