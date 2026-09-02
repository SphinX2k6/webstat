using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003897 RID: 14487
public class __LogicDataDestroyBullet_InheritProxy : LogicDataDestroyBullet
{
	// Token: 0x0601D631 RID: 120369 RVA: 0x008CA8FC File Offset: 0x008C8AFC
	[NullableContext(1)]
	public __LogicDataDestroyBullet_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D632 RID: 120370 RVA: 0x008CA92F File Offset: 0x008C8B2F
	protected __LogicDataDestroyBullet_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
