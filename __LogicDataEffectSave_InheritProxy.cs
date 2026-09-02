using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200389B RID: 14491
public class __LogicDataEffectSave_InheritProxy : LogicDataEffectSave
{
	// Token: 0x0601D639 RID: 120377 RVA: 0x008CA9EC File Offset: 0x008C8BEC
	[NullableContext(1)]
	public __LogicDataEffectSave_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataEffectSave.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D63A RID: 120378 RVA: 0x008CAA1F File Offset: 0x008C8C1F
	protected __LogicDataEffectSave_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
