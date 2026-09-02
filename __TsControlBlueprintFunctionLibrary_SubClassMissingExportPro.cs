using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C4 RID: 14532
public class __TsControlBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsControlBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D6A3 RID: 120483 RVA: 0x008CB8F0 File Offset: 0x008C9AF0
	[NullableContext(1)]
	protected __TsControlBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsControlBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6A4 RID: 120484 RVA: 0x008CB923 File Offset: 0x008C9B23
	protected __TsControlBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
