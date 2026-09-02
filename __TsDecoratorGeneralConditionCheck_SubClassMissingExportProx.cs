using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003572 RID: 13682
public class __TsDecoratorGeneralConditionCheck_SubClassMissingExportProxy : __TsDecoratorGeneralConditionCheck_InheritProxy
{
	// Token: 0x0601CBCD RID: 117709 RVA: 0x008B2020 File Offset: 0x008B0220
	[NullableContext(1)]
	protected __TsDecoratorGeneralConditionCheck_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsDecoratorGeneralConditionCheck.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CBCE RID: 117710 RVA: 0x008B2053 File Offset: 0x008B0253
	protected __TsDecoratorGeneralConditionCheck_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
