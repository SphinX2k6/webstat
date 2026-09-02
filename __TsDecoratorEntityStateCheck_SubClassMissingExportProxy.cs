using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003532 RID: 13618
public class __TsDecoratorEntityStateCheck_SubClassMissingExportProxy : __TsDecoratorEntityStateCheck_InheritProxy
{
	// Token: 0x0601CB2B RID: 117547 RVA: 0x008B0A34 File Offset: 0x008AEC34
	[NullableContext(1)]
	protected __TsDecoratorEntityStateCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorEntityStateCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CB2C RID: 117548 RVA: 0x008B0A67 File Offset: 0x008AEC67
	protected __TsDecoratorEntityStateCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
