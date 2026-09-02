using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B2 RID: 14514
public class __LogicDataSplineMovement_SubClassMissingExportProxy : __LogicDataSplineMovement_InheritProxy
{
	// Token: 0x0601D667 RID: 120423 RVA: 0x008CAF50 File Offset: 0x008C9150
	[NullableContext(1)]
	protected __LogicDataSplineMovement_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSplineMovement.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D668 RID: 120424 RVA: 0x008CAF83 File Offset: 0x008C9183
	protected __LogicDataSplineMovement_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
