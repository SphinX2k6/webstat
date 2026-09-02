using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003935 RID: 14645
public class __EffectModelGroup_InheritProxy : EffectModelGroup
{
	// Token: 0x0601D8DA RID: 121050 RVA: 0x008D2944 File Offset: 0x008D0B44
	[NullableContext(1)]
	public __EffectModelGroup_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGroup.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8DB RID: 121051 RVA: 0x008D2977 File Offset: 0x008D0B77
	protected __EffectModelGroup_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
