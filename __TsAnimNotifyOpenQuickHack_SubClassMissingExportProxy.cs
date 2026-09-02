using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020037DE RID: 14302
public class __TsAnimNotifyOpenQuickHack_SubClassMissingExportProxy : __TsAnimNotifyOpenQuickHack_InheritProxy
{
	// Token: 0x0601D3B7 RID: 119735 RVA: 0x008C4AB8 File Offset: 0x008C2CB8
	[NullableContext(1)]
	protected __TsAnimNotifyOpenQuickHack_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsAnimNotifyOpenQuickHack.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D3B8 RID: 119736 RVA: 0x008C4AEB File Offset: 0x008C2CEB
	protected __TsAnimNotifyOpenQuickHack_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
