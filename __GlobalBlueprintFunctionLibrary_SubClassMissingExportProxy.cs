using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003968 RID: 14696
public class __GlobalBlueprintFunctionLibrary_SubClassMissingExportProxy : __GlobalBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D9DA RID: 121306 RVA: 0x008D5D2C File Offset: 0x008D3F2C
	[NullableContext(1)]
	protected __GlobalBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(GlobalBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9DB RID: 121307 RVA: 0x008D5D5F File Offset: 0x008D3F5F
	protected __GlobalBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
