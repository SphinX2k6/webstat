using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003594 RID: 13716
public class __TsServiceAnimalPerception_SubClassMissingExportProxy : __TsServiceAnimalPerception_InheritProxy
{
	// Token: 0x0601CC23 RID: 117795 RVA: 0x008B2BBC File Offset: 0x008B0DBC
	[NullableContext(1)]
	protected __TsServiceAnimalPerception_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsServiceAnimalPerception.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CC24 RID: 117796 RVA: 0x008B2BEF File Offset: 0x008B0DEF
	protected __TsServiceAnimalPerception_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
