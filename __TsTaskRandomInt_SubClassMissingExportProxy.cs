using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003650 RID: 13904
public class __TsTaskRandomInt_SubClassMissingExportProxy : __TsTaskRandomInt_InheritProxy
{
	// Token: 0x0601CE3A RID: 118330 RVA: 0x008B77FC File Offset: 0x008B59FC
	[NullableContext(1)]
	protected __TsTaskRandomInt_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskRandomInt.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE3B RID: 118331 RVA: 0x008B782F File Offset: 0x008B5A2F
	protected __TsTaskRandomInt_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
