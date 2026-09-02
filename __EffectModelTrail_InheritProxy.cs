using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003947 RID: 14663
public class __EffectModelTrail_InheritProxy : EffectModelTrail
{
	// Token: 0x0601D8FE RID: 121086 RVA: 0x008D2D7C File Offset: 0x008D0F7C
	[NullableContext(1)]
	public __EffectModelTrail_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelTrail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8FF RID: 121087 RVA: 0x008D2DAF File Offset: 0x008D0FAF
	protected __EffectModelTrail_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
