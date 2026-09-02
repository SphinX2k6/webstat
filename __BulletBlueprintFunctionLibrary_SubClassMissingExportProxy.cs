using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200388A RID: 14474
public class __BulletBlueprintFunctionLibrary_SubClassMissingExportProxy : __BulletBlueprintFunctionLibrary_InheritProxy
{
	// Token: 0x0601D617 RID: 120343 RVA: 0x008CA5F0 File Offset: 0x008C87F0
	[NullableContext(1)]
	protected __BulletBlueprintFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D618 RID: 120344 RVA: 0x008CA623 File Offset: 0x008C8823
	protected __BulletBlueprintFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
