using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B0 RID: 14512
public class __LogicDataSpeedReduce_SubClassMissingExportProxy : __LogicDataSpeedReduce_InheritProxy
{
	// Token: 0x0601D663 RID: 120419 RVA: 0x008CAED8 File Offset: 0x008C90D8
	[NullableContext(1)]
	protected __LogicDataSpeedReduce_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpeedReduce.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D664 RID: 120420 RVA: 0x008CAF0B File Offset: 0x008C910B
	protected __LogicDataSpeedReduce_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
