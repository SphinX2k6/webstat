using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003890 RID: 14480
public class __LogicDataBase_SubClassMissingExportProxy : __LogicDataBase_InheritProxy
{
	// Token: 0x0601D623 RID: 120355 RVA: 0x008CA758 File Offset: 0x008C8958
	[NullableContext(1)]
	protected __LogicDataBase_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataBase.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D624 RID: 120356 RVA: 0x008CA78B File Offset: 0x008C898B
	protected __LogicDataBase_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
