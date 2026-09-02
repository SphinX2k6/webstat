using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003686 RID: 13958
public class __TsTaskWriteEntityId_SubClassMissingExportProxy : __TsTaskWriteEntityId_InheritProxy
{
	// Token: 0x0601CECF RID: 118479 RVA: 0x008B8CDC File Offset: 0x008B6EDC
	[NullableContext(1)]
	protected __TsTaskWriteEntityId_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskWriteEntityId.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CED0 RID: 118480 RVA: 0x008B8D0F File Offset: 0x008B6F0F
	protected __TsTaskWriteEntityId_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
