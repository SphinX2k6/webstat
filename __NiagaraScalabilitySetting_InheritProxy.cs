using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200394D RID: 14669
public class __NiagaraScalabilitySetting_InheritProxy : NiagaraScalabilitySetting
{
	// Token: 0x0601D90A RID: 121098 RVA: 0x008D2EE4 File Offset: 0x008D10E4
	[NullableContext(1)]
	public __NiagaraScalabilitySetting_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NiagaraScalabilitySetting.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D90B RID: 121099 RVA: 0x008D2F17 File Offset: 0x008D1117
	protected __NiagaraScalabilitySetting_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
