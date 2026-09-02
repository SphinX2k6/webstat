using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038E6 RID: 14566
public class __TsSimpleInteractHookPoint_SubClassMissingExportProxy : __TsSimpleInteractHookPoint_InheritProxy
{
	// Token: 0x0601D70C RID: 120588 RVA: 0x008CC8A0 File Offset: 0x008CAAA0
	[NullableContext(1)]
	protected __TsSimpleInteractHookPoint_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSimpleInteractHookPoint.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D70D RID: 120589 RVA: 0x008CC8D3 File Offset: 0x008CAAD3
	protected __TsSimpleInteractHookPoint_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
