using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200385C RID: 14428
public class __TsHideActorBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsHideActorBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D567 RID: 120167 RVA: 0x008C8E30 File Offset: 0x008C7030
	[NullableContext(1)]
	protected __TsHideActorBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHideActorBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D568 RID: 120168 RVA: 0x008C8E63 File Offset: 0x008C7063
	protected __TsHideActorBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
