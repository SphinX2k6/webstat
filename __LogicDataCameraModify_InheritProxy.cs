using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003893 RID: 14483
public class __LogicDataCameraModify_InheritProxy : LogicDataCameraModify
{
	// Token: 0x0601D629 RID: 120361 RVA: 0x008CA80C File Offset: 0x008C8A0C
	[NullableContext(1)]
	public __LogicDataCameraModify_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCameraModify.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D62A RID: 120362 RVA: 0x008CA83F File Offset: 0x008C8A3F
	protected __LogicDataCameraModify_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
