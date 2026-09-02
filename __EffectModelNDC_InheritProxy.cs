using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393B RID: 14651
public class __EffectModelNDC_InheritProxy : EffectModelNDC
{
	// Token: 0x0601D8E6 RID: 121062 RVA: 0x008D2AAC File Offset: 0x008D0CAC
	[NullableContext(1)]
	public __EffectModelNDC_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNDC.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8E7 RID: 121063 RVA: 0x008D2ADF File Offset: 0x008D0CDF
	protected __EffectModelNDC_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
