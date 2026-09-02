using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200367A RID: 13946
public class __TsTaskTurnToTarget_SubClassMissingExportProxy : __TsTaskTurnToTarget_InheritProxy
{
	// Token: 0x0601CEAD RID: 118445 RVA: 0x008B8814 File Offset: 0x008B6A14
	[NullableContext(1)]
	protected __TsTaskTurnToTarget_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CEAE RID: 118446 RVA: 0x008B8847 File Offset: 0x008B6A47
	protected __TsTaskTurnToTarget_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
