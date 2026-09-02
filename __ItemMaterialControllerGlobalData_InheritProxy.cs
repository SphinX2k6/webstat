using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003959 RID: 14681
public class __ItemMaterialControllerGlobalData_InheritProxy : ItemMaterialControllerGlobalData
{
	// Token: 0x0601D92F RID: 121135 RVA: 0x008D34E4 File Offset: 0x008D16E4
	[NullableContext(1)]
	public __ItemMaterialControllerGlobalData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerGlobalData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D930 RID: 121136 RVA: 0x008D3517 File Offset: 0x008D1717
	protected __ItemMaterialControllerGlobalData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
