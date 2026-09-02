using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003927 RID: 14631
public class __EffectClusteredStuffSettings_InheritProxy : EffectClusteredStuffSettings
{
	// Token: 0x0601D8BE RID: 121022 RVA: 0x008D25FC File Offset: 0x008D07FC
	[NullableContext(1)]
	public __EffectClusteredStuffSettings_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8BF RID: 121023 RVA: 0x008D262F File Offset: 0x008D082F
	protected __EffectClusteredStuffSettings_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
