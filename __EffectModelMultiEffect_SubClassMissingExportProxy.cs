using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394C RID: 14668
public class __EffectModelMultiEffect_SubClassMissingExportProxy : __EffectModelMultiEffect_InheritProxy
{
	// Token: 0x0601D908 RID: 121096 RVA: 0x008D2EA8 File Offset: 0x008D10A8
	[NullableContext(1)]
	protected __EffectModelMultiEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMultiEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D909 RID: 121097 RVA: 0x008D2EDB File Offset: 0x008D10DB
	protected __EffectModelMultiEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
