using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003848 RID: 14408
public class __TsGameSplineActor_SubClassMissingExportProxy : __TsGameSplineActor_InheritProxy
{
	// Token: 0x0601D521 RID: 120097 RVA: 0x008C80E8 File Offset: 0x008C62E8
	[NullableContext(1)]
	protected __TsGameSplineActor_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsGameSplineActor.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D522 RID: 120098 RVA: 0x008C811B File Offset: 0x008C631B
	protected __TsGameSplineActor_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
