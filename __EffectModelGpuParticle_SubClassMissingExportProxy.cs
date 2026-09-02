using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003934 RID: 14644
public class __EffectModelGpuParticle_SubClassMissingExportProxy : __EffectModelGpuParticle_InheritProxy
{
	// Token: 0x0601D8D8 RID: 121048 RVA: 0x008D2908 File Offset: 0x008D0B08
	[NullableContext(1)]
	protected __EffectModelGpuParticle_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGpuParticle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8D9 RID: 121049 RVA: 0x008D293B File Offset: 0x008D0B3B
	protected __EffectModelGpuParticle_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
