using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393D RID: 14653
public class __EffectModelNiagara_InheritProxy : EffectModelNiagara
{
	// Token: 0x0601D8EA RID: 121066 RVA: 0x008D2B24 File Offset: 0x008D0D24
	[NullableContext(1)]
	public __EffectModelNiagara_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelNiagara.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8EB RID: 121067 RVA: 0x008D2B57 File Offset: 0x008D0D57
	protected __EffectModelNiagara_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
