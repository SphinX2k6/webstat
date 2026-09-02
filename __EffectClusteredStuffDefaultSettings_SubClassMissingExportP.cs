using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003926 RID: 14630
public class __EffectClusteredStuffDefaultSettings_SubClassMissingExportProxy : __EffectClusteredStuffDefaultSettings_InheritProxy
{
	// Token: 0x0601D8BC RID: 121020 RVA: 0x008D25C0 File Offset: 0x008D07C0
	[NullableContext(1)]
	protected __EffectClusteredStuffDefaultSettings_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectClusteredStuffDefaultSettings.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8BD RID: 121021 RVA: 0x008D25F3 File Offset: 0x008D07F3
	protected __EffectClusteredStuffDefaultSettings_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
