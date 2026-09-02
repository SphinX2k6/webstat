using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200391E RID: 14622
public class __AnimNotifyStateGhost_SubClassMissingExportProxy : __AnimNotifyStateGhost_InheritProxy
{
	// Token: 0x0601D8A5 RID: 120997 RVA: 0x008D22A8 File Offset: 0x008D04A8
	[NullableContext(1)]
	protected __AnimNotifyStateGhost_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(AnimNotifyStateGhost.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D8A6 RID: 120998 RVA: 0x008D22DB File Offset: 0x008D04DB
	protected __AnimNotifyStateGhost_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
