using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393F RID: 14655
public class __EffectModelPostProcess_InheritProxy : EffectModelPostProcess
{
	// Token: 0x0601D8EE RID: 121070 RVA: 0x008D2B9C File Offset: 0x008D0D9C
	[NullableContext(1)]
	public __EffectModelPostProcess_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelPostProcess.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8EF RID: 121071 RVA: 0x008D2BCF File Offset: 0x008D0DCF
	protected __EffectModelPostProcess_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
