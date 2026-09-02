using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E0 RID: 14560
public class __TsBoxRangeItem_SubClassMissingExportProxy : __TsBoxRangeItem_InheritProxy
{
	// Token: 0x0601D6F8 RID: 120568 RVA: 0x008CC5A4 File Offset: 0x008CA7A4
	[NullableContext(1)]
	protected __TsBoxRangeItem_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsBoxRangeItem.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6F9 RID: 120569 RVA: 0x008CC5D7 File Offset: 0x008CA7D7
	protected __TsBoxRangeItem_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
