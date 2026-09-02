using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003889 RID: 14473
public class __BulletBlueprintFunctionLibrary_InheritProxy : BulletBlueprintFunctionLibrary
{
	// Token: 0x0601D615 RID: 120341 RVA: 0x008CA5B4 File Offset: 0x008C87B4
	[NullableContext(1)]
	public __BulletBlueprintFunctionLibrary_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletBlueprintFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D616 RID: 120342 RVA: 0x008CA5E7 File Offset: 0x008C87E7
	protected __BulletBlueprintFunctionLibrary_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
