using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393E RID: 14654
public class __EffectModelNiagara_SubClassMissingExportProxy : __EffectModelNiagara_InheritProxy
{
	// Token: 0x0601D8EC RID: 121068 RVA: 0x008D2B60 File Offset: 0x008D0D60
	[NullableContext(1)]
	protected __EffectModelNiagara_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNiagara.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8ED RID: 121069 RVA: 0x008D2B93 File Offset: 0x008D0D93
	protected __EffectModelNiagara_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
