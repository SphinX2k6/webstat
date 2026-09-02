using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389A RID: 14490
public class __LogicDataDestroyOtherBullet_SubClassMissingExportProxy : __LogicDataDestroyOtherBullet_InheritProxy
{
	// Token: 0x0601D637 RID: 120375 RVA: 0x008CA9B0 File Offset: 0x008C8BB0
	[NullableContext(1)]
	protected __LogicDataDestroyOtherBullet_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyOtherBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D638 RID: 120376 RVA: 0x008CA9E3 File Offset: 0x008C8BE3
	protected __LogicDataDestroyOtherBullet_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
