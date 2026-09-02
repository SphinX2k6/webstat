using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200391A RID: 14618
public class __AnimNotifyEffect_SubClassMissingExportProxy : __AnimNotifyEffect_InheritProxy
{
	// Token: 0x0601D893 RID: 120979 RVA: 0x008D2040 File Offset: 0x008D0240
	[NullableContext(1)]
	protected __AnimNotifyEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D894 RID: 120980 RVA: 0x008D2073 File Offset: 0x008D0273
	protected __AnimNotifyEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
