using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200383C RID: 14396
public class __TsEffectFunctionLibrary_SubClassMissingExportProxy : __TsEffectFunctionLibrary_InheritProxy
{
	// Token: 0x0601D506 RID: 120070 RVA: 0x008C7D3C File Offset: 0x008C5F3C
	[NullableContext(1)]
	protected __TsEffectFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsEffectFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D507 RID: 120071 RVA: 0x008C7D6F File Offset: 0x008C5F6F
	protected __TsEffectFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
