using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200377C RID: 14204
public class __TsAnimNotifyBase_SubClassMissingExportProxy : __TsAnimNotifyBase_InheritProxy
{
	// Token: 0x0601D291 RID: 119441 RVA: 0x008C25F8 File Offset: 0x008C07F8
	[NullableContext(1)]
	protected __TsAnimNotifyBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D292 RID: 119442 RVA: 0x008C262B File Offset: 0x008C082B
	protected __TsAnimNotifyBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
