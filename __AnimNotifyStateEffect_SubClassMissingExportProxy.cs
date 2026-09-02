using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200391C RID: 14620
public class __AnimNotifyStateEffect_SubClassMissingExportProxy : __AnimNotifyStateEffect_InheritProxy
{
	// Token: 0x0601D89D RID: 120989 RVA: 0x008D219C File Offset: 0x008D039C
	[NullableContext(1)]
	protected __AnimNotifyStateEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D89E RID: 120990 RVA: 0x008D21CF File Offset: 0x008D03CF
	protected __AnimNotifyStateEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
