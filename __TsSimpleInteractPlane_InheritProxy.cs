using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E7 RID: 14567
public class __TsSimpleInteractPlane_InheritProxy : TsSimpleInteractPlane
{
	// Token: 0x0601D70E RID: 120590 RVA: 0x008CC8DC File Offset: 0x008CAADC
	[NullableContext(1)]
	public __TsSimpleInteractPlane_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPlane.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D70F RID: 120591 RVA: 0x008CC90F File Offset: 0x008CAB0F
	protected __TsSimpleInteractPlane_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
