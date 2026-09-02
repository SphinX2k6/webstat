using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200392F RID: 14639
public class __EffectModelDecal_InheritProxy : EffectModelDecal
{
	// Token: 0x0601D8CE RID: 121038 RVA: 0x008D27DC File Offset: 0x008D09DC
	[NullableContext(1)]
	public __EffectModelDecal_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelDecal.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8CF RID: 121039 RVA: 0x008D280F File Offset: 0x008D0A0F
	protected __EffectModelDecal_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
