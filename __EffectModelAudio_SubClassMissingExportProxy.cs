using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200392A RID: 14634
public class __EffectModelAudio_SubClassMissingExportProxy : __EffectModelAudio_InheritProxy
{
	// Token: 0x0601D8C4 RID: 121028 RVA: 0x008D26B0 File Offset: 0x008D08B0
	[NullableContext(1)]
	protected __EffectModelAudio_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelAudio.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8C5 RID: 121029 RVA: 0x008D26E3 File Offset: 0x008D08E3
	protected __EffectModelAudio_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
