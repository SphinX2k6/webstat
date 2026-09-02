using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003636 RID: 13878
public class __TsTaskMoveToActor_SubClassMissingExportProxy : __TsTaskMoveToActor_InheritProxy
{
	// Token: 0x0601CDF3 RID: 118259 RVA: 0x008B6E38 File Offset: 0x008B5038
	[NullableContext(1)]
	protected __TsTaskMoveToActor_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskMoveToActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDF4 RID: 118260 RVA: 0x008B6E6B File Offset: 0x008B506B
	protected __TsTaskMoveToActor_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
