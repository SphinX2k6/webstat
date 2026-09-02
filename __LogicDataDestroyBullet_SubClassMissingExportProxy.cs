using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003898 RID: 14488
public class __LogicDataDestroyBullet_SubClassMissingExportProxy : __LogicDataDestroyBullet_InheritProxy
{
	// Token: 0x0601D633 RID: 120371 RVA: 0x008CA938 File Offset: 0x008C8B38
	[NullableContext(1)]
	protected __LogicDataDestroyBullet_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D634 RID: 120372 RVA: 0x008CA96B File Offset: 0x008C8B6B
	protected __LogicDataDestroyBullet_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
