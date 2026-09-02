using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003899 RID: 14489
public class __LogicDataDestroyOtherBullet_InheritProxy : LogicDataDestroyOtherBullet
{
	// Token: 0x0601D635 RID: 120373 RVA: 0x008CA974 File Offset: 0x008C8B74
	[NullableContext(1)]
	public __LogicDataDestroyOtherBullet_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataDestroyOtherBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D636 RID: 120374 RVA: 0x008CA9A7 File Offset: 0x008C8BA7
	protected __LogicDataDestroyOtherBullet_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
