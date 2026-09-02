using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038BE RID: 14526
public class __CharacterBlueprintFunctionLibrary_SubClassMissingExportProxy : __CharacterBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D697 RID: 120471 RVA: 0x008CB788 File Offset: 0x008C9988
	[NullableContext(1)]
	protected __CharacterBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharacterBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D698 RID: 120472 RVA: 0x008CB7BB File Offset: 0x008C99BB
	protected __CharacterBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
