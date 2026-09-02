using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200383D RID: 14397
public class __InputBlueprintFunctionLibrary_InheritProxy : InputBlueprintFunctionLibrary
{
	// Token: 0x0601D508 RID: 120072 RVA: 0x008C7D78 File Offset: 0x008C5F78
	[NullableContext(1)]
	public __InputBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(InputBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D509 RID: 120073 RVA: 0x008C7DAB File Offset: 0x008C5FAB
	protected __InputBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
