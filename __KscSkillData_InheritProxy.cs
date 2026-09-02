using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003843 RID: 14403
public class __KscSkillData_InheritProxy : KscSkillData
{
	// Token: 0x0601D514 RID: 120084 RVA: 0x008C7EE0 File Offset: 0x008C60E0
	[NullableContext(1)]
	public __KscSkillData_InheritProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscSkillData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D515 RID: 120085 RVA: 0x008C7F13 File Offset: 0x008C6113
	protected __KscSkillData_InheritProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
