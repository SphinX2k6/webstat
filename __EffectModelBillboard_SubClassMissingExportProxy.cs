using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200392C RID: 14636
public class __EffectModelBillboard_SubClassMissingExportProxy : __EffectModelBillboard_InheritProxy
{
	// Token: 0x0601D8C8 RID: 121032 RVA: 0x008D2728 File Offset: 0x008D0928
	[NullableContext(1)]
	protected __EffectModelBillboard_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelBillboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8C9 RID: 121033 RVA: 0x008D275B File Offset: 0x008D095B
	protected __EffectModelBillboard_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
