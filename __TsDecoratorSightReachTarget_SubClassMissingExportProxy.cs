using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003588 RID: 13704
public class __TsDecoratorSightReachTarget_SubClassMissingExportProxy : __TsDecoratorSightReachTarget_InheritProxy
{
	// Token: 0x0601CC04 RID: 117764 RVA: 0x008B2784 File Offset: 0x008B0984
	[NullableContext(1)]
	protected __TsDecoratorSightReachTarget_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorSightReachTarget.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC05 RID: 117765 RVA: 0x008B27B7 File Offset: 0x008B09B7
	protected __TsDecoratorSightReachTarget_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
