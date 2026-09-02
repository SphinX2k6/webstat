using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003924 RID: 14628
public class __AnimNotifyStopEffectFromEntity_SubClassMissingExportProxy : __AnimNotifyStopEffectFromEntity_InheritProxy
{
	// Token: 0x0601D8B8 RID: 121016 RVA: 0x008D2548 File Offset: 0x008D0748
	[NullableContext(1)]
	protected __AnimNotifyStopEffectFromEntity_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStopEffectFromEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8B9 RID: 121017 RVA: 0x008D257B File Offset: 0x008D077B
	protected __AnimNotifyStopEffectFromEntity_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
