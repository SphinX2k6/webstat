using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200356E RID: 13678
public class __TsDecoratorFight_SubClassMissingExportProxy : __TsDecoratorFight_InheritProxy
{
	// Token: 0x0601CBC3 RID: 117699 RVA: 0x008B1EC8 File Offset: 0x008B00C8
	[NullableContext(1)]
	protected __TsDecoratorFight_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorFight.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBC4 RID: 117700 RVA: 0x008B1EFB File Offset: 0x008B00FB
	protected __TsDecoratorFight_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
