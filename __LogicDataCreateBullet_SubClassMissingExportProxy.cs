using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003896 RID: 14486
public class __LogicDataCreateBullet_SubClassMissingExportProxy : __LogicDataCreateBullet_InheritProxy
{
	// Token: 0x0601D62F RID: 120367 RVA: 0x008CA8C0 File Offset: 0x008C8AC0
	[NullableContext(1)]
	protected __LogicDataCreateBullet_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D630 RID: 120368 RVA: 0x008CA8F3 File Offset: 0x008C8AF3
	protected __LogicDataCreateBullet_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
