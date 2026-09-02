using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200392B RID: 14635
public class __EffectModelBillboard_InheritProxy : EffectModelBillboard
{
	// Token: 0x0601D8C6 RID: 121030 RVA: 0x008D26EC File Offset: 0x008D08EC
	[NullableContext(1)]
	public __EffectModelBillboard_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelBillboard.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8C7 RID: 121031 RVA: 0x008D271F File Offset: 0x008D091F
	protected __EffectModelBillboard_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
