using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003835 RID: 14389
public class __CounterAttackCameraData_InheritProxy : CounterAttackCameraData
{
	// Token: 0x0601D4F1 RID: 120049 RVA: 0x008C79F4 File Offset: 0x008C5BF4
	[NullableContext(1)]
	public __CounterAttackCameraData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackCameraData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4F2 RID: 120050 RVA: 0x008C7A27 File Offset: 0x008C5C27
	protected __CounterAttackCameraData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
