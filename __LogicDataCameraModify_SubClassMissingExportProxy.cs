using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003894 RID: 14484
public class __LogicDataCameraModify_SubClassMissingExportProxy : __LogicDataCameraModify_InheritProxy
{
	// Token: 0x0601D62B RID: 120363 RVA: 0x008CA848 File Offset: 0x008C8A48
	[NullableContext(1)]
	protected __LogicDataCameraModify_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataCameraModify.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D62C RID: 120364 RVA: 0x008CA87B File Offset: 0x008C8A7B
	protected __LogicDataCameraModify_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
