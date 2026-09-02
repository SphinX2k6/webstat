using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003895 RID: 14485
public class __LogicDataCreateBullet_InheritProxy : LogicDataCreateBullet
{
	// Token: 0x0601D62D RID: 120365 RVA: 0x008CA884 File Offset: 0x008C8A84
	[NullableContext(1)]
	public __LogicDataCreateBullet_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D62E RID: 120366 RVA: 0x008CA8B7 File Offset: 0x008C8AB7
	protected __LogicDataCreateBullet_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
