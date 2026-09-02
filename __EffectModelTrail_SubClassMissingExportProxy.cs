using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003948 RID: 14664
public class __EffectModelTrail_SubClassMissingExportProxy : __EffectModelTrail_InheritProxy
{
	// Token: 0x0601D900 RID: 121088 RVA: 0x008D2DB8 File Offset: 0x008D0FB8
	[NullableContext(1)]
	protected __EffectModelTrail_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelTrail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D901 RID: 121089 RVA: 0x008D2DEB File Offset: 0x008D0FEB
	protected __EffectModelTrail_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
