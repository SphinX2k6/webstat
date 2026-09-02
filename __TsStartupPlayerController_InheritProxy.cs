using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003833 RID: 14387
public class __TsStartupPlayerController_InheritProxy : TsStartupPlayerController
{
	// Token: 0x0601D4ED RID: 120045 RVA: 0x008C797C File Offset: 0x008C5B7C
	[NullableContext(1)]
	public __TsStartupPlayerController_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsStartupPlayerController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4EE RID: 120046 RVA: 0x008C79AF File Offset: 0x008C5BAF
	protected __TsStartupPlayerController_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
