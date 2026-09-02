using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D0 RID: 14544
public class __TsMoveBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsMoveBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D6BB RID: 120507 RVA: 0x008CBBC0 File Offset: 0x008C9DC0
	[NullableContext(1)]
	protected __TsMoveBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMoveBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6BC RID: 120508 RVA: 0x008CBBF3 File Offset: 0x008C9DF3
	protected __TsMoveBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
