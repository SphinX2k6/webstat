using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003838 RID: 14392
public class __CounterAttackEffectData_SubClassMissingExportProxy : __CounterAttackEffectData_InheritProxy
{
	// Token: 0x0601D4F7 RID: 120055 RVA: 0x008C7AA8 File Offset: 0x008C5CA8
	[NullableContext(1)]
	protected __CounterAttackEffectData_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackEffectData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4F8 RID: 120056 RVA: 0x008C7ADB File Offset: 0x008C5CDB
	protected __CounterAttackEffectData_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
