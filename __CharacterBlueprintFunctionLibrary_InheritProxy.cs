using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038BD RID: 14525
public class __CharacterBlueprintFunctionLibrary_InheritProxy : CharacterBlueprintFunctionLibrary
{
	// Token: 0x0601D695 RID: 120469 RVA: 0x008CB74C File Offset: 0x008C994C
	[NullableContext(1)]
	public __CharacterBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CharacterBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D696 RID: 120470 RVA: 0x008CB77F File Offset: 0x008C997F
	protected __CharacterBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
