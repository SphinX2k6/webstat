using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003940 RID: 14656
public class __EffectModelPostProcess_SubClassMissingExportProxy : __EffectModelPostProcess_InheritProxy
{
	// Token: 0x0601D8F0 RID: 121072 RVA: 0x008D2BD8 File Offset: 0x008D0DD8
	[NullableContext(1)]
	protected __EffectModelPostProcess_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelPostProcess.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8F1 RID: 121073 RVA: 0x008D2C0B File Offset: 0x008D0E0B
	protected __EffectModelPostProcess_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
