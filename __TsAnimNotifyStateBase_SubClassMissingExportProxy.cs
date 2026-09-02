using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020036A4 RID: 13988
public class __TsAnimNotifyStateBase_SubClassMissingExportProxy : __TsAnimNotifyStateBase_InheritProxy
{
	// Token: 0x0601CF93 RID: 118675 RVA: 0x008BB7E8 File Offset: 0x008B99E8
	[NullableContext(1)]
	protected __TsAnimNotifyStateBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyStateBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CF94 RID: 118676 RVA: 0x008BB81B File Offset: 0x008B9A1B
	protected __TsAnimNotifyStateBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
