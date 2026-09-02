using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003847 RID: 14407
public class __TsGameSplineActor_InheritProxy : TsGameSplineActor
{
	// Token: 0x0601D51F RID: 120095 RVA: 0x008C80AC File Offset: 0x008C62AC
	[NullableContext(1)]
	public __TsGameSplineActor_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameSplineActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D520 RID: 120096 RVA: 0x008C80DF File Offset: 0x008C62DF
	protected __TsGameSplineActor_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
