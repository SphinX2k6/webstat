using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003560 RID: 13664
public class __TsDecoratorCheckMoveStuck_SubClassMissingExportProxy : __TsDecoratorCheckMoveStuck_InheritProxy
{
	// Token: 0x0601CBA0 RID: 117664 RVA: 0x008B1A14 File Offset: 0x008AFC14
	[NullableContext(1)]
	protected __TsDecoratorCheckMoveStuck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorCheckMoveStuck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBA1 RID: 117665 RVA: 0x008B1A47 File Offset: 0x008AFC47
	protected __TsDecoratorCheckMoveStuck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
