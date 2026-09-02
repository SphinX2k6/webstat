using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200392D RID: 14637
public class __EffectModelCurveTrailDecal_InheritProxy : EffectModelCurveTrailDecal
{
	// Token: 0x0601D8CA RID: 121034 RVA: 0x008D2764 File Offset: 0x008D0964
	[NullableContext(1)]
	public __EffectModelCurveTrailDecal_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelCurveTrailDecal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8CB RID: 121035 RVA: 0x008D2797 File Offset: 0x008D0997
	protected __EffectModelCurveTrailDecal_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
