using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003892 RID: 14482
public class __LogicDataBulletCollision_SubClassMissingExportProxy : __LogicDataBulletCollision_InheritProxy
{
	// Token: 0x0601D627 RID: 120359 RVA: 0x008CA7D0 File Offset: 0x008C89D0
	[NullableContext(1)]
	protected __LogicDataBulletCollision_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBulletCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D628 RID: 120360 RVA: 0x008CA803 File Offset: 0x008C8A03
	protected __LogicDataBulletCollision_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
