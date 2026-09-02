using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003965 RID: 14693
public class __CombatDebugBlueprintFunctionLibrary_InheritProxy : CombatDebugBlueprintFunctionLibrary
{
	// Token: 0x0601D9D4 RID: 121300 RVA: 0x008D5C78 File Offset: 0x008D3E78
	[NullableContext(1)]
	public __CombatDebugBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CombatDebugBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9D5 RID: 121301 RVA: 0x008D5CAB File Offset: 0x008D3EAB
	protected __CombatDebugBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
