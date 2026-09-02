using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393C RID: 14652
public class __EffectModelNDC_SubClassMissingExportProxy : __EffectModelNDC_InheritProxy
{
	// Token: 0x0601D8E8 RID: 121064 RVA: 0x008D2AE8 File Offset: 0x008D0CE8
	[NullableContext(1)]
	protected __EffectModelNDC_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8E9 RID: 121065 RVA: 0x008D2B1B File Offset: 0x008D0D1B
	protected __EffectModelNDC_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
