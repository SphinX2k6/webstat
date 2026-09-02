using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035A8 RID: 13736
public class __TsTaskKeepFollowing_SubClassMissingExportProxy : __TsTaskKeepFollowing_InheritProxy
{
	// Token: 0x0601CC59 RID: 117849 RVA: 0x008B3320 File Offset: 0x008B1520
	[NullableContext(1)]
	protected __TsTaskKeepFollowing_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskKeepFollowing.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC5A RID: 117850 RVA: 0x008B3353 File Offset: 0x008B1553
	protected __TsTaskKeepFollowing_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
