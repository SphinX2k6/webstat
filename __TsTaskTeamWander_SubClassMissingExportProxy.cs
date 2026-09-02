using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003672 RID: 13938
public class __TsTaskTeamWander_SubClassMissingExportProxy : __TsTaskTeamWander_InheritProxy
{
	// Token: 0x0601CE92 RID: 118418 RVA: 0x008B83D0 File Offset: 0x008B65D0
	[NullableContext(1)]
	protected __TsTaskTeamWander_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskTeamWander.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE93 RID: 118419 RVA: 0x008B8403 File Offset: 0x008B6603
	protected __TsTaskTeamWander_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
