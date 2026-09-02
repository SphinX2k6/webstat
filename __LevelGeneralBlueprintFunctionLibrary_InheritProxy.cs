using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200384B RID: 14411
public class __LevelGeneralBlueprintFunctionLibrary_InheritProxy : LevelGeneralBlueprintFunctionLibrary
{
	// Token: 0x0601D527 RID: 120103 RVA: 0x008C819C File Offset: 0x008C639C
	[NullableContext(1)]
	public __LevelGeneralBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LevelGeneralBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D528 RID: 120104 RVA: 0x008C81CF File Offset: 0x008C63CF
	protected __LevelGeneralBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
