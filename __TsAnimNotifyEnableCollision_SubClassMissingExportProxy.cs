using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037BE RID: 14270
public class __TsAnimNotifyEnableCollision_SubClassMissingExportProxy : __TsAnimNotifyEnableCollision_InheritProxy
{
	// Token: 0x0601D357 RID: 119639 RVA: 0x008C3EB8 File Offset: 0x008C20B8
	[NullableContext(1)]
	protected __TsAnimNotifyEnableCollision_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyEnableCollision.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D358 RID: 119640 RVA: 0x008C3EEB File Offset: 0x008C20EB
	protected __TsAnimNotifyEnableCollision_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
