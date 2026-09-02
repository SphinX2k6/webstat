using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200396C RID: 14700
public class __WorldFunctionLibrary_SubClassMissingExportProxy : __WorldFunctionLibrary_InheritProxy
{
	// Token: 0x0601D9E2 RID: 121314 RVA: 0x008D5E1C File Offset: 0x008D401C
	[NullableContext(1)]
	protected __WorldFunctionLibrary_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(WorldFunctionLibrary.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601D9E3 RID: 121315 RVA: 0x008D5E4F File Offset: 0x008D404F
	protected __WorldFunctionLibrary_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
