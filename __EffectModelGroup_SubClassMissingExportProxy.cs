using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003936 RID: 14646
public class __EffectModelGroup_SubClassMissingExportProxy : __EffectModelGroup_InheritProxy
{
	// Token: 0x0601D8DC RID: 121052 RVA: 0x008D2980 File Offset: 0x008D0B80
	[NullableContext(1)]
	protected __EffectModelGroup_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(EffectModelGroup.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8DD RID: 121053 RVA: 0x008D29B3 File Offset: 0x008D0BB3
	protected __EffectModelGroup_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
