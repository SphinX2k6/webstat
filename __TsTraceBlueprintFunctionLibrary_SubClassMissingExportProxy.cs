using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D4 RID: 14548
public class __TsTraceBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsTraceBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D6C3 RID: 120515 RVA: 0x008CBCB0 File Offset: 0x008C9EB0
	[NullableContext(1)]
	protected __TsTraceBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTraceBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6C4 RID: 120516 RVA: 0x008CBCE3 File Offset: 0x008C9EE3
	protected __TsTraceBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
