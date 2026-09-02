using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003928 RID: 14632
public class __EffectClusteredStuffSettings_SubClassMissingExportProxy : __EffectClusteredStuffSettings_InheritProxy
{
	// Token: 0x0601D8C0 RID: 121024 RVA: 0x008D2638 File Offset: 0x008D0838
	[NullableContext(1)]
	protected __EffectClusteredStuffSettings_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8C1 RID: 121025 RVA: 0x008D266B File Offset: 0x008D086B
	protected __EffectClusteredStuffSettings_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
