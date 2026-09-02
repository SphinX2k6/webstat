using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Utils;

// Token: 0x02003616 RID: 13846
public class __TsTaskFightOrFlee_SubClassMissingExportProxy : __TsTaskFightOrFlee_InheritProxy
{
	// Token: 0x0601CD9B RID: 118171 RVA: 0x008B61AC File Offset: 0x008B43AC
	[NullableContext(1)]
	protected __TsTaskFightOrFlee_SubClassMissingExportProxy(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsTaskFightOrFlee.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601CD9C RID: 118172 RVA: 0x008B61DF File Offset: 0x008B43DF
	protected __TsTaskFightOrFlee_SubClassMissingExportProxy(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}
}
