using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035CA RID: 13770
public class __TsTaskTurnToEntity_SubClassMissingExportProxy : __TsTaskTurnToEntity_InheritProxy
{
	// Token: 0x0601CCB4 RID: 117940 RVA: 0x008B3F80 File Offset: 0x008B2180
	[NullableContext(1)]
	protected __TsTaskTurnToEntity_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTurnToEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CCB5 RID: 117941 RVA: 0x008B3FB3 File Offset: 0x008B21B3
	protected __TsTaskTurnToEntity_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
