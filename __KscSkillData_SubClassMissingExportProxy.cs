using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003844 RID: 14404
public class __KscSkillData_SubClassMissingExportProxy : __KscSkillData_InheritProxy
{
	// Token: 0x0601D516 RID: 120086 RVA: 0x008C7F1C File Offset: 0x008C611C
	[NullableContext(1)]
	protected __KscSkillData_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(KscSkillData.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D517 RID: 120087 RVA: 0x008C7F4F File Offset: 0x008C614F
	protected __KscSkillData_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
