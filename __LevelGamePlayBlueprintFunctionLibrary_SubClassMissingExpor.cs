using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384A RID: 14410
public class __LevelGamePlayBlueprintFunctionLibrary_SubClassMissingExportProxy : __LevelGamePlayBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D525 RID: 120101 RVA: 0x008C8160 File Offset: 0x008C6360
	[NullableContext(1)]
	protected __LevelGamePlayBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGamePlayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D526 RID: 120102 RVA: 0x008C8193 File Offset: 0x008C6393
	protected __LevelGamePlayBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
