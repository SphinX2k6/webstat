using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003930 RID: 14640
public class __EffectModelDecal_SubClassMissingExportProxy : __EffectModelDecal_InheritProxy
{
	// Token: 0x0601D8D0 RID: 121040 RVA: 0x008D2818 File Offset: 0x008D0A18
	[NullableContext(1)]
	protected __EffectModelDecal_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelDecal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8D1 RID: 121041 RVA: 0x008D284B File Offset: 0x008D0A4B
	protected __EffectModelDecal_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
