using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200393A RID: 14650
public class __EffectModelMaterialController_SubClassMissingExportProxy : __EffectModelMaterialController_InheritProxy
{
	// Token: 0x0601D8E4 RID: 121060 RVA: 0x008D2A70 File Offset: 0x008D0C70
	[NullableContext(1)]
	protected __EffectModelMaterialController_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelMaterialController.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8E5 RID: 121061 RVA: 0x008D2AA3 File Offset: 0x008D0CA3
	protected __EffectModelMaterialController_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
