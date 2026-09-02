using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A8 RID: 14504
public class __LogicDataShakeScreen_SubClassMissingExportProxy : __LogicDataShakeScreen_InheritProxy
{
	// Token: 0x0601D653 RID: 120403 RVA: 0x008CACF8 File Offset: 0x008C8EF8
	[NullableContext(1)]
	protected __LogicDataShakeScreen_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShakeScreen.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D654 RID: 120404 RVA: 0x008CAD2B File Offset: 0x008C8F2B
	protected __LogicDataShakeScreen_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
