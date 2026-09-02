using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200395C RID: 14684
public class __ItemMaterialDataMap_SubClassMissingExportProxy : __ItemMaterialDataMap_InheritProxy
{
	// Token: 0x0601D935 RID: 121141 RVA: 0x008D3598 File Offset: 0x008D1798
	[NullableContext(1)]
	protected __ItemMaterialDataMap_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDataMap.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D936 RID: 121142 RVA: 0x008D35CB File Offset: 0x008D17CB
	protected __ItemMaterialDataMap_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
