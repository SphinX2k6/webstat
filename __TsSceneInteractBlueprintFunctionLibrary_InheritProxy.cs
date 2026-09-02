using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D1 RID: 14545
public class __TsSceneInteractBlueprintFunctionLibrary_InheritProxy : TsSceneInteractBlueprintFunctionLibrary
{
	// Token: 0x0601D6BD RID: 120509 RVA: 0x008CBBFC File Offset: 0x008C9DFC
	[NullableContext(1)]
	public __TsSceneInteractBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSceneInteractBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6BE RID: 120510 RVA: 0x008CBC2F File Offset: 0x008C9E2F
	protected __TsSceneInteractBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
