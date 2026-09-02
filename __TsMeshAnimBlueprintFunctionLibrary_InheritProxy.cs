using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038CD RID: 14541
public class __TsMeshAnimBlueprintFunctionLibrary_InheritProxy : TsMeshAnimBlueprintFunctionLibrary
{
	// Token: 0x0601D6B5 RID: 120501 RVA: 0x008CBB0C File Offset: 0x008C9D0C
	[NullableContext(1)]
	public __TsMeshAnimBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsMeshAnimBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6B6 RID: 120502 RVA: 0x008CBB3F File Offset: 0x008C9D3F
	protected __TsMeshAnimBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
