using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200354C RID: 13644
public class __TsDecoratorBlackboardHasEntity_SubClassMissingExportProxy : __TsDecoratorBlackboardHasEntity_InheritProxy
{
	// Token: 0x0601CB6C RID: 117612 RVA: 0x008B12F0 File Offset: 0x008AF4F0
	[NullableContext(1)]
	protected __TsDecoratorBlackboardHasEntity_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboardHasEntity.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB6D RID: 117613 RVA: 0x008B1323 File Offset: 0x008AF523
	protected __TsDecoratorBlackboardHasEntity_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
