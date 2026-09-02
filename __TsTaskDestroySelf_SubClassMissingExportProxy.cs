using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003610 RID: 13840
public class __TsTaskDestroySelf_SubClassMissingExportProxy : __TsTaskDestroySelf_InheritProxy
{
	// Token: 0x0601CD8B RID: 118155 RVA: 0x008B5F80 File Offset: 0x008B4180
	[NullableContext(1)]
	protected __TsTaskDestroySelf_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskDestroySelf.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD8C RID: 118156 RVA: 0x008B5FB3 File Offset: 0x008B41B3
	protected __TsTaskDestroySelf_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
