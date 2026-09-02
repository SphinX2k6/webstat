using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038BA RID: 14522
public class __LogicDataWhirlpool_SubClassMissingExportProxy : __LogicDataWhirlpool_InheritProxy
{
	// Token: 0x0601D677 RID: 120439 RVA: 0x008CB130 File Offset: 0x008C9330
	[NullableContext(1)]
	protected __LogicDataWhirlpool_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataWhirlpool.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D678 RID: 120440 RVA: 0x008CB163 File Offset: 0x008C9363
	protected __LogicDataWhirlpool_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
