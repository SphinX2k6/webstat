using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A1 RID: 14497
public class __LogicDataManipulatableCreateBullet_InheritProxy : LogicDataManipulatableCreateBullet
{
	// Token: 0x0601D645 RID: 120389 RVA: 0x008CAB54 File Offset: 0x008C8D54
	[NullableContext(1)]
	public __LogicDataManipulatableCreateBullet_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D646 RID: 120390 RVA: 0x008CAB87 File Offset: 0x008C8D87
	protected __LogicDataManipulatableCreateBullet_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
