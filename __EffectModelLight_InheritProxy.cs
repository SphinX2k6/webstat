using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003937 RID: 14647
public class __EffectModelLight_InheritProxy : EffectModelLight
{
	// Token: 0x0601D8DE RID: 121054 RVA: 0x008D29BC File Offset: 0x008D0BBC
	[NullableContext(1)]
	public __EffectModelLight_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelLight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8DF RID: 121055 RVA: 0x008D29EF File Offset: 0x008D0BEF
	protected __EffectModelLight_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
