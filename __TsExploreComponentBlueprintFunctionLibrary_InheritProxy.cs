using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038C5 RID: 14533
public class __TsExploreComponentBlueprintFunctionLibrary_InheritProxy : TsExploreComponentBlueprintFunctionLibrary
{
	// Token: 0x0601D6A5 RID: 120485 RVA: 0x008CB92C File Offset: 0x008C9B2C
	[NullableContext(1)]
	public __TsExploreComponentBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsExploreComponentBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6A6 RID: 120486 RVA: 0x008CB95F File Offset: 0x008C9B5F
	protected __TsExploreComponentBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
