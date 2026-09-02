using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003841 RID: 14401
public class __KscBulletData_InheritProxy : KscBulletData
{
	// Token: 0x0601D510 RID: 120080 RVA: 0x008C7E68 File Offset: 0x008C6068
	[NullableContext(1)]
	public __KscBulletData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscBulletData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D511 RID: 120081 RVA: 0x008C7E9B File Offset: 0x008C609B
	protected __KscBulletData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
