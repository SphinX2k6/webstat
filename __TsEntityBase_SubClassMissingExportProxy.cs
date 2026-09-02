using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003978 RID: 14712
public class __TsEntityBase_SubClassMissingExportProxy : __TsEntityBase_InheritProxy
{
	// Token: 0x0601DA13 RID: 121363 RVA: 0x008D674C File Offset: 0x008D494C
	[NullableContext(1)]
	protected __TsEntityBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEntityBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601DA14 RID: 121364 RVA: 0x008D677F File Offset: 0x008D497F
	protected __TsEntityBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
