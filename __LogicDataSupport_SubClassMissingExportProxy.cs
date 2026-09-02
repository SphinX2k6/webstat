using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038B8 RID: 14520
public class __LogicDataSupport_SubClassMissingExportProxy : __LogicDataSupport_InheritProxy
{
	// Token: 0x0601D673 RID: 120435 RVA: 0x008CB0B8 File Offset: 0x008C92B8
	[NullableContext(1)]
	protected __LogicDataSupport_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataSupport.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D674 RID: 120436 RVA: 0x008CB0EB File Offset: 0x008C92EB
	protected __LogicDataSupport_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
