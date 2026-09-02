using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035C6 RID: 13766
public class __TsTaskPatrolWithEvents_SubClassMissingExportProxy : __TsTaskPatrolWithEvents_InheritProxy
{
	// Token: 0x0601CCA9 RID: 117929 RVA: 0x008B3DFC File Offset: 0x008B1FFC
	[NullableContext(1)]
	protected __TsTaskPatrolWithEvents_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolWithEvents.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CCAA RID: 117930 RVA: 0x008B3E2F File Offset: 0x008B202F
	protected __TsTaskPatrolWithEvents_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
