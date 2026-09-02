using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B4 RID: 14516
public class __LogicDataSuiGuang_SubClassMissingExportProxy : __LogicDataSuiGuang_InheritProxy
{
	// Token: 0x0601D66B RID: 120427 RVA: 0x008CAFC8 File Offset: 0x008C91C8
	[NullableContext(1)]
	protected __LogicDataSuiGuang_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSuiGuang.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D66C RID: 120428 RVA: 0x008CAFFB File Offset: 0x008C91FB
	protected __LogicDataSuiGuang_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
