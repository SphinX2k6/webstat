using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200386C RID: 14444
public class __TsSkeletalObserver_SubClassMissingExportProxy : __TsSkeletalObserver_InheritProxy
{
	// Token: 0x0601D5B2 RID: 120242 RVA: 0x008C9C0C File Offset: 0x008C7E0C
	[NullableContext(1)]
	protected __TsSkeletalObserver_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsSkeletalObserver.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D5B3 RID: 120243 RVA: 0x008C9C3F File Offset: 0x008C7E3F
	protected __TsSkeletalObserver_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
