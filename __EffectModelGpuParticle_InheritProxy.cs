using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003933 RID: 14643
public class __EffectModelGpuParticle_InheritProxy : EffectModelGpuParticle
{
	// Token: 0x0601D8D6 RID: 121046 RVA: 0x008D28CC File Offset: 0x008D0ACC
	[NullableContext(1)]
	public __EffectModelGpuParticle_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGpuParticle.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8D7 RID: 121047 RVA: 0x008D28FF File Offset: 0x008D0AFF
	protected __EffectModelGpuParticle_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
