using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200395B RID: 14683
public class __ItemMaterialDataMap_InheritProxy : ItemMaterialDataMap
{
	// Token: 0x0601D933 RID: 121139 RVA: 0x008D355C File Offset: 0x008D175C
	[NullableContext(1)]
	public __ItemMaterialDataMap_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(ItemMaterialDataMap.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D934 RID: 121140 RVA: 0x008D358F File Offset: 0x008D178F
	protected __ItemMaterialDataMap_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
