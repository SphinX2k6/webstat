using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D8 RID: 14552
public class __SkillTriggerBase_SubClassMissingExportProxy : __SkillTriggerBase_InheritProxy
{
	// Token: 0x0601D6CB RID: 120523 RVA: 0x008CBDA0 File Offset: 0x008C9FA0
	[NullableContext(1)]
	protected __SkillTriggerBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6CC RID: 120524 RVA: 0x008CBDD3 File Offset: 0x008C9FD3
	protected __SkillTriggerBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
