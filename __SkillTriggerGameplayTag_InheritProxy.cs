using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D9 RID: 14553
public class __SkillTriggerGameplayTag_InheritProxy : SkillTriggerGameplayTag
{
	// Token: 0x0601D6CD RID: 120525 RVA: 0x008CBDDC File Offset: 0x008C9FDC
	[NullableContext(1)]
	public __SkillTriggerGameplayTag_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerGameplayTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6CE RID: 120526 RVA: 0x008CBE0F File Offset: 0x008CA00F
	protected __SkillTriggerGameplayTag_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
