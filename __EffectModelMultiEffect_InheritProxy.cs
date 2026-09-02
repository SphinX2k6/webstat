using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394B RID: 14667
public class __EffectModelMultiEffect_InheritProxy : EffectModelMultiEffect
{
	// Token: 0x0601D906 RID: 121094 RVA: 0x008D2E6C File Offset: 0x008D106C
	[NullableContext(1)]
	public __EffectModelMultiEffect_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMultiEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D907 RID: 121095 RVA: 0x008D2E9F File Offset: 0x008D109F
	protected __EffectModelMultiEffect_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
