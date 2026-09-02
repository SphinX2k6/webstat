using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x0200362E RID: 13870
public class __TsTaskGetStartPosition_SubClassMissingExportProxy : __TsTaskGetStartPosition_InheritProxy
{
	// Token: 0x0601CDDD RID: 118237 RVA: 0x008B6B28 File Offset: 0x008B4D28
	[NullableContext(1)]
	protected __TsTaskGetStartPosition_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskGetStartPosition.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CDDE RID: 118238 RVA: 0x008B6B5B File Offset: 0x008B4D5B
	protected __TsTaskGetStartPosition_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
