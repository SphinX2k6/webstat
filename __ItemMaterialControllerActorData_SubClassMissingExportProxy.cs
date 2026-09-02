using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003958 RID: 14680
public class __ItemMaterialControllerActorData_SubClassMissingExportProxy : __ItemMaterialControllerActorData_InheritProxy
{
	// Token: 0x0601D92D RID: 121133 RVA: 0x008D34A8 File Offset: 0x008D16A8
	[NullableContext(1)]
	protected __ItemMaterialControllerActorData_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialControllerActorData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D92E RID: 121134 RVA: 0x008D34DB File Offset: 0x008D16DB
	protected __ItemMaterialControllerActorData_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
