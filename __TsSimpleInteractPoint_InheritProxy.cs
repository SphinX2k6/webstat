using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E9 RID: 14569
public class __TsSimpleInteractPoint_InheritProxy : TsSimpleInteractPoint
{
	// Token: 0x0601D712 RID: 120594 RVA: 0x008CC954 File Offset: 0x008CAB54
	[NullableContext(1)]
	public __TsSimpleInteractPoint_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D713 RID: 120595 RVA: 0x008CC987 File Offset: 0x008CAB87
	protected __TsSimpleInteractPoint_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
