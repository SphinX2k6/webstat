using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394A RID: 14666
public class __EffectScalabilitySetting_SubClassMissingExportProxy : __EffectScalabilitySetting_InheritProxy
{
	// Token: 0x0601D904 RID: 121092 RVA: 0x008D2E30 File Offset: 0x008D1030
	[NullableContext(1)]
	protected __EffectScalabilitySetting_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D905 RID: 121093 RVA: 0x008D2E63 File Offset: 0x008D1063
	protected __EffectScalabilitySetting_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
