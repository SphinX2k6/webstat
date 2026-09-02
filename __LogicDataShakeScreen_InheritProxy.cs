using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A7 RID: 14503
public class __LogicDataShakeScreen_InheritProxy : LogicDataShakeScreen
{
	// Token: 0x0601D651 RID: 120401 RVA: 0x008CACBC File Offset: 0x008C8EBC
	[NullableContext(1)]
	public __LogicDataShakeScreen_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShakeScreen.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D652 RID: 120402 RVA: 0x008CACEF File Offset: 0x008C8EEF
	protected __LogicDataShakeScreen_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
