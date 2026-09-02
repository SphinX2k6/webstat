using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003922 RID: 14626
public class __AnimNotifyStateTrail_SubClassMissingExportProxy : __AnimNotifyStateTrail_InheritProxy
{
	// Token: 0x0601D8B3 RID: 121011 RVA: 0x008D249C File Offset: 0x008D069C
	[NullableContext(1)]
	protected __AnimNotifyStateTrail_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateTrail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8B4 RID: 121012 RVA: 0x008D24CF File Offset: 0x008D06CF
	protected __AnimNotifyStateTrail_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
