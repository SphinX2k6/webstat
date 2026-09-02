using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200356C RID: 13676
public class __TsDecoratorDistance_SubClassMissingExportProxy : __TsDecoratorDistance_InheritProxy
{
	// Token: 0x0601CBBE RID: 117694 RVA: 0x008B1E1C File Offset: 0x008B001C
	[NullableContext(1)]
	protected __TsDecoratorDistance_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorDistance.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBBF RID: 117695 RVA: 0x008B1E4F File Offset: 0x008B004F
	protected __TsDecoratorDistance_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
