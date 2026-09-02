using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038A2 RID: 14498
public class __LogicDataManipulatableCreateBullet_SubClassMissingExportProxy : __LogicDataManipulatableCreateBullet_InheritProxy
{
	// Token: 0x0601D647 RID: 120391 RVA: 0x008CAB90 File Offset: 0x008C8D90
	[NullableContext(1)]
	protected __LogicDataManipulatableCreateBullet_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataManipulatableCreateBullet.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D648 RID: 120392 RVA: 0x008CABC3 File Offset: 0x008C8DC3
	protected __LogicDataManipulatableCreateBullet_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
