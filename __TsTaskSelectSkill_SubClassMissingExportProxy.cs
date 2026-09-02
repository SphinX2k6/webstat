using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003658 RID: 13912
public class __TsTaskSelectSkill_SubClassMissingExportProxy : __TsTaskSelectSkill_InheritProxy
{
	// Token: 0x0601CE4F RID: 118351 RVA: 0x008B7AD4 File Offset: 0x008B5CD4
	[NullableContext(1)]
	protected __TsTaskSelectSkill_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSelectSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE50 RID: 118352 RVA: 0x008B7B07 File Offset: 0x008B5D07
	protected __TsTaskSelectSkill_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
