using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384C RID: 14412
public class __LevelGeneralBlueprintFunctionLibrary_SubClassMissingExportProxy : __LevelGeneralBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D529 RID: 120105 RVA: 0x008C81D8 File Offset: 0x008C63D8
	[NullableContext(1)]
	protected __LevelGeneralBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D52A RID: 120106 RVA: 0x008C820B File Offset: 0x008C640B
	protected __LevelGeneralBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
