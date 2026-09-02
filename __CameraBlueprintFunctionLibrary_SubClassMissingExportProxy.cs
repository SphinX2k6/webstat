using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003826 RID: 14374
public class __CameraBlueprintFunctionLibrary_SubClassMissingExportProxy : __CameraBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D48A RID: 119946 RVA: 0x008C6514 File Offset: 0x008C4714
	[NullableContext(1)]
	protected __CameraBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CameraBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D48B RID: 119947 RVA: 0x008C6547 File Offset: 0x008C4747
	protected __CameraBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
