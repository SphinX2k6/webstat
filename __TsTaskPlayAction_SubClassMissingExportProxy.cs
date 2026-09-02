using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003640 RID: 13888
public class __TsTaskPlayAction_SubClassMissingExportProxy : __TsTaskPlayAction_InheritProxy
{
	// Token: 0x0601CE10 RID: 118288 RVA: 0x008B7250 File Offset: 0x008B5450
	[NullableContext(1)]
	protected __TsTaskPlayAction_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPlayAction.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE11 RID: 118289 RVA: 0x008B7283 File Offset: 0x008B5483
	protected __TsTaskPlayAction_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
