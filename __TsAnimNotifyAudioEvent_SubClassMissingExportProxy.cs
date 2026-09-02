using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200377A RID: 14202
public class __TsAnimNotifyAudioEvent_SubClassMissingExportProxy : __TsAnimNotifyAudioEvent_InheritProxy
{
	// Token: 0x0601D28C RID: 119436 RVA: 0x008C254C File Offset: 0x008C074C
	[NullableContext(1)]
	protected __TsAnimNotifyAudioEvent_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyAudioEvent.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D28D RID: 119437 RVA: 0x008C257F File Offset: 0x008C077F
	protected __TsAnimNotifyAudioEvent_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
