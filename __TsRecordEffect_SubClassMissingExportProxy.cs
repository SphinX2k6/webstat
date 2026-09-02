using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003900 RID: 14592
public class __TsRecordEffect_SubClassMissingExportProxy : __TsRecordEffect_InheritProxy
{
	// Token: 0x0601D787 RID: 120711 RVA: 0x008CE040 File Offset: 0x008CC240
	[NullableContext(1)]
	protected __TsRecordEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D788 RID: 120712 RVA: 0x008CE073 File Offset: 0x008CC273
	protected __TsRecordEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
