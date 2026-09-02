using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038EA RID: 14570
public class __TsSimpleInteractPoint_SubClassMissingExportProxy : __TsSimpleInteractPoint_InheritProxy
{
	// Token: 0x0601D714 RID: 120596 RVA: 0x008CC990 File Offset: 0x008CAB90
	[NullableContext(1)]
	protected __TsSimpleInteractPoint_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D715 RID: 120597 RVA: 0x008CC9C3 File Offset: 0x008CABC3
	protected __TsSimpleInteractPoint_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
