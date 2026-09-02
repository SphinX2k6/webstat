using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x020035D2 RID: 13778
public class __TsTaskGetTargetInfo_SubClassMissingExportProxy : __TsTaskGetTargetInfo_InheritProxy
{
	// Token: 0x0601CCCA RID: 117962 RVA: 0x008B4288 File Offset: 0x008B2488
	[NullableContext(1)]
	protected __TsTaskGetTargetInfo_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskGetTargetInfo.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CCCB RID: 117963 RVA: 0x008B42BB File Offset: 0x008B24BB
	protected __TsTaskGetTargetInfo_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
