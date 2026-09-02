using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B1 RID: 14513
public class __LogicDataSplineMovement_InheritProxy : LogicDataSplineMovement
{
	// Token: 0x0601D665 RID: 120421 RVA: 0x008CAF14 File Offset: 0x008C9114
	[NullableContext(1)]
	public __LogicDataSplineMovement_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSplineMovement.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D666 RID: 120422 RVA: 0x008CAF47 File Offset: 0x008C9147
	protected __LogicDataSplineMovement_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
