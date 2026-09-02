using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003574 RID: 13684
public class __TsDecoratorHasWeapon_SubClassMissingExportProxy : __TsDecoratorHasWeapon_InheritProxy
{
	// Token: 0x0601CBD2 RID: 117714 RVA: 0x008B20CC File Offset: 0x008B02CC
	[NullableContext(1)]
	protected __TsDecoratorHasWeapon_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorHasWeapon.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBD3 RID: 117715 RVA: 0x008B20FF File Offset: 0x008B02FF
	protected __TsDecoratorHasWeapon_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
