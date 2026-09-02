using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003942 RID: 14658
public class __EffectModelSequencePose_SubClassMissingExportProxy : __EffectModelSequencePose_InheritProxy
{
	// Token: 0x0601D8F4 RID: 121076 RVA: 0x008D2C50 File Offset: 0x008D0E50
	[NullableContext(1)]
	protected __EffectModelSequencePose_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSequencePose.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8F5 RID: 121077 RVA: 0x008D2C83 File Offset: 0x008D0E83
	protected __EffectModelSequencePose_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
