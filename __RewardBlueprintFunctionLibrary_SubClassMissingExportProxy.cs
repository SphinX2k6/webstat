using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003862 RID: 14434
public class __RewardBlueprintFunctionLibrary_SubClassMissingExportProxy : __RewardBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D593 RID: 120211 RVA: 0x008C978C File Offset: 0x008C798C
	[NullableContext(1)]
	protected __RewardBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(RewardBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D594 RID: 120212 RVA: 0x008C97BF File Offset: 0x008C79BF
	protected __RewardBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
