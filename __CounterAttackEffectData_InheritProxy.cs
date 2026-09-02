using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003837 RID: 14391
public class __CounterAttackEffectData_InheritProxy : CounterAttackEffectData
{
	// Token: 0x0601D4F5 RID: 120053 RVA: 0x008C7A6C File Offset: 0x008C5C6C
	[NullableContext(1)]
	public __CounterAttackEffectData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(CounterAttackEffectData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D4F6 RID: 120054 RVA: 0x008C7A9F File Offset: 0x008C5C9F
	protected __CounterAttackEffectData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
