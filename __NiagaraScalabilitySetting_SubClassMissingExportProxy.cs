using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394E RID: 14670
public class __NiagaraScalabilitySetting_SubClassMissingExportProxy : __NiagaraScalabilitySetting_InheritProxy
{
	// Token: 0x0601D90C RID: 121100 RVA: 0x008D2F20 File Offset: 0x008D1120
	[NullableContext(1)]
	protected __NiagaraScalabilitySetting_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NiagaraScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D90D RID: 121101 RVA: 0x008D2F53 File Offset: 0x008D1153
	protected __NiagaraScalabilitySetting_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
