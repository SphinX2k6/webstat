using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AD RID: 14509
public class __LogicDataSpawnObstacles_InheritProxy : LogicDataSpawnObstacles
{
	// Token: 0x0601D65D RID: 120413 RVA: 0x008CAE24 File Offset: 0x008C9024
	[NullableContext(1)]
	public __LogicDataSpawnObstacles_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSpawnObstacles.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D65E RID: 120414 RVA: 0x008CAE57 File Offset: 0x008C9057
	protected __LogicDataSpawnObstacles_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
