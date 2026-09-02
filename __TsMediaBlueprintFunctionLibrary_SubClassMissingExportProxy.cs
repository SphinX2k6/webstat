using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038CC RID: 14540
public class __TsMediaBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsMediaBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D6B3 RID: 120499 RVA: 0x008CBAD0 File Offset: 0x008C9CD0
	[NullableContext(1)]
	protected __TsMediaBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMediaBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6B4 RID: 120500 RVA: 0x008CBB03 File Offset: 0x008C9D03
	protected __TsMediaBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
