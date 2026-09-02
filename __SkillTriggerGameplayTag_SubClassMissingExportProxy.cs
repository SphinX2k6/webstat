using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038DA RID: 14554
public class __SkillTriggerGameplayTag_SubClassMissingExportProxy : __SkillTriggerGameplayTag_InheritProxy
{
	// Token: 0x0601D6CF RID: 120527 RVA: 0x008CBE18 File Offset: 0x008CA018
	[NullableContext(1)]
	protected __SkillTriggerGameplayTag_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerGameplayTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6D0 RID: 120528 RVA: 0x008CBE4B File Offset: 0x008CA04B
	protected __SkillTriggerGameplayTag_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
