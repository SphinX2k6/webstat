using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200363C RID: 13884
public class __TsTaskPatrolLogic_SubClassMissingExportProxy : __TsTaskPatrolLogic_InheritProxy
{
	// Token: 0x0601CE05 RID: 118277 RVA: 0x008B70CC File Offset: 0x008B52CC
	[NullableContext(1)]
	protected __TsTaskPatrolLogic_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskPatrolLogic.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE06 RID: 118278 RVA: 0x008B70FF File Offset: 0x008B52FF
	protected __TsTaskPatrolLogic_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
