using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003939 RID: 14649
public class __EffectModelMaterialController_InheritProxy : EffectModelMaterialController
{
	// Token: 0x0601D8E2 RID: 121058 RVA: 0x008D2A34 File Offset: 0x008D0C34
	[NullableContext(1)]
	public __EffectModelMaterialController_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMaterialController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8E3 RID: 121059 RVA: 0x008D2A67 File Offset: 0x008D0C67
	protected __EffectModelMaterialController_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
