using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200367E RID: 13950
public class __TsTaskUseSkill_SubClassMissingExportProxy : __TsTaskUseSkill_InheritProxy
{
	// Token: 0x0601CEB8 RID: 118456 RVA: 0x008B899C File Offset: 0x008B6B9C
	[NullableContext(1)]
	protected __TsTaskUseSkill_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskUseSkill.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CEB9 RID: 118457 RVA: 0x008B89CF File Offset: 0x008B6BCF
	protected __TsTaskUseSkill_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
