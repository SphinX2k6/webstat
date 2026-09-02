using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037C0 RID: 14272
public class __TsAnimNotifyEnableEntity_SubClassMissingExportProxy : __TsAnimNotifyEnableEntity_InheritProxy
{
	// Token: 0x0601D35D RID: 119645 RVA: 0x008C3F78 File Offset: 0x008C2178
	[NullableContext(1)]
	protected __TsAnimNotifyEnableEntity_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEnableEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D35E RID: 119646 RVA: 0x008C3FAB File Offset: 0x008C21AB
	protected __TsAnimNotifyEnableEntity_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
