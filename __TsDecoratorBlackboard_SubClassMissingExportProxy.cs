using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003544 RID: 13636
public class __TsDecoratorBlackboard_SubClassMissingExportProxy : __TsDecoratorBlackboard_InheritProxy
{
	// Token: 0x0601CB58 RID: 117592 RVA: 0x008B1040 File Offset: 0x008AF240
	[NullableContext(1)]
	protected __TsDecoratorBlackboard_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorBlackboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB59 RID: 117593 RVA: 0x008B1073 File Offset: 0x008AF273
	protected __TsDecoratorBlackboard_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
