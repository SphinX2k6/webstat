using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035E8 RID: 13800
public class __TsTaskAddBuffToSelf_SubClassMissingExportProxy : __TsTaskAddBuffToSelf_InheritProxy
{
	// Token: 0x0601CD07 RID: 118023 RVA: 0x008B4AF8 File Offset: 0x008B2CF8
	[NullableContext(1)]
	protected __TsTaskAddBuffToSelf_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAddBuffToSelf.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD08 RID: 118024 RVA: 0x008B4B2B File Offset: 0x008B2D2B
	protected __TsTaskAddBuffToSelf_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
