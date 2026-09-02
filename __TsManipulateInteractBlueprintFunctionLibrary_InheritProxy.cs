using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C9 RID: 14537
public class __TsManipulateInteractBlueprintFunctionLibrary_InheritProxy : TsManipulateInteractBlueprintFunctionLibrary
{
	// Token: 0x0601D6AD RID: 120493 RVA: 0x008CBA1C File Offset: 0x008C9C1C
	[NullableContext(1)]
	public __TsManipulateInteractBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsManipulateInteractBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6AE RID: 120494 RVA: 0x008CBA4F File Offset: 0x008C9C4F
	protected __TsManipulateInteractBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
