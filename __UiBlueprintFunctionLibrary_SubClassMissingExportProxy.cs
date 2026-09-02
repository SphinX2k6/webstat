using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003856 RID: 14422
public class __UiBlueprintFunctionLibrary_SubClassMissingExportProxy : __UiBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D559 RID: 120153 RVA: 0x008C8C60 File Offset: 0x008C6E60
	[NullableContext(1)]
	protected __UiBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(UiBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D55A RID: 120154 RVA: 0x008C8C93 File Offset: 0x008C6E93
	protected __UiBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
