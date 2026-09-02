using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035B8 RID: 13752
public class __TsTaskMoveToTarget_SubClassMissingExportProxy : __TsTaskMoveToTarget_InheritProxy
{
	// Token: 0x0601CC83 RID: 117891 RVA: 0x008B38C8 File Offset: 0x008B1AC8
	[NullableContext(1)]
	protected __TsTaskMoveToTarget_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC84 RID: 117892 RVA: 0x008B38FB File Offset: 0x008B1AFB
	protected __TsTaskMoveToTarget_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
