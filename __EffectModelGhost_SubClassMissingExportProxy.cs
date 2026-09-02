using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003932 RID: 14642
public class __EffectModelGhost_SubClassMissingExportProxy : __EffectModelGhost_InheritProxy
{
	// Token: 0x0601D8D4 RID: 121044 RVA: 0x008D2890 File Offset: 0x008D0A90
	[NullableContext(1)]
	protected __EffectModelGhost_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGhost.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8D5 RID: 121045 RVA: 0x008D28C3 File Offset: 0x008D0AC3
	protected __EffectModelGhost_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
