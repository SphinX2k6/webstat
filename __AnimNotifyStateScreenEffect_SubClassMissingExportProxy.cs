using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003920 RID: 14624
public class __AnimNotifyStateScreenEffect_SubClassMissingExportProxy : __AnimNotifyStateScreenEffect_InheritProxy
{
	// Token: 0x0601D8AC RID: 121004 RVA: 0x008D23A4 File Offset: 0x008D05A4
	[NullableContext(1)]
	protected __AnimNotifyStateScreenEffect_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateScreenEffect.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8AD RID: 121005 RVA: 0x008D23D7 File Offset: 0x008D05D7
	protected __AnimNotifyStateScreenEffect_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
