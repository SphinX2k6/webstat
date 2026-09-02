using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003570 RID: 13680
public class __TsDecoratorGeCheck_SubClassMissingExportProxy : __TsDecoratorGeCheck_InheritProxy
{
	// Token: 0x0601CBC8 RID: 117704 RVA: 0x008B1F74 File Offset: 0x008B0174
	[NullableContext(1)]
	protected __TsDecoratorGeCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBC9 RID: 117705 RVA: 0x008B1FA7 File Offset: 0x008B01A7
	protected __TsDecoratorGeCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
