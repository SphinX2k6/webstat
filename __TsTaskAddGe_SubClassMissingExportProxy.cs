using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035EA RID: 13802
public class __TsTaskAddGe_SubClassMissingExportProxy : __TsTaskAddGe_InheritProxy
{
	// Token: 0x0601CD0C RID: 118028 RVA: 0x008B4BA4 File Offset: 0x008B2DA4
	[NullableContext(1)]
	protected __TsTaskAddGe_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskAddGe.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD0D RID: 118029 RVA: 0x008B4BD7 File Offset: 0x008B2DD7
	protected __TsTaskAddGe_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
