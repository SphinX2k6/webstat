using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200352E RID: 13614
public class __TsDecoratorDistanceCheck_SubClassMissingExportProxy : __TsDecoratorDistanceCheck_InheritProxy
{
	// Token: 0x0601CB21 RID: 117537 RVA: 0x008B08DC File Offset: 0x008AEADC
	[NullableContext(1)]
	protected __TsDecoratorDistanceCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistanceCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB22 RID: 117538 RVA: 0x008B090F File Offset: 0x008AEB0F
	protected __TsDecoratorDistanceCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
