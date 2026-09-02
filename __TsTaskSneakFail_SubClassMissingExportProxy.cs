using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003668 RID: 13928
public class __TsTaskSneakFail_SubClassMissingExportProxy : __TsTaskSneakFail_InheritProxy
{
	// Token: 0x0601CE78 RID: 118392 RVA: 0x008B8050 File Offset: 0x008B6250
	[NullableContext(1)]
	protected __TsTaskSneakFail_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskSneakFail.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CE79 RID: 118393 RVA: 0x008B8083 File Offset: 0x008B6283
	protected __TsTaskSneakFail_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
