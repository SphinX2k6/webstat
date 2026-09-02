using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003957 RID: 14679
public class __ItemMaterialControllerActorData_InheritProxy : ItemMaterialControllerActorData
{
	// Token: 0x0601D92B RID: 121131 RVA: 0x008D346C File Offset: 0x008D166C
	[NullableContext(1)]
	public __ItemMaterialControllerActorData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerActorData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D92C RID: 121132 RVA: 0x008D349F File Offset: 0x008D169F
	protected __ItemMaterialControllerActorData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
