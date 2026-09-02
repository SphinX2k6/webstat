using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003849 RID: 14409
public class __LevelGamePlayBlueprintFunctionLibrary_InheritProxy : LevelGamePlayBlueprintFunctionLibrary
{
	// Token: 0x0601D523 RID: 120099 RVA: 0x008C8124 File Offset: 0x008C6324
	[NullableContext(1)]
	public __LevelGamePlayBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGamePlayBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D524 RID: 120100 RVA: 0x008C8157 File Offset: 0x008C6357
	protected __LevelGamePlayBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
