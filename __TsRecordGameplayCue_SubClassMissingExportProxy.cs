using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003902 RID: 14594
public class __TsRecordGameplayCue_SubClassMissingExportProxy : __TsRecordGameplayCue_InheritProxy
{
	// Token: 0x0601D790 RID: 120720 RVA: 0x008CE100 File Offset: 0x008CC300
	[NullableContext(1)]
	protected __TsRecordGameplayCue_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsRecordGameplayCue.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D791 RID: 120721 RVA: 0x008CE133 File Offset: 0x008CC333
	protected __TsRecordGameplayCue_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
