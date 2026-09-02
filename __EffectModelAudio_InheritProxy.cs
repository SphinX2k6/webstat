using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003929 RID: 14633
public class __EffectModelAudio_InheritProxy : EffectModelAudio
{
	// Token: 0x0601D8C2 RID: 121026 RVA: 0x008D2674 File Offset: 0x008D0874
	[NullableContext(1)]
	public __EffectModelAudio_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelAudio.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8C3 RID: 121027 RVA: 0x008D26A7 File Offset: 0x008D08A7
	protected __EffectModelAudio_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
