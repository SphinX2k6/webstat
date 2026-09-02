using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003891 RID: 14481
public class __LogicDataBulletCollision_InheritProxy : LogicDataBulletCollision
{
	// Token: 0x0601D625 RID: 120357 RVA: 0x008CA794 File Offset: 0x008C8994
	[NullableContext(1)]
	public __LogicDataBulletCollision_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBulletCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D626 RID: 120358 RVA: 0x008CA7C7 File Offset: 0x008C89C7
	protected __LogicDataBulletCollision_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
