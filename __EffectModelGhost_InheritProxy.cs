using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003931 RID: 14641
public class __EffectModelGhost_InheritProxy : EffectModelGhost
{
	// Token: 0x0601D8D2 RID: 121042 RVA: 0x008D2854 File Offset: 0x008D0A54
	[NullableContext(1)]
	public __EffectModelGhost_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGhost.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8D3 RID: 121043 RVA: 0x008D2887 File Offset: 0x008D0A87
	protected __EffectModelGhost_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
