using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AE RID: 14510
public class __LogicDataSpawnObstacles_SubClassMissingExportProxy : __LogicDataSpawnObstacles_InheritProxy
{
	// Token: 0x0601D65F RID: 120415 RVA: 0x008CAE60 File Offset: 0x008C9060
	[NullableContext(1)]
	protected __LogicDataSpawnObstacles_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpawnObstacles.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D660 RID: 120416 RVA: 0x008CAE93 File Offset: 0x008C9093
	protected __LogicDataSpawnObstacles_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
