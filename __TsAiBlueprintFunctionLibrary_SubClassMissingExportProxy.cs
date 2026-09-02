using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C0 RID: 14528
public class __TsAiBlueprintFunctionLibrary_SubClassMissingExportProxy : __TsAiBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D69B RID: 120475 RVA: 0x008CB800 File Offset: 0x008C9A00
	[NullableContext(1)]
	protected __TsAiBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D69C RID: 120476 RVA: 0x008CB833 File Offset: 0x008C9A33
	protected __TsAiBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
