using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003949 RID: 14665
public class __EffectScalabilitySetting_InheritProxy : EffectScalabilitySetting
{
	// Token: 0x0601D902 RID: 121090 RVA: 0x008D2DF4 File Offset: 0x008D0FF4
	[NullableContext(1)]
	public __EffectScalabilitySetting_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D903 RID: 121091 RVA: 0x008D2E27 File Offset: 0x008D1027
	protected __EffectScalabilitySetting_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
