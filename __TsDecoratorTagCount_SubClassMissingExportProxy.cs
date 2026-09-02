using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200358C RID: 13708
public class __TsDecoratorTagCount_SubClassMissingExportProxy : __TsDecoratorTagCount_InheritProxy
{
	// Token: 0x0601CC0E RID: 117774 RVA: 0x008B28DC File Offset: 0x008B0ADC
	[NullableContext(1)]
	protected __TsDecoratorTagCount_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorTagCount.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC0F RID: 117775 RVA: 0x008B290F File Offset: 0x008B0B0F
	protected __TsDecoratorTagCount_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
