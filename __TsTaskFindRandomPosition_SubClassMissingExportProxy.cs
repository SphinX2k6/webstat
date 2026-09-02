using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003622 RID: 13858
public class __TsTaskFindRandomPosition_SubClassMissingExportProxy : __TsTaskFindRandomPosition_InheritProxy
{
	// Token: 0x0601CDB9 RID: 118201 RVA: 0x008B659C File Offset: 0x008B479C
	[NullableContext(1)]
	protected __TsTaskFindRandomPosition_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFindRandomPosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDBA RID: 118202 RVA: 0x008B65CF File Offset: 0x008B47CF
	protected __TsTaskFindRandomPosition_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
