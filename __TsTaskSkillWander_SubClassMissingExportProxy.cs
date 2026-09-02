using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003664 RID: 13924
public class __TsTaskSkillWander_SubClassMissingExportProxy : __TsTaskSkillWander_InheritProxy
{
	// Token: 0x0601CE6E RID: 118382 RVA: 0x008B7F00 File Offset: 0x008B6100
	[NullableContext(1)]
	protected __TsTaskSkillWander_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSkillWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE6F RID: 118383 RVA: 0x008B7F33 File Offset: 0x008B6133
	protected __TsTaskSkillWander_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
