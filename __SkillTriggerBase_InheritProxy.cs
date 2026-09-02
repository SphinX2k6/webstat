using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038D7 RID: 14551
public class __SkillTriggerBase_InheritProxy : SkillTriggerBase
{
	// Token: 0x0601D6C9 RID: 120521 RVA: 0x008CBD64 File Offset: 0x008C9F64
	[NullableContext(1)]
	public __SkillTriggerBase_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(SkillTriggerBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D6CA RID: 120522 RVA: 0x008CBD97 File Offset: 0x008C9F97
	protected __SkillTriggerBase_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
