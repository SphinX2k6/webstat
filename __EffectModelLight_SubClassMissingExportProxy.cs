using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003938 RID: 14648
public class __EffectModelLight_SubClassMissingExportProxy : __EffectModelLight_InheritProxy
{
	// Token: 0x0601D8E0 RID: 121056 RVA: 0x008D29F8 File Offset: 0x008D0BF8
	[NullableContext(1)]
	protected __EffectModelLight_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelLight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8E1 RID: 121057 RVA: 0x008D2A2B File Offset: 0x008D0C2B
	protected __EffectModelLight_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
