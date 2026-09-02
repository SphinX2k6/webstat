using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003925 RID: 14629
public class __EffectClusteredStuffDefaultSettings_InheritProxy : EffectClusteredStuffDefaultSettings
{
	// Token: 0x0601D8BA RID: 121018 RVA: 0x008D2584 File Offset: 0x008D0784
	[NullableContext(1)]
	public __EffectClusteredStuffDefaultSettings_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffDefaultSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8BB RID: 121019 RVA: 0x008D25B7 File Offset: 0x008D07B7
	protected __EffectClusteredStuffDefaultSettings_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
