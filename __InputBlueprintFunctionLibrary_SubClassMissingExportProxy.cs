using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200383E RID: 14398
public class __InputBlueprintFunctionLibrary_SubClassMissingExportProxy : __InputBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D50A RID: 120074 RVA: 0x008C7DB4 File Offset: 0x008C5FB4
	[NullableContext(1)]
	protected __InputBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(InputBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D50B RID: 120075 RVA: 0x008C7DE7 File Offset: 0x008C5FE7
	protected __InputBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
