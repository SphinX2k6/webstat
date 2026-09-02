using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020038AA RID: 14506
public class __LogicDataShield_SubClassMissingExportProxy : __LogicDataShield_InheritProxy
{
	// Token: 0x0601D657 RID: 120407 RVA: 0x008CAD70 File Offset: 0x008C8F70
	[NullableContext(1)]
	protected __LogicDataShield_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(LogicDataShield.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D658 RID: 120408 RVA: 0x008CADA3 File Offset: 0x008C8FA3
	protected __LogicDataShield_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
