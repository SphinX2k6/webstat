using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003966 RID: 14694
public class __CombatDebugBlueprintFunctionLibrary_SubClassMissingExportProxy : __CombatDebugBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D9D6 RID: 121302 RVA: 0x008D5CB4 File Offset: 0x008D3EB4
	[NullableContext(1)]
	protected __CombatDebugBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CombatDebugBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9D7 RID: 121303 RVA: 0x008D5CE7 File Offset: 0x008D3EE7
	protected __CombatDebugBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
