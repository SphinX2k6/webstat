using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003976 RID: 14710
public class __TsCharacterEntityBase_SubClassMissingExportProxy : __TsCharacterEntityBase_InheritProxy
{
	// Token: 0x0601DA0D RID: 121357 RVA: 0x008D66C4 File Offset: 0x008D48C4
	[NullableContext(1)]
	protected __TsCharacterEntityBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsCharacterEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA0E RID: 121358 RVA: 0x008D66F7 File Offset: 0x008D48F7
	protected __TsCharacterEntityBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
