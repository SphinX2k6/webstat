using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003662 RID: 13922
public class __TsTaskSetTag_SubClassMissingExportProxy : __TsTaskSetTag_InheritProxy
{
	// Token: 0x0601CE68 RID: 118376 RVA: 0x008B7E24 File Offset: 0x008B6024
	[NullableContext(1)]
	protected __TsTaskSetTag_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSetTag.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE69 RID: 118377 RVA: 0x008B7E57 File Offset: 0x008B6057
	protected __TsTaskSetTag_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
