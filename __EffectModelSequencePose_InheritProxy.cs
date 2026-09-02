using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003941 RID: 14657
public class __EffectModelSequencePose_InheritProxy : EffectModelSequencePose
{
	// Token: 0x0601D8F2 RID: 121074 RVA: 0x008D2C14 File Offset: 0x008D0E14
	[NullableContext(1)]
	public __EffectModelSequencePose_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelSequencePose.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8F3 RID: 121075 RVA: 0x008D2C47 File Offset: 0x008D0E47
	protected __EffectModelSequencePose_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
