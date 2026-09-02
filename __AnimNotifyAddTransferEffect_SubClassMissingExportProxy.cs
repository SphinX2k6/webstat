using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003912 RID: 14610
public class __AnimNotifyAddTransferEffect_SubClassMissingExportProxy : __AnimNotifyAddTransferEffect_InheritProxy
{
	// Token: 0x0601D804 RID: 120836 RVA: 0x008CF8BC File Offset: 0x008CDABC
	[NullableContext(1)]
	protected __AnimNotifyAddTransferEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyAddTransferEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D805 RID: 120837 RVA: 0x008CF8EF File Offset: 0x008CDAEF
	protected __AnimNotifyAddTransferEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
