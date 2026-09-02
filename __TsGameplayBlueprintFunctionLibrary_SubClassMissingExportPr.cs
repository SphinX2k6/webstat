using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C8 RID: 14536
public class __TsGameplayBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsGameplayBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D6AB RID: 120491 RVA: 0x008CB9E0 File Offset: 0x008C9BE0
	[NullableContext(1)]
	protected __TsGameplayBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameplayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6AC RID: 120492 RVA: 0x008CBA13 File Offset: 0x008C9C13
	protected __TsGameplayBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
