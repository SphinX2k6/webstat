using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035DC RID: 13788
public class __TsTaskNpcPatrol_SubClassMissingExportProxy : __TsTaskNpcPatrol_InheritProxy
{
	// Token: 0x0601CCE7 RID: 117991 RVA: 0x008B46A0 File Offset: 0x008B28A0
	[NullableContext(1)]
	protected __TsTaskNpcPatrol_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskNpcPatrol.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CCE8 RID: 117992 RVA: 0x008B46D3 File Offset: 0x008B28D3
	protected __TsTaskNpcPatrol_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
