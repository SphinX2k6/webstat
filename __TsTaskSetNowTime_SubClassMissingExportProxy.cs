using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200365E RID: 13918
public class __TsTaskSetNowTime_SubClassMissingExportProxy : __TsTaskSetNowTime_InheritProxy
{
	// Token: 0x0601CE5E RID: 118366 RVA: 0x008B7CD0 File Offset: 0x008B5ED0
	[NullableContext(1)]
	protected __TsTaskSetNowTime_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetNowTime.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE5F RID: 118367 RVA: 0x008B7D03 File Offset: 0x008B5F03
	protected __TsTaskSetNowTime_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
