using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003861 RID: 14433
public class __RewardBlueprintFunctionLibrary_InheritProxy : RewardBlueprintFunctionLibrary
{
	// Token: 0x0601D591 RID: 120209 RVA: 0x008C9750 File Offset: 0x008C7950
	[NullableContext(1)]
	public __RewardBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(RewardBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D592 RID: 120210 RVA: 0x008C9783 File Offset: 0x008C7983
	protected __RewardBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
